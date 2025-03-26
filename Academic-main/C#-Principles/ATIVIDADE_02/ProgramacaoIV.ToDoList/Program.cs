
using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Context;
using ProgramacaoIV.ToDoList.Model;

namespace ProgramacaoIV.ToDoList;

public class Program
{
    private const string _connectionString = "Server=localhost;Port=3306;Database=umfg_todo_list;Uid=root;Pwd=root;";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<TodoContext>(options => options.UseMySQL(_connectionString));

        var app = builder.Build();

        #region endpoints

        // GET - Listar todas as tarefas
        app.MapGet("/todos", async (TodoContext context) => await context.Todos.ToListAsync());

        // GET - Obter uma tarefa por ID
        app.MapGet("/todos/{id}", async (string id, TodoContext context) =>
            await context.Todos.FindAsync(Guid.Parse(id)) is Todo todo ? Results.Ok(todo) : Results.NotFound());

        // POST - Criar uma nova tarefa
        app.MapPost("/todos", async (Todo todo, TodoContext context) => {
            context.Todos.Add(todo);
            await context.SaveChangesAsync();

            return Results.Created($"/todos/{todo.Id}", todo);
        });

        // PUT - Atualizar uma tarefa
        app.MapPut("/todos/{id}", async (string id, Todo inputTodo, TodoContext context) => {
            var todo = await context.Todos.FindAsync(Guid.Parse(id));
            
            if (todo is null) 
                return Results.NotFound();

            todo.Title = inputTodo.Title;
            todo.IsDone = inputTodo.IsDone;

            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE - Remover uma tarefa
        app.MapDelete("/todos/{id}", async (string id, TodoContext context) => {
            var todo = await context.Todos.FindAsync(Guid.Parse(id));
            
            if (todo is null) 
                return Results.NotFound();

            context.Todos.Remove(todo);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        #endregion endpoints

        app.Run();
    }
}