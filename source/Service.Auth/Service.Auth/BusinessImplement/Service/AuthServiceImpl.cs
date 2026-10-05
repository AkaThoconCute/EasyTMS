using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessImplement.Service
{
  public class AuthServiceImpl(
    IUserService userService,
    ITokenService tokenService) : IAuthService
  {
    public async Task<ServiceResult<TokensResponse>> SignUpAsync(SignUpRequest signUpRequest)
    {
      // 1. Validate request
      // Data Annotations

      // 2. Create user
      ServiceResult<CoreUser> userRes = await userService.CreateUser(signUpRequest);
      if (!userRes.Success)
      {
        return ServiceResult.FromError<TokensResponse>(userRes.Error!);
      }

      CoreUser user = userRes.Result!;

      // 3. Generate tokens
      var tokensRes = tokenService.GenerateTokenPair(user);
      if (!tokensRes.Success)
      {
        return ServiceResult.FromError<TokensResponse>(tokensRes.Error!);
      }

      TokensResponse tokens = tokensRes.Result!;
      return ServiceResult.FromResult(tokens);
    }

    public async Task<ServiceResult<TokensResponse>> LogInAsync(LogInRequest logInRequest)
    {
      // 1. Validate request
      // Data Annotations

      // 2. Find user


      // 3. Check password is match

      // 4. Generate token

      // 4. Return result
      TokensResponse tokensRes = new()
      {
        AccessToken = "AccessToken:Example",
        RefreshToken = "RefreshToken:Example"
      };

      return ServiceResult.FromResult(tokensRes);
    }
  }
}
