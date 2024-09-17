using BCOAPI.Core.Domain.Dtos;

namespace BCOAPI.Core.Domain.Responses
{
    public class historialTarjetaResponse
    {
        public ResponseStatus Status { get; set; }

        public IEnumerable<tranTarjetaDto> listTransaction { get; set; }
    }
}
