using BCOAPI.Domain.Dtos;
using MediatR;

namespace BCOAPI.Domain.CQRS.Queries
{
    public record GetClienteTarjetasQuery(string idCliente) : IRequest<IEnumerable<tarjetasClienteDto>>;
}
