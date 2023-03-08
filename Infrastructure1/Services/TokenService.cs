using Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        public string CreateToken(IUser user, List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512Signature));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
