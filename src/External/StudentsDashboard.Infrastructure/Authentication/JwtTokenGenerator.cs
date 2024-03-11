using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentsDashboard.Application.Common.Interfaces.Authentication;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace StudentsDashboard.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions, IHttpContextAccessor contextAccessor)
    {
        _jwtSettings = jwtOptions.Value;
        _httpContextAccessor = contextAccessor;
    }

    public void GenerateToken(int userId, string firstName, string lastName)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, $"{firstName} {lastName}")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expires,
            signingCredentials: cred
            );
        
        var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
        
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddMinutes(_jwtSettings.ExpiryMinutes)
        };
        
        _httpContextAccessor.HttpContext.Response.Cookies.Append("Token", tokenHandler, cookieOptions);
    }
}