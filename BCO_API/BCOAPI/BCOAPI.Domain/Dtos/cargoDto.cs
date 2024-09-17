using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCOAPI.Domain.Dtos
{
    public class cargoDto
    {
        public string numeroTarjeta { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
    }
}
