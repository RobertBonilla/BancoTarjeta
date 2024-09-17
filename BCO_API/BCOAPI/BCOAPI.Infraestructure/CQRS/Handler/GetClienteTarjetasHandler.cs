using BCOAPI.Domain.CQRS.Queries;
using BCOAPI.Domain.Dtos;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.CQRS.Handler
{
    public class GetClienteTarjetasHandler : IRequestHandler<GetClienteTarjetasQuery, IEnumerable<tarjetasClienteDto>>
    {
        private readonly MyDbContext _dbContext;
        public GetClienteTarjetasHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<tarjetasClienteDto>> Handle(GetClienteTarjetasQuery request, CancellationToken cancellationToken)
        {
            List<tarjetasClienteDto> list = new List<tarjetasClienteDto>();
            string query = "EXEC tarjetasCliente @cliente";
            using (SqlConnection con = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    SqlCommand myCommand = new SqlCommand(query, con);
                    myCommand.Parameters.AddWithValue("@cliente", request.idCliente);


                    SqlDataReader dr = myCommand.ExecuteReaderAsync().Result;
                    while (dr.Read())
                    {
                        tarjetasClienteDto model = new tarjetasClienteDto();
                        model.nombres = Convert.ToString(dr["nombres"]);
                        model.apellidos = Convert.ToString(dr["apellidos"]);
                        model.marca = Convert.ToString(dr["marca"]);
                        model.noTarjeta = Convert.ToString(dr["noTarjeta"]);
                        list.Add(model);
                    }
                }               
            }
            return list.AsEnumerable();
        }
    }
}
