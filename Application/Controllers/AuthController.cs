using Domain.Application.Users.Commands.CreateUserCommand;
using Domain.Application.Users.Commands.LoginCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/user/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<CreateUserViewModel>> Register(CreateUserCommand request)
        {
            var response = await _mediator.Send(request);

            return response;
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="request"></param>
        /// <returns>JWT - token</returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginCommand request)
        {
            var response = await _mediator.Send(request);

            return response;
        }
    }
}
