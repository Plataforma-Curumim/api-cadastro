namespace api_cadastro.Application.Domain.Entities
{
    public record Book
    {
        public string RfidId { get; set; }
        public string BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Sinopse { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string UrlImage { get; set; }
        public List<string> Publishers { get; set; }
        public string PublishDate { get; set; }
        public string PhysicalDimensions { get; set; }
        public List<string> PublishPlaces { get; set; }
        public int NumberOfPages { get; set; }
    }
}
