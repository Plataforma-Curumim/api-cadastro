using api_cadastro.Adapters.Outbound.DB.Postgres;
using api_cadastro.Application.Ports.Outbound.DB;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class RespositoryExtensions
    {
        public static void AddRepositoryExtension(this IServiceCollection service)
        {
            service.AddSingleton<IDBConnection, PostgresConnection>();
            service.AddSingleton<IDBRepository, PostgresRepository>();
        }
    }
}
