using api_cadastro.Application.Domain.DTO.Sql;

namespace api_cadastro.Application.Ports.Outbound.DB.Repository
{
    public interface IRegisterUserRepository
    {
        public Task<RegisterUserSql> RegisterUser(RegisterUserSql command);
    }
}
