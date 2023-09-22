using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Empleado
    {
        public int Cedula { get; set; }
        public string? Empleado1 { get; set; }
        public int? CodigoRoles { get; set; }

        public virtual Role? CodigoRolesNavigation { get; set; }
    }
}
