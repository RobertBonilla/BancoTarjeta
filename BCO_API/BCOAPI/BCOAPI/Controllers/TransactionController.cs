using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ITransactionService _service;

        public TransactionController(ILogger<ClienteController> logger, ITransactionService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("Compra")]

        public IActionResult compraTarjeta(cargoDto cargo)
        {
            var model = _service.compraTarjeta(cargo);
            return Ok(model);
        }

        [HttpPost("Pago")]

        public IActionResult pagoTarjeta(abonoDto abono)
        {
            var model = _service.pagoTarjeta(abono);
            return Ok(model);
        }
    }
}
