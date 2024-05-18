using api_cadastro.Application.Domain.Base;
using api_cadastro.Application.Domain.Command;
using api_cadastro.Application.Ports.Inbound.UseCases;

namespace api_cadastro.Application.Core.UseCases
{
    public class UseCaseRegisterUser : IUseCaseRegisterUser
    {
        public Task<BaseReturn> Execute(CommandRegisterUser transacao)
        {
            throw new NotImplementedException();
        }
    }
}
