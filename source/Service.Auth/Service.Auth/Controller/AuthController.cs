using Microsoft.AspNetCore.Mvc;
using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Auth.Controller
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
