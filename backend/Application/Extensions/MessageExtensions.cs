using Application.Dtos.Common;
using Application.Enums;
using Application.Exceptions;
using Data.Models;

namespace Application.Extensions
{
    internal static class MessageExtensions
    {
        internal static IQueryable<Message> SortMessages(this IQueryable<Message> messages, SortRequestDto sortDto)
        {
            var sorted = sortDto.SortByProperty switch
            {
                SortByProperty.Rating => throw new NotSupportedRequestException<Message>(nameof(SortMessages), nameof(SortByProperty.Rating)),

                SortByProperty.Name => throw new NotSupportedRequestException<Message>(nameof(SortMessages), nameof(SortByProperty.Name)),

                SortByProperty.Distance => throw new NotSupportedRequestException<Message>(nameof(SortMessages), nameof(SortByProperty.Name)),

                SortByProperty.Date => messages.OrderBy(message => message.CreatedAt),

                _ => throw new InvalidRequestException<Message>(nameof(SortMessages), null)
            };

            return sorted.SortOrder(sortDto.SortOrder);
        }
    }
}
