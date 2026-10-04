using Microsoft.AspNetCore.Mvc;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;

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
    public IActionResult SignUp([FromBody] SignUpRequest signUpRequest)
    {
      return Ok(authService.SignUpAsync(signUpRequest));
    }

    // Login API
    [HttpPost]
    public IActionResult LogIn([FromBody] LogInRequest logInRequest)
    {
      return Ok(authService.LoginAsync(logInRequest));
    }
  }
}
