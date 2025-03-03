using Cardapio.ApiService.Data;
using Cardapio.ApiService.Entities;
using Cardapio.ApiService.Services.Service;
using Cardapio.ApiService.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Cardapio.ApiService.Repositories.Repository;
using Cardapio.ApiService.Repositories.Interface;
using Microsoft.Extensions.Logging;
using Cardapio.ApiService.Exceptions;
using Cardapio.ApiService.Models;

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
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/PegarTodosOsUsuarios", async ([FromServices] IUsuarioService usuarioService) =>
{
    try
    {
        var usuarios = await usuarioService.SelecionarTodosUsuarios(new UsuarioEntity());
        return Results.Ok(usuarios);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/ValidarUsuario", async ([FromBody] ValidacaoUsuarioModel validacaoUsuario, [FromServices] IUsuarioService usuarioService) =>
{
    try
    {
        var usuarioExiste = await usuarioService.ValidarUsuarioPeloNomeESenha(validacaoUsuario.nome, validacaoUsuario.senha);
        

        if(usuarioExiste != null)
            return Results.Ok(usuarioExiste);

        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/AdicionarUsuario", async ([FromBody] UsuarioEntity usuario, [FromServices] IUsuarioService usuarioService) =>
{
    try
    {
        var usuarioResult = await usuarioService.AdicionarUsuario(usuario);
        return Results.Ok();
    }
    catch (ErroUsuarioJaExiste)
    {
        return Results.BadRequest("ErroNome");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/AtualizarUsuario", async ([FromBody] UsuarioEntity usuario, [FromServices] IUsuarioService usuarioService) =>
{
    try
    {
        var usuarioResult = await usuarioService.AtualizarUsuario(usuario);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/RemoverUsuario", async ([FromBody] UsuarioEntity usuario, [FromServices] IUsuarioService usuarioService) =>
{
    try
    {
        var usuarioResult = await usuarioService.RemoverUsuario(usuario);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/PegarTodosOsPedidos", async ([FromServices]IPedidoService perdidoService) =>
{
    try
    {
        var pedidos = await perdidoService.SelecionarTodosPedidosAsync(new PedidoEntity());

        if (pedidos != null)
            return Results.Ok(pedidos);

        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/PegarPedidosPeloStatus/{status}", async  ([FromRoute]string status, [FromServices]IPedidoService pedidosService) =>
{
    try
    {
        var pedidos = await pedidosService.RetornarPedidosPeloStatus(status);
        if (pedidos != null)
            return Results.Ok(pedidos);

        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/AdicionarPedido", async ([FromBody] PedidoEntity pedido, [FromServices] IPedidoService pedidoService) =>
{
    try
    {
        var pedidoResult = await pedidoService.AdicionarPedidoAsync(pedido);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPut("/AtualizarPedido", async ([FromBody] PedidoEntity pedido, [FromServices] IPedidoService pedidoService) =>
{
    try
    {
        var pedidoResult = await pedidoService.AtualizarPedidoAsync(pedido);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/RemoverPedido", async ([FromBody] PedidoEntity pedido, [FromServices] IPedidoService pedidoService) =>
{
    try
    {
        var pedidoResult = await pedidoService.RemoverPedidoAsync(pedido);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/PegarTodasAsMesas", async ([FromServices] IMesaService mesaService) =>
{

    var mesas = await mesaService.SelecionarTodosAsync(new MesaEntity());

    if (mesas != null)
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

app.MapGet("/PegarTodosOsProdutos", async ([FromServices] IProdutoService produtoService) =>
{
    try
    {
        var produtos = await produtoService.SelecionarTodosAsync(new ProdutoEntity());
        return Results.Ok(produtos);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/PegarProdutoPeloCodigo/{codigo}", async ([FromRoute] int codigo, [FromServices] IProdutoService produtoService) =>
{
    try
    {
        var produto = await produtoService.SelecionarProdutoPeloCodigo(codigo);
        if (produto != null)
            return Results.Ok(produto);

        return Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/AdicionarProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoService produtoService) =>
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

app.MapPut("/AtualizarProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoService produtoServuce) =>
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

app.MapDelete("/RemoverProduto", async ([FromBody] ProdutoEntity produto, [FromServices] IProdutoService produtoService) =>
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

