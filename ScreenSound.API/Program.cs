using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/artistas", ([FromServices] Dal<Artista> dal) => { return Results.Ok(dal.Listar()); });

app.MapGet("/artistas/{nome}", ([FromServices] Dal<Artista> dal, string nome) =>
{
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

    if (artista == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artista);
});
app.MapPost("/artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("/artistas/{id}", ([FromServices] Dal<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista == null)
    {
        return Results.NotFound();
    }
    dal.Deletar(artista);
    return Results.NoContent();
});

app.Run();