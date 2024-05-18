using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Application.Domain.Dto.Command;

namespace api_cadastro.Adapters.Inbound.HTTP.Mapping
{
    public static class MapRegisterUser
    {
        public static CommandRegisterUser ToCommand(RegisterUserRequest request)
        {
            return new CommandRegisterUser
            {
                User = request.User,
                ConfigUserLibrary = request.ConfigUserLibrary,
            };
        }
    }
}
