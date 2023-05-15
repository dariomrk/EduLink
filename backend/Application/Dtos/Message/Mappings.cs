using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Message
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial IQueryable<MessageResponseDto> ProjectToDto(this IQueryable<Data.Models.Message> messages);
    }
}
