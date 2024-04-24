using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "SELECT * FROM Artistas";
        SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);
            Artista artista = new Artista(nomeArtista, bioArtista) { Id = idArtista };
            lista.Add(artista);
        }

        return lista;
    }

    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "INSERT INTO ARTISTAS (Nome, FotoPerfil, Bio) values (@nome, @perfilPadrao, @bio)";

        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@perfilPadrao", artista.FotoPerfil);

        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Foram adicionadas {linhasAfetadas} linhas na tabela Artistas");
    }

    public void Atualizar(Artista artista, int id)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";

        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", artista.Nome);
        command.Parameters.AddWithValue("@bio", artista.Bio);
        command.Parameters.AddWithValue("@id", id);

        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Foram adicionadas {linhasAfetadas} linhas na tabela Artistas");
    }

    public void Deletar(int id)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "DELETE FROM Artistas WHERE Id = @id";

        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        int linhasAfetadas = command.ExecuteNonQuery();
        Console.WriteLine($"Foram adicionadas {linhasAfetadas} linhas na tabela Artistas");
    }
}