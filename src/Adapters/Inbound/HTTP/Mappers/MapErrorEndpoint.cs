using api_cadastro.Application.Domain.Dto.Base;

namespace api_cadastro.Adapters.Inbound.HTTP.Mappers
{
    public static class MapErrorEndpoint
    {
        public static IResult ToEndpointError(BaseError? error)
        {
            return error!.code == "500" ? Results.Json(error, statusCode: StatusCodes.Status500InternalServerError) : Results.BadRequest(error);
        }

    }
}
