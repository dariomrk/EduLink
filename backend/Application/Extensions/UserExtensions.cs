using Application.Dtos.Common;
using Application.Enums;
using Application.Exceptions;
using Data.Models;

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

                SortByProperty.Distance => throw new NotImplementedException(), // TODO: Implement sorting by distance from the user in SortTutors

                SortByProperty.Date => throw new InvalidRequestException<User>(nameof(SortByProperty), nameof(SortByProperty.Date)),

                _ => throw new NotSupportedRequestException<User>(nameof(SortTutors), null),
            };

            return sorted.SortOrder(sortDto.SortOrder);
        }
    }
}
