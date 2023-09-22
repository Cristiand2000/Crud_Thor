using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Cita
    {
        public int IdCitas { get; set; }
        public int? IdCliente { get; set; }
        public TimeSpan? Hora { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Recomendacion { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
