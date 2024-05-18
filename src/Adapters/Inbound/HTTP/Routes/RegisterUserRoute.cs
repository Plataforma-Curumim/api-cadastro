using api_cadastro.Adapters.Inbound.HTTP.Mapping;
using api_cadastro.Application.Domain.Base;
using api_cadastro.Application.Ports.Inbound.UseCases;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;

namespace api_cadastro.Adapters.Inbound.HTTP.Routes
{
    public static class RegisterUserRoute
    {
        public static void AddRegisterUser(this WebApplication app)
        {
            app.MapPost("/cadastrar-usuario", RegisterUser);
        }
        private static async Task<IResult> RegisterUser(IUseCaseRegisterUser useCase, HttpContext context, RequestRegisterUser request)
        {
            try
            {
                var response = await useCase.Execute(MapRegisterUser.ToCommand(request));
                return response.GetResponse();
            }
            catch (Exception ex)
            {
                return new BaseReturn().ErroSistema(ex).GetResponse();
            }
        }
    }
}
