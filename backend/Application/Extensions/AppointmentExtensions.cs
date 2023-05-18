using Application.Dtos.Common;
using Application.Exceptions;
using Data.Models;

namespace Application.Extensions
{
    internal static class AppointmentExtensions
    {
        public static IQueryable<Appointment> SortAppointments(this IQueryable<Appointment> appointments, SortRequestDto sortDto)
        {
            var sorted = sortDto.SortByProperty switch
            {
                Enums.SortByProperty.Rating => throw new NotSupportedRequestException<Appointment>(nameof(SortAppointments), nameof(Enums.SortByProperty.Rating)),

                Enums.SortByProperty.Name => throw new NotSupportedRequestException<Appointment>(nameof(SortAppointments), nameof(Enums.SortByProperty.Name)),

                Enums.SortByProperty.Date => appointments.OrderBy(appointment => appointment.AppointmentTimeFrame.Start),

                _ => throw new InvalidRequestException<Appointment>(nameof(SortAppointments), null),
            };

            return sorted.SortOrder(sortDto.SortOrder);
        }
    }
}
