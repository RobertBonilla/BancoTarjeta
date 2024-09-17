using BCOAPI.Domain.Dtos;
using MediatR;

namespace BCOAPI.Domain.CQRS.Queries
{
    public record GetInfoTarjetasQuery(string tarjeta) : IRequest<infoTarjetaDto>;
}
