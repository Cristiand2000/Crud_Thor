using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int CodigoRoles { get; set; }
        public string? Nombre { get; set; }
        public string? Permisos { get; set; }

        public virtual Permiso? PermisosNavigation { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
