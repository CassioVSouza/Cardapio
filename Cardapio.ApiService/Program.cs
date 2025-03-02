using Cardapio.ApiService.Data;
using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Repositories.Interface.GenericoRepository;
using Cardapio.ApiService.Repositories.Repository.GenericoRepository;
using Cardapio.ApiService.Services.Service;
using Cardapio.ApiService.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppContextData>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IGenericoRepository<>), typeof(GenericoRepository<>));
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IMesaService, MesaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/PegarTodasAsMesas", async ([FromServices] IMesaService mesaService) => {
    
    var mesas = await mesaService.SelecionarTodosAsync(new MesaEntity());

    if(mesas != null)
        return Results.Ok(mesas);

    return Results.NotFound();
});

app.MapPost("/AdicionarMesa", async ([FromBody] MesaEntity mesa, [FromServices] IMesaService mesaService) =>
{
    try
    {
        var mesaResult = await mesaService.AdicionarAsync(mesa);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/RemoverMesa", async ([FromBody] MesaEntity mesa, [FromServices] IMesaService mesaService) =>
{
    try
    {
        var mesaResult = await mesaService.RemoverAsync(mesa);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/AtualizarMesa", async ([FromBody] MesaEntity mesa, [FromServices] IMesaService mesaService) =>
{
    try
    {
        var mesaResult = await mesaService.AtualizarAsync(mesa);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/AdicionarProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoInterface produtoService) =>
{
    try
    {
        var produtoResult = await produtoService.AdicionarAsync(produto);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/AtualizarProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoInterface produtoServuce) =>
{
    try
    {
        var produtoResult = await produtoServuce.AtualizarAsync(produto);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/RemoverProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoInterface produtoService) =>
{
    try
    {
        var produtoResult = await produtoService.RemoverAsync(produto);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});


app.MapDefaultEndpoints();

app.Run();

