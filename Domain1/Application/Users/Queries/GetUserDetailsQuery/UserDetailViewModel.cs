using AutoMapper;
using Domain.Application.Common.Mappings;
using Domain.Model;

namespace Domain.Application.Users.Queries.GetUserDetailsQuery
{
    public class UserDetailViewModel : IMapWith<User>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailViewModel>()
                .ForMember(vm => vm.UserId,
                opt => opt.MapFrom(u => u.Id));
        }
    }
}