using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Domain.Responses;

namespace BCOAPI.Core.Interfaces
{
    public interface ITransactionService
    {
        TransactionResponse compraTarjeta(cargoDto model);

        TransactionResponse pagoTarjeta(abonoDto model);
    }
}
