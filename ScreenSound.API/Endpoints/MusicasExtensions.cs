using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndpointsMusicas(this WebApplication app)
    {
        app.MapGet("/musicas", ([FromServices] Dal<Musica> dal) =>
        {
            var listaDeMusicas = dal.Listar();
            if (listaDeMusicas is null)
            {
                return Results.NotFound();
            }

            var listaDeMusicasResponse = EntityListToResponseList(listaDeMusicas);
            return Results.Ok(listaDeMusicasResponse);
        });

        app.MapGet("/musicas/{nome}", ([FromServices] Dal<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
            if (musica is null)
            {
                return Results.NotFound();
            }

            var musicaResponse = EntityToResponse(musica);
            return Results.Ok(musicaResponse);
        });

        app.MapPost("/musicas", ([FromServices] Dal<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(musicaRequest.Nome)
            {
                AnoLancamento = musicaRequest.AnoLancamento,
                ArtistaId = musicaRequest.ArtistaId
            };
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

        app.MapPut("/musicas", ([FromServices] Dal<Musica> dal, [FromBody] MusicaRequestEdit musicaRequestEdit) =>
        {
            var musicaAAtualizar = dal.RecuperarPor(m => m.Id.Equals(musicaRequestEdit.Id));

            if (musicaAAtualizar is null)
            {
                return Results.NotFound();
            }

            musicaAAtualizar.Nome = musicaRequestEdit.Nome;
            musicaAAtualizar.AnoLancamento = musicaRequestEdit.AnoLancamento;
            dal.Atualizar(musicaAAtualizar);
            return Results.NoContent();
        });
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> listaDeMusicas)
    {
        return listaDeMusicas.Select(m => EntityToResponse(m)).ToList();
    }

    private static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
    }
}