using Application.Dtos.TimeFrame;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;

namespace Application.Services
{
    public class TimeFrameService : ITimeFrameService
    {
        private readonly IRepository<TimeFrame, long> _timeFrameRepository;

        public TimeFrameService(IRepository<TimeFrame, long> timeFrameRepository)
        {
            _timeFrameRepository = timeFrameRepository;
        }

        public bool IsValidTimeFrame(TimeFrameRequestDto timeFrames)
        {
            return timeFrames.Start < timeFrames.End;
        }

        public bool DoTimeFramesOverlap(TimeFrameRequestDto timeFrame1, TimeFrameRequestDto timeFrame2)
        {
            return timeFrame1.Start < timeFrame2.End && timeFrame1.End > timeFrame2.Start;
        }

        public bool AnyOverlappingTimeFrames(IEnumerable<TimeFrameRequestDto> timeFrames)
        {
            var timeFrameList = timeFrames.ToList();

            for (var i = 0; i < timeFrameList.Count; i++)
            {
                for (var j = i + 1; j < timeFrameList.Count; j++)
                {
                    if (DoTimeFramesOverlap(timeFrameList[i], timeFrameList[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> IsAvailableTimeFrameAsync(
            long timeFrameId,
            CancellationToken cancellationToken = default)
        {
            // TODO check whether the timeframe is in the future
            // TODO check whether the timeframe is taken
            throw new NotImplementedException();
        }
    }
}
