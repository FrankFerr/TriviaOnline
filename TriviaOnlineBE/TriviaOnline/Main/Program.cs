
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Logging.ClearProviders();

            Logger logger = new LoggerConfiguration().WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../logs/log.txt"),
                rollingInterval: RollingInterval.Hour,
                retainedFileCountLimit: 90
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
    }
}
