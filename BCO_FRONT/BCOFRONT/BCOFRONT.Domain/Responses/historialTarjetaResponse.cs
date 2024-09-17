using BCOFRONT.Domain.Dtos;

namespace BCOFRONT.Domain.Responses
{
    public class historialTarjetaResponse
    {
        public ResponseStatus Status { get; set; }

        public IEnumerable<tranTarjetaDto> listTransaction { get; set; }
    }
}
