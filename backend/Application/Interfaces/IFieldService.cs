namespace Application.Interfaces
{
    public interface IFieldService
    {
        internal Task<bool> FieldInSubject(string fieldName, string subjectName, CancellationToken cancellationToken = default);
        internal Task<bool> SubjectExists(string subjectName, CancellationToken cancellationToken = default);
    }
}
