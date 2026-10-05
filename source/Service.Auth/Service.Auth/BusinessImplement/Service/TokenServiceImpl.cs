using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.BusinessContract.Service;
using Service.Auth.BusinessImplement.Common;
using Service.Auth.RepositoryContract.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Service.Auth.BusinessImplement.Service
{
  public class TokenServiceImpl(
    UserManager<CoreUser> userManager,
    IConfiguration config) : ITokenService

  {
    // GenerateTokenPair
    public ServiceResult<TokensResponse> GenerateTokenPair(CoreUser user)
    {
      var accessTokenRes = GenerateAccessToken(user);
      if (!accessTokenRes.Success)
      {
        return ServiceResult.FromError<TokensResponse>(accessTokenRes.Error!);
      }

      var refreshTokenRes = GenerateRefreshToken(user);
      if (!refreshTokenRes.Success)
      {
        return ServiceResult.FromError<TokensResponse>(refreshTokenRes.Error!);
      }

      return ServiceResult.FromResult(new TokensResponse()
      {
        AccessToken = accessTokenRes.Result!,
        RefreshToken = refreshTokenRes.Result!
      });
    }

    // GenerateAccessToken
    private ServiceResult<string> GenerateAccessToken(CoreUser user) //, IList<string> roles)
    {
      try
      {
        // 1. Lấy thông tin cấu hình Token
        string? key = config.GetValue<string?>("JWT:Key");
        if (string.IsNullOrEmpty(key))
        {
          return ServiceResult.FromError<string>(Errors.AccessTokenGernationFailed);
        }

        // Kiểm tra key đủ độ dài cho HS512 (512 bits = 64 bytes)
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        if (keyBytes.Length < 64)
        {
          return ServiceResult.FromError<string>(Errors.AccessTokenGernationFailed);
        }

        SymmetricSecurityKey securityKey = new(keyBytes);
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);

        double duration = config.GetValue<double>("JWT:Duration");
        string? issuer = config["JWT:Issuer"];
        string? audience = config["JWT:Audience"];

        // 2. Tạo danh sách Claims
        List<Claim> claims =
        [
          new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        new(JwtRegisteredClaimNames.GivenName, user.UserName ?? ""),
        new(JwtRegisteredClaimNames.NameId, user.Id)
        ];

        //foreach (string role in roles)
        //{
        //  claims.Add(new Claim(ClaimTypes.Role, role));
        //}

        // 3. Create token
        SecurityTokenDescriptor tokenDescriptor = new()
        {
          Subject = new ClaimsIdentity(claims),
          Expires = DateTime.UtcNow.AddDays(duration),
          SigningCredentials = credentials,
          Issuer = issuer,
          Audience = audience
        };

        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);

        return ServiceResult.FromResult(tokenString);
      }
      catch (Exception)
      {
        return ServiceResult.FromError<string>(Errors.AccessTokenGernationError);
      }
    }

    // GenerateRefreshToken
    private ServiceResult<string> GenerateRefreshToken(CoreUser user)
    {
      try
      {
        byte[] randomNumber = new byte[64];
        using var randomGenerator = RandomNumberGenerator.Create();
        randomGenerator.GetBytes(randomNumber);
        string tokenString = Convert.ToBase64String(randomNumber);

        double duration = config.GetValue<double>("JWT:Duration");

        user.RefreshToken = tokenString;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(duration);
        userManager.UpdateAsync(user);

        return ServiceResult.FromResult(tokenString);
      }
      catch (Exception)
      {
        return ServiceResult.FromError<string>(Errors.AccessTokenGernationError);
      }
    }
  }
}
