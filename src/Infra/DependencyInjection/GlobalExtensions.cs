namespace api_cadastro.Infra.DependencyInjection
{
    public static class GlobalExtensions
    {
        public static void AddGlobalExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUseCaseExtensions();
            services.AddRepositoryExtension();
        }

        public static void UseGlobalExtensions(this WebApplication app)
        {
           app.UseSwagger();
           app.UseSwaggerUI();
           app.UseEndpointExtentions();
        }
    }
}
