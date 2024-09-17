using BCOAPI.Domain.CQRS.Queries;
using BCOAPI.Domain.Dtos;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.CQRS.Handler
{
    public class GetTranTarjetaHandler : IRequestHandler<GetTranTarjetaQuery, IEnumerable<tranTarjetaDto>>
    {
        private readonly MyDbContext _dbContext;
        public GetTranTarjetaHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<tranTarjetaDto>> Handle(GetTranTarjetaQuery request, CancellationToken cancellationToken)
        {
            List<tranTarjetaDto> list = new List<tranTarjetaDto>();
            string query = "EXEC transaccionesTarjeta @tarjeta,@fechaIni, @fechaFin";
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
                        tranTarjetaDto model = new tranTarjetaDto();
                        model.referencia = Convert.ToString(dr["ref"]);
                        model.fecha = Convert.ToString(dr["fecha"]);
                        model.descripcion = Convert.ToString(dr["descripcion"]);
                        model.cargo = Decimal.Parse(Convert.ToString(dr["cargo"]));
                        model.abono = Decimal.Parse(Convert.ToString(dr["abono"]));
                        list.Add(model);
                    }
                }
            }
            return Task.FromResult(list.AsEnumerable());
        }
    }
}
