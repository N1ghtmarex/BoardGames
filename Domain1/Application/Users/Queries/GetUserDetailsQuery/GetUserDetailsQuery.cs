using MediatR;

namespace Domain.Application.Users.Queries.GetUserDetailsQuery
{
    public class GetUserDetailsQuery : IRequest<UserDetailViewModel>
    {
        public string Username { get; set; } = string.Empty;
    }
}
