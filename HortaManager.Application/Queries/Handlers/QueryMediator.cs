using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries.Handlers
{
    public class QueryMediator : IQueryMediator
    {
        private readonly IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery> getHortaReportsByRangeHandler;
        private readonly IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery> getArduinoHardwareByIdHandler;

        public QueryMediator(
            IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery> getHortaReportsByRangeHandler,
            IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery> getArduinoHardwareByIdHandler
            )
        {
            this.getHortaReportsByRangeHandler = getHortaReportsByRangeHandler;
            this.getArduinoHardwareByIdHandler = getArduinoHardwareByIdHandler;
        }

        public IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery> getHortaReportsByRangeCaller() => getHortaReportsByRangeHandler;
        public IQueryHandler<ArduinoDevice, GetArduinoHardwareByIdQuery> GetArduinoHardwareByIdCaller() => getArduinoHardwareByIdHandler;

    }
}
