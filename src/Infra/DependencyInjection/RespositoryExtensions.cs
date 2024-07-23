namespace api_cadastro.Infra.DependencyInjection
{
    public static class RespositoryExtensions
    {
        public static void AddRepositoryExtension(this IServiceCollection service)
        {
            /*
            service.AddSingleton<IDBConnection, PostgresConnection>();
            service.AddScoped<IRegisterUserRepository, RepositoryRegisterUser>();
            service.AddScoped<IRegisterBookRepository, RepositoryRegisterBook>();  
            */
        }
    }
}
