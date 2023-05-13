using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment, long> _appointmentRepository;

        public AppointmentService(IRepository<Appointment, long> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

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
            CreateReviewAsStudentRequestDto reviewDto)
        {
            // TODO validate that the appointment has passed
            // TODO validate that the student is actually the student that attended the appointment
            throw new NotImplementedException();
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> ReviewAppointmentAsTutorAsync(
            long appointmentId,
            CreateReviewAsTutorRequestDto reviewDto)
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

        public async Task<bool> StudentIsAssignedToAppointment(
            string username,
            long appointmentId,
            CancellationToken cancellationToken = default)
        {
            return await _appointmentRepository.Query()
                .Where(appointment => appointment.Id == appointmentId)
                .Where(appointment => appointment.AppointmentTimeSpan.TakenByStudent != null)
                .AnyAsync(appointment =>
                    appointment.AppointmentTimeSpan.TakenByStudent!.Username == username.ToNormalizedLower(),
                    cancellationToken);
        }
    }
}
