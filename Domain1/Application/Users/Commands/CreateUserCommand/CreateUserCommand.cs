using MediatR;

namespace Domain.Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<CreateUserViewModel>
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
