namespace Application.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string About { get; set; } = null!;
        public string CityName { get; set; } = null!;

        public bool IsTutor => TutorInfo is not null;
        public TutorInfoDto? TutorInfo { get; set; }
    }
}
