using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Application.Domain.Dto.Command
{
    public record CommandRegisterUser
    {
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime DateRegister { get; set; }
        public ConfigLibrary Config { get; set; }

    }
}
