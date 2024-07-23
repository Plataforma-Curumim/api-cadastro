using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO;
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

        public async Task<BaseReturn<DomainModel>> Execute(DomainModel domainModel)
        {
            try
            {
                var repositoryModel = MapperRepository.ToRepository(domainModel);
                var responseRepository = await _repository!.RegisterBook(repositoryModel);

                if (responseRepository.tinStatus > 0)
                {
                    var error = new BaseError
                    {
                        code = "400",
                        message = "Erro ao cadastrar livro.",
                    };

                    return new BaseReturn<DomainModel>().Error(EnumState.BUSINESS, error);

                }

                var response = MapperRepository.ToDomainModel(domainModel, responseRepository);

                return new BaseReturn<DomainModel>().Success(response);

            } catch (Exception ex)
            {
                var error = new BaseError("500", ex.Message);
                return new BaseReturn<DomainModel>().Error(EnumState.SYSTEM, error);

            }

        }
    }
}
