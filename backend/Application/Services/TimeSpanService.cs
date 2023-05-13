using Application.Dtos.AvailableTimeSpan;
using Application.Interfaces;

namespace Application.Services
{
    public class TimeSpanService : ITimeSpanService
    {
        public bool IsValidTimeSpan(AvailableTimeSpanRequestDto timeSpan)
        {
            return timeSpan.Start < timeSpan.End;
        }

        public bool DoTimeSpansOverlap(AvailableTimeSpanRequestDto timeSpan1, AvailableTimeSpanRequestDto timeSpan2)
        {
            return timeSpan1.Start < timeSpan2.End && timeSpan1.End > timeSpan2.Start;
        }

        public bool AnyOverlappingTimeSpans(IEnumerable<AvailableTimeSpanRequestDto> timeSpans)
        {
            var timeSpanList = timeSpans.ToList();

            for (var i = 0; i < timeSpanList.Count; i++)
            {
                for (var j = i + 1; j < timeSpanList.Count; j++)
                {
                    if (DoTimeSpansOverlap(timeSpanList[i], timeSpanList[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
