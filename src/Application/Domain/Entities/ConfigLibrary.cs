namespace api_cadastro.Application.Domain.Entities
{
    public record ConfigLibrary
    {
        //configurações de biblioteca para rastrabilidade
        public string LibraryId { get; set; }
        public string UserRootId { get; set; }
    }
}
