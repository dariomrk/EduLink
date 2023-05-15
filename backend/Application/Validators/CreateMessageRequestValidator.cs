using Application.Dtos.Message;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators
{
    public class CreateMessageRequestValidator : AbstractValidator<CreateMessageRequestDto>
    {
        private readonly IUserService _userService;

        public CreateMessageRequestValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(message => message.SenderUsername)
                .NotEmpty()
                .MustAsync(_userService.UserExistsAsync);

            RuleFor(message => message.RecipientUsername)
                .NotEmpty()
                .MustAsync(_userService.UserExistsAsync);

            RuleFor(message => message)
                .MustAsync(async (message, cancellationToken) =>
                {
                    var isStudentOf = await _userService.IsStudentOfTutorAsync(
                        message.SenderUsername,
                        message.RecipientUsername,
                        cancellationToken);

                    var isTutorOf = await _userService.IsTutorOfStudentAsync(
                        message.SenderUsername,
                        message.RecipientUsername,
                        cancellationToken);

                    return isStudentOf || isTutorOf;
                })
                .WithMessage((message) =>
                    $"The message with sender `{message.SenderUsername}` " +
                    $"and recipient `{message.RecipientUsername}` could not be sent " +
                    $"as the users have no relation to one another.");

            RuleFor(message => message.Message)
                .NotEmpty()
                .MaximumLength(2048)
                .WithMessage("Maximum message length is 2048 characters.");
        }
    }
}
