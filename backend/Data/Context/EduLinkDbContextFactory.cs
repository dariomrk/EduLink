using Laraue.EfCoreTriggers.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class EduLinkDbContextFactory : IDesignTimeDbContextFactory<EduLinkDbContext>
    {
        public EduLinkDbContext CreateDbContext(string[] args)
        {
            var connectionString = ConfigurationHelper
                .GetConfiguration()
                .GetConnectionString("Database")
                ?? throw new ArgumentNullException("Database connection string is not specified.");

            var options = new DbContextOptionsBuilder<EduLinkDbContext>()
                .UseNpgsql(connectionString)
                .UsePostgreSqlTriggers()
                .Options;

            return new EduLinkDbContext(options);
        }
    }
}
