using Microsoft.EntityFrameworkCore;
using Apimedical.Models;

namespace Apimedical.Data // Asegúrate de que el namespace coincide con el de tu proyecto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
