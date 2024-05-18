using api_cadastro.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_cadastro.Application.Domain.ValueObjects
{
    public record User
    {
        public string? UserId { get; set; }
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Cpf/Cnpj do usuário obrigatório")]
        public string? CpfCnpj { get; set; }
        [Required(ErrorMessage = "Email do usuário obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Username do usuário obrigatório")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Senha do usuário obrigatório")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Data de Nascimento do usuário obrigatório")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Numero de celular do usuário obrigatório")]
        public string? NumberPhone { get; set; }
        [Required(ErrorMessage = "Endereço do usuário obrigatório")]
        public string? Address { get; set; }
        public string? IdRfid { get; set; }
        [Required(ErrorMessage = "Status do usuário obrigatório")]
        [EnumDataType(typeof(EnumStateUser), ErrorMessage = "Status do usuário deve ser uma das opções permitidas.")]
        public EnumStateUser StateUser { get; set; }

        [Required(ErrorMessage = "Tipo do usuário obrigatório")]
        [EnumDataType(typeof(EnumTypeUser), ErrorMessage = "Tipo do usuário deve ser uma das opções permitidas.")]
        public EnumTypeUser TypeUser { get; set; }
    }
}
