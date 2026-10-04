using Service.Auth.BusinessContract.DTO;
using Service.Auth.Common.ResultHandler;

namespace Service.Auth.BusinessContract.Service
{
  public interface IAuthService
  {
    public Task<ServiceResult<TokensResponse>> SignUpAsync(SignUpRequest signUpRequest);
    public Task<ServiceResult<TokensResponse>> LoginAsync(LogInRequest logInRequest);
  }
}
