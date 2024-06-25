using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Domain.DTO.Sql;

namespace api_cadastro.Application.Domain.Mappers
{
    public static class MapBookRepository
    {
        public static RegisterBookSql ToRepository(CommandRegisterBook command)
        {
            return new RegisterBookSql
            {
                UserId = command.UserId,
                Book = command.Book!
            };
        }
        public static CommandRegisterBook ToCommand(RegisterBookSql model)
        {
            return new CommandRegisterBook
            {
                Book = model.Book,
                UserId = model.UserId,
                BookId = model.BookId,
                DateRegister = DateTime.Parse(model.DateOfRegister)
            };
        }
    }
}
