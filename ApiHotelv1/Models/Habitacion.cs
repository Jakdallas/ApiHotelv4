using System;
using System.Collections.Generic;

namespace ApiHotelv1.Models
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            Alquiler = new HashSet<Alquiler>();
        }

        public int IdHabitacion { get; set; }
        public int? NumeroCamas { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? IdTipo { get; set; }
        public string Observacion { get; set; }

        public Tipo IdTipoNavigation { get; set; }
        public ICollection<Alquiler> Alquiler { get; set; }
    }
}
