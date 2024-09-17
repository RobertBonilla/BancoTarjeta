using BCOAPI.Core.Domain.Dtos;
using BCOAPI.Core.Domain.Responses;

namespace BCOAPI.Core.Interfaces
{
    public interface IClienteService
    {
        ClienteResponse getDatosCliente(string idCliente);
    }
}
