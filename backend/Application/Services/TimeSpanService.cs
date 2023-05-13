using Application.Dtos.AvailableTimeSpan;
using Application.Interfaces;

namespace Application.Services
{
    public class TimeSpanService : ITimeSpanService
    {
        public bool IsValidTimeSpan(TimeSpanDto timeSpan)
        {
            return timeSpan.Start < timeSpan.End;
        }

        public bool DoTimeSpansOverlap(TimeSpanDto timeSpan1, TimeSpanDto timeSpan2)
        {
            return timeSpan1.Start < timeSpan2.End && timeSpan1.End > timeSpan2.Start;
        }

        public bool AnyOverlappingTimeSpans(IEnumerable<TimeSpanDto> timeSpans)
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
