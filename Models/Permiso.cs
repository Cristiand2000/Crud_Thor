using System;
using System.Collections.Generic;

namespace CrudThor1.Models
{
    public partial class Permiso
    {
        public Permiso()
        {
            Roles = new HashSet<Role>();
        }

        public int IdPermiso { get; set; }
        public string Permisos { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}
