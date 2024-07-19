using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Application.Domain.DTO.Sql
{
    public record RegisterBookSql
    {
        public string BookId { get; set; }
        public string DateOfRegister { get; set; }
        public string UserId { get; set; }
        public Book Book { get; set; }
    }
}
