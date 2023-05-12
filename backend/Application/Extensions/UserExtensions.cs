using Data.Models;

namespace Application.Extensions
{
    public static class UserExtensions
    {
        public static bool IsTutor(this User user) =>
            user.TutoringPosts.Any();

        public static bool IsStudentOfTutor(this User user, string tutorUsername) =>
            user.TutoringAppointments
                .Any(appointment => appointment.Tutor.Username == tutorUsername.ToNormalizedLower());

    }
}
