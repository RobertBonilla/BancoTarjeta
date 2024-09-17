
using BCOFRONT.Domain.Dtos;
using BCOFRONT.Domain.Responses;

namespace BCOFRONT.Domain.ViewModels
{
    public class historialTarjetaViewModel
    {
        public historialTarjetaViewModel(historialTarjetaResponse response)
        {
            listTransaction = response.listTransaction;
        }
        public IEnumerable<tranTarjetaDto> listTransaction { get; set; }
    }
}
