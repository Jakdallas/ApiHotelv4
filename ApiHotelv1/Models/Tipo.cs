using System;
using System.Collections.Generic;

namespace ApiHotelv1.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Habitacion = new HashSet<Habitacion>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Habitacion> Habitacion { get; set; }
    }
}
