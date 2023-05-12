﻿using Application.Dtos.Common;
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
            //return sortByProperty switch
            //{
            //    SortByProperty.Rating => tutors.OrderBy(tutor => tutor.TutoringAppointments
            //        .Where(appointment => appointment.StudentsReview != null)
            //        .Average(appointment => appointment.StudentsReview!.Stars)),

            //    SortByProperty.Name => tutors.OrderBy(tutor => tutor.FirstName),

            //    SortByProperty.Distance => throw new NotImplementedException(),

            //    SortByProperty.Date => throw new InvalidRequestException<User>(nameof(SortTutors), nameof(SortByProperty.Date)),

            //    _ => throw new InvalidOperationException(),
            //};
        }

    }
}
