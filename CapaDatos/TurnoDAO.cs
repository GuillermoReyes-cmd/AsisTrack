using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TurnoDAO
    {
        public List<Turno> ListarTodo()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Turno.OrderBy(t => t.TurnoID).ToList();
            }
        }
        public List<Turno> ListarActivos()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Turno.Where(t => t.Estado == true).OrderBy(t => t.TurnoID).ToList();
            }
        }
        public int Insertar(Turno objTurno)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Turno.Add(objTurno);
                context.SaveChanges();
                return objTurno.TurnoID;
            }
        }
        public int Modificar(Turno objTurno)
        {
            using (var context = new AsisTrackDBContext())
            {
                Turno tTemp = context.Turno.Find(objTurno.TurnoID);
                tTemp.NombreTurno = objTurno.NombreTurno;
                tTemp.HoraInicio = objTurno.HoraInicio;
                tTemp.HoraFin = objTurno.HoraFin;
                tTemp.ToleranciaMinutos = objTurno.ToleranciaMinutos;
                tTemp.Estado = objTurno.Estado;
                tTemp.ModifiedBy = objTurno.ModifiedBy;
                tTemp.ModifiedAt = objTurno.ModifiedAt;
                context.SaveChanges();
                return objTurno.TurnoID;
            }
        }
        public bool NombreTurnoExiste(string NombreTurno, int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                List<Turno> lista = context.Turno.
                                    Where(t => t.NombreTurno.Equals(NombreTurno) &&
                                               t.TurnoID != id).ToList();
                return lista.Count > 0;
            }
        }
        public Turno BuscarTurnoPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Turno.Find(id);
            }
        }
        public void EliminarLogico(int id, int modificadoPor)
        {
            using (var context = new AsisTrackDBContext())
            {
                Turno tTemp = context.Turno.Find(id);
                tTemp.Estado = false;
                tTemp.ModifiedBy = modificadoPor;
                tTemp.ModifiedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
        public int CantidadColaboradoresActivos(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Colaborador.Where(c => c.TurnoID == id && c.Estado == true).Count();
            }
        }
    }
}
