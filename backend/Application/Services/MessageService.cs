using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message, long> _messageRepository;
        private readonly IUserService _userService;
        private readonly IValidator<CreateMessageRequestDto> _createMessageRequestValidator;
        private readonly ILogger<MessageService> _logger;

        public MessageService(
            IRepository<Message, long> messageRepository,
            IUserService userService,
            IValidator<CreateMessageRequestDto> createMessageRequestValidator,
            ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _userService = userService;
            _createMessageRequestValidator = createMessageRequestValidator;
            _logger = logger;
        }

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

        public async Task<(ServiceActionResult Result, MessageResponseDto? Created)> SendMessage(CreateMessageRequestDto message)
        {
            await _createMessageRequestValidator.ValidateAndThrowAsync(message);

            var sender = _userService.GetByUsernameAsync(message.SenderUsername);
            var recipient = _userService.GetByUsernameAsync(message.RecipientUsername);

            var newMessage = new Message
            {
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Content = message.Message,
            };

            var (result, created) = await _messageRepository.CreateAsync(newMessage);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);
            return (ServiceActionResult.Created, created!.ToDto());
        }
    }
}
