using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Programacion
    {
        public int IdProgramacion { get; set; }
        public int ClaseId { get; set; }
        public DateTime FechaProgramacion { get; set; }
        public string Instructor { get; set; } = null!;
        public bool? DiaLaboral { get; set; }
        public bool? Estado { get; set; }

        public virtual Clase Clase { get; set; } = null!;
    }
}
