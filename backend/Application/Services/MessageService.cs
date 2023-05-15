using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string recipientUsername,
            string senderUsername,
            PaginationRequestDto? paginationDto = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string username,
            PaginationRequestDto? paginationDto = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<(ServiceActionResult Result, MessageResponseDto? Created)> SendMessage(MessageRequestDto message)
        {
            throw new NotImplementedException();
        }
    }
}
