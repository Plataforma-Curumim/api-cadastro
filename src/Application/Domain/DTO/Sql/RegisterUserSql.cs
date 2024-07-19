using api_cadastro.Application.Domain.Entities;

namespace api_cadastro.Application.Domain.DTO.Sql
{
    public record RegisterUserSql
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public string DateOfRegister { get; set; }

    }
}
