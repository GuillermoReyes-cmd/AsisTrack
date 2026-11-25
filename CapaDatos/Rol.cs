// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Rol
    {
        public int RolID { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
    }
}
