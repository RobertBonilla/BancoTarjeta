using BCOAPI.Domain.Dtos;
using MediatR;

namespace BCOAPI.Domain.CQRS.Queries
{
    public record GetTotalTranQuery(paramReport1 param) : IRequest<totalTranDto>;
}
