using Application.Dtos.Subject;

namespace Application.Interfaces
{
    public interface ISubjectService
    {
        public Task<ICollection<string>> GetAllSubjectsAsync(CancellationToken cancellationToken = default);
        public Task<SubjectResponseDto> GetSubjectAsync(string subject, CancellationToken cancellationToken = default);
    }
}
