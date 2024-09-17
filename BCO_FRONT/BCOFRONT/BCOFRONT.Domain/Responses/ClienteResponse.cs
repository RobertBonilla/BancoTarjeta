

using BCOFRONT.Domain.Dtos;

namespace BCOFRONT.Domain.Responses
{
    public class ClienteResponse
    {
        public ResponseStatus Status { get; set; }
        public ClienteDto clienteDto { get; set; }
        public IEnumerable<tarjetasClienteDto> listTarjetasClienteDto { get; set; }
    }
}
