using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{

    private readonly string connectionString =
        "Server = localhost;Port=5432;Database = dappercruddb;Username = postgres;Password = LMard1909";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}