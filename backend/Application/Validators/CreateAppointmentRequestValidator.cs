using Application.Dtos.Appointment;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators
{
    public class CreateAppointmentRequestValidator : AbstractValidator<CreateAppointmentRequestDto>
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITutoringPostService _tutoringPostService;
        private readonly ITimeFrameService _timeFrameService;

        public CreateAppointmentRequestValidator(
            IUserService userService,
            IAppointmentService appointmentService,
            ITutoringPostService tutoringPostService,
            ITimeFrameService timeFrameService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _tutoringPostService = tutoringPostService;
            _timeFrameService = timeFrameService;

            RuleFor(appointment => appointment.StudentUsername)
                .NotEmpty()
                .MustAsync(async (username, cancellationToken) =>
                    await _userService.UserExistsAsync(username));

            RuleFor(appointment => appointment.PostId)
                .NotEmpty()
                .MustAsync(_tutoringPostService.TutoringPostExistsAsync)
                .WithMessage(postId => $"Tutoring post with id `{postId} does not exist.`");

            RuleFor(appointment => appointment.AppointmentTimeFrameId)
                .NotEmpty()
                .MustAsync(async (appointment, appointmentId, cancellationToken) =>
                    await _appointmentService.IsPartOfPostAsync(appointmentId, appointment.PostId, cancellationToken))
                .WithMessage((instance, appointmentId) =>
                    $"Appointment with id `{appointmentId}` is " +
                    $"not a part of the post with id `{instance.PostId}.`")
                .MustAsync(_timeFrameService.IsAvailableTimeFrameAsync)
                .WithMessage("Time frame is already taken.");
        }
    }
}
