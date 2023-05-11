using Data.Constants;
using Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class File : BaseModel
    {
        public string FilePath { get; set; } = null!;
        public DateTimeOffset AddedAt { get; set; }
        public FileType FileType { get; set; }
        public User? User { get; set; }
        public Appointment? Appointment { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureFile(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<File>();

            entity
                .Property(x => x.FilePath)
                .IsRequired();

            entity
                .Property(x => x.AddedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.FileType)
                .IsRequired();

            return modelBuilder;
        }
    }
}
