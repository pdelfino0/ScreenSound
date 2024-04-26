using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        #region RotasMusicas

        app.MapGet("/musicas", ([FromServices] Dal<Musica> dal) => { return Results.Ok(dal.Listar()); });

        app.MapPost("/Musicas", ([FromServices] Dal<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(musicaRequest.Nome, musicaRequest.AnoLancamento);
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
    }
}