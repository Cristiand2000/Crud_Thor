using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdCliente { get; set; }
        public int? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        public string? Restricciones { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
