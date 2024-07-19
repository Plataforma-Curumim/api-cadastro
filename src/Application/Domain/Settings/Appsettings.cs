namespace api_cadastro.Application.Domain.Settings
{
    public record Appsettings
    {
        public DatabaseSettings Database { get; set; }


        public Appsettings()
        {
            
        }
    }
}
