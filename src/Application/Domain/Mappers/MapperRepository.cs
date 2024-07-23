using api_cadastro.Application.Domain.DTO;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Domain.DTO.Sql;

namespace api_cadastro.Application.Domain.Mappers
{
    public static class MapperRepository
    {
        public static DtoSql ToRepository(DomainModel domainModel)
        {
            return new DtoSql
            {
                pvchMsgIN = domainModel.pvchMsgIN,
                pvchMsgOUT = domainModel.pvchMsgOUT,
            };
        }
        public static DomainModel ToDomainModel(DomainModel domainModel, DtoSql dto)
        {
            domainModel.tinStatus = dto.tinStatus;
            domainModel.pvchMsgOUT = dto.pvchMsgOUT;

            return domainModel;
        }
    }
}
