using Service.Auth.BusinessContract.DTO.Request;
using Service.Auth.BusinessContract.DTO.Response;
using Service.Auth.BusinessContract.Service;

namespace Service.Auth.BusinessImplement.Service
{
  public class AuthServiceImpl : IAuthService
  {
    public AuthResponse Login(LoginRequest loginRequest)
    {
      // 1. Validate request

      // 2. Find user

      // 3. Check password is match

      // 4. Generate token

      // 4. Return result
      AuthResponse authRes = new()
      {
        AccessToken = "AccessToken:Example",
        RefreshToken = "RefreshToken:Example"
      };

      return authRes;
    }
  }
}
