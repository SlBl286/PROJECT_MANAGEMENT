using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PM.Application.Common.Interfaces.Authentication;
using PM.Application.Common.Interfaces.Services;
using PM.Domain.UserAggregate;

namespace PM.Infrastrcture.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

    private readonly IDatetimeProvider _datetimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDatetimeProvider datetimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _datetimeProvider = datetimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                                        SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.Value.ToString()),
            new Claim(JwtRegisteredClaimNames.Name,user.Name),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _datetimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}