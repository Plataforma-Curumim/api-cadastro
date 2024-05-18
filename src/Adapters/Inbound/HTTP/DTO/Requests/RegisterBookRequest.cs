using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Requests
{
    public record RegisterBookRequest
    {
        [Required(ErrorMessage = "As informações do livro são obrigatórias")]
        public Book? Book { get; set; }
    }
}
