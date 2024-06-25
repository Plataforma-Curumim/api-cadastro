using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Application.Ports.Outbound.DB.Repository;

namespace api_cadastro.Application.Core.UseCases
{
    public class UseCaseRegisterBook : IUseCaseRegisterBook
    {
        private readonly IRegisterBookRepository ?_repository;
        public UseCaseRegisterBook(IServiceProvider provider)
        {
            _repository = provider.GetService<IRegisterBookRepository>();
        }

        public async Task<RegisterBookResponse> Execute(CommandRegisterBook command)
        {
            throw new NotImplementedException();
        }
    }
}
