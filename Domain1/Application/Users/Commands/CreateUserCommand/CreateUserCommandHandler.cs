using Domain.Interfaces;
using Domain.Model;
using MediatR;

namespace Domain.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserViewModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordService _passwordService;

        public CreateUserCommandHandler(IApplicationDbContext context, IPasswordService passwordService, ITokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<CreateUserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = await _context.Users.AddAsync(new User
            {
                Username = request.Username,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            },
            cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            CreateUserViewModel response = new CreateUserViewModel
            {
                Id = user.Entity.Id,
                Email = user.Entity.Email,
                Name = user.Entity.Name,
                Username = user.Entity.Username,
                Surname = user.Entity.Surname,
                Password = request.Password
            };

            return response;
        }
    }
}
