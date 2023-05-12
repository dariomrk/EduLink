using Application.Dtos.Common;
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

        internal static IQueryable<User> SortTutors(this IQueryable<User> tutors, SortDto sortDto)
        {
            // TODO re-implement
            // TODO add-ordering

            return sortDto.SortByProperty switch
            {
                Enums.SortByProperty.Rating => tutors.OrderBy(tutor => tutor.TutoringAppointments
                    .Where(appointment => appointment.StudentsReview != null)
                    .Average(appointment => appointment.StudentsReview!.Stars)),

                Enums.SortByProperty.Name => tutors.OrderBy(tutor => tutor.FirstName),

                Enums.SortByProperty.Distance => throw new NotImplementedException(),

                Enums.SortByProperty.Date => throw new NotImplementedException(),

                _ => throw new NotSupportedException(),
            };
        }

    }
}
