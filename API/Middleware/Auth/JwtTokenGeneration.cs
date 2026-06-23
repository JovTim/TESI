using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TesiApi.Core.Model;

namespace TesiApi.Api.Middleware;

public class JWT
{

  private readonly IConfiguration _configuration;

  public JWT(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  private string RoleType(int role)
  {
    if (role == 1)
    {
      return "Seller";
    }
    return "Tenant";
  }
  public string GenerateJWTToken(Users users)
  {
    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, users.AccountID.ToString()),
      new Claim(ClaimTypes.Email, users.Accounts?.AccountEmail ?? string.Empty),
      new Claim(ClaimTypes.Role, RoleType(users.IsSeller))
    };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new Exception("JWT is missing")));

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      issuer: _configuration["Jwt:Issuer"],
      audience: _configuration["Jwt:Audience"],
      claims: claims,
      expires: DateTime.UtcNow.AddDays(7),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
