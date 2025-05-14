using HortaManager.Application.DTO.Models;
using HortaManager.Application.Queries;
using HortaManager.Application.Queries.Handlers;
using HortaManager.Application.Services;
using HortaManager.Infrastructure.EntityContext;
using HortaManager.Infrastructure.Integrations;
using HortaManager.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HortaManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfigurationManager configBuilder)
        {

            //Infrastructure
            services.AddDbContext<SqlDatabaseContext>(options =>
                options.UseSqlServer(configBuilder["sqlite:connectionString"])
            );

            services.AddScoped<ITelegramService, TelegramService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Application
            services.AddScoped<IHortaService, HortaService>();
            services.AddScoped<IArduinoDeviceService, ArduinoDeviceService>();

            services.AddCommandsInjection();
            services.AddQueriesInjection();




            return services;
        }
    }
}
