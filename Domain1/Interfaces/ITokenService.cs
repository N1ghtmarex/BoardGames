using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IUser user, List<Claim> claims);
    }
}
