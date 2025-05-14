
using HortaManager.Domain.Models;

namespace HortaManager.Application.Services
{
    public interface IArduinoDeviceService
    {
        Task<ArduinoDevice> getArduinoDevice(string code);
        Task<ArduinoDevice> InsertDevice(string code);
    }
}