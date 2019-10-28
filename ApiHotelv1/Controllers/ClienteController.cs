using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHotelv1.DataProvider;
using ApiHotelv1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiHotelv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteDataProvider oCLienteDataProvider;

        public ClienteController(IClienteDataProvider oCLienteDataProvider)
        {
            this.oCLienteDataProvider = oCLienteDataProvider;
        }
        // GET: api/Cliente
        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await this.oCLienteDataProvider.GetClientes();
        }

        [HttpGet("{IdCliente}")]
        public async Task<Cliente> Get(int IdCliente)
        {
            return await this.oCLienteDataProvider.GetCliente(IdCliente);
        }
        [HttpPost]
        public async Task Post([FromBody]Cliente oCliente)
        {
            await this.oCLienteDataProvider.AddCliente(oCliente);
        }

        [HttpGet("{Correo}/{Contrasena}")]
        public async Task Get( string Correo,  string Contrasena)
        {
            await this.oCLienteDataProvider.GetLogin(Correo, Contrasena);
        }

        [HttpPut("{IdCliente}")]
        public async Task Put(int IdCliente, [FromBody]Cliente oCliente)
        {
            await this.oCLienteDataProvider.UpdateCliente(oCliente);
        }

        [HttpDelete("{IdCliente}")]
        public async Task Delete(int IdCliente)
        {
            await this.oCLienteDataProvider.DeleteCliente(IdCliente);
        }


        // GET: api/Cliente/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Cliente
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Cliente/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
