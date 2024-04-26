using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndpointsArtistas(this WebApplication app)
    {
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
        app.MapPost("/artistas", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);
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
    }
}