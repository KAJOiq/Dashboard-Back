using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using projects.Dtos.Account;
using Ticket.Interfaces;
using projects.Models;

namespace projects.Services;
public class TokenService(IConfiguration configuration, IOptions<JwtSettings> jwtSettings) : ITokenService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string CreateToken(User user)
    {
        if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.UserName))
        {
            throw new InvalidOperationException("unable to find the email or user name");
        }

        var claims = new List<Claim>{
            new("uid", user.Id),
            new(JwtRegisteredClaimNames.Email , user.Email),
            new(JwtRegisteredClaimNames.GivenName, user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
