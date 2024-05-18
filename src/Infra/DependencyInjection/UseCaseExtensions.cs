using api_cadastro.Application.Core.UseCases;
using api_cadastro.Application.Ports.Inbound.UseCases;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class UseCaseExtensions
    {
        public static void AddUseCaseExtensions(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseRegisterUser, UseCaseRegisterUser>();
        }
    }
}
