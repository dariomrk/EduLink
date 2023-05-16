using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<ICollection<AppointmentResponseDto>> GetAppointmentsAsync(
            string username,
            SortRequestDto? sortRequest = null,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<AppointmentResponseDto>> GetFutureAppointmentsAsync(
            string username,
            SortRequestDto? sortRequest = null,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<AppointmentResponseDto> GetAppointmentAsync(
            string username,
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, AppointmentResponseDto? Created)> CreateAppointmentAsync(
            CreateAppointmentRequestDto createDto);

        public Task<(ServiceActionResult Result, AppointmentResponseDto? Updated)> CancelAppointmentAsync(
            string username,
            long appointmentId);

        public Task<(ServiceActionResult Result, AppointmentResponseDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            CreateReviewAsStudentRequestDto reviewDto);

        public Task<(ServiceActionResult Result, AppointmentResponseDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            CreateReviewAsTutorRequestDto reviewDto);

        internal Task<bool> IsStudentAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsTutorAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsAppointmentCancelableAsync(long id, CancellationToken cancellationToken = default);
        internal Task<bool> HasAppointmentPassedAsync(long id, CancellationToken cancellationToken = default);
    }
}
