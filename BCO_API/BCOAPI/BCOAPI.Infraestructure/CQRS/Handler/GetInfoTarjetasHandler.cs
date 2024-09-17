using BCOAPI.Domain.CQRS.Queries;
using BCOAPI.Domain.Dtos;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.CQRS.Handler
{
    public class GetInfoTarjetasHandler : IRequestHandler<GetInfoTarjetasQuery, infoTarjetaDto>
    {
        private readonly MyDbContext _dbContext;
        public GetInfoTarjetasHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<infoTarjetaDto> Handle(GetInfoTarjetasQuery request, CancellationToken cancellationToken)
        {
            infoTarjetaDto model = new infoTarjetaDto();
            string query = "EXEC infoTarjeta @tarjeta";
            using (SqlConnection con = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    SqlCommand myCommand = new SqlCommand(query, con);
                    myCommand.Parameters.AddWithValue("@tarjeta", request.tarjeta);


                    SqlDataReader dr = myCommand.ExecuteReaderAsync().Result;
                    while (dr.Read())
                    {
                        model.nombres = Convert.ToString(dr["nombres"]);
                        model.apellidos = Convert.ToString(dr["apellidos"]);
                        model.noTarjeta = Convert.ToString(dr["noTarjeta"]);
                        model.saldo = Decimal.Parse(Convert.ToString(dr["saldo"]));
                        model.limite = Decimal.Parse(Convert.ToString(dr["limite"]));
                        model.disponible = Decimal.Parse(Convert.ToString(dr["disponible"]));
                        model.intMensual = Int32.Parse(Convert.ToString(dr["intMensual"]));
                        model.intBonif = Decimal.Parse(Convert.ToString(dr["intBonif"]));
                        model.saldoMin = Int32.Parse(Convert.ToString(dr["saldoMin"]));
                        model.minimo = Decimal.Parse(Convert.ToString(dr["minimo"]));
                        model.saldoInt = Decimal.Parse(Convert.ToString(dr["sldint"]));

                    }
                }
            }
            return Task.FromResult(model);
        }
    }
}
