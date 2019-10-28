using System;
using System.Collections.Generic;

namespace ApiHotelv1.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Alquiler = new HashSet<Alquiler>();
        }

        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public decimal? Sueldo { get; set; }

        public ICollection<Alquiler> Alquiler { get; set; }
    }
}
