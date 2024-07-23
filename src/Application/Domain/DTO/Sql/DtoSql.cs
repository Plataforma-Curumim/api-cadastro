namespace api_cadastro.Application.Domain.DTO.Sql
{
    public record DtoSql
    {
        public short tinStatus { get; set; }
        public string? pvchMsgIN { get; set; }
        public string? pvchMsgOUT { get; set; }
    }
}
