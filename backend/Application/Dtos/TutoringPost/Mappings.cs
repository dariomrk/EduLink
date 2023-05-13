using Application.Dtos.TutoringPost;
using Riok.Mapperly.Abstractions;

namespace Application.TutoringPost
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial ResponseDto ToDto(this Data.Models.TutoringPost tutoringPost);
    }
}
