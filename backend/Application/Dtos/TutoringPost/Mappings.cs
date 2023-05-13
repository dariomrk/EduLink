using Application.Dtos.TutoringPost;
using Riok.Mapperly.Abstractions;

namespace Application.TutoringPost
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
    internal static partial class Mappings
    {
        internal static partial ResponseDto ToDto(this Data.Models.TutoringPost tutoringPost);
        [MapperIgnoreTarget(nameof(Data.Models.TutoringPost.Fields))]
        internal static partial Data.Models.TutoringPost ToModel(this RequestDto dto);
    }
}
