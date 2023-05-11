using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TutorsReview : BaseModel
    {
        public int PreviousKnowledge { get; set; }
        public int LearningRate { get; set; }
        public int Engagement { get; set; }
        public int Behaviour { get; set; }
        public DateTimeOffset AddedAt { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureTutorsReview(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TutorsReview>();

            entity
                .ToTable(nameof(TutorsReview), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TutorsReview)}\"_\"{nameof(TutorsReview.PreviousKnowledge)}\"",
                        $"\"{nameof(TutorsReview.PreviousKnowledge)}\" >= 1 AND \"{nameof(TutorsReview.PreviousKnowledge)}\" <= 5");

                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TutorsReview)}\"_\"{nameof(TutorsReview.LearningRate)}\"",
                        $"\"{nameof(TutorsReview.LearningRate)}\" >= 1 AND \"{nameof(TutorsReview.LearningRate)}\" <= 5");

                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TutorsReview)}\"_\"{nameof(TutorsReview.Engagement)}\"",
                        $"\"{nameof(TutorsReview.Engagement)}\" >= 1 AND \"{nameof(TutorsReview.Engagement)}\" <= 5");

                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TutorsReview)}\"_\"{nameof(TutorsReview.Behaviour)}\"",
                        $"\"{nameof(TutorsReview.Behaviour)}\" >= 1 AND \"{nameof(TutorsReview.Behaviour)}\" <= 5");
                });

            entity
                .Property(x => x.PreviousKnowledge)
                .IsRequired();

            entity
                .Property(x => x.LearningRate)
                .IsRequired();

            entity
                .Property(x => x.Engagement)
                .IsRequired();

            entity
                .Property(x => x.Behaviour)
                .IsRequired();

            entity
                .Property(x => x.AddedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            return modelBuilder;
        }
    }
}
