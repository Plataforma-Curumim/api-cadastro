using api_cadastro.Adapters.Outbound.DB.Postgres.Connection;
using api_cadastro.Adapters.Outbound.DB.Postgres.Repository;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using api_cadastro.Application.Ports.Outbound.DB.Repository;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class RespositoryExtensions
    {
        public static void AddRepositoryExtension(this IServiceCollection service)
        {
            service.AddSingleton<IDBConnection, PostgresConnection>();
            service.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            service.AddScoped<IRegisterBookRepository, RegisterBookRepository>();   
        }
    }
}
