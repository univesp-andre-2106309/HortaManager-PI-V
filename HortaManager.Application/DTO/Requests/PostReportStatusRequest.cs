using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.DTO.Requests
{
    public record PostReportStatusRequest
    {
       public required string arduinoName { get; init; }
       public required string status { get; init; }
       public required int humidityLevel { get; init; }
    }
}
