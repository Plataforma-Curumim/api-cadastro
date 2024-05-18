using api_cadastro.Application.Domain.Base;
using api_cadastro.Application.Domain.Command;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterUser
    {
        public Task<BaseReturn> Execute(CommandRegisterUser transacao);
    }
}
