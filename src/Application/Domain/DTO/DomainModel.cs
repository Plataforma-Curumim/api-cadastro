namespace api_cadastro.Application.Domain.DTO
{
    public record DomainModel
    {
        public short tinStatus { get; set; }
        public string? pvchMsgIN { get; set; }
        public string? pvchMsgOUT { get; set; }
    }
}
