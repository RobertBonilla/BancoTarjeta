
using BCOFRONT.Domain.Dtos;

namespace BCOFRONT.Domain.Responses
{
    public class infoTarjetaResponse
    {
        public ResponseStatus Status { get; set; }

        public infoTarjetaDto infoTarjeta { get; set; }

        public IEnumerable<tranTarjetaDto> listTransaction { get; set; }

        public totalTranDto mesActual { get; set; }

        public totalTranDto mesAnterior { get; set; }
    }
}
