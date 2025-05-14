
namespace HortaManager.Application.DTO.Models
{
    public class HortaReportDTO
    {
        public string Status { get; set; }
        public bool IsIrrigationActive { get; set; }
        public int SoilHumidity { get; set; }
        public int ArduinoScanHardwareId { get; set; }
        public DateTime Date { get; set; }
    }
}
