using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Command;
using api_cadastro.Application.Domain.DTO.Command;

namespace api_cadastro.Adapters.Inbound.HTTP.Mappers
{
    public static class MapRegisterUser
    {
        public static CommandRegisterUser ToCommand(RegisterUserRequest request)
        {
            return new CommandRegisterUser
            {
                User = request.User,
                Config = request.Config
            };
        }
        public static RegisterUserResponse ToResponse(CommandRegisterUser response)
        {
            return new RegisterUserResponse
            {
                DateRegister = response.DateRegister,
                UserId = response.UserId,
            };
        }
    }
}
