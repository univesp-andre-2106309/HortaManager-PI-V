using HortaManager.Application.Commands.Handlers;
using HortaManager.Application.DTO.Models;
using HortaManager.Application.Queries;
using HortaManager.Application.Queries.Handlers;
using HortaManager.Domain.Models;
using HortaManager.Infrastructure.Integrations;


namespace HortaManager.Application.Services
{
    public class HortaService : IHortaService
    {
        private ITelegramService telegramService;
        private readonly IArduinoDeviceService arduinoDeviceService;
        private readonly IQueryMediator mediator;
        private readonly ICommandMediator commandMediator;

        public HortaService(ITelegramService telegramService,
            IArduinoDeviceService arduinoDeviceService, IQueryMediator queryMediator, ICommandMediator commandMediator)
        {
            this.telegramService = telegramService;
            this.arduinoDeviceService = arduinoDeviceService;
            this.mediator = queryMediator;
            this.commandMediator = commandMediator;
        }
        public async Task<bool> PostNewAlert(string arduinoName, string status, int humidityLevel)
        {

            ArduinoDevice device = await this.arduinoDeviceService.getArduinoDevice(arduinoName);
            if (device == null)
            {
                return false;
            }

            await this.telegramService.SendTelegramAlert(status, humidityLevel, arduinoName);
            await this.commandMediator.AddHortaReportCaller().Handle(new Commands.AddHortaReportCommand
            {
                ArduinoDevice = device,
                Status = status,
                Date = DateTime.Now,
                IsIrrigationActive = humidityLevel < 70,
                SoilHumidity = humidityLevel
            });

            return true;
        }

        public async Task<List<HortaReportDTO>> GetReportsByDateRange(DateTime InitialRange, DateTime EndRange)
        {
            List<HortaReportDTO> reports = await this.mediator.getHortaReportsByRangeCaller().Handle(new GetHortaReportsByRangeQuery
            {
                InitialRange = InitialRange,
                LimitRange = EndRange
            });
            return reports;
        }
    }
}
