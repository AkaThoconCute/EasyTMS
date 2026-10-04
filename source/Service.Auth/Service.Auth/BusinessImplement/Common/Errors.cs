using Service.Auth.Common.ResultHandler;

namespace Service.Auth.BusinessImplement.Common
{
  public class Errors
  {
    public static readonly CustomError UserCreationFailed = new()
    {
      Code = 2001,
      Message = "Failed to create the new user",
      HttpStatusCode = StatusCodes.Status400BadRequest
    };

    public static readonly CustomError AccessTokenGernationFailed = new()
    {
      Code = 2002,
      Message = "Failed to generate the acess token",
      HttpStatusCode = StatusCodes.Status400BadRequest
    };

    public static readonly CustomError AccessTokenGernationError = new()
    {
      Code = 2002,
      Message = "Server error while generating a acess token",
      HttpStatusCode = StatusCodes.Status500InternalServerError
    };
  }
}
