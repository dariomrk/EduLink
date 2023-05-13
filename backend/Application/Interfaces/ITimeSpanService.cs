
using Application.Dtos.AvailableTimeSpan;

namespace Application.Interfaces
{
    public interface ITimeSpanService
    {
        internal bool IsValidTimeSpan(AvailableTimeSpanRequestDto timeSpan);
        internal bool DoTimeSpansOverlap(AvailableTimeSpanRequestDto timeSpan1, AvailableTimeSpanRequestDto timeSpan2);
        internal bool AnyOverlappingTimeSpans(IEnumerable<AvailableTimeSpanRequestDto> timeSpans);
    }
}
