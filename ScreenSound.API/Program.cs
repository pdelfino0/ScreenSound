using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();
builder.Services.AddTransient<Dal<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

#region RotasArtistas

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

app.MapPut("/artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaAAtualizar = dal.RecuperarPor(a => a.Id.Equals(artista.Id));
    if (artistaAAtualizar == null)
    {
        return Results.NotFound();
    }

    artistaAAtualizar.Nome = artista.Nome;
    artistaAAtualizar.Bio = artista.Bio;
    artistaAAtualizar.FotoPerfil = artista.FotoPerfil;
    dal.Atualizar(artistaAAtualizar);
    return Results.Ok();
});

#endregion

#region RotasMusicas

app.MapGet("/musicas", ([FromServices] Dal<Musica> dal) => { return Results.Ok(dal.Listar()); });

app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapDelete("/musicas/{id}", ([FromServices] Dal<Musica> dal, int id) =>
{
    var musicaRecuperada = dal.RecuperarPor(m => m.Id == id);
    if (musicaRecuperada is null)
    {
        return Results.NotFound();
    }

    dal.Deletar(musicaRecuperada);
    return Results.NoContent();
});

app.MapPut("/musicas", ([FromServices] Dal<Musica> dal, [FromBody] Musica musica) =>
{
    var musicaAAtualizar = dal.RecuperarPor(m => m.Id.Equals(musica.Id));

    if (musicaAAtualizar is null)
    {
        return Results.NotFound();
    }

    musicaAAtualizar.Nome = musica.Nome;
    musicaAAtualizar.AnoLancamento = musica.AnoLancamento;
    dal.Atualizar(musicaAAtualizar);
    return Results.NoContent();
});

#endregion

app.Run();