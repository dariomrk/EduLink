using Api.Extensions;
using Application.Constants;
using Application.Dtos.Common;
using Application.Dtos.Message;
using Application.Enums;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet(Endpoints.Messages.GetAllMessages)]
        public async Task<ActionResult<ICollection<MessageResponseDto>>> GetAllMessages(
            [FromQuery] PaginationRequestDto paginationOptions,
            [FromQuery] SortRequestDto sortOptions,
            CancellationToken cancellationToken)
        {
            var messages = await _messageService.GetMessagesAsync(
                User.GetUsername(),
                paginationOptions,
                sortOptions,
                cancellationToken);

            return Ok(messages);
        }

        [HttpPost(Endpoints.Messages.CreateMessage)]
        public async Task<ActionResult<MessageResponseDto>> CreateMessage(
            [FromBody] CreateMessageRequestDto createRequest)
        {
            var (result, created) = await _messageService.SendMessage(createRequest);

            if (result is not ServiceActionResult.Created)
                return BadRequest();
            return Ok(created);
        }
    }
}
