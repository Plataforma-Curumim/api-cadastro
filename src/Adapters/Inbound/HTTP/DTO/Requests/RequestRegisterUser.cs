using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.ValueObjects;

namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Requests
{
    public record RequestRegisterUser
    {
        public User? User{ get; set; }
        public ConfigUserLibrary? ConfigUserLibrary { get; set; }

    }
}
