namespace Application.Interfaces
{
    public interface IFieldService
    {
        internal Task<bool> SubjectContainsField(string subjectName, string fieldName, CancellationToken cancellationToken = default);
        internal Task<bool> SubjectExists(string subjectName, CancellationToken cancellationToken = default);
        internal Task<(int SubjectKey, ICollection<int> FieldKeys)> GetSubjectAndFieldKeys(
            string subjectName,
            ICollection<string> fieldName,
            CancellationToken cancellationToken = default);
    }
}
