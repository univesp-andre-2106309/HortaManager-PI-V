using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Domain.Models
{
    [Table("HortaReport")]
    public class HortaReport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public bool IsIrrigationActive { get; set; }
        [Required]
        public int SoilHumidity { get; set; }
        [Required]
        [ForeignKey("ArduinoDeviceId")]
        public ArduinoDevice ArduinoDevice { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
