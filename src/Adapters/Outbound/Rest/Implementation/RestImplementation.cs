using api_cadastro.Adapters.Outbound.Rest.DTO;
using api_cadastro.Application.Domain.Settings;
using api_cadastro.Application.Ports.Outbound.Rest;
using Flurl.Http;

namespace api_cadastro.Adapters.Outbound.Rest.Implementation
{
    public class RestImplementation : IRestImplementation
    {
        private FlurlRequest _flurlRequest;
        public RestImplementation(RestSettings settings)
        {
            _flurlRequest = new FlurlRequest(settings.OpenLibraryUrl);
        }

        public async Task<GetBookResponse> GetBookIsbn(string isbn)
        {
            _flurlRequest.AppendPathSegment(isbn + ".json");
            return await _flurlRequest.GetJsonAsync<GetBookResponse>();           
        }
    }
}
