namespace api_cadastro.Adapters.Outbound.Rest.DTO
{
    public record GetBookResponse
    {
        public string title { get; set; }
        public List<string> publishers { get; set; }
        public string publish_date { get; set; }
        public string isbn_10 { get; set; }
        public string isbn_13 { get; set; }
        public string physical_dimensions { get; set; }
        public string subtitle { get; set; }
        public List<string> publish_places { get; set; }
        public int number_of_pages { get; set; }
    }
}
