using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCOAPI.Domain.Entities
{
    [Table("Cliente")]
    public class ClienteEntity
    {
        [Key]
        [Column("idCliente", TypeName = "uniqueidentifier")]
        public System.Guid idCliente { get; set; }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
    }
}
