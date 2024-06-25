using api_cadastro.Application.Domain.DTO.Sql;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using api_cadastro.Application.Ports.Outbound.DB.Repository;
using Npgsql;
using NpgsqlTypes;

namespace api_cadastro.Adapters.Outbound.DB.Postgres.Repository
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly IDBConnection _dbConnection;
        private readonly NpgsqlConnection _connection;

        public RegisterUserRepository(IServiceProvider provider)
        {
            _dbConnection = provider.GetRequiredService<IDBConnection>();
            _connection = _dbConnection.GetConnection();
        }
        public async Task<RegisterUserSql> RegisterUser(RegisterUserSql msgIn)
        {
            using (NpgsqlTransaction transaction = _connection.BeginTransaction())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("sps_registerUser", _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pvchUserId", NpgsqlDbType.Varchar, msgIn.User!.UserId!);
                cmd.Parameters.AddWithValue("pvchName", NpgsqlDbType.Varchar, msgIn.User!.Name!);
                cmd.Parameters.AddWithValue("pvchCpfCnpj", NpgsqlDbType.Varchar, msgIn.User!.CpfCnpj!);
                cmd.Parameters.AddWithValue("pvchEmail", NpgsqlDbType.Varchar, msgIn.User!.Email!);
                cmd.Parameters.AddWithValue("pvchUsername", NpgsqlDbType.Varchar, msgIn.User!.Username!);
                cmd.Parameters.AddWithValue("pvchPassword", NpgsqlDbType.Varchar, msgIn.User!.Password!);
                cmd.Parameters.AddWithValue("pdatDateOfBirth", NpgsqlDbType.Date, msgIn.User!.DateOfBirth!);
                cmd.Parameters.AddWithValue("pvchNumberPhone", NpgsqlDbType.Varchar, msgIn.User!.NumberPhone!);
                cmd.Parameters.AddWithValue("pvchAddress", NpgsqlDbType.Varchar, msgIn.User!.Address!);
                cmd.Parameters.AddWithValue("pvchIdRfid", NpgsqlDbType.Varchar, msgIn.User!.IdRfid!);
                cmd.Parameters.AddWithValue("psmlStateUser", NpgsqlDbType.Smallint, msgIn.User!.StateUser!);
                cmd.Parameters.AddWithValue("psmlTypeUser", NpgsqlDbType.Smallint, msgIn.User!.TypeUser!);

                try
                {
                    var response = cmd.ExecuteReader();
                    transaction.Commit();

                    //get value dos parametros

                    return msgIn;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    transaction.Commit();

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
