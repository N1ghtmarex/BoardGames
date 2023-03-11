using AutoMapper;
using Domain.Application.Common.Mappings;
using Domain.Model;

namespace Domain.Application.Users.Queries.GetUsersListQuery
{
    public class UserViewModel : IMapWith<User>
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = string.Empty;
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.UserId,
                opt => opt.MapFrom(u => u.Id));
        }
    }
}
