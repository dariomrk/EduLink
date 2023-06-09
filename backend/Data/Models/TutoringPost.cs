﻿using Data.Constants;
using Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    public class TutoringPost : BaseModel
    {
        public long TutorId { get; set; }
        public User Tutor { get; set; } = null!;
        public decimal PricePerHour { get; set; }
        public Currency Currency { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool IsPaidAd { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TimeFrame> AvailableTimeFrames { get; set; } = new List<TimeFrame>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<TutoringPostField> Fields { get; set; } = new List<TutoringPostField>();
    }

    public static partial class ModelConfigurations
    {
        public static ModelBuilder ConfigureTutoringPost(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<TutoringPost>();

            entity
                .ToTable(nameof(TutoringPost), table =>
                {
                    table.HasCheckConstraint(
                        $"CK_\"{nameof(TutoringPost)}\"_\"{nameof(TutoringPost.PricePerHour)}\"",
                        $"\"{nameof(TutoringPost.PricePerHour)}\" > 0");
                });

            entity
                .Property(x => x.TutorId)
                .IsRequired();

            entity
                .Property(x => x.PricePerHour)
                .IsRequired();

            entity
                .Property(x => x.Currency)
                .IsRequired()
                .HasDefaultValue(Currency.EUR);

            entity
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql(RawSql.Timestamp);

            entity
                .Property(x => x.IsPaidAd)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .Property(x => x.IsActive)
                .IsRequired();

            return modelBuilder;
        }
    }
}
