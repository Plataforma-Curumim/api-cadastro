using api_cadastro.Application.Domain.Base;

namespace api_cadastro.Application.Ports.Outbound.DB
{
    public interface IDBConnection
    {
        public Task<BaseReturn> GetConnection();
    }
}
