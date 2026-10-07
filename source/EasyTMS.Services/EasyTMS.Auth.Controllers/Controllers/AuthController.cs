using EasyTMS.Auth.BusinessContract.DTO;
using EasyTMS.Auth.BusinessContract.Service;
using EasyTMS.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EasyTMS.Auth.Controllers.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class AuthController(
    IAuthService authService) : ControllerBase
  {
    // Sign up API
    [HttpPost]
    public async Task<IServiceResult> SignUp([FromBody] SignUpRequest signUpRequest)
    {
      var result = await authService.SignUpAsync(signUpRequest);
      return result;
    }

    // Login API
    [HttpPost]
    public async Task<IServiceResult> SignIn([FromBody] SignInRequest signInRequest)
    {
      var result = await authService.SignInAsync(signInRequest);
      return result;
    }
  }
}
