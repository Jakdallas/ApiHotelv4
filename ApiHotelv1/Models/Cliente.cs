using System;
using System.Collections.Generic;

namespace ApiHotelv1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Alquiler = new HashSet<Alquiler>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public ICollection<Alquiler> Alquiler { get; set; }
    }
}
