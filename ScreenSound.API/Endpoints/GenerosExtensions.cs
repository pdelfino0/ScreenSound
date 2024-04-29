using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Responses;
using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class GenerosExtensions
{
    public static void AddEndpointGeneros(this WebApplication app)
    {
        #region GetGeneros

        app.MapGet("/generos", ([FromServices] Dal<Genero> dal) =>
        {
            var listaDeGeneros = dal.Listar();
            if (listaDeGeneros is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(EntityToResponseList(listaDeGeneros));
        });

        #endregion

        #region GetGenerosPorNome

        app.MapGet("/generos{nome}", ([FromServices] Dal<Genero> dal, string nome) =>
        {
            var generoRecuperado = dal.RecuperarPor(g => g.Nome.ToUpper().Equals(nome.ToUpper()));
            if (generoRecuperado is null)
            {
                return Results.NotFound();
            }

            var generoResponse =
                new GeneroResponse(generoRecuperado.Nome, generoRecuperado.Descricao, generoRecuperado.Id);
            return Results.Ok(generoResponse);
        });

        #endregion

        #region PostGeneros

        app.MapPost("/generos", ([FromServices] Dal<Genero> dal, [FromBody] GeneroRequest genero) =>
        {
            dal.Adicionar(RequestToEntity(genero));
            return Results.Ok();
        });

        #endregion

        #region PutGeneros

        app.MapPut("/generos", ([FromServices] Dal<Genero> dal, [FromBody] GeneroEditRequest generoEditRequest) =>
        {
            var generoRecuperado = dal.RecuperarPor(g => g.Id == generoEditRequest.Id);

            if (generoRecuperado is null)
            {
                return Results.NotFound();
            }

            generoRecuperado.Nome = generoEditRequest.Nome;
            generoRecuperado.Descricao = generoEditRequest.Descricao;
            dal.Atualizar(generoRecuperado);
            return Results.Ok();
        });

        #endregion

        #region DeleteGeneros

        app.MapDelete("/generos/{id}", ([FromServices] Dal<Genero> dal, int id) =>
        {
            var generoRecuperado = dal.RecuperarPor(g => g.Id.Equals(id));
            if (generoRecuperado is null)
            {
                return Results.NotFound();
            }

            dal.Deletar(generoRecuperado);
            return Results.NoContent();
        });

        #endregion
    }

    private static Genero RequestToEntity(GeneroRequest generoRequest)
    {
        return new Genero(generoRequest.Nome, generoRequest.Descricao);
    }

    private static GeneroResponse EntityToResponse(Genero genero)
    {
        return new GeneroResponse(genero.Nome, genero.Descricao, genero.Id);
    }

    private static ICollection<GeneroResponse> EntityToResponseList(IEnumerable<Genero> listaDeGeneros)
    {
        return listaDeGeneros.Select(g => EntityToResponse(g)).ToList();
    }
}