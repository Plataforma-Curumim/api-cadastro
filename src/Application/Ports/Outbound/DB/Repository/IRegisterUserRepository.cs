using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Dto.Command;

namespace api_cadastro.Application.Ports.Outbound.DB.Repository
{
    public interface IRegisterUserRepository
    {
        public Task<BaseReturn> RegisterUser(CommandRegisterUser command);
    }
}
