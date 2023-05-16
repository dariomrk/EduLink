namespace Application.Dtos.Location
{
    public class RegionResponseDto
    {
        public string RegionName { get; set; } = null!;
        public ICollection<CityResponseDto> Cities { get; set; } = new List<CityResponseDto>();
    }
}
