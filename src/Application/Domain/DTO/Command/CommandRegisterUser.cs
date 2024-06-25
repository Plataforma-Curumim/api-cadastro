using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Application.Domain.Dto.Command
{
    public record CommandRegisterUser
    {
        public User? User { get; set; }
        public ConfigUserLibrary? ConfigUserLibrary { get; set; }

    }
}
