using api_cadastro.Application.Ports.Outbound.DB.Connection;
using Npgsql;

namespace api_cadastro.Adapters.Outbound.DB.Postgres.Connection
{
    public class PostgresConnection : IDBConnection
    {
        private readonly string _connectionString;
        private readonly NpgsqlConnection _connection;
        private readonly bool _isConnect;
        public PostgresConnection(IServiceProvider _provider)
        {
            _isConnect = false;
            //_connectionString = "Host=my_host;Port=port_number;Database=database_name;User Id = username;Password=password;";
            _connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")!;
            _connection = new NpgsqlConnection(_connectionString);
        }

        public NpgsqlConnection GetConnection()
        {
            try
            {
                if (!_isConnect)
                {
                    _connection.Open();
                }
                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
