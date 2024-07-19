using api_cadastro.Application.Domain.DTO.Sql;

namespace api_cadastro.Application.Ports.Outbound.DB.Repository
{
    public interface IRegisterBookRepository
    {
        public Task<RegisterBookSql> RegisterBook(RegisterBookSql msgIn);
    }
}
