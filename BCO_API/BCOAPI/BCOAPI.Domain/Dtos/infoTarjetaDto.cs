namespace BCOAPI.Domain.Dtos
{
    public class infoTarjetaDto
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string noTarjeta { get; set; }
        public decimal saldo { get; set; }
        public decimal limite { get; set; }
        public decimal disponible { get; set; }
        public int intMensual { get; set; }
        public decimal intBonif { get; set; }
        public int saldoMin { get; set; }
        public decimal minimo { get; set; }
        public decimal saldoInt { get; set; }
    }
}
