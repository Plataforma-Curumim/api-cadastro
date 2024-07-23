using api_cadastro.Application.Domain.Dto.Command;
using api_cadastro.Application.Domain.DTO;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterUser
    {
        public Task<BaseReturn<DomainModel>> Execute(DomainModel domainModel);
    }
}
