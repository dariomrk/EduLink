using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Field : BaseModel
    {
        public string Name { get; set; } = null!;
        public long SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public ICollection<TutoringPostField> TutoringPostsFields { get; set; } = new List<TutoringPostField>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureField(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Field>();

            entity
                .Property(x => x.Name)
                .IsRequired();

            entity
                .Property(x => x.SubjectId)
                .IsRequired();

            entity.HasData(new List<Field>
            {
                new Field
                {
                    Id = 1,
                    SubjectId = 1,
                    Name = "trigonometrija",
                },
                new Field
                {
                    Id = 2,
                    SubjectId = 1,
                    Name = "algebra",
                },
                new Field
                {
                    Id = 3,
                    SubjectId = 1,
                    Name = "geometrija",
                },
                new Field
                {
                    Id = 4,
                    SubjectId = 2,
                    Name = "mehanika",
                },
                new Field
                {
                    Id = 5,
                    SubjectId = 2,
                    Name = "elektromagnetizam",
                },
                new Field
                {
                    Id = 6,
                    SubjectId = 2,
                    Name = "termodinamika",
                },
                new Field
                {
                    Id = 7,
                    SubjectId = 3,
                    Name = "organska kemija",
                },
                new Field
                {
                    Id = 8,
                    SubjectId = 3,
                    Name = "anorganska kemija",
                },
                new Field
                {
                    Id = 9,
                    SubjectId = 3,
                    Name = "fizikalna kemija",
                },
                new Field
                {
                    Id = 10,
                    SubjectId = 4,
                    Name = "botanika",
                },
                new Field
                {
                    Id = 11,
                    SubjectId = 4,
                    Name = "zoologija",
                },
                new Field
                {
                    Id = 12,
                    SubjectId = 4,
                    Name = "genetika",
                }
            });

            return modelBuilder;
        }
    }
}
