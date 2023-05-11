using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Message : BaseModel
    {
        public string Content { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public long SenderId { get; set; }
        public User Sender { get; set; } = null!;
        public long RecipientId { get; set; }
        public User Recipient { get; set; } = null!;
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureMessage(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Message>();

            entity
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentMessages)
                .HasForeignKey(x => x.Id);

            entity
                .HasOne(x => x.Recipient)
                .WithMany(x => x.RecievedMessages)
                .HasForeignKey(x => x.Id);

            entity
                .Property(x => x.Content)
                .IsRequired();

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.SenderId)
                .IsRequired();

            entity
                .Property(x => x.RecipientId)
                .IsRequired();

            return modelBuilder;
        }
    }
}
