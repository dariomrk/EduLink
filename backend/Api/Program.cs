using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplication
                .CreateBuilder(args)
                .ConfigureHost()
                .RegisterApplicationServices()
                .Build()
                .ConfigureMiddleware()
                .Run();
        }
    }

    public static class HostInitializer
    {
        public static WebApplicationBuilder ConfigureHost(this WebApplicationBuilder builder)
        {
            var host = builder.Host;
            // TODO: Configure host properties

            return builder;
        }
    }

    public static class ServiceInitializer
    {
        public static WebApplicationBuilder RegisterApplicationServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            // TODO: Configure services

            #region Controller registration
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // endpoints recieve and send enum string representations
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            #endregion

            #region Service registration
            // services go here
            #endregion

            #region Repository registration
            // repositories go here
            #endregion

            var connectionString = ConfigurationHelper
                .GetConfiguration()
                .GetConnectionString("Database");

            services.AddDbContext<EduLinkDbContext>(options =>
                options.UseNpgsql(connectionString, options =>
                    options.UseNetTopologySuite()));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return builder;
        }
    }

    public static class MiddlewareInitializer
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
