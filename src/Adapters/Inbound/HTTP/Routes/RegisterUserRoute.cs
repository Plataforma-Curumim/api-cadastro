using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Adapters.Inbound.HTTP.Mappers;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class RegisterUserRoute
    {
        public static void AddRegisterUser(this WebApplication app)
        {
            app.MapPost("/registerUser", RegisterUser)
                .Accepts<RegisterUserRequest>("application/json")
                .Produces<RegisterUserResponse>(201)
                .Produces<BaseError>(400)
                .Produces<BaseError>(401)
                .Produces<BaseError>(404)
                .Produces<BaseError>(422)
                .Produces<BaseError>(500);


        }
        private static async Task<IResult> RegisterUser(IUseCaseRegisterUser useCase, HttpContext context, RegisterUserRequest request)
        {
            try
            {
                var response = await useCase.Execute(MapRegisterUser.ToCommand(request));
                return Results.Json(response, statusCode: 200);
            }
            catch (Exception ex)
            {
                return new BaseReturn().SystemError(ex).GetResponse();
            }
        }
    }
}
