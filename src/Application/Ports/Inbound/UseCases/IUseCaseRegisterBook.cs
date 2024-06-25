using api_cadastro.Application.Domain.DTO.Command;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterBook
    {
        public Task<BaseReturn<CommandRegisterBook>> Execute(CommandRegisterBook command);
    }
}
