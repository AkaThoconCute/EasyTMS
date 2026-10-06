using Microsoft.AspNetCore.Identity;
using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;
using Service.Auth.BusinessImplement.Common;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessImplement.Service
{
  public class AuthServiceImpl(
    IUserService userService,
    ITokenService tokenService,
    UserManager<CoreUser> coreUserManager,
    SignInManager<CoreUser> signInManager) : IAuthService
  {
    private const bool IsLockOutOnFailure = false;

    public async Task<ServiceResult<TokensResponse>> SignUpAsync(SignUpRequest signUpRequest)
    {
      // 1. Validate request
      // Data Annotations

      // 2. Create user
      CoreUser? user = await userService.CreateUser(signUpRequest);
      if (user is null)
      {
        return ServiceResult.FromError<TokensResponse>(Errors.SignUpFailed);
      }

      // 3. Generate tokens
      TokensResponse? tokens = tokenService.GenerateTokenPair(user);
      if (tokens is null)
      {
        return ServiceResult.FromError<TokensResponse>(Errors.SignUpError);
      }

      return ServiceResult.FromResult(tokens);
    }

    public async Task<ServiceResult<TokensResponse>> SignInAsync(SignInRequest signInRequest)
    {
      // 1. Validate request
      // Data Annotations

      // 2. Check password
      CoreUser? user = await CheckPasswordAsync(signInRequest);
      if (user is null)
      {
        return ServiceResult.FromError<TokensResponse>(Errors.LogInFailed
          .WithMessage("Username or Password is incorrect. Please try again."));
      }

      // 3. Generate token
      TokensResponse? tokens = tokenService.GenerateTokenPair(user!);
      if (tokens is null)
      {
        return ServiceResult.FromError<TokensResponse>(Errors.LogInError);
      }

      return ServiceResult.FromResult(tokens!);
    }

    private async Task<CoreUser?> CheckPasswordAsync(SignInRequest signInRequest)
    {
      CoreUser? user = await coreUserManager.FindByNameAsync(signInRequest.Username);
      if (user is null) return null;

      SignInResult result = await signInManager.CheckPasswordSignInAsync(
        user,
        signInRequest.Password,
        IsLockOutOnFailure);
      if (result.Succeeded is false) return null;

      return user;
    }
  }
}
