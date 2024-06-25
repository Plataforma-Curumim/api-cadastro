using api_cadastro.Adapters.Outbound.Rest.DTO;

namespace api_cadastro.Application.Ports.Outbound.Rest
{
    public interface IRestImplementation
    {
        public Task<GetBookResponse> GetBookIsbn(string isbn);
    }
}
