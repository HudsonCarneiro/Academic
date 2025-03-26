using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Model;

namespace ProgramacaoIV.ToDoList.Context;

public sealed class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region todo

        modelBuilder.Entity<Todo>().HasKey(t => t.Id);
        modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired();
        modelBuilder.Entity<Todo>().Property(t => t.IsDone).IsRequired();

        #endregion todo
    }
}