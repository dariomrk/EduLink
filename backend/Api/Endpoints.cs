namespace Api
{
    public static class Endpoints
    {
        private const string ApiBase = "api";

        public static class Users
        {
            private const string ControllerBase = $"{ApiBase}/users";

            public const string GetAllTutors = $"{ControllerBase}/tutors/{{countryName}}/{{regionName}}/{{cityName}}";
            public const string GetAllStudents = $"{ControllerBase}/students";
            public const string GetStudent = $"{ControllerBase}/students/{{id:int}}";
            public const string GetTutor = $"{ControllerBase}/tutors/{{id:int}}";
        }
    }
}
