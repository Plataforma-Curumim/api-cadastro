using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;

namespace api_cadastro.Application.Ports.Outbound.DB.Repository
{
    public interface IRegisterBookRepository
    {
        public Task<BaseReturn> RegisterBook(CommandRegisterBook command);
    }
}
