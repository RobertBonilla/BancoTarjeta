using AutoMapper;
using BCOAPI.Infraestructure.Interfaces;

namespace BCOAPI.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAbonoRepository abonoRepository { get; }
        public ICargoRepository cargoRepository { get; }

        public IMapper mapper { get; }
        Task<int> save();
    }
}
