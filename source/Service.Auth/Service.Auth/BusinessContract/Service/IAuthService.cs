using Service.Auth.BusinessContract.DTO.Request;
using Service.Auth.BusinessContract.DTO.Response;

namespace Service.Auth.BusinessContract.Service
{
  public interface IAuthService
  {
    public AuthResponse Login(LoginRequest loginRequest);
  }
}
