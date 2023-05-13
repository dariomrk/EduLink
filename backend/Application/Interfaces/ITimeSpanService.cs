
using Application.Dtos.AvailableTimeSpan;

namespace Application.Interfaces
{
    public interface ITimeSpanService
    {
        internal bool IsValidTimeSpan(TimeSpanDto timeSpan);
        internal bool DoTimeSpansOverlap(TimeSpanDto timeSpan1, TimeSpanDto timeSpan2);
        internal bool AnyOverlappingTimeSpans(IEnumerable<TimeSpanDto> timeSpans);
    }
}
