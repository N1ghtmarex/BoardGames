using Domain.Application.Users.Commands.DeleteUserCommand;
using Domain.Application.Users.Commands.UpdateUserCommand;
using Domain.Application.Users.Queries.GetUserDetailsQuery;
using Domain.Application.Users.Queries.GetUsersListQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Обновление dffd
        /// </summary>
        /// <param name="request"></param>
        /// <returns>string</returns>
        [HttpPut("user")]
        [Authorize]
        public async Task<ActionResult<string>> UserUpdate(UpdateUserCommand request)
        {
            var response = await mediator.Send(request);

            return response;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("user")]
        [Authorize]
        public async Task<ActionResult<UserDetailViewModel>> GetUser(GetUserDetailsQuery request)
        {
            var response = await mediator.Send(request);

            return response;
        }

        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("{offset}/{limit}")]
        [Authorize]
        public async Task<ActionResult<UserListViewModel>> GetUsers(int offset, int limit)
        {
            var query = new GetUserListQuery
            {
                limit = limit,
                offset = offset
            };

            var response = await mediator.Send(query);

            return response;
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("user")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteUser(DeleteUserCommand request)
        {
            var response = await mediator.Send(request);

            return response;
        }
    }
}
