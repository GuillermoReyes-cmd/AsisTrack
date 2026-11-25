// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Justificacion
    {
        public int JustificacionID { get; set; }
        public int ColaboradorID { get; set; }
        public int? MarcacionID { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoAprobacion { get; set; }
        public int? AprobadoPor { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Colaborador Colaborador { get; set; }
        public virtual Marcacion Marcacion { get; set; }
        public virtual Usuario AprobadoPorNavigation { get; set; }
    }
}
