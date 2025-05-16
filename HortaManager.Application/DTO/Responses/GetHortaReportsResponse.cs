using HortaManager.Application.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HortaManager.Application.DTO.Responses
{
    public class GetHortaReportsResponse
    {
        public List<HortaReportDTO> reports { get; set; }
    }
}
