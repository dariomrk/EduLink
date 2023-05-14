using Riok.Mapperly.Abstractions;

namespace Application.Dtos.Review
{
    [Mapper]
    internal static partial class Mappings
    {
        internal static partial Data.Models.StudentsReview ToStudentsReview(this CreateReviewAsStudentRequestDto dto);
        internal static partial Data.Models.TutorsReview ToTutorsReview(this CreateReviewAsTutorRequestDto dto);
    }
}
