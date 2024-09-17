using BCOAPI.Domain.Dtos;
using BCOAPI.Infraestructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BCOAPI.Infraestructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly MyDbContext _dbContext;
        public CargoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool compraTarjeta(cargoDto model)
        {
            try
            {
                string query = "EXEC cargoTarjeta @numeroTarjeta, @monto,@fecha,@descripcion";
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
                        myCommand.Parameters.AddWithValue("@descripcion", model.descripcion);
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
