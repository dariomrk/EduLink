namespace Application.Dtos.Indentity
{
    public class RegisterRequestDto
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string CityName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
    }
}
