using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string recipientUsername,
            string senderUsername,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string username,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, MessageResponseDto? Created)> SendMessage(
            CreateMessageRequestDto message);
    }
}
