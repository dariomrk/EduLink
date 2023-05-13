using Application.Dtos.TimeFrame;

namespace Application.Interfaces
{
    public interface ITimeFrameService
    {
        internal bool IsValidTimeFrame(TimeFrameRequestDto timeFrame);
        internal bool DoTimeFramesOverlap(TimeFrameRequestDto timeFrame1, TimeFrameRequestDto timeFrame2);
        internal bool AnyOverlappingTimeFrames(IEnumerable<TimeFrameRequestDto> timeFrames);
        internal Task<bool> IsAvailableTimeFrameAsync(long appointmentTimeFrame, CancellationToken cancellationToken = default);
    }
}
