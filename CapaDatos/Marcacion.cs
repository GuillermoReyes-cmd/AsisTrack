// Clase de entidad generada con Scaffold-DbContext (EF Core - Database First) a partir de AsisTrackDB.
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public partial class Marcacion
    {
        public int MarcacionID { get; set; }
        public int ColaboradorID { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoMarcacion { get; set; }
        public string Estado { get; set; }
        public int MinutosTardanza { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Colaborador Colaborador { get; set; }
        public virtual ICollection<Justificacion> Justificacion { get; set; } = new List<Justificacion>();
    }
}
