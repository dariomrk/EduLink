using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Message
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial MessageResponseDto ToDto(this Data.Models.Message message);
    }
}
