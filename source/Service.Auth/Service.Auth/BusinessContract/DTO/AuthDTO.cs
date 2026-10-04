using System.ComponentModel.DataAnnotations;

namespace Service.Auth.BusinessContract.DTO
{
  // LoginRequest
  public class LogInRequest
  {
    private string _userName = string.Empty;
    public string UserName
    {
      get => _userName;
      init => _userName = value ?? string.Empty;
    }

    private string _password = string.Empty;
    public string Passwords
    {
      get => _password;
      init => _password = value ?? string.Empty;
    }
  }

  // SignupRequest
  public class SignUpRequest
  {
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, digits, and underscores.")]
    public string UserName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Password must contain only numbers.")]
    public string Password { get; init; } = string.Empty;

    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Full Name can only contain letters and spaces.")]
    public string FullName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string Phone { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;
  }

  // AuthResponse
  public class AuthResponse
  {
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
  }
}
