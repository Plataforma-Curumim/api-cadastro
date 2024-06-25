using api_cadastro.Application.Domain.Entities;
using api_cadastro.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Requests
{
    public record RegisterUserRequest
    {
        [Required(ErrorMessage = "As informações do usuario são obrigatórias")]
        public User? User{ get; set; }
        public ConfigUserLibrary? ConfigUserLibrary { get; set; }

    }
}
