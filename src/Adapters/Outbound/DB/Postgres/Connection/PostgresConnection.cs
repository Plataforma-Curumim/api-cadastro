using api_cadastro.Application.Domain.Settings;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using Npgsql;
using System.Diagnostics.Metrics;

namespace api_cadastro.Adapters.Outbound.DB.Postgres.Connection
{
    public class PostgresConnection : IDBConnection
    {
        private readonly string _connectionString;
        private readonly NpgsqlConnection _connection;
        private readonly bool _isConnect;
        public PostgresConnection(DatabaseSettings settings)
        {
            _isConnect = false;

            //implementar criptografia
            _connectionString = $"Data Source={settings.Cluster};Initial Catalog={settings.Banco};Persist Security Info=True;User ID={settings.Username};Password={settings.Password}";
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

        //public string GetConnectionString(string banco)
        //{
        //    var crypt = new CryptSPA();
        //    string _Password = crypt.decryptDES(Password!, crypt.chave);
        //    return $"Data Source={Cluster};Initial Catalog={banco};Persist Security Info=True;User ID={Username};Password={_Password}";
        //}

    }
}
