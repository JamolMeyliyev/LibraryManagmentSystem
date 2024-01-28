





using LibraryManagmentSystem.Core.Options;
using LibraryManagmentSystem.DataLayer.Entities;
using LibraryManagmentSystem.LogicLayer.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryManagmentSystem.LogicLayer.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOption;
    public TokenService(IOptions<JwtOptions> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }
    public async ValueTask<TokenReturnModel> GenerateTokenAsync(User user)
    {


        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("FirstName", user.FirstName),
            //new Claim("UserRole",user.UserRoleId.ToString())

        };



        var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOption.ExpiresInMinutes),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
        );

        
        var tokenModel = new TokenReturnModel();
        tokenModel.Token = new JwtSecurityTokenHandler().WriteToken(security);

        return tokenModel;

    }
}

