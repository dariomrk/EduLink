using Api.Extensions;
using Application.Constants;
using Application.Dtos.Appointment;
using Application.Dtos.Common;
using Application.Dtos.Review;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;

        public AppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet(Endpoints.Appointments.GetAllAppointments)]
        public async Task<ActionResult<ICollection<AppointmentResponseDto>>> GetAllAppointments(
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var appointments = await _appointmentsService.GetAppointmentsAsync(
                User.GetUsername(),
                sortOptions,
                paginationOptions,
                cancellationToken);

            return Ok(appointments);
        }

        [HttpGet(Endpoints.Appointments.GetFutureAppointments)]
        public async Task<ActionResult<ICollection<AppointmentResponseDto>>> GetAllFutureAppointments(
            [FromQuery] SortRequestDto sortOptions,
            [FromQuery] PaginationRequestDto paginationOptions,
            CancellationToken cancellationToken)
        {
            var appointments = await _appointmentsService.GetFutureAppointmentsAsync(
                User.GetUsername(),
                sortOptions,
                paginationOptions,
                cancellationToken);

            return Ok(appointments);
        }

        [HttpGet(Endpoints.Appointments.GetAppointment)]
        public async Task<ActionResult<AppointmentResponseDto>> GetAppointment(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var appointment = await _appointmentsService.GetAppointmentAsync(
                User.GetUsername(),
                id,
                cancellationToken);

            return Ok(appointment);
        }

        [HttpPost(Endpoints.Appointments.CreateAppointment)]
        public async Task<ActionResult<AppointmentResponseDto>> CreateAppointment(
            CreateAppointmentRequestDto createRequest)
        {
            var (result, created) = await _appointmentsService.CreateAppointmentAsync(
                createRequest);

            if (result is not Application.Enums.ServiceActionResult.Created)
                return BadRequest();
            return Ok(created);
        }

        [HttpPatch(Endpoints.Appointments.CancelAppointment)]
        public async Task<ActionResult<AppointmentResponseDto>> CancelAppointment([FromRoute] long id)
        {
            var (result, updated) = await _appointmentsService.CancelAppointmentAsync(
                User.GetUsername(),
                id);

            if (result is not Application.Enums.ServiceActionResult.Created)
                return BadRequest();
            return Ok(updated);
        }

        [HttpPost(Endpoints.Appointments.ReviewAppointmentAsStudent)]
        public async Task<ActionResult<AppointmentResponseDto>> ReviewAppointmentAsStudent(
            [FromRoute] long id,
            [FromBody] CreateReviewAsStudentRequestDto reviewRequest)
        {
            var (result, created) = await _appointmentsService.ReviewAppointmentAsStudentAsync(
                id,
                reviewRequest);

            if (result is not Application.Enums.ServiceActionResult.Created)
                return BadRequest();
            return Ok(created);
        }

        [HttpPost(Endpoints.Appointments.ReviewAppointmentAsTutor)]
        public async Task<ActionResult<AppointmentResponseDto>> ReviewAppointmentAsTutor(
            [FromRoute] long id,
            [FromBody] CreateReviewAsTutorRequestDto reviewRequest)
        {
            var (result, created) = await _appointmentsService.ReviewAppointmentAsTutorAsync(
                id,
                reviewRequest);

            if (result is not Application.Enums.ServiceActionResult.Created)
                return BadRequest();
            return Ok(created);
        }
    }
}
