using BCOAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BCOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _service;
        private readonly IMediator _mediator;

        public ClienteController(ILogger<ClienteController> logger, IClienteService service, IMediator mediator)
        {
            _logger = logger;
            _service = service;
            _mediator = mediator;
        }

        [HttpGet(template: "GetCliente/{idCliente}", Name = "GetCliente")]

        public IActionResult getCliente(string idCliente)
        {
            var model = _service.getDatosCliente(idCliente);
            return Ok(model);
        }


    }
}
