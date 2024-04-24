using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class Connection
{
    private const string ConnectionString =
        "Server=localhost\\SQLEXPRESS;Database=Alura;Integrated Security=True;TrustServerCertificate=true;";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(ConnectionString);
    }

    public IEnumerable<Artista> Listar()
    {
       var lista = new List<Artista>();
        using var connection = ObterConexao();
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
}