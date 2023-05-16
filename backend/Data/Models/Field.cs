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
                    Name = "Trigonometrija",
                },
                new Field
                {
                    Id = 2,
                    SubjectId = 1,
                    Name = "Algebra",
                },
                new Field
                {
                    Id = 3,
                    SubjectId = 1,
                    Name = "Geometrija",
                },
                new Field
                {
                    Id = 4,
                    SubjectId = 2,
                    Name = "Mehanika",
                },
                new Field
                {
                    Id = 5,
                    SubjectId = 2,
                    Name = "Elektromagnetizam",
                },
                new Field
                {
                    Id = 6,
                    SubjectId = 2,
                    Name = "Termodinamika",
                },
                new Field
                {
                    Id = 7,
                    SubjectId = 3,
                    Name = "Organska kemija",
                },
                new Field
                {
                    Id = 8,
                    SubjectId = 3,
                    Name = "Anorganska kemija",
                },
                new Field
                {
                    Id = 9,
                    SubjectId = 3,
                    Name = "Fizikalna kemija",
                },
                new Field
                {
                    Id = 10,
                    SubjectId = 4,
                    Name = "Botanika",
                },
                new Field
                {
                    Id = 11,
                    SubjectId = 4,
                    Name = "Zoologija",
                },
                new Field
                {
                    Id = 12,
                    SubjectId = 4,
                    Name = "Genetika",
                }
            });

            return modelBuilder;
        }
    }
}
