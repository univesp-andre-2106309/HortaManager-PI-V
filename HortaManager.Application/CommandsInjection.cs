using HortaManager.Application.DTO.Models;
using HortaManager.Application.Queries.Handlers;
using HortaManager.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using HortaManager.Application.Commands.Handlers;
using HortaManager.Domain.Models;
using HortaManager.Application.Commands;

namespace HortaManager.Application
{
    public static class CommandsInjection
    {
        public static IServiceCollection AddCommandsInjection(this IServiceCollection services)
        {

            services.AddTransient<ICommandMediator, CommandMediator>();
            services.AddTransient<ICommandHandler<HortaReportDTO, AddHortaReportCommand>, AddHortaReportHandler>();


            return services;
        }
    }
}
