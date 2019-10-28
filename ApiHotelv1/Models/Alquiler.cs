using System;
using System.Collections.Generic;

namespace ApiHotelv1.Models
{
    public partial class Alquiler
    {
        public int IdAlquiler { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Habitacion IdHabitacionNavigation { get; set; }
        public Vendedor IdVendedorNavigation { get; set; }
    }
}
