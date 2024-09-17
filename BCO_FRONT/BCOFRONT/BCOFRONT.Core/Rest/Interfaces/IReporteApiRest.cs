
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Core.Rest.Interfaces
{
    public interface IReporteApiRest
    {
        infoTarjetaResponse GetInfoGeneral(string noTarjeta);

        historialTarjetaResponse GetHistorial(string noTarjeta);
    }
}
