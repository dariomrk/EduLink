using Application.Dtos.Appointment;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validators
{
    internal class AppointmentValidator : AbstractValidator<RequestCreateDto>
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly ITutoringPostService _tutoringPostService;

        internal AppointmentValidator(
            IUserService userService,
            IAppointmentService appointmentService,
            ITutoringPostService tutoringPostService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            _tutoringPostService = tutoringPostService;

            RuleFor(appointment => appointment.StudentUsername)
                .NotEmpty()
                .MustAsync(async (username, cancellationToken) =>
                    await _userService.UserExistsAsync(username));

            RuleFor(appointment => appointment.PostId)
                .NotEmpty()
                .MustAsync(_tutoringPostService.TutoringPostExists)
                .WithMessage(postId => $"Tutoring post with id `{postId} does not exist.`");

            RuleFor(appointment => appointment.AppointmentTimeSpanId)
                .NotEmpty()
                .MustAsync(async (appointment, appointmentId, cancellationToken) =>
                    await _appointmentService.IsPartOfPost(appointmentId, appointment.PostId, cancellationToken))
                .WithMessage((instance, appointmentId) =>
                    $"Appointment with id `{appointmentId}` is " +
                    $"not a part of the post with id `{instance.PostId}.`")
                .MustAsync(_appointmentService.IsAvailableTimeSpan)
                .WithMessage("Appointment is already taken.");
        }
    }
}
