using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class TurnoNegocio
    {
        private TurnoDAO tDAO = new TurnoDAO();

        public List<Turno> ListarTodo()
        {
            return tDAO.ListarTodo();
        }
        public List<Turno> ListarActivos()
        {
            return tDAO.ListarActivos();
        }
        public DataTable ListarTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Inicio");
            dt.Columns.Add("Fin");
            dt.Columns.Add("Toler.", typeof(int));
            dt.Columns.Add("Estado");
            foreach (Turno t in tDAO.ListarTodo())
            {
                dt.Rows.Add(t.TurnoID, t.NombreTurno, t.HoraInicio.ToString(@"hh\:mm"), t.HoraFin.ToString(@"hh\:mm"),
                            t.ToleranciaMinutos, t.Estado ? "Activo" : "Inactivo");
            }
            return dt;
        }
        public Turno BuscarTurnoPorId(int id)
        {
            return tDAO.BuscarTurnoPorId(id);
        }
        public string TextoTurno(Turno turno)
        {
            return turno.NombreTurno + " (" + turno.HoraInicio.ToString(@"hh\:mm") + " - " + turno.HoraFin.ToString(@"hh\:mm") + ")";
        }
        public bool CruzaMedianoche(Turno turno)
        {
            return turno.HoraFin <= turno.HoraInicio;
        }
        bool NombreTurnoExiste(string NombreTurno, int id)
        {
            return tDAO.NombreTurnoExiste(NombreTurno, id);
        }
        bool TieneColaboradores(int id)
        {
            return tDAO.CantidadColaboradoresActivos(id) > 0;
        }
        public int Insertar(Turno objTurno)
        {
            if (objTurno.HoraInicio == objTurno.HoraFin)
            {
                return -4;
            }
            if (NombreTurnoExiste(objTurno.NombreTurno, -1))
            {
                return -2;
            }
            objTurno.CreatedAt = DateTime.Now;
            return tDAO.Insertar(objTurno);
        }
        public int Modificar(Turno objTurno)
        {
            if (objTurno.HoraInicio == objTurno.HoraFin)
            {
                return -4;
            }
            if (NombreTurnoExiste(objTurno.NombreTurno, objTurno.TurnoID))
            {
                return -2;
            }
            if (objTurno.Estado == false && TieneColaboradores(objTurno.TurnoID))
            {
                return -3;
            }
            objTurno.ModifiedAt = DateTime.Now;
            return tDAO.Modificar(objTurno);
        }
        public int EliminarLogico(int id, int modificadoPor)
        {
            if (TieneColaboradores(id))
            {
                return -3;
            }
            tDAO.EliminarLogico(id, modificadoPor);
            return id;
        }
    }
}
