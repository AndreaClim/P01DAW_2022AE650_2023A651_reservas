using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01DAW_2022AE650_2023A651_reservas.Models
{
    public class espaciosContext : DbContext
    {
        public espaciosContext(DbContextOptions<espaciosContext> options) : base(options)
        {
        }
        public DbSet<espacios> espacios { get; set; }
    }
}
