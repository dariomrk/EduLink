using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class EduLinkDbContext : DbContext
    {
        public EduLinkDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseModel>();

            modelBuilder
                .ConfigureAppointment()
                .ConfigureAvailableTimeFrame()
                .ConfigureCity()
                .ConfigureCountry()
                .ConfigureField()
                .ConfigureFile()
                .ConfigureLoginTimestamp()
                .ConfigureMessage()
                .ConfigurePasswordHashingAlgorithm()
                .ConfigureRegion()
                .ConfigureStudentsReview()
                .ConfigureSubject()
                .ConfigureTutoringPost()
                .ConfigureTutoringPostField()
                .ConfigureTutorsReview()
                .ConfigureUser();
        }
    }
}
