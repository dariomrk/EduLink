using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string myUsername,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ResponseAppointmentDto> GetAppointmentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(
            CreateAppointmentRequestDto createDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string myUsername,
            long appointmentId);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsStudentAsync(
            long appointmentId,
            CreateReviewAsStudentRequestDto reviewDto);

        public Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            CreateReviewAsTutorRequestDto reviewDto);

        internal Task<bool> IsPartOfPost(long appointmentId, long postId, CancellationToken cancellationToken = default);

        internal Task<bool> StudentIsAssignedToAppointment(string username, long appointmentId, CancellationToken cancellationToken = default);
    }
}
