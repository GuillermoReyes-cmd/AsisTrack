// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Colaborador
    {
        public int ColaboradorID { get; set; }
        public int TurnoID { get; set; }
        public int? UsuarioID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public bool Estado { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Turno Turno { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Justificacion> Justificacion { get; set; } = new List<Justificacion>();
        public virtual ICollection<Marcacion> Marcacion { get; set; } = new List<Marcacion>();
    }
}
