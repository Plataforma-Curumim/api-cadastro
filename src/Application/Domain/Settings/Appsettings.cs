namespace api_cadastro.Application.Domain.Settings
{
    public record Appsettings
    {
        public DatabaseSettings Database { get; set; }
        public RestSettings restSettings { get; set; }


        public Appsettings()
        {
            
        }
    }
}
