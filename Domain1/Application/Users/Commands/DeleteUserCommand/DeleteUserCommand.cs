using MediatR;

namespace Domain.Application.Users.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
