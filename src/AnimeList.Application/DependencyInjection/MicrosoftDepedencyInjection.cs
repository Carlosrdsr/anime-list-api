using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using AnimeList.Domain.Interface;
using AnimeList.Infrastructure.Data;
using AnimeList.Infrastructure.Repositories;
using AnimeList.Application.Features.AnimesList.CreateList;

namespace AnimeList.Application.DependencyInjection
{
    public static class MicrosoftDepedencyInjection
    {
        public static IServiceCollection AnimeListApplication(
            this IServiceCollection services, string applicatioName)
        {
            AddApplicationServices(services);            

            AddInfrastructure(services, applicatioName);

            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assemblyApplication = AppDomain.CurrentDomain.Load("AnimeList.Application");
            var assemblyInfrastructure = AppDomain.CurrentDomain.Load("AnimeList.Infrastructure");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateListCommandHandler>());
            services.AddAutoMapper(assemblyApplication, assemblyInfrastructure);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        }

        public static void AddInfrastructure(this IServiceCollection services, string applicationName)
        {
            var connectionString = "Server=DESKTOP-IL6MI7E;Database=desafiodb;Integrated Security=SSPI;TrustServerCertificate=True";            
            AddInfrastructureDataModule(services, opt => opt.UseSqlServer(connectionString));
        }        

        public static void AddInfrastructureDataModule(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<AnimeDbContext>(optionsAction);
            services.AddScoped<IAnimeRepository, AnimeRepository>();
        }
    }
}
