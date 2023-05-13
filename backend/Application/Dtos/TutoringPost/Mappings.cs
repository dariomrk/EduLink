using Application.Dtos.TutoringPost;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial ResponseDto ToDto(this TutoringPost tutoringPost);
    }
}
