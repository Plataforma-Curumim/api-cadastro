using api_cadastro.Application.Ports.Outbound.Rest;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class RestExtensions
    {
        public static void AddRestExtension(this IServiceCollection service)
        {
            service.AddTransient<IRestImplementation, IRestImplementation>();
        }
    }
}
