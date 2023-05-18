using Application.Dtos.Common;
using Application.Enums;
using Application.Exceptions;
using Data.Models;
using NetTopologySuite.Geometries;

namespace Application.Extensions
{
    internal static class UserExtensions
    {
        internal static IQueryable<User> SortTutors(this IQueryable<User> tutors, SortRequestDto sortDto)
        {
            var sorted = sortDto.SortByProperty switch
            {
                SortByProperty.Rating => tutors.OrderBy(tutor =>
                    tutor.TutoringAppointments
                        .Where(appointment => appointment.StudentsReview != null)
                        .Select(appointment => (double?)appointment.StudentsReview!.Stars)
                        .DefaultIfEmpty(0)
                        .Average()),

                SortByProperty.Name => tutors.OrderBy(tutor => tutor.FirstName),

                SortByProperty.Distance => tutors.OrderBy(tutor =>
                    tutor.Coordinates != null
                    ? tutor.Coordinates.Distance(new Point(sortDto.Longitude!.Value, sortDto.Latitude!.Value)
                    {
                        SRID = 4326
                    })
                    : tutor.City.Coordinates.Distance(new Point(sortDto.Longitude!.Value, sortDto.Longitude!.Value)
                    {
                        SRID = 4326
                    })),

                SortByProperty.Date => throw new NotSupportedRequestException<User>(nameof(SortByProperty), nameof(SortByProperty.Date)),

                _ => throw new InvalidRequestException<User>(nameof(SortTutors), null),
            };

            return sorted.SortOrder(sortDto.SortOrder);
        }
    }
}
