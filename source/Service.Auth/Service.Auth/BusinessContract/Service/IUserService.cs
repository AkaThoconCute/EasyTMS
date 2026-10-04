using Service.Auth.BusinessContract.Common;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.Common.ResultHandler;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessContract.Service
{
  public interface IUserService
  {
    public Task<ServiceResult<CoreUser>> CreateUser(SignUpRequest signupRequest, RoleEnum role = RoleEnum.User);
  }
}
