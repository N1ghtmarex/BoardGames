using FluentValidation;

namespace Domain.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().MaximumLength(35).EmailAddress();
            RuleFor(u => u.Name).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Surname).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Username).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Password).NotEmpty().MaximumLength(15);
        }
    }
}
