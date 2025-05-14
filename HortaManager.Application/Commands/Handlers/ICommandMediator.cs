using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Commands.Handlers
{
    public interface ICommandMediator
    {
        ICommandHandler<HortaReportDTO, AddHortaReportCommand> AddHortaReportCaller();
    }
}
