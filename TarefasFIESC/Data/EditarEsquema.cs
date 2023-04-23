using Npgsql;
using Dapper;

namespace TarefasFIESC.Data;

public static class EditarEsquema
{   
    public static void ExecuteQuery(this IConfiguration configuration)
    {
        var connString = configuration["DbContextSettings:ConnectionString"];

        using var conn = new NpgsqlConnection(connString);

        conn.Query("ALTER TABLE IF EXISTS public.\"Observacao\" \r\nADD COLUMN IF NOT EXISTS \"UsuarioNome\" TEXT;\r\n");

        conn.Query("ALTER TABLE IF EXISTS public.\"Tarefa\" \r\nADD COLUMN IF NOT EXISTS \"UsuarioNome\" TEXT;\r\n");
    }

}