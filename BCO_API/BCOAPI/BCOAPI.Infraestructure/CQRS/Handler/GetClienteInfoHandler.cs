using AutoMapper;
using BCOAPI.Domain.Dtos;
using BCOAPI.Domain.CQRS.Queries;
using MediatR;

namespace BCOAPI.Infraestructure.CQRS.Handler
{
    public class GetClienteInfoHandler : IRequestHandler<GetClienteInfoQuery, ClienteDto>
    {
        private readonly MyDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetClienteInfoHandler(MyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ClienteDto> Handle(GetClienteInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = _dbContext.Cliente.First(x => x.idCliente == new Guid(request.idCliente));
                var cli = _mapper.Map<ClienteDto>(cliente);
                return cli;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
