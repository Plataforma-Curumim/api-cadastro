using api_cadastro.Application.Domain.Dto.Base;

namespace api_cadastro.Application.Ports.Outbound.DB
{
    public interface IDBConnection
    {
        public Task<BaseReturn> GetConnection();
    }
}
