using api_cadastro.Application.Domain.Dto.Command;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterUser
    {
        public Task<BaseReturn<CommandRegisterUser>> Execute(CommandRegisterUser command);
    }
}
