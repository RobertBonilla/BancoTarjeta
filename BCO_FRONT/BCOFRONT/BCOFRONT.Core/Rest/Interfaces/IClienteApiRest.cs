
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Core.Rest.Interfaces
{
    public interface IClienteApiRest
    {
        ClienteResponse GetCliente(string IdCliente);
    }
}
