using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace NZWalks.Api.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration _config;

    public TokenRepository(IConfiguration config)
    {
        _config = config;
    }

    public string CreateJwTToken(IdentityUser user, List<string> roles)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Email, user.Email!));
        foreach (string role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]??""));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
