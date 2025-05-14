using HortaManager.Application.DTO.Models;
using HortaManager.Application.Queries.Handlers;
using HortaManager.Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HortaManager.Domain.Models;


namespace HortaManager.Application
{
    public static class QueriesInjection
    {
        public static IServiceCollection AddQueriesInjection(this IServiceCollection services)
        {
            services.AddTransient<IQueryMediator, QueryMediator>();
            services.AddTransient<IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery>, GetHortaReportsByRangeHandler>();
            services.AddTransient<IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery>, GetArduinoHardwareByIdHandler>();

            return services;
        }
    }
}
