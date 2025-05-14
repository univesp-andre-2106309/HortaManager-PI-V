using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Commands.Handlers
{
    public class CommandMediator: ICommandMediator
    {
        private readonly ICommandHandler<HortaReportDTO, AddHortaReportCommand> addHortaReportHandler;

        public CommandMediator(ICommandHandler<HortaReportDTO, AddHortaReportCommand> AddHortaReportHandler) {
            addHortaReportHandler = AddHortaReportHandler;
        }


        public ICommandHandler<HortaReportDTO, AddHortaReportCommand> AddHortaReportCaller() => this.addHortaReportHandler;

    }
}
