namespace Api
{
    public class Routes
    {
        private const string Base = "api";

        public static class Users
        {
            public const string GetTutorsInCity = Base + $"/users/tutors/{{countryName:string}}/region/{{regionName:string}}/city/{{cityName:string}}";
            public const string GetTutorsInRegion = Base + $"/users/tutors/{{countryName:string}}/region/{{regionName:string}}";
            public const string GetAllStudents = Base + $"/users/students";
            public const string GetStudent = Base + $"/users/students/{{username:string}}";
            public const string GetTutor = Base + $"/users/tutors/{{username:string}}";
        }
            public static class Posts
        {
            public const string GetAll = Base + $"/users/country/{{countryName:string}}/region/{{regionName:string}}/city/{{cityName:string}}/posts";
            public const string Get = Base + $"/posts /{{id:int}}";
            public const string Create = Base + $"/posts ";
        }

        public static class Appointments
        {
            public const string GetAll = Base + $"/appointments";
            public const string Get = Base + $"/appointments/{{id:int}}";
            public const string Create = Base + $"/appointments";
            public const string Cancel = Base + $"/appointments/{{id:int}}/cancel";
            public const string Review = Base + $"/appointments/{{id:int}}/review";
        }
        public static class Messages
        {
            public const string GetAll = Base + $"/messages";
            public const string Get = Base + $"/messages/{{id:int}}";
            public const string Create = Base + $"/messages/{{id:int}}/new";
        }
        public static class Identity
        {
            public const string Register = Base + $"/identity/register";
            public const string Login = Base + $"/identity/login";
        }
    }
}
