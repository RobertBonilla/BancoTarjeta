using BCOAPI.Domain.Dtos;
using BCOAPI.Infraestructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.Repositories
{
    public class AbonoRepository : IAbonoRepository
    {
        private readonly MyDbContext _dbContext;
        public AbonoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool pagoTarjeta(abonoDto model)
        {
            try
            {
                string query = "EXEC abonoTarjeta @numeroTarjeta, @monto,@fecha";
                using (SqlConnection con = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = query;
                        SqlCommand myCommand = new SqlCommand(query, con);
                        myCommand.Parameters.AddWithValue("@numeroTarjeta", model.numeroTarjeta);
                        myCommand.Parameters.AddWithValue("@monto", model.monto);
                        myCommand.Parameters.AddWithValue("@fecha", model.fecha);
                        int num = myCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
