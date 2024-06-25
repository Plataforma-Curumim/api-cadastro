using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Application.Domain.DTO.Command
{
    public record CommandRegisterBook
    {
        public Book? Book{ get; set; }
        public string UserId { get; set; }
        public string? BookId { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
