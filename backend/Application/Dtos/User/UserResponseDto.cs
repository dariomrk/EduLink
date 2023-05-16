namespace Application.Dtos.User
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? About { get; set; }
        public string? CityName { get; set; }

        public bool IsTutor => TutorInfo is not null;
        public TutorInfoResponseDto? TutorInfo { get; set; }
    }
}
