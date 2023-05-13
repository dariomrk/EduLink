using Application.Enums;

namespace Application.Dtos.Common
{
    public class RequestSortDto
    {
        public SortByProperty SortByProperty { get; set; }
        public SortOrder SortOrder { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
