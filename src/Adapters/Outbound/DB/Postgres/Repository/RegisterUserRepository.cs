using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Dto.Command;
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
        public async Task<BaseReturn> RegisterUser(CommandRegisterUser command)
        {
            using (NpgsqlTransaction transaction = _connection.BeginTransaction())
            {
                NpgsqlCommand cmd = new NpgsqlCommand("sps_registerUser", _connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pvchUserId", NpgsqlDbType.Varchar, command.User!.UserId!);
                cmd.Parameters.AddWithValue("pvchName", NpgsqlDbType.Varchar, command.User!.Name!);
                cmd.Parameters.AddWithValue("pvchCpfCnpj", NpgsqlDbType.Varchar, command.User!.CpfCnpj!);
                cmd.Parameters.AddWithValue("pvchEmail", NpgsqlDbType.Varchar, command.User!.Email!);
                cmd.Parameters.AddWithValue("pvchUsername", NpgsqlDbType.Varchar, command.User!.Username!);
                cmd.Parameters.AddWithValue("pvchPassword", NpgsqlDbType.Varchar, command.User!.Password!);
                cmd.Parameters.AddWithValue("pdatDateOfBirth", NpgsqlDbType.Date, command.User!.DateOfBirth!);
                cmd.Parameters.AddWithValue("pvchNumberPhone", NpgsqlDbType.Varchar, command.User!.NumberPhone!);
                cmd.Parameters.AddWithValue("pvchAddress", NpgsqlDbType.Varchar, command.User!.Address!);
                cmd.Parameters.AddWithValue("pvchIdRfid", NpgsqlDbType.Varchar, command.User!.IdRfid!);
                cmd.Parameters.AddWithValue("psmlStateUser", NpgsqlDbType.Smallint, command.User!.StateUser!);
                cmd.Parameters.AddWithValue("psmlTypeUser", NpgsqlDbType.Smallint, command.User!.TypeUser!);

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
