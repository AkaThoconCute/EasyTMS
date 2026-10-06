using Service.Auth.BusinessContract.Common;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessContract.Service
{
  public interface IUserService
  {
    public Task<CoreUser?> CreateUser(SignUpRequest signupRequest, RoleEnum role = RoleEnum.User);
  }
}
