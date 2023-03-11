using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Application.Users.Queries.GetUserDetailsQuery
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailViewModel>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

            var userViewModel = _mapper.Map<UserDetailViewModel>(user);

            return userViewModel;
        }
    }
}
