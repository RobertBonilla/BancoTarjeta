using BCOAPI.Domain.Dtos;

namespace BCOAPI.Infraestructure.Interfaces
{
    public interface IAbonoRepository
    {
        bool pagoTarjeta(abonoDto model);
    }
}
