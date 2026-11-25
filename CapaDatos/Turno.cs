// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Turno
    {
        public int TurnoID { get; set; }
        public string NombreTurno { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int ToleranciaMinutos { get; set; }
        public bool Estado { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Colaborador> Colaborador { get; set; } = new List<Colaborador>();
    }
}
