using AutoMapper;
using BCOAPI.Core.Interfaces;
using BCOAPI.Infraestructure;
using BCOAPI.Infraestructure.Interfaces;

namespace BCOAPI.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
        public IAbonoRepository abonoRepository { get; }
        public ICargoRepository cargoRepository { get; }
        public IMapper mapper { get; }
        public UnitOfWork(MyDbContext dbContext, IAbonoRepository _abonoRepository, ICargoRepository _cargoRepository, IMapper _mapper)
        {
            _dbContext = dbContext;
            abonoRepository = _abonoRepository;
            cargoRepository = _cargoRepository;
            mapper = _mapper;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> save() => await _dbContext.SaveChangesAsync();
    }
}
