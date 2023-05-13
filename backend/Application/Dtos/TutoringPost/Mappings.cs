﻿using Application.Dtos.TutoringPost;
using Riok.Mapperly.Abstractions;

namespace Application.TutoringPost
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
    internal static partial class Mappings
    {
        internal static partial ResponseDto ToDto(this Data.Models.TutoringPost tutoringPost);

        [MapperIgnoreTarget(nameof(Data.Models.TutoringPost.Fields))]
        internal static partial Data.Models.TutoringPost ToModel(this RequestDto dto);

        internal static IQueryable<ResponseDto> ProjectToDto(this IQueryable<Data.Models.TutoringPost> posts)
        {
            return posts.Select(post => new ResponseDto
            {
                TutorUsername = post.Tutor.Username,
                Currency = post.Currency.ToString(),
                Fields = post.Fields
                    .Select(field => field.Field.Name)
                    .ToList(),
                PricePerHour = post.PricePerHour,
                SubjectName = post.Fields.FirstOrDefault()!.Field.Subject.Name,
                AvailableTimeSpans = post.AvailableTimeSpans
                    .Select(timeSpan => new Dtos.AvailableTimeSpan.ResponseDto
                    {
                        Start = timeSpan.Start,
                        End = timeSpan.End,
                        IsAvailable = timeSpan.TakenByStudent == null,
                    })
                    .ToList(),
            });
        }
    }
}
