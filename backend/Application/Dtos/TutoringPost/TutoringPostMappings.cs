using Application.Dtos.TutoringPost;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    internal static partial class TutoringPostMappings
    {
        internal static partial TutoringPostDto ToDto(this TutoringPost tutoringPost);
    }
}
