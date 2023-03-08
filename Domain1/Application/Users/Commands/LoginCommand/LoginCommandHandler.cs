using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Domain.Application.Users.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IApplicationDbContext context, IPasswordService passwordService, ITokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user != null)
            {
                if (_passwordService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    List<Claim> claims = new()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username)
                    };

                    string token = _tokenService.CreateToken(user, claims);

                    return token;
                }
                else return "Wrong password.";
            }
            else return "User not found.";

        }
    }
}
