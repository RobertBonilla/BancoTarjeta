using BCOAPI.Domain.Dtos;
using MediatR;

namespace BCOAPI.Domain.CQRS.Queries
{
    public record GetClienteInfoQuery(string idCliente) : IRequest<ClienteDto>;
}
