using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Dto.Command;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.Mappers;
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
        public async Task<BaseReturn<CommandRegisterUser>> Execute(CommandRegisterUser command)
        {
            try
            {
                var repositoryModel = MapUserRepository.ToRepository(command);
                var responseRepository = await _repository!.RegisterUser(repositoryModel);

                if (responseRepository.UserId == "")
                {
                    var error = new BaseError
                    {
                        code = "400",
                        message = "Erro ao cadastrar usuario.",
                    };

                    return new BaseReturn<CommandRegisterUser>().Error(EnumState.BUSINESS, error);
                }

                var response = MapUserRepository.ToCommand(responseRepository);

                return new BaseReturn<CommandRegisterUser>().Success(response);

            }catch (Exception ex)
            {
                var error = new BaseError("500", ex.Message);
                return new BaseReturn<CommandRegisterUser>().Error(EnumState.SYSTEM, error);
            }
        }
    }
}
