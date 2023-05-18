using Application.Enums;

namespace Application.Dtos.Common
{
    public class SortRequestDto
    {
        public SortByProperty SortByProperty { get; set; }
        public SortOrder SortOrder { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
