using HortaManager.Application.DTO.Models;
using HortaManager.Application.DTO.Requests;
using HortaManager.Application.DTO.Responses;
using HortaManager.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HortaManager.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HortaController : ControllerBase
    {
        private readonly IHortaService hortaService;

        public HortaController(IHortaService hortaService)
        {
            this.hortaService = hortaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostReportStatus([FromBody] PostReportStatusRequest requestBody)
        {
            try
            {
                bool alertStatus = await this.hortaService.PostNewAlert(requestBody.arduinoName, requestBody.status, requestBody.humidityLevel);

                if (alertStatus)
                {
                    return Ok(new PostReportStatusResponse { status = "OK" });
                }
                return BadRequest(new PostReportStatusResponse { status = "Codigo do dispositivo não registrado ou desativado no momento" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("query")]
        public async Task<IActionResult> GetHortaReports([FromQuery]DateTime startRange, DateTime endRange, string arduinoName = null)
        {
            List<HortaReportDTO> response = await this.hortaService.GetReportsByDateRange(startRange, endRange, arduinoName);
            return Ok(new GetHortaReportsResponse { reports = response});

        }

    }
}
