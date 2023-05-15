using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class FieldService : IFieldService
    {
        private readonly IRepository<Field, long> _fieldRepository;
        private readonly IRepository<Subject, long> _subjectRepository;
        private readonly ILogger<FieldService> _logger;

        public FieldService(
            IRepository<Field, long> fieldRepository,
            IRepository<Subject, long> subjectRepository,
            ILogger<FieldService> logger)
        {
            _fieldRepository = fieldRepository;
            _subjectRepository = subjectRepository;
            _logger = logger;
        }

        public async Task<(long SubjectKey, ICollection<long> FieldKeys)> GetSubjectAndFieldKeys(
            string subjectName,
            ICollection<string> fieldNames,
            CancellationToken cancellationToken)
        {
            var subject = await _subjectRepository.Query()
                .FirstOrDefaultAsync(subject => subject.Name == subjectName.ToNormalizedLower());

            if (subject is null)
                throw new NotFoundException<Subject>(subjectName);

            var fields = await _fieldRepository.Query()
                .Where(field =>
                    field.SubjectId == subject.Id
                    && fieldNames.Any(fieldName =>
                        fieldName.ToNormalizedLower() == field.Name))
                .Select(field => field.Id)
                .ToListAsync(cancellationToken);

            return (subject.Id, fields);
        }

        public async Task<bool> SubjectContainsField(
            string subjectName,
            string fieldName,
            CancellationToken cancellationToken)
        {
            return await _subjectRepository.Query()
                .AnyAsync(subject =>
                    subject.Name == subjectName.ToNormalizedLower()
                    && subject.Fields.Any(field =>
                        field.Name == fieldName.ToNormalizedLower()),
                cancellationToken);
        }

        public async Task<bool> SubjectExists(
            string subjectName,
            CancellationToken cancellationToken)
        {
            return await _subjectRepository.AnyAsync(subject =>
                subject.Name == subjectName.ToNormalizedLower(),
                cancellationToken);
        }
    }
}
