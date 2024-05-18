using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Adapters.Inbound.HTTP.Mappers;
using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Ports.Inbound.UseCases;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class RegisterBookRoute
    {
        public static void AddRegisterBook(this WebApplication app)
        {
            app.MapPost("/cadastrar-livro", RegisterBook)
                .Accepts<RegisterBookRequest>("application/json")
                .Produces<RegisterBookResponse>(201)
                .Produces<BaseError>(400)
                .Produces<BaseError>(401)
                .Produces<BaseError>(404)
                .Produces<BaseError>(422)
                .Produces<BaseError>(500);


        }
        private static async Task<IResult> RegisterBook(IUseCaseRegisterBook useCase, HttpContext context, RegisterBookRequest request)
        {
            try
            {
                var response = await useCase.Execute(MapRegisterBook.ToCommand(request));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn().SystemError(ex).GetResponse();
            }
        }
    }
}
