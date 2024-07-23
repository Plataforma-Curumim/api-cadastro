using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Adapters.Inbound.HTTP.Mappers;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Enums;
using api_cadastro.Application.Ports.Inbound.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class EndpointRegisterBook
    {
        public static void AddRegisterBook(this WebApplication app)
        {
            app.MapPost("/registerBook", RegisterBook)
                .WithTags("Cadastrar Livro")
                .Accepts<RequestRegisterBook>("application/json")
                .Produces<RegisterBookResponse>(201)
                .Produces<BaseError>(400)
                .Produces<BaseError>(422)
                .Produces<BaseError>(500);


        }
        private static async Task<IResult> RegisterBook([FromServices]IUseCaseRegisterBook useCase,
                                                        [FromBody]RequestRegisterBook request,
                                                        HttpContext context)
        {
            try
            {
                var mapper = MapperRegisterBook.ToDomain(request);
                var response = await useCase.Execute(mapper);

                if (response.State != EnumState.SUCCESS) return MapperErrorEndpoint.ToEndpointError(response.ErrorObject);

                var responseMap = MapperRegisterBook.ToResponse(response.SucessObject!);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }
    }
}
