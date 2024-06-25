using api_cadastro.Application.Domain.Settings;

namespace api_cadastro.Infra.DependencyInjection
{
    public static class GlobalExtensions
    {
        public static void AddGlobalExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            configuration.GetSection("Database").Bind(databaseSettings);

            services.Configure<DatabaseSettings>(options => configuration.GetSection("Database").Bind(options));


            services.AddSwaggerGen();   
            services.AddEndpointsApiExplorer();
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
