using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Domain.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(ClienteResponse response)
        {
            clienteDto = response.clienteDto;
            listTarjetasClienteDto = response.listTarjetasClienteDto;
            foreach (var item in listTarjetasClienteDto)
            {                
                item.noTarjetaView = item.noTarjeta.Substring(item.noTarjeta.Length-4,4);
            }
        }

        public ClienteDto clienteDto { get; set; }
        public IEnumerable<tarjetasClienteDto> listTarjetasClienteDto { get; set; }
    }
}
