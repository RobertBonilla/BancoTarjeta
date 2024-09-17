
using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Core.Rest.Interfaces
{
    public interface ITransactionApiRest
    {
        TransactionResponse compraTarjeta(cargoDto model);

        TransactionResponse pagoTarjeta(abonoDto model);
    }
}
