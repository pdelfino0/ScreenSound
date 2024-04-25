using System.Text.Json.Serialization;
using ScreenSound.Banco;
using ScreenSound.Modelos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/artistas", () =>
{
    var dal = new Dal<Artista>(new ScreenSoundContext());
    return Results.Ok(dal.Listar());
});
app.MapGet("/artistas/{nome}", (string nome) =>
{
    var dal = new Dal<Artista>(new ScreenSoundContext());
    var artista = dal.RecuperarPor(a => a.Nome == nome);

    if (artista == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artista);
});
app.Run();