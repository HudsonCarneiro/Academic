using Microsoft.EntityFrameworkCore;
using MinimalApiNotas.Models;

namespace MinimalApiNotas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Nota> Notas { get; set; }
    }
}
