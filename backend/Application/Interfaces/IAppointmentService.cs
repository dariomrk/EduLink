using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Enums;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<ICollection<AppointmentDto>> GetAppointmentsAsync(
            string myUsername,
            PaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<ICollection<AppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            PaginationDto? paginationOptions = null,
            CancellationToken cancellationToken = default);

        public Task<AppointmentDto> GetAppointmentAsync(
            string myUsername,
            long id,
            CancellationToken cancellationToken = default);

        public Task<(ServiceActionResult Result, AppointmentDto? Created)> CreateAppointmentAsync(
            CreateDto createDto);

        public Task<(ServiceActionResult Result, AppointmentDto? Updated)> CancelAppointmentAsync(
            string myUsername,
            long appointmentId);

        public Task<(ServiceActionResult Result, AppointmentDto? Updated)> ReviewAppointmentAsync(
            long appointmentId,
            ReviewDto reviewDto);
    }
}
