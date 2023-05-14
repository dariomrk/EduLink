using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Enums;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment, long> _appointmentRepository;
        private readonly IValidator<CreateAppointmentRequestDto> _createAppointmentRequestValidator;

        public AppointmentService(
            IRepository<Appointment, long> appointmentRepository,
            IValidator<CreateAppointmentRequestDto> createAppointmentRequestValidator)
        {
            _appointmentRepository = appointmentRepository;
            _createAppointmentRequestValidator = createAppointmentRequestValidator;
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Updated)> CancelAppointmentAsync(
            string username,
            long appointmentId)
        {
            await GetAppointmentAsync(username, appointmentId);

            var isAssignedToAppointment = await IsAssignedToAppointmentAsync(username, appointmentId);

            var isCancelable = await IsAppointmentCancelableAsync(appointmentId);

            if (isCancelable is false)
                throw new InvalidRequestException<Appointment>(nameof(CancelAppointmentAsync), appointmentId);

            var appointment = await _appointmentRepository.FindByIdAsync(appointmentId);

            appointment!.IsCancelled = true;

            var (result, updated) = await _appointmentRepository.UpdateAsync(appointment);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);

            return (ServiceActionResult.Updated, updated!.ToDto());
        }

        public async Task<(ServiceActionResult Result, ResponseAppointmentDto? Created)> CreateAppointmentAsync(CreateAppointmentRequestDto createDto)
        {
            await _createAppointmentRequestValidator.ValidateAndThrowAsync(createDto);

            var mapped = createDto.ToModel();

            var (result, created) = await _appointmentRepository.CreateAsync(mapped);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);

            return (ServiceActionResult.Created, created!.ToDto());
        }

        public async Task<ResponseAppointmentDto> GetAppointmentAsync(
            string username,
            long id,
            CancellationToken cancellationToken = default)
        {
            var appointment = await _appointmentRepository.Query()
                .FirstOrDefaultAsync(appointment => appointment.Id == id &&
                    (appointment.Tutor.Username == username.ToNormalizedLower()
                    || appointment.AppointmentTimeFrame.TakenByStudentId.HasValue
                        && appointment.AppointmentTimeFrame.TakenByStudent!.Username == username.ToNormalizedLower()),
                    cancellationToken);

            return appointment?.ToDto() ?? throw new NotFoundException<Appointment>(id);
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetAppointmentsAsync(
            string username,
            SortRequestDto? sortOptions = null,
            PaginationRequestDto? paginationOptions = null,
            CancellationToken cancellationToken = default)
        {
            return await _appointmentRepository.Query()
                .Where(appointment =>
                    appointment.Tutor.Username == username.ToNormalizedLower()
                    || appointment.AppointmentTimeFrame.TakenByStudentId.HasValue
                        && appointment.AppointmentTimeFrame.TakenByStudent!.Username == username.ToNormalizedLower())
                .OrderBy(appointment => appointment.AppointmentTimeFrame.Start)
                .SortAppointments(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Date, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 25 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<ResponseAppointmentDto>> GetFutureAppointmentsAsync(
            string myUsername,
            SortRequestDto? sortRequest = null,
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

        public async Task<bool> IsPartOfPostAsync(
            long appointmentId,
            long postId,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsStudentAssignedToAppointmentAsync(
            string username,
            long appointmentId,
            CancellationToken cancellationToken = default)
        {
            return await _appointmentRepository.Query()
                .Where(appointment => appointment.Id == appointmentId)
                .AnyAsync(appointment => appointment.AppointmentTimeFrame.TakenByStudentId.HasValue
                    && appointment.AppointmentTimeFrame.TakenByStudent!.Username == username.ToNormalizedLower(),
                    cancellationToken);
        }

        public async Task<bool> IsTutorAssignedToAppointmentAsync(
            string username,
            long appointmentId,
            CancellationToken cancellationToken = default)
        {
            return await _appointmentRepository.Query()
                .AnyAsync(appointment =>
                    appointment.Id == appointmentId
                        && appointment.Tutor.Username == username.ToNormalizedLower(),
                    cancellationToken);
        }

        public async Task<bool> IsAssignedToAppointmentAsync(
            string username,
            long appointmentId,
            CancellationToken cancellationToken = default)
        {
            var toStudent = await IsStudentAssignedToAppointmentAsync(username, appointmentId, cancellationToken);
            var toTutor = await IsTutorAssignedToAppointmentAsync(username, appointmentId, cancellationToken);

            return toStudent || toTutor;
        }

        public async Task<bool> IsAppointmentCancelableAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            return await _appointmentRepository.Query()
                .AnyAsync(appointment => appointment.Id == id
                    && appointment.AppointmentTimeFrame.Start.AddHours(-24) // TODO add configuration field in appsettings.json
                        > DateTime.Now.Add(appointment.AppointmentTimeFrame.Start.Offset),
                    cancellationToken);
        }
    }
}
