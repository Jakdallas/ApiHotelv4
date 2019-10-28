using ApiHotelv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotelv1.DataProvider
{
    public interface IClienteDataProvider
    {
        Task<IEnumerable<Cliente>> GetClientes();

        Task<Cliente> GetCliente(int ClienteId);

        Task AddCliente(Cliente oCliente);

        Task UpdateCliente(Cliente oCliente);

        Task DeleteCliente(int ClienteId);

        Task<Cliente> GetLogin(string Correo, string Contrasena);
    }
}
