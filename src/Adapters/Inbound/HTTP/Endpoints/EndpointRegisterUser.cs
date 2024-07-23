using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Adapters.Inbound.HTTP.Mappers;
using api_cadastro.Application.Domain.Enums;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class EndpointRegisterUser
    {
        public static void AddRegisterUser(this WebApplication app)
        {
            app.MapPost("/registerUser", RegisterUser)
                .WithTags("Cadastro de Usuário")
                .Accepts<RequestRegisterUser>("application/json")
                .Produces<RegisterUserResponse>(201)
                .Produces<BaseError>(400)
                .Produces<BaseError>(422)
                .Produces<BaseError>(500);


        }
        private static async Task<IResult> RegisterUser(IUseCaseRegisterUser useCase, HttpContext context, RequestRegisterUser request)
        {
            try
            {
                var mapper = MapperRegisterUser.ToDomain(request);
                var response = await useCase.Execute(mapper);

                if (response.State != EnumState.SUCCESS) return MapperErrorEndpoint.ToEndpointError(response.ErrorObject);

                var responseMap = MapperRegisterUser.ToResponse(response.SucessObject!);
                return Results.Ok(responseMap);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
