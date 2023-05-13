using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<ResponseDto>> GetMessagesAsync(
            string myUsername,
            string sendersUsername,
            RequestPaginationDto? paginationDto = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<ResponseDto>> GetMessagesAsync(
            string myUsername,
            RequestPaginationDto? paginationDto = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, ResponseDto? Created)> SendMessage(
            RequestDto message);
    }
}
