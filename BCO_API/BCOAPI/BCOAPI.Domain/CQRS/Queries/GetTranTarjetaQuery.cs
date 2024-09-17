

using BCOAPI.Domain.Dtos;
using MediatR;

namespace BCOAPI.Domain.CQRS.Queries
{
    public record GetTranTarjetaQuery(paramReport1 param) : IRequest<IEnumerable<tranTarjetaDto>>;
}
