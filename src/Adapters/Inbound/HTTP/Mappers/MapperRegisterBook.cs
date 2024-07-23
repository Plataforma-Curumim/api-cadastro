using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.DTO;
using api_cadastro.Application.Domain.DTO.Command;
using System.Text.Json;

namespace api_cadastro.Adapters.Inbound.HTTP.Mappers
{
    public static class MapperRegisterBook
    {
        public static DomainModel ToDomain(RequestRegisterBook request)
        {
            return new DomainModel
            {
                pvchMsgIN = JsonSerializer.Serialize(request)
            };
        }

        public static RegisterBookResponse ToResponse(DomainModel domainModel)
        {
            RegisterBookResponse response = JsonSerializer.Deserialize<RegisterBookResponse>(domainModel.pvchMsgOUT!) ?? new();
            return response;
        }
    }
}
