using Application.Dtos.User;
using Data.Models;
using Riok.Mapperly.Abstractions;

namespace Application.Mappings
{
    [Mapper]
    internal static partial class UserMappings
    {
        internal static partial UserDto ToDto(this User user);
        internal static partial IQueryable<UserDto> ProjectToDto(this IQueryable<User> users);
        internal static IQueryable<UserDto> ProjectTutorToDto(this IQueryable<User> tutors) =>
            tutors.Select(tutor => new UserDto
            {
                Id = tutor.Id,
                Username = tutor.Username,
                FirstName = tutor.FirstName,
                LastName = tutor.LastName,
                About = tutor.About,
                CityName = tutor.City.Name,
                TutorInfo = new TutorInfoDto
                {
                    AverageRating = tutor.TutoringAppointments
                            .Where(appointment => appointment.StudentsReview != null)
                            .Any()
                                ? tutor.TutoringAppointments.Average(appointment => appointment.StudentsReview!.Stars)
                                : null,
                    TotalTutoringHours = tutor.TutoringAppointments
                            .Any(appointment =>
                                appointment.StartAt.AddMinutes(appointment.DurationMinutes)
                                < DateTime.UtcNow.Add(appointment.StartAt.Offset))
                                ? tutor.TutoringAppointments.Sum(x => x.DurationMinutes) / 60
                                : 0,
                }
            });
    }
}
