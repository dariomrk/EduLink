using Application.Dtos.Common;
using Application.Enums;
using Application.Exceptions;
using Data.Models;

namespace Application.Extensions
{
    internal static class UserExtensions
    {
        internal static bool IsTutor(this User user) =>
            user.TutoringPosts.Any();

        internal static bool IsStudentOfTutor(this User user, string tutorUsername) =>
            user.TutoringAppointments
                .Any(appointment => appointment.Tutor.Username == tutorUsername.ToNormalizedLower());

        internal static IQueryable<User> SortTutors(this IQueryable<User> tutors, RequestSortDto sortDto)
        {
            return sortDto.SortByProperty switch
            {
                SortByProperty.Rating => tutors.OrderBy(tutor => tutor.TutoringAppointments
                    .Where(appointment => appointment.StudentsReview != null)
                    .Average(appointment => appointment.StudentsReview!.Stars)),

                SortByProperty.Name => tutors.OrderBy(tutor => tutor.FirstName),

                SortByProperty.Distance => throw new NotImplementedException(), // TODO implement sorting by distance from the user

                SortByProperty.Date => throw new InvalidRequestException<User>(nameof(SortByProperty), nameof(SortByProperty.Date)),

                _ => throw new NotSupportedException(),
            };
        }
    }
}
