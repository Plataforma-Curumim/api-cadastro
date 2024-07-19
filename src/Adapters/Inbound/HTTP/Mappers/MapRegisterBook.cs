using api_cadastro.Adapters.Inbound.HTTP.DTO.Requests;
using api_cadastro.Adapters.Inbound.HTTP.DTO.Responses;
using api_cadastro.Application.Domain.DTO.Command;

namespace api_cadastro.Adapters.Inbound.HTTP.Mappers
{
    public static class MapRegisterBook
    {
        public static CommandRegisterBook ToCommand(RegisterBookRequest request)
        {
            return new CommandRegisterBook
            {
                Book = request.Book,
                config = request.Config,
            };
        }

        public static RegisterBookResponse ToResponse(CommandRegisterBook response)
        {
            return new RegisterBookResponse
            {
                BookId = response.BookId,
                DateRegister = response.DateRegister
            };
        }
    }
}
