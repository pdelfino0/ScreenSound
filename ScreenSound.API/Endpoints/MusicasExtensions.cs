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
        #region GetMusicas

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

        #endregion

        #region GetMusicasPorNome

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

        #endregion

        #region PostMusicas

        app.MapPost("/musicas",
            ([FromServices] Dal<Musica> dalMusica, [FromServices] Dal<Genero> dalGenero,
                [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.Nome)
                {
                    AnoLancamento = musicaRequest.AnoLancamento,
                    ArtistaId = musicaRequest.ArtistaId,
                    Generos = musicaRequest.Generos is not null
                        ? RequestToEntityGeneros(musicaRequest.Generos, dalGenero)
                        : new List<Genero>()
                };
                dalMusica.Adicionar(musica);
                return Results.Ok();
            });

        #endregion

        #region DeleteMusicas

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

        #endregion

        #region PutMusicas

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

        #endregion
    }

    private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> listaDeMusicas)
    {
        return listaDeMusicas.Select(m => EntityToResponse(m)).ToList();
    }

    private static MusicaResponse EntityToResponse(Musica musica)
    {
        return new MusicaResponse(musica.Id, musica.Nome!, musica.Artista!.Id, musica.Artista.Nome);
    }

    private static ICollection<Genero> RequestToEntityGeneros(ICollection<GeneroRequest> generosRequest,
        Dal<Genero> dalGenero)
    {
        var listaDeGeneros = new List<Genero>();
        foreach (var item in generosRequest)
        {
            var entity = RequestToEntity(item);
            var genero = dalGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper()));
            if (genero is not null)
            {
                listaDeGeneros.Add(genero);
            }

            listaDeGeneros.Add(entity);
        }

        return listaDeGeneros;
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }
}