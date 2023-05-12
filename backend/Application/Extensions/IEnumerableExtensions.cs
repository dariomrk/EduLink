using Application.Dtos.Common;
using Application.Enums;

namespace Application.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, PaginationDto paginationDto) =>
            collection.Skip(paginationDto.Skip)
                .Take(paginationDto.Take);

        public static IEnumerable<T> Order<T>(this IEnumerable<T> collection, SortOrder sortOrder) =>
        sortOrder switch
        {
            SortOrder.Ascending => collection,
            SortOrder.Descending => collection.Reverse(),
            _ => collection,
        };
    }
}
