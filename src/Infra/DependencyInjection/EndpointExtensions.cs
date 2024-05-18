using api_cadastro.Adapters.Inbound.HTTP.Routes;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class EndpointExtensions
    {
        public static void UseEndpointExtentions(this WebApplication app)
        {
            app.AddRegisterUser();
        }
    }
}
