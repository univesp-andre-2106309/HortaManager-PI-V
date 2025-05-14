using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Infrastructure.Integrations
{
    public interface ITelegramService
    {
        Task SendTelegramAlert(string status, int soilHumidity, string arduinoIdentifier);

    }
}
