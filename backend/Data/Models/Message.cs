﻿using Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class Message : BaseModel
    {
        public string Content { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureMessage(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Message>();

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
