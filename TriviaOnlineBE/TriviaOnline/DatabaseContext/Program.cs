using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using TriviaRepository.Services;
using Microsoft.EntityFrameworkCore;

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
            
            builder.Services.AddDbContext<TriviaContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString(builder.Environment.EnvironmentName));
            });

            AddRepository(builder.Services);

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

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IStandardRepository<Utenti>, StandardRepository<Utenti>>();
            services.AddScoped<IStandardRepository<Partite>, StandardRepository<Partite>>();
            services.AddScoped<IStandardRepository<PartiteDomande>, StandardRepository<PartiteDomande>>();
            services.AddScoped<IStandardRepository<PartiteUtenti>, StandardRepository<PartiteUtenti>>();
            services.AddScoped<IStandardRepository<PartiteUtentiRisposte>, StandardRepository<PartiteUtentiRisposte>>();
            services.AddScoped<IStandardRepository<Categorie>, StandardRepository<Categorie>>();
            services.AddScoped<IStandardRepository<Domande>, StandardRepository<Domande>>();
            services.AddScoped<IStandardRepository<DomandeRisposte>, StandardRepository<DomandeRisposte>>();
        }
    }
}
