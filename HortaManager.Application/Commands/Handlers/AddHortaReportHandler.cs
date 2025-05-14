using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using HortaManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HortaManager.Application.Commands.Handlers
{
    public class AddHortaReportHandler : ICommandHandler<HortaReportDTO, AddHortaReportCommand>
    {
        private readonly IRepository<HortaReport> repository;

        public AddHortaReportHandler(IRepository<HortaReport> repository)
        {
            this.repository = repository;
        }
        public async Task<HortaReportDTO> Handle(AddHortaReportCommand command)
        {


            HortaReport report = new HortaReport
            {
                ArduinoDevice = command.ArduinoDevice,
                Status = command.Status,
                Date = DateTime.Now,
                IsIrrigationActive = command.IsIrrigationActive,
                SoilHumidity = command.SoilHumidity
            };

            await this.repository.AddAsync(report);


            return new HortaReportDTO
            {
                ArduinoScanHardwareId = report.ArduinoDevice.Id,
                Date = DateTime.Now,
                IsIrrigationActive = report.IsIrrigationActive,
                SoilHumidity = report.SoilHumidity,
                Status = report.Status,
            };
        }
    }
}
