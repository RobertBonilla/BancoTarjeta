using BCOFRONT.Core.Rest.Interfaces;
using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;
using BCOFRONT.Domain.ViewModels;
using BCOFRONT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BCOFRONT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteApiRest _clienteApiRest;
        private readonly IReporteApiRest _reporteApiRest;
        private readonly ITransactionApiRest _transactionApiRest;

        public HomeController(ILogger<HomeController> logger, IClienteApiRest clienteApiRest, IReporteApiRest reporteApiRest, ITransactionApiRest transactionApiRest)
        {
            _logger = logger;
            _clienteApiRest = clienteApiRest;
            _reporteApiRest = reporteApiRest;
            _transactionApiRest = transactionApiRest;
        }

        public IActionResult Index()
        {
            ClienteResponse data = _clienteApiRest.GetCliente("2CD3266D-6DFF-45AD-A9E9-B93BCFEA552C");
            return View(new ClienteViewModel(data));
        }

        public IActionResult Pago(saveViewModel model)
        {
            return View(model);
        }

        public IActionResult Compra(saveViewModel model)
        {
            return View(model);
        }

        public IActionResult Estado(saveViewModel model)
        {
            infoTarjetaResponse response = _reporteApiRest.GetInfoGeneral(model.tarjeta);
            return View(new infoTarjetaViewModel(response));
        }

        public IActionResult Historial(saveViewModel model)
        {
            historialTarjetaResponse response = _reporteApiRest.GetHistorial(model.tarjeta);
            return View(new historialTarjetaViewModel(response));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //string tarjeta, DateTime fecha, decimal monto
        [HttpPost]
        public string setPago(abonoDto model)
        {
            var respuest = _transactionApiRest.pagoTarjeta(model);
            if (respuest.IsSuccess)
            {
                return "OK";
            }
            else
            {
                return "FAIL";
            }           
        }

        public string setCompra(cargoDto model)
        {
            string Message = "";
            var respuest = _transactionApiRest.compraTarjeta(model);
            if (respuest.IsSuccess)
            {
                return "OK";
            }
            else
            {
                return "FAIL";
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}