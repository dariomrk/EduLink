using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string recipientUsername,
            string senderUsername,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await _messageRepository.Query()
                .Where(message =>
                    message.Recipient.Username == recipientUsername.ToNormalizedLower()
                    && message.Sender.Username == senderUsername.ToNormalizedLower())
                .SortMessages(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Date, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 50 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<MessageResponseDto>> GetMessagesAsync(
            string username,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await _messageRepository.Query()
                .Where(message =>
                    message.Recipient.Username == username.ToNormalizedLower()
                    && message.Sender.Username == username.ToNormalizedLower())
                .SortMessages(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Date, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 50 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);
        }

        public async Task<(ServiceActionResult Result, MessageResponseDto? Created)> SendMessage(CreateMessageRequestDto message)
        {
            await _createMessageRequestValidator.ValidateAndThrowAsync(message);

            var sender = await _userService.GetByUsernameAsync(message.SenderUsername);
            var recipient = await _userService.GetByUsernameAsync(message.RecipientUsername);

            var newMessage = new Message
            {
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Content = message.Content,
            };

            var (result, created) = await _messageRepository.CreateAsync(newMessage);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);

            return (ServiceActionResult.Created, new MessageResponseDto
            {
                Content = created!.Content,
                RecipientUsername = recipient.Username,
                SenderUsername = sender.Username,
                CreatedAt = created!.CreatedAt,
            });
        }
    }
}
