using AutoMapper;
using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Domain.Responses;
using BCOAPI.Core.Interfaces;
using BCOAPI.Domain.CQRS.Queries;
using MediatR;
using System.Net;

namespace BCOAPI.Core.Services
{
    public class ReportService : IReportService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ReportService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public historialTarjetaResponse getHistorialTarjetas(string noTarjeta)
        {
            historialTarjetaResponse response = new historialTarjetaResponse();
            try
            {

                DateTime Fecha_Inicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime Fecha_Final = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddMilliseconds(-1);

                paramReport1 parametros = new paramReport1 { noTarjeta = noTarjeta, fechaIni = Fecha_Inicio, fechaFin = Fecha_Final };

                response.listTransaction = getTransactions(parametros);

                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.OK, Message = "OK" };

            }
            catch (Exception ex)
            {
                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = "Error en la consulta" };
            }
            return response;
        }

        public infoTarjetaResponse getInfoTarjetas(string noTarjeta)
        {
            infoTarjetaResponse response = new infoTarjetaResponse();
            try
            {
                var query = new GetInfoTarjetasQuery(noTarjeta);
                var infoTdc = _mediator.Send(query).Result;
                response.infoTarjeta = _mapper.Map<infoTarjetaDto>(infoTdc);

                DateTime Fecha_Inicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime Fecha_Final = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddMilliseconds(-1);

                paramReport1 parametros = new paramReport1{ noTarjeta = noTarjeta, fechaIni = Fecha_Inicio, fechaFin = Fecha_Final};

                response.listTransaction = getTransactions(parametros);
                response.mesActual = getTotalTransactions(parametros);

                Fecha_Inicio = Fecha_Inicio.AddMonths(-1);
                Fecha_Final = Fecha_Final.AddMonths(-1);
                parametros = new paramReport1 { noTarjeta = noTarjeta, fechaIni = Fecha_Inicio, fechaFin = Fecha_Final };
                response.mesAnterior = getTotalTransactions(parametros);

                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.OK, Message = "OK" };

            }
            catch (Exception ex)
            {
                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = "Error en la consulta" };
            }
            return response;
        }

        public totalTranDto getTotalTransactions(paramReport1 param)
        {
            try
            {
                var paramConvert = _mapper.Map<BCOAPI.Domain.Dtos.paramReport1>(param);
                var query = new GetTotalTranQuery(paramConvert);
                var result = _mediator.Send(query).Result;
                totalTranDto data = _mapper.Map<totalTranDto>(result);
                return data;
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public IEnumerable<tranTarjetaDto> getTransactions(paramReport1 param)
        {
            try
            {
                var paramConvert = _mapper.Map<BCOAPI.Domain.Dtos.paramReport1>(param);
                var query = new GetTranTarjetaQuery(paramConvert);
                var result = _mediator.Send(query).Result;
                List< tranTarjetaDto> data = _mapper.Map<List<tranTarjetaDto>>(result);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
