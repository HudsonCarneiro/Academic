using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Model;

namespace ProgramacaoIV.ToDoList.Context;

public class AppDbContext : DbContext
{
    public DbSet<Nota> Notas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nota>()
            .Property(n => n.DataLancamento)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}