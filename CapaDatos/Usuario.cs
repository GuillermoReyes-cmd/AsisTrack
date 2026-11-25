// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Usuario
    {
        public int UsuarioID { get; set; }
        public int RolID { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Colaborador> Colaborador { get; set; } = new List<Colaborador>();
        public virtual ICollection<Justificacion> Justificacion { get; set; } = new List<Justificacion>();
    }
}
