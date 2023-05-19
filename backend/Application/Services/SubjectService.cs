using Application.Dtos.Subject;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject, long> _subjectRepository;
        private readonly ILogger<SubjectService> _logger;

        public SubjectService(
            IRepository<Subject, long> subjectRepository,
            ILogger<SubjectService> logger)
        {
            _subjectRepository = subjectRepository;
            _logger = logger;
        }

        public async Task<SubjectResponseDto> GetSubjectAsync(
            string subjectName,
            CancellationToken cancellationToken = default)
        {
            var subject = await _subjectRepository.Query()
                .Where(subject => subject.Name == subjectName.ToNormalizedLower())
                .Select(subject => new SubjectResponseDto
                {
                    SubjectName = subjectName,
                    Fields = subject.Fields.Select(field => field.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return subject ?? throw new NotFoundException<Subject>(subjectName);
        }

        public async Task<ICollection<string>> GetAllSubjectsAsync(
            CancellationToken cancellationToken = default)
        {
            return await _subjectRepository.Query()
                .Select(subject => subject.Name)
                .ToListAsync(cancellationToken);
        }
    }
}
