using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Clase
    {
        public Clase()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int ClaseId { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
