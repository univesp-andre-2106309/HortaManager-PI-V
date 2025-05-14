using HortaManager.Application.DTO.Models;
using HortaManager.Domain.Models;
using HortaManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries.Handlers
{
    public class GetHortaReportsByRangeHandler : IQueryHandler<List<HortaReportDTO>, GetHortaReportsByRangeQuery>
    {
        private readonly IRepository<HortaReport> hortaRepository;

        public GetHortaReportsByRangeHandler(IRepository<HortaReport> hortaRepository)
        {
            this.hortaRepository = hortaRepository;
        }

        public async Task<List<HortaReportDTO>> Handle(GetHortaReportsByRangeQuery query)
        {
            var response = this.hortaRepository.GetQueryable()
                     .Where(i => i.Date >= query.InitialRange
                              && i.Date <= query.LimitRange)
                     .OrderByDescending(i => i.Date)
                     .Select(i => new HortaReportDTO
                     {
                         ArduinoScanHardwareId = i.ArduinoDevice.Id,
                         Date = i.Date,
                         IsIrrigationActive = i.IsIrrigationActive,
                         SoilHumidity = i.SoilHumidity,
                         Status = i.Status,
                     })
                     .ToList();

            return response;
        }


    }
}
