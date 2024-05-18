using api_cadastro.Application.Domain.Enums;

namespace api_cadastro.Application.Domain.ValueObjects
{
    public record User
    {
        public string? Name { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? NumberPhone { get; set; }
        public string? Address { get; set; }
        public string? IdRfid { get; set; }
        public EnumStateUser StateUser { get; set; }
        public EnumTypeUser TypeUser { get; set; }
    }
}
