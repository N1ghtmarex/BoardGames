using FluentValidation;
using FluentValidation.Validators;

namespace Domain.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Email).NotEmpty().MaximumLength(35).EmailAddress(EmailValidationMode.Net4xRegex);
            RuleFor(u => u.Name).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Surname).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Username).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Password).NotEmpty().MaximumLength(15);
            RuleFor(u => u.Id).NotEmpty();
        }
    }
}
