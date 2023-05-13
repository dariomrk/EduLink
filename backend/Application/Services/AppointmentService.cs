using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string myUsername,
            long appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(RequestCreateDto createDto)
        {
            // TODO validate that the appointment is not already taken
            throw new NotImplementedException();
        }

        public Task<ResponseAppointmentDto> GetAppointmentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string myUsername,
            RequestPaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            RequestPaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            RequestReviewAsStudentDto reviewDto)
        {
            // TODO validate that the appointment has passed
            // TODO validate that the student is actually the student that attended the appointment
            throw new NotImplementedException();
        }

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            RequestReviewAsTutorDto reviewDto)
        {
            // TODO validate that the appointment has passed
            // TODO validate that the tutor is actually the tutor of said appointment
            throw new NotImplementedException();
        }
    }
}
