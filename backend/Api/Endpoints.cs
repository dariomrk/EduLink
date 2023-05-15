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
    }
}
