using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string myUsername,
            string sendersUsername,
            PaginationRequestDto? paginationDto = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string myUsername,
            PaginationRequestDto? paginationDto = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, MessageResponseDto? Created)> SendMessage(
            MessageRequestDto message);
    }
}
