using Domain.Application.Users.Commands.CreateUserCommand;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private IApplicationDbContext _context;
        private IPasswordService _passwordService;

        public UpdateUserCommandHandler(IApplicationDbContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);

            if (user != null)
            {
                user.Name = request.Name;
                user.Surname = request.Surname;
                user.Username = request.Username;
                user.Email = request.Email;
                _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return "User updated.";
            }
            else
                return "User not found.";
        }
    }
}
