using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class StudentsReview : BaseModel
    {
        public int Stars { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset AddedAt { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureStudentsReview(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<StudentsReview>();

            entity
                .ToTable(nameof(StudentsReview), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(StudentsReview)}\"_\"{nameof(StudentsReview.Stars)}\"",
                        $"\"{nameof(StudentsReview.Stars)}\" >= 1 AND \"{nameof(StudentsReview.Stars)}\" <= 5");
                });

            entity
                .Property(x => x.Stars)
                .IsRequired();

            entity
                .Property(x => x.Comment)
                .HasMaxLength(200)
                .HasDefaultValue(string.Empty);

            entity
                .Property(x => x.AddedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            return modelBuilder;
        }
    }
}
