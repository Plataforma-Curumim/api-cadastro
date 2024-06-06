using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Dto.Command;
using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Application.Ports.Outbound.DB.Repository;

namespace api_cadastro.Application.Core.UseCases
{
    public class UseCaseRegisterUser : IUseCaseRegisterUser
    {
        private readonly IRegisterUserRepository ?_repository;

        public UseCaseRegisterUser(IServiceProvider provider)
        {
            _repository = provider.GetService<IRegisterUserRepository>();
        }
        public async Task<BaseReturn> Execute(CommandRegisterUser command)
        {
            try
            {
                var response = await _repository!.RegisterUser(command);
                return new BaseReturn().Success(response);
            }catch (Exception ex) 
            {
                return new BaseReturn().SystemError(ex);
            }
        }
    }
}
