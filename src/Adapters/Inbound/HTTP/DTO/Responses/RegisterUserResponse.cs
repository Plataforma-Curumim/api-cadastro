using api_cadastro.Application.Domain.ValueObjects;

namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Responses
{
    public record RegisterUserResponse
    {
        public string? UserId { get; set; }
        public DateTime DateCreate { get; set; }
        public User? User{ get; set; }
    }
}
