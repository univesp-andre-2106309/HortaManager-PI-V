using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries
{
    public record GetHortaReportsByRangeQuery
    {
        public DateTime InitialRange { get; init; }
        public DateTime LimitRange { get; init; }

        public string arduinoCode { get; init; }
    }
}
