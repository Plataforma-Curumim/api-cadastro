using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Domain.DTO.Sql;

namespace api_cadastro.Application.Ports.Outbound.DB.Repository
{
    public interface IRegisterBookRepository
    {
        public Task<RegisterBookSql> RegisterBook(RegisterBookSql msgIn);
    }
}
