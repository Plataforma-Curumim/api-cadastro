using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterBook
    {
        public Task<RegisterBookResponse> Execute(CommandRegisterBook command);
    }
}
