using api_cadastro.Application.Domain.ValueObjects;

namespace api_cadastro.Application.Domain.DTO.Command
{
    public record CommandRegisterBook
    {
        public Book? Book{ get; set; }
    }
}
