
using Application.Dtos.AvailableTimeSpan;

namespace Application.Interfaces
{
    public interface ITimeSpanService
    {
        internal bool IsValidTimeSpan(RequestDto timeSpan);
        internal bool DoTimeSpansOverlap(RequestDto timeSpan1, RequestDto timeSpan2);
        internal bool AnyOverlappingTimeSpans(IEnumerable<RequestDto> timeSpans);
    }
}
