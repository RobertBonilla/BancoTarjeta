using BCOAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReporteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IReportService _service;

        public ReporteController(ILogger<ClienteController> logger, IReportService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(template: "GetInfoGeneral/{noTarjeta}", Name = "GetInfoGeneral")]

        public IActionResult getInfoTarjeta(string noTarjeta)
        {
            var model = _service.getInfoTarjetas(noTarjeta);
            return Ok(model);
        }

        [HttpGet(template: "GetHistorial/{noTarjeta}", Name = "GetHistorial")]

        public IActionResult getHistorial(string noTarjeta)
        {
            var model = _service.getHistorialTarjetas(noTarjeta);
            return Ok(model);
        }
    }
}
