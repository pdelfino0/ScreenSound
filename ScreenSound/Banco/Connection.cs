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


}