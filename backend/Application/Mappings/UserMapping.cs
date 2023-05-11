using Application.Dtos.User;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    public static partial class UserMapping
    {
        public static partial UserDto ToDto(this User user);
    }
}
