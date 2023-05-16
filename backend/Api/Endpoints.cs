namespace Api
{
    public static class Endpoints
    {
        private const string ApiBase = "api";

        public static class Users
        {
            private const string ControllerBase = $"{ApiBase}/users";

            public const string GetAllTutorsInRegion = $"{ControllerBase}/tutors/{{countryName}}/{{regionName}}";
            public const string GetAllTutorsInCity = $"{ControllerBase}/tutors/{{countryName}}/{{regionName}}/{{cityName}}";
            public const string GetAllStudents = $"{ControllerBase}/students";
            public const string GetStudent = $"{ControllerBase}/students/{{id:long}}";
            public const string GetTutor = $"{ControllerBase}/tutors/{{id:long}}";
        }

        public static class Identity
        {
            private const string ControllerBase = $"{ApiBase}/identity";

            public const string Register = $"{ControllerBase}/register";
            public const string Login = $"{ControllerBase}/login";
        }

        public static class Posts
        {
            private const string ControllerBase = $"{ApiBase}/posts";

            public const string GetAllPosts = $"{ControllerBase}/{{country}}/{{region}}";
            public const string GetPost = $"{ControllerBase}/{{id:long}}";
            public const string CreatePost = $"{ControllerBase}";
        }

        public static class Appointments
        {
            private const string ControllerBase = $"{ApiBase}/appointments";

            public const string GetAllAppointments = $"{ControllerBase}";
            public const string GetFutureAppointments = $"{ControllerBase}/future";
            public const string GetAppointment = $"{ControllerBase}/{{id:long}}";
            public const string CreateAppointment = $"{ControllerBase}";
            public const string CancelAppointment = $"{ControllerBase}/{{id:long}}/cancel";
            public const string ReviewAppointmentAsStudent = $"{ControllerBase}/{{id:long}}/review-student";
            public const string ReviewAppointmentAsTutor = $"{ControllerBase}/{{id:long}}/review-tutor";
        }
    }
}
