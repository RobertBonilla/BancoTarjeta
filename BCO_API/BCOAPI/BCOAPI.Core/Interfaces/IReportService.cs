using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Domain.Responses;

namespace BCOAPI.Core.Interfaces
{
    public interface IReportService
    {
        infoTarjetaResponse getInfoTarjetas(string noTarjeta);

        historialTarjetaResponse getHistorialTarjetas(string noTarjeta);
        IEnumerable<tranTarjetaDto> getTransactions(paramReport1 param);

        totalTranDto getTotalTransactions(paramReport1 param);

    }
}
