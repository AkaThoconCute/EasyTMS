using EasyTMS.Auth.BusinessContract.DTO;
using EasyTMS.Common.DTO;

namespace EasyTMS.Auth.BusinessContract.Service
{
  public interface IAuthService
  {
    public Task<ServiceResult<TokensResponse>> SignUpAsync(SignUpRequest signUpRequest);
    public Task<ServiceResult<TokensResponse>> SignInAsync(SignInRequest logInRequest);
  }
}
