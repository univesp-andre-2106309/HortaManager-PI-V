using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Queries
{
    public record GetArduinoHardwareByIdQuery
    {
        public string Code { get; init; }
    }
}
