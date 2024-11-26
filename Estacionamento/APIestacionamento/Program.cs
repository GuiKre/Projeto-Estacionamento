using APIestacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

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

app.MapPost("/api/clientes/cadastrar", ([FromBody] Cliente cliente,
    [FromServices] AppDataContext ctx) =>
{
    var carro = ctx.Carros.Find(cliente.CarroId);
    if (carro == null)
    {
        return Results.BadRequest("O carro especificado não existe.");
    }

    ctx.Clientes.Add(cliente);
    ctx.SaveChanges();
    return Results.Created("", cliente);
});

app.MapPost("/api/recibos/cadastrar", ([FromBody] Recibo recibo,
    [FromServices] AppDataContext ctx) =>
{
    var cliente = ctx.Clientes.Find(recibo.ClienteId);
    if (cliente == null)
    {
        return Results.BadRequest("O cliente especificado não existe.");
    }

    var carro = ctx.Carros.Find(recibo.CarroId);
    if (carro == null)
    {
        return Results.BadRequest("O carro especificado não existe.");
    }

    if (carro.CarroId != cliente.CarroId)
    {
        return Results.BadRequest("O carro especificado não pertence ao cliente.");
    }

    recibo.Carro = carro;
    recibo.CalcularValor();

    cliente.Recibos ??= new List<Recibo>();
    cliente.Recibos.Add(recibo);

    ctx.Recibos.Add(recibo);
    ctx.SaveChanges();

    return Results.Created("", recibo);
});

app.MapGet("/api/carros/buscar/{id}", ([FromRoute] int id,
    [FromServices] AppDataContext ctx) =>
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
    var carrosComClientes = ctx.Carros
        .Include(c => c.cliente)
        .ToList();

    if (carrosComClientes.Any())
    {
        return Results.Ok(carrosComClientes);
    }

    return Results.NotFound();
});

app.MapGet("/api/clientes/listar", ([FromServices] AppDataContext ctx) =>
{
    var clientes = ctx.Clientes
        .Include(cl => cl.Recibos)
        .ToList();

    if (clientes.Any())
    {
        return Results.Ok(clientes);
    }

    return Results.NotFound();
});

app.MapGet("/api/recibos/listar", ([FromServices] AppDataContext ctx) =>
{
    var recibos = ctx.Recibos
        .Include(r => r.Cliente)
        // .Include(r => r.Carro)
        .ToList();

    if (recibos.Any())
    {
        return Results.Ok(recibos);
    }

    return Results.NotFound();
});

app.MapDelete("/api/carros/deletar/{id}", ([FromRoute] int id,
    [FromServices] AppDataContext ctx) =>
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

app.MapPut("/api/carros/alterar/{id}", ([FromRoute] int id,
    [FromBody] Carro carroAlterado,
    [FromServices] AppDataContext ctx) =>
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

app.MapPost("/api/vagas/cadastrar", ([FromBody] Vaga vaga,
    [FromServices] AppDataContext ctx) =>
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

app.UseCors("Acesso Total");

app.Run();