using MediatR;

namespace Domain.Application.Users.Queries.GetUsersListQuery
{
    public class GetUserListQuery : IRequest<UserListViewModel>
    {
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
