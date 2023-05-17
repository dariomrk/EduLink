using Api.Middleware;
using Application.Constants;
using Application.Dtos.Appointment;
using Application.Dtos.Indentity;
using Application.Dtos.Message;
using Application.Dtos.TutoringPost;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Data.Context;
using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
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

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            host.UseSerilog();
            builder.Services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog());

            return builder;
        }
    }

    public static class ServiceInitializer
    {
        public static WebApplicationBuilder RegisterApplicationServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            #region Controller registration
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // endpoints recieve and send enum string representations
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            #endregion

            #region Validator registration
            services.AddScoped<IValidator<CreateAppointmentRequestDto>, CreateAppointmentRequestValidator>();
            services.AddScoped<IValidator<CreateMessageRequestDto>, CreateMessageRequestValidator>();
            services.AddScoped<IValidator<RegisterRequestDto>, RegisterRequestValidator>();
            services.AddScoped<IValidator<TutoringPostRequestDto>, TutoringPostRequestValidator>();
            #endregion

            #region Service registration
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITimeFrameService, TimeFrameService>();
            services.AddScoped<ITutoringPostService, TutoringPostService>();
            services.AddScoped<IUserService, UserService>();
            // services go here
            #endregion

            #region Repository registration
            services.AddScoped<IRepository<Appointment, long>, BaseRepository<Appointment, long>>();
            services.AddScoped<IRepository<City, long>, BaseRepository<City, long>>();
            services.AddScoped<IRepository<Country, long>, BaseRepository<Country, long>>();
            services.AddScoped<IRepository<Field, long>, BaseRepository<Field, long>>();
            services.AddScoped<IRepository<Data.Models.File, long>, BaseRepository<Data.Models.File, long>>();
            services.AddScoped<IRepository<Appointment, long>, BaseRepository<Appointment, long>>();
            // TODO: Implement login timestamp
            services.AddScoped<IRepository<LoginTimestamp, long>, BaseRepository<LoginTimestamp, long>>();
            services.AddScoped<IRepository<Message, long>, BaseRepository<Message, long>>();
            services.AddScoped<IRepository<Region, long>, BaseRepository<Region, long>>();
            services.AddScoped<IRepository<StudentsReview, long>, BaseRepository<StudentsReview, long>>();
            services.AddScoped<IRepository<Subject, long>, BaseRepository<Subject, long>>();
            services.AddScoped<IRepository<TimeFrame, long>, BaseRepository<TimeFrame, long>>();
            services.AddScoped<IRepository<TutoringPost, long>, BaseRepository<TutoringPost, long>>();
            services.AddScoped<IRepository<TutorsReview, long>, BaseRepository<TutorsReview, long>>();
            services.AddScoped<IRepository<User, long>, BaseRepository<User, long>>();
            #endregion

            var connectionString = ConfigurationHelper
                .GetConfiguration()
                .GetConnectionString("Database");

            services.AddDbContext<EduLinkDbContext>(options =>
                options.UseNpgsql(connectionString, options =>
                    options.UseNetTopologySuite()));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration.GetValue<string>("Identity:Issuer")!,
                        ValidAudience = builder.Configuration.GetValue<string>("Identity:Audience")!,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Identity:TokenSecret")!)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Roles.User, policy =>
                    policy.RequireRole(Roles.User));
            });

            return builder;
        }
    }

    public static class MiddlewareInitializer
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseMiddleware<CustomExceptionHandler>();
            app.UseMiddleware<ValidationExceptionHandler>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(config =>
            {
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
                config.AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
