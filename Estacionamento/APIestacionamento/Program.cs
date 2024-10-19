using System.Text.Json.Serialization;
using APIestacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
var app = builder.Build();

app.MapGet("/", () => "Projeto Estacionamento");

app.MapPost("/api/carros/cadastrar", ([FromBody] Carro carro, [FromServices] AppDataContext ctx) =>
{
    var vaga = ctx.Vagas.Find(carro.VagaId);
    var cliente = ctx.Clientes.Find(carro.ClienteId);
    if (vaga == null)
    {
        return Results.BadRequest("A vaga especificada não existe.");
    }
    if (cliente == null)
    {
        return Results.BadRequest("O cliente especificado não existe.");
    }
    ctx.Carros.Add(carro);
    ctx.SaveChanges();
    return Results.Created("", carro);
});

app.MapPost("/api/clientes/cadastrar", ([FromBody] Cliente cliente, [FromServices] AppDataContext ctx) =>
{
    try
    {
        ctx.Clientes.Add(cliente);
        ctx.SaveChanges();
        return Results.Created("", cliente);
    }
    catch (DbUpdateException ex)
    {
        return Results.Problem($"Erro ao atualizar banco de dados: {ex.Message}");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Erro desconhecido: {ex.Message}");
    }
});

app.MapGet("/api/clientes/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Clientes.Any())
    {
        return Results.Ok(ctx.Clientes.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/api/carros/buscar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{
    Carro? carro = ctx.Carros.Find(id);
    if (carro is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(carro);
});

app.MapGet("/api/carros/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Carros.Any())
    {
        return Results.Ok(ctx.Carros.ToList());
    }
    return Results.NotFound();
});

app.MapDelete("/api/carros/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{
    Carro? carro = ctx.Carros.Find(id);
    if (carro is null)
    {
        return Results.NotFound();
    }
    ctx.Carros.Remove(carro);
    ctx.SaveChanges();
    return Results.Ok(carro);
});

app.MapPut("/api/carros/alterar/{id}", ([FromRoute] int id, [FromBody] Carro carroAlterado, [FromServices] AppDataContext ctx) =>
{
    Carro? carro = ctx.Carros.Find(id);
    if (carro is null)
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

app.MapPost("/api/vagas/cadastrar", ([FromBody] Vaga vaga, [FromServices] AppDataContext ctx) =>
{
    ctx.Vagas.Add(vaga);
    ctx.SaveChanges();
    return Results.Created("", vaga);
});

app.MapGet("/api/vagas/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Vagas.Any())
    {
        return Results.Ok(ctx.Vagas.ToList());
    }
    return Results.NotFound();
});

app.MapPost("/api/recibos/cadastrar/{vagaId}", (int vagaId, [FromServices] AppDataContext ctx) =>
{
    var vaga = ctx.Vagas.Find(vagaId);
    if (vaga == null)
    {
        return Results.NotFound();
    }
    var carro = ctx.Carros
        .Include(c => c.Cliente)
        .FirstOrDefault(c => c.VagaId == vagaId);
    if (carro == null)
    {
        return Results.NotFound();
    }
    var dataSaida = DateTime.Now;
    TimeSpan duracao = dataSaida - carro.DataChegada;
    decimal valorTotal = (decimal)duracao.TotalHours * 5;
    var novoRecibo = new Recibo
    {
        ClienteId = carro.ClienteId,
        CarroId = carro.CarroId,
        VagaId = vaga.VagaId,
        DataChegada = carro.DataChegada,
        HoraSaida = dataSaida,
        ValorTotal = valorTotal,
    };
    ctx.Recibos.Add(novoRecibo);
    ctx.SaveChanges();
    return Results.Created("", novoRecibo);
});

app.MapGet("/api/recibos/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Recibos.Any())
    {
        return Results.Ok(ctx.Recibos.ToList());
    }
    return Results.NotFound();
});

app.Run();
