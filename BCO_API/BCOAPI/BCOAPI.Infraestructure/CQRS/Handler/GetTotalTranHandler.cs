using BCOAPI.Domain.CQRS.Queries;
using BCOAPI.Domain.Dtos;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.CQRS.Handler
{
    public class GetTotalTranHandler : IRequestHandler<GetTotalTranQuery, totalTranDto>
    {
        private readonly MyDbContext _dbContext;
        public GetTotalTranHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<totalTranDto> Handle(GetTotalTranQuery request, CancellationToken cancellationToken)
        {
            totalTranDto model = new totalTranDto();
            string query = "EXEC totalTranTarjeta @tarjeta,@fechaIni, @fechaFin";
            using (SqlConnection con = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    SqlCommand myCommand = new SqlCommand(query, con);
                    myCommand.Parameters.AddWithValue("@tarjeta", request.param.noTarjeta);
                    myCommand.Parameters.AddWithValue("@fechaIni", request.param.fechaIni);
                    myCommand.Parameters.AddWithValue("@fechaFin", request.param.fechaFin);

                    SqlDataReader dr = myCommand.ExecuteReaderAsync().Result;
                    while (dr.Read())
                    {
                        model.cargo = Decimal.Parse(Convert.ToString(dr["cargo"]));
                        model.abono = Decimal.Parse(Convert.ToString(dr["abono"]));
                        model.saldo = Decimal.Parse(Convert.ToString(dr["saldo"]));

                    }
                }
            }
            return Task.FromResult(model);
        }
    }
}
