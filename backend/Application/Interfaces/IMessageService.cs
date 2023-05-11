using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<MessageDto>> GetMessagesAsync(
            string myUsername,
            string sendersUsername,
            PaginationDto? paginationDto = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.CreatedAt,
            CancellationToken cancellationToken = default);

        public Task<ICollection<MessageDto>> GetMessagesAsync(
            string myUsername,
            PaginationDto? paginationDto = null,
            SortOrder sortOrder = SortOrder.Ascending,
            SortProperties orderBy = SortProperties.CreatedAt,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, MessageDto? Created)> SendMessage(
            CreateDto message);
    }
}
