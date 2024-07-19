using api_cadastro.Application.Domain.DTO.Sql;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using api_cadastro.Application.Ports.Outbound.DB.Repository;
using Npgsql;
using NpgsqlTypes;
using System.Data;

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

        public async Task<RegisterBookSql> RegisterBook(RegisterBookSql msgIn)
        {
            using (NpgsqlTransaction transaction = _connection.BeginTransaction())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("sps_registerBook", _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchUserId", msgIn.UserId!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchBookId", msgIn.Book!.BookId!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchIsbn", msgIn.Book!.Isbn!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchTitle", msgIn.Book!.Title!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchAuthor", msgIn.Book!.Author!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchPublishers", msgIn.Book!.Publishers!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("psmlPublishDate", msgIn.Book!.PublishDate!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchSinopse", msgIn.Book!.Sinopse!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchGender", msgIn.Book!.Gender!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchLanguage", msgIn.Book!.Language!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchUrlImage", msgIn.Book!.UrlImage!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchRfidId", msgIn.Book!.RfidId!));

                NpgsqlParameter pvchBookId = new NpgsqlParameter("pvchBookId", NpgsqlDbType.Varchar, 1000, "", ParameterDirection.Output, false, new byte(), new byte(), new DataRowVersion(), msgIn.Book!.BookId!);
                NpgsqlParameter pdatDateOfRegister = new NpgsqlParameter("pdatDateOfRegister", NpgsqlDbType.Date, 1000, "", ParameterDirection.Output, false, new byte(), new byte(), new DataRowVersion(), msgIn.DateOfRegister!);

                cmd.Parameters.AddWithValue(pvchBookId);
                cmd.Parameters.AddWithValue(pdatDateOfRegister);
                cmd.Prepare(); 

                var response = cmd.ExecuteReader();
                transaction.Commit();

                msgIn.BookId = cmd.Parameters.FirstOrDefault(pvchBookId).Value.ToString() ?? "";
                msgIn.DateOfRegister = cmd.Parameters.FirstOrDefault(pdatDateOfRegister).Value.ToString() ?? "";
                return msgIn;
            }
        }
    }
}
