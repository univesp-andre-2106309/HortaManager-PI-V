using HortaManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Commands
{
    public record AddHortaReportCommand
    {
        public string Status { get; init; }
        public DateTime Date { get; init; }
        public bool IsIrrigationActive { get; init; }
        public int SoilHumidity { get; init; }
        public ArduinoDevice ArduinoDevice { get; init; }
    }
}
