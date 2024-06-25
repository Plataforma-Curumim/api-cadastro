namespace api_cadastro.Adapters.Inbound.HTTP.DTO.Responses
{
    public record RegisterBookIsbnResponse
    {
        public string Title { get; set; }
        public List<string> Publishers { get; set; }
        public string Publish_date { get; set; }
        public string Isbn_10 { get; set; }
        public string Isbn_13 { get; set; }
        public string Physical_dimensions { get; set; }
        public string Subtitle { get; set; }
        public List<string> Publish_places { get; set; }
        public int Number_of_pages { get; set; }
    }
}
