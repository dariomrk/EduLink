using Application.Dtos.Common;
using Application.Enums;

namespace Application.Extensions
{
    internal static class CollectionExtensions
    {
        internal static IQueryable<T> Paginate<T>(this IQueryable<T> collection, RequestPaginationDto paginationDto) =>
            collection.Skip(paginationDto.Skip)
                .Take(paginationDto.Take);

        internal static IQueryable<T> SortOrder<T>(this IQueryable<T> collection, SortOrder sortOrder) =>
        sortOrder switch
        {
            Enums.SortOrder.Ascending => collection,
            Enums.SortOrder.Descending => collection.Reverse(),
            _ => collection,
        };

        internal static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> predicate)
        {
            foreach (var item in collection)
            {
                predicate(item);
            }

            return collection;
        }

        internal static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T, int> predicate)
        {
            var index = 0;
            collection.ForEach(item =>
            {
                predicate(item, index);
                index++;
            });

            return collection;
        }
    }
}
