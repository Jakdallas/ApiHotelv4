using ApiHotelv1.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotelv1.DataProvider
{
    public class ClienteDataProvider:IClienteDataProvider
    {
        private readonly string connectionString = "Server=DESKTOP-CVA4KO0;Database=DBHOTELV1;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddCliente(Cliente oCliente)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Nombre", oCliente.Nombre);
                dynamicParameters.Add("@Apellido", oCliente.Apellido);
                dynamicParameters.Add("@FechaNac", oCliente.FechaNac);
                dynamicParameters.Add("@Sexo", oCliente.Sexo);
                dynamicParameters.Add("@Correo", oCliente.Correo);
                dynamicParameters.Add("@Contrasena", oCliente.Contrasena);
                await sqlConnection.ExecuteAsync(
                    "spAddCliente",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteCliente(int IdCliente)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ClienteId", IdCliente);
                await sqlConnection.ExecuteAsync(
                    "spDeleteCliente",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Cliente> GetCliente(int IdCliente)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdCliente", IdCliente);
                return await sqlConnection.QuerySingleOrDefaultAsync<Cliente>(
                    "spGetCliente",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Cliente>(
                    "spGetClientes",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateCliente(Cliente oCliente)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdCLiente", oCliente.IdCliente);
                dynamicParameters.Add("@Nombre", oCliente.Nombre);
                dynamicParameters.Add("@Apellido", oCliente.Apellido);
                dynamicParameters.Add("@FechaNac", oCliente.FechaNac);
                dynamicParameters.Add("@Sexo", oCliente.Sexo);
                dynamicParameters.Add("@Correo", oCliente.Correo);
                dynamicParameters.Add("@Contrasena", oCliente.Contrasena);
                await sqlConnection.ExecuteAsync(
                    "spUpdateCliente",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Cliente> GetLogin(string Correo, string Contrasena)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Correo", Correo);
                dynamicParameters.Add("@Contrasena", Contrasena);
                return await sqlConnection.QuerySingleOrDefaultAsync<Cliente>(
                    "spGetLogin",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
