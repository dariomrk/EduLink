using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string myUsername,
            long appointmentId)
        {
            // TODO check whether the appointment is cancelable
            throw new NotImplementedException();
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(CreateAppointmentRequestDto createDto)
        {
            // TODO validate that the appointment is not already taken
            throw new NotImplementedException();
        }

        public async Task<ResponseAppointmentDto> GetAppointmentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string myUsername,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            ReviewAsStudentRequestDto reviewDto)
        {
            // TODO validate that the appointment has passed
            // TODO validate that the student is actually the student that attended the appointment
            throw new NotImplementedException();
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            ReviewAsTutorRequestDto reviewDto)
        {
            // TODO validate that the appointment has passed
            // TODO validate that the tutor is actually the tutor of said appointment
            throw new NotImplementedException();
        }

        public async Task<bool> IsAvailableTimeSpan(
            long appointmentId,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsPartOfPost(
            long appointmentId,
            long postId,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
