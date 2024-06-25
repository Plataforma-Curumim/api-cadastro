using api_cadastro.Application.Domain.DTO.Sql;
using api_cadastro.Application.Ports.Outbound.DB.Connection;
using api_cadastro.Application.Ports.Outbound.DB.Repository;
using Npgsql;
using NpgsqlTypes;
using System.Data;

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

                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchName", msgIn.User!.Name!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchCpfCnpj", msgIn.User!.CpfCnpj!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchEmail", msgIn.User!.Email!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchUsername", msgIn.User!.Username!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchPassword", msgIn.User!.Password!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pdatDateOfBirth", msgIn.User!.DateOfBirth!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchNumberPhone", msgIn.User!.NumberPhone!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchAddress", msgIn.User!.Address!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("pvchIdRfid", msgIn.User!.IdRfid!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("psmlStateUser", msgIn.User!.StateUser!));
                cmd.Parameters.AddWithValue(new NpgsqlParameter("psmlTypeUser", msgIn.User!.TypeUser!));

                NpgsqlParameter pvchUserId = new NpgsqlParameter("pvchUserId", NpgsqlDbType.Varchar, 1000, "", ParameterDirection.Output, false, new byte(), new byte(), new DataRowVersion(), msgIn.UserId!);
                NpgsqlParameter pdatDateOfRegister = new NpgsqlParameter("pdatDateOfRegister", NpgsqlDbType.Date, 1000, "", ParameterDirection.Output, false, new byte(), new byte(), new DataRowVersion(), msgIn.DateOfRegister!);

                cmd.Parameters.AddWithValue(pvchUserId);
                cmd.Parameters.AddWithValue(pdatDateOfRegister);
                cmd.Prepare();

                var response = cmd.ExecuteReader();
                transaction.Commit();

                msgIn.UserId = cmd.Parameters.FirstOrDefault(pvchUserId).Value.ToString() ?? "";
                msgIn.DateOfRegister = cmd.Parameters.FirstOrDefault(pdatDateOfRegister).Value.ToString() ?? "";

                return msgIn;
                
            }
        }
    }
}
