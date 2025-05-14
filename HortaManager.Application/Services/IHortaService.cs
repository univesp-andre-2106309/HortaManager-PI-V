using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.Services
{
    public interface IHortaService
    {

        Task<bool> PostNewAlert(string arduinoName, string status, int humidityLevel);
    }
}
