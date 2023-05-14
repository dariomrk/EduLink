using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string username,
            SortRequestDto? sortRequest = null,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string username,
            SortRequestDto? sortRequest = null,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ResponseAppointmentDto> GetAppointmentAsync(
            string username,
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(
            CreateAppointmentRequestDto createDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string username,
            long appointmentId);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            CreateReviewAsStudentRequestDto reviewDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            CreateReviewAsTutorRequestDto reviewDto);

        internal Task<bool> IsPartOfPostAsync(long appointmentId, long postId, CancellationToken cancellationToken = default);
        internal Task<bool> IsStudentAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsTutorAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsAssignedToAppointmentAsync(string username, long appointmentId, CancellationToken cancellationToken = default);
        internal Task<bool> IsAppointmentCancelableAsync(long id, CancellationToken cancellationToken = default);
        internal Task<bool> HasAppointmentPassedAsync(long id, CancellationToken cancellationToken = default);
    }
}
