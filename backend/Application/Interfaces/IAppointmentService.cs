using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string myUsername,
            RequestPaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            RequestPaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ResponseAppointmentDto> GetAppointmentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(
            RequestCreateDto createDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string myUsername,
            long appointmentId);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            Dtos.StudentsReview.RequestAsStudentDto reviewDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            Dtos.StudentsReview.RequestAsTutorDto reviewDto);
    }
}
