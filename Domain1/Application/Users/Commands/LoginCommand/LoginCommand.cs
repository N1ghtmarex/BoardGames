using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Users.Commands.LoginCommand
{
    public class LoginCommand : IRequest<string>
    {
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
