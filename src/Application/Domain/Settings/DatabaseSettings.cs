namespace api_cadastro.Application.Domain.Settings
{
    public record DatabaseSettings
    {
        public string Cluster { get; set; }
        public string Banco { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DatabaseSettings()
        {
            
        }
    }
}
