

using Microsoft.EntityFrameworkCore;
using BCOAPI.Domain.Entities;

namespace BCOAPI.Infraestructure
{
    public class MyDbContext: DbContext
    {

        public MyDbContext( DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteEntity> Cliente { get; set; }



    }
}
