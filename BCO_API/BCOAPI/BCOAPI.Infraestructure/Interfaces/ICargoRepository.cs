using BCOAPI.Domain.Dtos;

namespace BCOAPI.Infraestructure.Interfaces
{
    public interface ICargoRepository
    {
        bool compraTarjeta(cargoDto model);
    }
}
