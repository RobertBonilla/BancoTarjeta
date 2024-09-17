using AutoMapper;
using BCOAPI.Core.Domain.Responses;
using BCOAPI.Domain.CQRS.Queries;
using BCOAPI.Core.Interfaces;
using MediatR;
using BCOAPI.Core.Domain.Dtos;
using System.Net;

namespace BCOAPI.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClienteService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        ClienteResponse IClienteService.getDatosCliente(string idCliente)
        {

            ClienteResponse response = new ClienteResponse();
            try
            {                
                var query = new GetClienteInfoQuery(idCliente);
                var cliente = _mediator.Send(query).Result;
                response.clienteDto = _mapper.Map<ClienteDto>(cliente);

                var query2 = new GetClienteTarjetasQuery(idCliente);
                var listTarjetas = _mediator.Send(query2).Result;
                response.listTarjetasClienteDto = _mapper.Map<List<tarjetasClienteDto>>(listTarjetas);

                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.OK, Message = "OK" };
                
            }
            catch (Exception ex)
            {
                response.Status = new ResponseStatus { HttpCode = HttpStatusCode.BadRequest, Message = "Error en la consulta" };
            }
            return response;
           
        }
    }
}
