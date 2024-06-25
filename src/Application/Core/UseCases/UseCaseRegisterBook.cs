using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.Mappers;
using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Application.Ports.Outbound.DB.Repository;

namespace api_cadastro.Application.Core.UseCases
{
    public class UseCaseRegisterBook : IUseCaseRegisterBook
    {
        private readonly IRegisterBookRepository? _repository;
        public UseCaseRegisterBook(IServiceProvider provider)
        {
            _repository = provider.GetService<IRegisterBookRepository>();
        }

        public async Task<BaseReturn<CommandRegisterBook>> Execute(CommandRegisterBook command)
        {
            try
            {
                var repositoryModel = MapBookRepository.ToRepository(command);
                var responseRepository = await _repository!.RegisterBook(repositoryModel);

                if (responseRepository.BookId == "")
                {
                    var error = new BaseError
                    {
                        code = "500",
                        message = "Erro ao cadastrar livro.",
                    };

                    return new BaseReturn<CommandRegisterBook>().Error(EnumState.BUSINESS, error);

                }

                var response = MapBookRepository.ToCommand(responseRepository);
                return new BaseReturn<CommandRegisterBook>().Success(response);

            } catch (Exception ex)
            {
                var error = new BaseError("500", ex.Message);
                return new BaseReturn<CommandRegisterBook>().Error(EnumState.SYSTEM, error);

            }

        }
    }
}
