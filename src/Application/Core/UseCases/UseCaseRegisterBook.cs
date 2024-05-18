using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Dto.Command;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Ports.Inbound.UseCases;

namespace api_cadastro.Application.Core.UseCases
{
    public class UseCaseRegisterBook : IUseCaseRegisterBook
    {
        public Task<BaseReturn> Execute(CommandRegisterBook command)
        {
            throw new NotImplementedException();
        }
    }
}
