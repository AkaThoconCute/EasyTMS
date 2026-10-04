using Microsoft.AspNetCore.Mvc;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;
using Service.Auth.Common.ResultHandler;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Auth.API
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
      IServiceResult result = await authService.SignUpAsync(signUpRequest);
      return result;
    }

    // Login API
    [HttpPost]
    public IActionResult LogIn([FromBody] LogInRequest logInRequest)
    {
      return Ok(authService.LoginAsync(logInRequest));
    }
  }
}
