using api_cadastro.Application.Domain.DTO;

namespace api_cadastro.Application.Ports.Inbound.UseCases
{
    public interface IUseCaseRegisterBook
    {
        public Task<BaseReturn<DomainModel>> Execute(DomainModel domainModel);
    }
}
