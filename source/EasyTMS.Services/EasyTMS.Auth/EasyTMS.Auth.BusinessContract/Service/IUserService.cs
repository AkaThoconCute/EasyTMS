using EasyTMS.Auth.BusinessContract.DTO;
using EasyTMS.Auth.BusinessContract.Enum;
using EasyTMS.Auth.RepositoryContract.Entity;

namespace EasyTMS.Auth.BusinessContract.Service
{
  public interface IUserService
  {
    public Task<CoreUser?> CreateUser(SignUpRequest signupRequest, RoleEnum role = RoleEnum.User);
  }
}
