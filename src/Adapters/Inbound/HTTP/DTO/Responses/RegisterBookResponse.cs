using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Responses
{
    public record RegisterBookResponse
    {
        public string? BookId { get; set; }
        public DateTime DateRegister { get; set; }
        //public Book? Book { get; set; }
    }
}
