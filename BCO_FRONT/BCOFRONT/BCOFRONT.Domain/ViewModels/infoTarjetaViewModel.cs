
using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Domain.ViewModels
{
    public class infoTarjetaViewModel
    {
        public infoTarjetaViewModel(infoTarjetaResponse response)
        {
            infoTarjeta = response.infoTarjeta;
            listTransaction = response.listTransaction;
            mesActual = response.mesActual;
            mesAnterior = response.mesAnterior;
        }
        public infoTarjetaDto infoTarjeta { get; set; }

        public IEnumerable<tranTarjetaDto> listTransaction { get; set; }

        public totalTranDto mesActual { get; set; }

        public totalTranDto mesAnterior { get; set; }
    }
}
