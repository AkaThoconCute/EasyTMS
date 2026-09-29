namespace Service.Auth.BusinessContract.DTO.Response
{
  public class AuthResponse
  {
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
  }
}
