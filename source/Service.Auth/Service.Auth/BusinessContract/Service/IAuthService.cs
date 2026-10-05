using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;

namespace Service.Auth.BusinessContract.Service
{
  public interface IAuthService
  {
    public Task<ServiceResult<TokensResponse>> SignUpAsync(SignUpRequest signUpRequest);
    public Task<ServiceResult<TokensResponse>> LogInAsync(LogInRequest logInRequest);
  }
}
