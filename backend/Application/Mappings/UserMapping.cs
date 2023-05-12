using Application.Dtos.User;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    public static partial class UserMappings
    {
        public static partial UserDto ToDto(this User user);
        public static partial IQueryable<UserDto> ProjectToDto(this IQueryable<User> users);
    }
}
