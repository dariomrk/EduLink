﻿using Riok.Mapperly.Abstractions;

namespace Application.Dtos.User
{
    [Mapper]
    internal static partial class UserMappings
    {
        internal static partial UserResponseDto ToDto(this Data.Models.User user);

        internal static partial IQueryable<UserResponseDto> ProjectToDto(this IQueryable<Data.Models.User> users);

        internal static IQueryable<UserResponseDto> ProjectTutorToDto(this IQueryable<Data.Models.User> tutors) =>
            tutors.Select(tutor => new UserResponseDto
            {
                Id = tutor.Id,
                Username = tutor.Username,
                FirstName = tutor.FirstName,
                LastName = tutor.LastName,
                About = tutor.About,
                CityName = tutor.City.Name,
                TutorInfo = new TutorInfoResponseDto
                {
                    AverageRating = tutor.TutoringAppointments
                            .Where(appointment => appointment.StudentsReview != null)
                            .Any()
                                ? tutor.TutoringAppointments.Average(appointment => appointment.StudentsReview!.Stars)
                                : null,
                    // TODO: Fix total tutoring hours calculation
                    //TotalTutoringHours = tutor.TutoringAppointments
                    //        .Any(appointment =>
                    //            appointment.StartAt.AddMinutes(appointment.DurationMinutes)
                    //            < DateTime.UtcNow.Add(appointment.StartAt.Offset))
                    //            ? tutor.TutoringAppointments.Sum(x => x.DurationMinutes) / 60
                    //            : 0,
                }
            });
    }
}
