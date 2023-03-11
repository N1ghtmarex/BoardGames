using MediatR;


namespace Domain.Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<string>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;
        /// <summary>
        /// Имя пользователя (логин)
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
