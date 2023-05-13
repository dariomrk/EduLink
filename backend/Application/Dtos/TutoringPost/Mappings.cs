using Application.Dtos.TutoringPost;
using Riok.Mapperly.Abstractions;

namespace Application.TutoringPost
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
    internal static partial class Mappings
    {
        internal static partial TutoringPostResponseDto ToDto(this Data.Models.TutoringPost tutoringPost);

        [MapperIgnoreTarget(nameof(Data.Models.TutoringPost.Fields))]
        internal static partial Data.Models.TutoringPost ToModel(this TutoringPostRequestDto dto);

        internal static IQueryable<TutoringPostResponseDto> ProjectToDto(this IQueryable<Data.Models.TutoringPost> posts)
        {
            return posts.Select(post => new TutoringPostResponseDto
            {
                TutorUsername = post.Tutor.Username,
                Currency = post.Currency.ToString(),
                Fields = post.Fields
                    .Select(field => field.Field.Name)
                    .ToList(),
                PricePerHour = post.PricePerHour,
                SubjectName = post.Fields.FirstOrDefault()!.Field.Subject.Name,
                AvailableTimeFrames = post.AvailableTimeFrames
                    .Select(timeFrame => new Dtos.TimeFrame.TimeFrameResponseDto
                    {
                        Start = timeFrame.Start,
                        End = timeFrame.End,
                        IsAvailable = timeFrame.TakenByStudent == null,
                    })
                    .ToList(),
            });
        }
    }
}
