using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.DTO;
using System.Text.Json;

namespace api_cadastro.Adapters.Inbound.HTTP.Mappers
{
    public static class MapperRegisterUser
    {
        public static DomainModel ToDomain(RequestRegisterUser request)
        {
            return new DomainModel
            {
                pvchMsgIN = JsonSerializer.Serialize(request)
            };
        }
        public static RegisterUserResponse ToResponse(DomainModel domainModel)
        {
            RegisterUserResponse response = JsonSerializer.Deserialize<RegisterUserResponse>(domainModel.pvchMsgOUT!) ?? new();
            return response;
        }
    }
}
