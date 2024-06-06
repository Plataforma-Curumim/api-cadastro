using api_cadastro.Application.Domain.Dto.Base;
using Npgsql;

namespace api_cadastro.Application.Ports.Outbound.DB.Connection
{
    public interface IDBConnection
    {
        public NpgsqlConnection GetConnection();
    }
}
