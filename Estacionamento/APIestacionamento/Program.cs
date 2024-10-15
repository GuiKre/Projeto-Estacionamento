using System.Resources;
using APIestacionamento.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Projeto Estacionamento");

app.MapPost("/api/carros/cadastrar", ([FromBody] Carro carro,
    [FromServices] AppDataContext ctx) => 
{
    var vaga = ctx.Vagas.Find(carro.VagaId);

    if (vaga == null)
    {
        return Results.BadRequest("A vaga espeificada não existe.");
    }

    ctx.Carros.Add(carro);
    ctx.SaveChanges();
    return Results.Created("", carro);
});

app.MapGet("/api/carros/buscar/{id}", ([FromRoute] int id, 
    [FromServices] AppDataContext ctx) => 
{
    Carro? carro = ctx.Carros.Find(id);
    if(carro is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(carro);
});

app.MapGet("/api/carros/listar", ([FromServices] AppDataContext ctx) => 
{
    if(ctx.Carros.Any())
    {
        return Results.Ok(ctx.Carros.ToList());
    }
    return Results.NotFound();
});

app.MapDelete("/api/carros/deletar/{id}", ([FromRoute] int id, 
    [FromServices] AppDataContext ctx) => 
{
    Carro? carro = ctx.Carros.Find(id);
    if(carro is null)
    {
        return Results.NotFound();
    }
    ctx.Carros.Remove(carro);
    ctx.SaveChanges();
    return Results.Ok(carro);
});

app.MapPut("/api/carros/alterar/{id}", ([FromRoute] int id,
    [FromBody] Carro carroAlterado,
    [FromServices] AppDataContext ctx) => 
{
    Carro? carro = ctx.Carros.Find(id);
    if(carro is null)
    {
        return Results.NotFound();
    }
    carro.Placa = carroAlterado.Placa;
    carro.Marca = carroAlterado.Marca;
    carro.Modelo = carroAlterado.Modelo;
    carro.Cor = carroAlterado.Cor;
    ctx.Carros.Update(carro);
    ctx.SaveChanges();
    return Results.Ok(carro);
});

app.MapPost("/api/vagas/cadastrar", ([FromBody] Vaga vaga,
    [FromServices] AppDataContext ctx) => 
{
    ctx.Vagas.Add(vaga);
    ctx.SaveChanges();
    return Results.Created("", vaga);
});

app.MapGet("/api/vagas/listar", ([FromServices] AppDataContext ctx) => 
{
    if(ctx.Vagas.Any())
    {
        return Results.Ok(ctx.Vagas.ToList());
    }
    return Results.NotFound();
});
app.Run();
