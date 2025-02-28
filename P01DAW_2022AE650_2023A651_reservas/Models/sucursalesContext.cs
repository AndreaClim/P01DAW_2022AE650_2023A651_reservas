using L01_2022AE650_2023CA651.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01DAW_2022AE650_2023A651_reservas.Models
{
    public class sucursalesContext : DbContext
    {
        public sucursalesContext(DbContextOptions<sucursalesContext> options) : base(options) 
        {

        }
        public DbSet<sucursales> sucursales { get; set; }

        public DbSet<espacios> espacios { get; set; }
    }
}
