using Application.Dtos.Common;
using Application.Enums;

namespace Application.Extensions
{
    internal static class CollectionExtensions
    {
        internal static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, PaginationDto paginationDto) =>
            collection.Skip(paginationDto.Skip)
                .Take(paginationDto.Take);

        internal static IQueryable<T> Paginate<T>(this IQueryable<T> collection, PaginationDto paginationDto) =>
            collection.Skip(paginationDto.Skip)
                .Take(paginationDto.Take);

        internal static IEnumerable<T> SortOrder<T>(this IEnumerable<T> collection, SortOrder sortOrder) =>
        sortOrder switch
        {
            Enums.SortOrder.Ascending => collection,
            Enums.SortOrder.Descending => collection.Reverse(),
            _ => collection,
        };

        internal static IQueryable<T> SortOrder<T>(this IQueryable<T> collection, SortOrder sortOrder) =>
        sortOrder switch
        {
            Enums.SortOrder.Ascending => collection,
            Enums.SortOrder.Descending => collection.Reverse(),
            _ => collection,
        };
    }
}
