using Microsoft.EntityFrameworkCore;
using ProgramacaoIV.ToDoList.Context;
using ProgramacaoIV.ToDoList.Model;


var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados usando appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

#region Endpoints

// GET - Listar todas as tarefas
app.MapGet("/todos", async (TodoContext context) =>
    await context.Todos.ToListAsync());

// GET - Obter uma tarefa por ID
app.MapGet("/todos/{id}", async (Guid id, TodoContext context) =>
    await context.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());

// POST - Criar uma nova tarefa
app.MapPost("/todos", async (Todo todo, TodoContext context) =>
{
    context.Todos.Add(todo);
    await context.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

// PUT - Atualizar uma tarefa
app.MapPut("/todos/{id}", async (Guid id, Todo inputTodo, TodoContext context) =>
{
    var todo = await context.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Title = inputTodo.Title;
    todo.IsDone = inputTodo.IsDone;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE - Remover uma tarefa
app.MapDelete("/todos/{id}", async (Guid id, TodoContext context) =>
{
    var todo = await context.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    context.Todos.Remove(todo);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

#endregion

app.Run();
