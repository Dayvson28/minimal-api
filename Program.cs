using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using minimalApi.DTOs;
using minimalApi.Infraestrutura.Db;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContexto>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Sql"));
});
var app = builder.Build();

app.MapGet("/", () => "Olá, Pessoal!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "admin@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com sucesso");
    else
        return Results.Unauthorized();
});

app.Run();
