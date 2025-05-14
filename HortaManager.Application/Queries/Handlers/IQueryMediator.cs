using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries.Handlers
{
    public interface IQueryMediator
    {
        IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery> GetArduinoHardwareByIdCaller();
        public IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery> getHortaReportsByRangeCaller();
    }
}
