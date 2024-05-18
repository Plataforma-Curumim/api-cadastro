namespace api_cadastro.Application.Domain.ValueObjects
{
    public record Book
    {
        public string? BookId { get; set; }
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? PublishingCompany { get; set; }
        public int? YearOfPublication { get; set; }
        public string? Sinopse { get; set; }
        public string? Gender { get; set; }
        public string? Language { get; set; }
        public string? UrlImage { get; set; }
        public string? RfidId { get; set; }
    }
}
