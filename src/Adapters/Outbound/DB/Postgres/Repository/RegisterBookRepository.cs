using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.DTO.Command;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using api_cadastro.Application.Ports.Outbound.DB.Repository;
using Npgsql;
using NpgsqlTypes;

namespace api_cadastro.Adapters.Outbound.DB.Postgres.Repository
{
    public class RegisterBookRepository : IRegisterBookRepository
    {
        private readonly IDBConnection _dbConnection;
        private readonly NpgsqlConnection _connection;

        public RegisterBookRepository(IServiceProvider provider)
        {
            _dbConnection = provider.GetRequiredService<IDBConnection>();
            _connection = _dbConnection.GetConnection();
        }

        public async Task<BaseReturn> RegisterBook(CommandRegisterBook command)
        {
            using (NpgsqlTransaction transaction = _connection.BeginTransaction())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("sps_registerBook", _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pvchBookId", NpgsqlDbType.Varchar, command.Book!.BookId!);
                cmd.Parameters.AddWithValue("pvchIsbn", NpgsqlDbType.Varchar, command.Book!.Isbn!);
                cmd.Parameters.AddWithValue("pvchTitle", NpgsqlDbType.Varchar, command.Book!.Title!);
                cmd.Parameters.AddWithValue("pvchAuthor", NpgsqlDbType.Varchar, command.Book!.Author!);
                cmd.Parameters.AddWithValue("pvchPublishingCompany", NpgsqlDbType.Varchar, command.Book!.PublishingCompany!);
                cmd.Parameters.AddWithValue("psmlYearOfPublication", NpgsqlDbType.Smallint, command.Book!.YearOfPublication!);
                cmd.Parameters.AddWithValue("pvchSinopse", NpgsqlDbType.Varchar, command.Book!.Sinopse!);
                cmd.Parameters.AddWithValue("pvchGender", NpgsqlDbType.Varchar, command.Book!.Gender!);
                cmd.Parameters.AddWithValue("pvchLanguage", NpgsqlDbType.Varchar, command.Book!.Language!);
                cmd.Parameters.AddWithValue("pvchUrlImage", NpgsqlDbType.Varchar, command.Book!.UrlImage!);
                cmd.Parameters.AddWithValue("pvchRfidId", NpgsqlDbType.Varchar, command.Book!.RfidId!);
                try
                {
                    var response = cmd.ExecuteReader();
                    transaction.Commit();
                    return new BaseReturn().Success(response);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Commit();
                    return new BaseReturn().BusinessError(ex.Message);
                }
            }
        }
    }
}
