using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Adapters.Inbound.HTTP.Mappers;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Ports.Inbound.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class RegisterBookRoute
    {
        public static void AddRegisterBook(this WebApplication app)
        {
            app.MapPost("/registerBook", RegisterBook)
                .Accepts<RegisterBookRequest>("application/json")
                .Produces<RegisterBookResponse>(201)
                .Produces<BaseError>(400)
                .Produces<BaseError>(422)
                .Produces<BaseError>(500);


        }
        private static async Task<IResult> RegisterBook([FromServices]IUseCaseRegisterBook useCase,
                                                        [FromBody]RegisterBookRequest request,
                                                        HttpContext context)
        {
            try
            {
                var response = await useCase.Execute(MapRegisterBook.ToCommand(request));

                if (response.State != EnumState.SUCCESS) return MapErrorEndpoint.ToEndpointError(response.ErrorObject);

                var responseMap = MapRegisterBook.ToResponse(response.SucessObject!);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
