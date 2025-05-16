using HortaManager.Application.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Services
{
    public interface IHortaService
    {
        Task<List<HortaReportDTO>> GetReportsByDateRange(DateTime initialRange, DateTime endRange, string arduinoCode);
        Task<bool> PostNewAlert(string arduinoName, string status, int humidityLevel);
    }
}
