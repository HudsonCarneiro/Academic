using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiNotas.Data;
using MinimalApiNotas.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar banco de dados

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL("server=localhost;database=notasdb;user=root;password=admin;"));



var app = builder.Build();


// Criar uma nota
app.MapPost("/notas", async (AppDbContext db, Nota nota) =>
{
    if (string.IsNullOrWhiteSpace(nota.Aluno) || string.IsNullOrWhiteSpace(nota.Disciplina) || nota.Valor < 0 || nota.Valor > 10)
    {
        return Results.BadRequest("Dados inválidos.");
    }

    db.Notas.Add(nota);
    await db.SaveChangesAsync();
    return Results.Created($"/notas/{nota.Id}", nota);
});

// Listar todas as notas
app.MapGet("/notas", async (AppDbContext db) =>
    await db.Notas.ToListAsync());

// Buscar uma nota por ID
app.MapGet("/notas/{id}", async (AppDbContext db, Guid id) =>
    await db.Notas.FindAsync(id) is Nota nota ? Results.Ok(nota) : Results.NotFound());

// Atualizar uma nota
app.MapPut("/notas/{id}", async (AppDbContext db, Guid id, Nota notaAtualizada) =>
{
    var nota = await db.Notas.FindAsync(id);
    if (nota == null) return Results.NotFound();

    nota.Aluno = notaAtualizada.Aluno;
    nota.Disciplina = notaAtualizada.Disciplina;
    nota.Valor = notaAtualizada.Valor;
    nota.DataLancamento = DateTime.UtcNow;

    await db.SaveChangesAsync();
    return Results.Ok(nota);
});

// Excluir uma nota
app.MapDelete("/notas/{id}", async (AppDbContext db, Guid id) =>
{
    var nota = await db.Notas.FindAsync(id);
    if (nota == null) return Results.NotFound();

    db.Notas.Remove(nota);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();

