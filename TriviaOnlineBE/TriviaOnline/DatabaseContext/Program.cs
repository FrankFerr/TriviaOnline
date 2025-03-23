using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using TriviaRepository.Middleware;
using TriviaRepository.Services.Implementations;
using Shared.ViewModel;

namespace TriviaRepository
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
            
            // DB Context
            builder.Services.AddDbContext<TriviaContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString(builder.Environment.EnvironmentName));
            });

            // Repositories
            AddRepository(builder.Services);

            // Logging
            builder.Logging.ClearProviders();

            Logger logger = new LoggerConfiguration().WriteTo.File(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../logs/log.txt"),
                rollingInterval: RollingInterval.Hour,
                retainedFileCountLimit: 90
            ).CreateLogger();

            builder.Logging.AddSerilog(logger);

            //Mapper
            builder.Services.AddAutoMapper(typeof(RepositoryMapper));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IStandardRepository<Utenti, UtentiVM>, UtentiRepository>();
            services.AddScoped<IStandardRepository<Partite, PartiteVM>, StandardRepository<Partite, PartiteVM>>();
            services.AddScoped<IStandardRepository<PartiteDomande, PartiteDomandeVM>, StandardRepository<PartiteDomande, PartiteDomandeVM>>();
            services.AddScoped<IStandardRepository<PartiteUtenti, PartiteUtentiVM>, StandardRepository<PartiteUtenti, PartiteUtentiVM>>();
            services.AddScoped<IStandardRepository<PartiteUtentiRisposte, PartiteUtentiRisposteVM>, StandardRepository<PartiteUtentiRisposte, PartiteUtentiRisposteVM>>();
            services.AddScoped<IStandardRepository<Categorie, CategorieVM>, StandardRepository<Categorie, CategorieVM>>();
            services.AddScoped<IStandardRepository<Domande, DomandeVM>, StandardRepository<Domande, DomandeVM>>();
            services.AddScoped<IStandardRepository<DomandeRisposte, DomandeRisposteVM>, StandardRepository<DomandeRisposte, DomandeRisposteVM>>();
            services.AddScoped<IStandardRepository<StoricoPartite, StoricoPartiteVM>, StandardRepository<StoricoPartite, StoricoPartiteVM>>();
            services.AddScoped<IStandardRepository<StoricoPartiteUtenti, StoricoPartiteUtentiVM>, StandardRepository<StoricoPartiteUtenti, StoricoPartiteUtentiVM>>();
            services.AddScoped<IStandardRepository<StoricoPartiteUtentiDom, StoricoPartiteUtentiDomVM>, StandardRepository<StoricoPartiteUtentiDom, StoricoPartiteUtentiDomVM>>();
        }
    }
}
