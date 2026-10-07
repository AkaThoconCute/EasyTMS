using EasyTMS.Auth.BusinessContract.Enum;
using EasyTMS.Auth.RepositoryContract.Entity;
using static EasyTMS.Auth.BusinessContract.DTO.AuthDTO;

namespace EasyTMS.Auth.BusinessContract.Service
{
  public interface IUserService
  {
    public Task<CoreUser?> CreateUser(SignUpRequest signupRequest, RoleEnum role = RoleEnum.User);
  }
}
