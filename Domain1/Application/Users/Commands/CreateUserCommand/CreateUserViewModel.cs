using AutoMapper;
using Domain.Application.Common.Mappings;
using Domain.Model;

namespace Domain.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserViewModel : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
