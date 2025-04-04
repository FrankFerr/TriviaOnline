
using Main.Services.Implementations;
using Main.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Shared.BaseHttpManager;
using Shared.RequestConfigManager;
using Shared.RequestManager;

namespace Main
{
    public class Program
    {
        private static string endpointsPath = string.Empty;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            endpointsPath = $"{Directory.GetCurrentDirectory()}{builder.Configuration["EndpointsFolder"]}/{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";

            AddServices(builder.Services);

            // LOGGER
            builder.Logging.ClearProviders();

            Logger logger = new LoggerConfiguration().WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../logs/log.txt"),
                rollingInterval: RollingInterval.Hour,
                retainedFileCountLimit: 30
            ).CreateLogger();

            builder.Logging.AddSerilog(logger);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IRequestConfigManager, RequestConfigManager>((c) => new RequestConfigManager().Initialize<RequestConfigManager>(endpointsPath));

            services.AddScoped<IUserRegistration, UserRegistration>();
            services.AddScoped<IBaseHttpManager, BaseHttpManager>();
            services.AddScoped<IRequestManager, RequestManager>();
        }
    }
}
