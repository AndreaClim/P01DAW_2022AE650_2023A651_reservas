using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01DAW_2022AE650_2023A651_reservas.Models
{
    public class reservasContext : DbContext
    {
        public reservasContext(DbContextOptions<reservasContext> options) : base(options)
        {
        }
        public DbSet<reservas> reservas { get; set; }
    }
}
