using Microsoft.AspNetCore.Identity;
using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.Common;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;
using Service.Auth.BusinessImplement.Common;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessImplement.Service
{
  public class UserServiceImpl(
    UserManager<CoreUser> userManager) : IUserService
  {
    public async Task<ServiceResult<CoreUser>> CreateUser(
      SignUpRequest signupRequest,
      RoleEnum role = RoleEnum.User)
    {
      // 1. Create a new user
      CoreUser user = new()
      {
        UserName = signupRequest.UserName,
        FullName = signupRequest.FullName,
        Email = signupRequest.Email,
        PhoneNumber = signupRequest.Phone,
        Address = signupRequest.Address,
      };

      string password = signupRequest.Password;

      IdentityResult createRes = await userManager.CreateAsync(user, password);

      if (createRes.Succeeded is false)
      {
        string message = string.Join(" ", createRes.Errors.Select(e => e.Description));
        return ServiceResult.FromError<CoreUser>(Errors.UserCreationFailed.WithMessage(message));
      }

      // 2. Update the user to add role
      //IdentityResult updateRes = await userManager.AddToRoleAsync(user, role.ToString());

      if (createRes.Succeeded is false)
      {
        string message = string.Join(", ", createRes.Errors.Select(e => e.Description));
        return ServiceResult.FromError<CoreUser>(Errors.UserCreationFailed.WithMessage(message));
      }

      // 3. Response
      CoreUser? createdUser = await userManager.FindByNameAsync(user.UserName);

      if (createdUser is null)
      {
        return ServiceResult.FromError<CoreUser>(Errors.UserCreationFailed);
      }

      return ServiceResult.FromResult(createdUser);
    }
  }
}
