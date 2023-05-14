using Application.Dtos.Common;
using Application.Enums;
using Application.Exceptions;

namespace Application.Extensions
{
    internal static class TutoringPostExtensions
    {
        internal static IQueryable<Data.Models.TutoringPost> SortTutoringPosts(this IQueryable<Data.Models.TutoringPost> tutoringPosts, SortRequestDto sortDto)
        {
            var sorted = sortDto.SortByProperty switch
            {
                SortByProperty.Rating => tutoringPosts.OrderBy(tutoringPost =>
                    tutoringPost.Tutor.TutoringAppointments
                        .Where(appointment => appointment.StudentsReview != null)
                        .Select(appointment => (double?)appointment.StudentsReview!.Stars)
                        .DefaultIfEmpty(0)
                        .Average()),

                SortByProperty.Name => tutoringPosts.OrderBy(tutoringPost => tutoringPost.Tutor.FirstName),

                SortByProperty.Distance => throw new NotImplementedException(), // TODO: Implement sorting by distance from the user in SortTutoringPosts

                SortByProperty.Date => tutoringPosts.OrderBy(tutoringPost =>
                    tutoringPost.AvailableTimeFrames.OrderBy(timeFrame => timeFrame.Start)),

                _ => throw new InvalidRequestException<Data.Models.TutoringPost>(nameof(SortTutoringPosts), null),
            };

            return sorted.SortOrder(sortDto.SortOrder);
        }
    }
}
