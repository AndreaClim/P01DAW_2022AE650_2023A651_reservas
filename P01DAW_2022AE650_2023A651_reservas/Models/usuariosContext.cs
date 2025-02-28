using P01DAW_2022AE650_2023A651_reservas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01DAW_2022AE650_2023A651_reservas.Models
{
    public class usuariosContext : DbContext
    {
        public usuariosContext(DbContextOptions<usuariosContext> options) : base(options)
        {

        }
        public DbSet<usuarios> usuarios { get; set; }
    }
}
