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
    }
}
