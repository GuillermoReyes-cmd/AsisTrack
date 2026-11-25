using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class ColaboradorNegocio
    {
        private ColaboradorDAO cDAO = new ColaboradorDAO();
        private TurnoDAO tDAO = new TurnoDAO();

        public List<Colaborador> ListarTodo()
        {
            return cDAO.ListarTodo();
        }
        public List<Colaborador> ListarActivos()
        {
            return cDAO.ListarActivos();
        }
        public DataTable ListarTabla(string filtro, string departamento)
        {
            List<Turno> turnos = tDAO.ListarTodo();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("DNI");
            dt.Columns.Add("Nombres");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Departamento");
            dt.Columns.Add("Turno");
            dt.Columns.Add("Estado");
            foreach (Colaborador c in cDAO.ListarTodo())
            {
                if (filtro != "" && !c.DNI.Contains(filtro) &&
                    !c.Nombres.ToLower().Contains(filtro.ToLower()) &&
                    !c.Apellidos.ToLower().Contains(filtro.ToLower()))
                {
                    continue;
                }
                if (departamento != "" && c.Departamento != departamento)
                {
                    continue;
                }
                string nombreTurno = "";
                foreach (Turno t in turnos)
                {
                    if (t.TurnoID == c.TurnoID)
                    {
                        nombreTurno = t.NombreTurno;
                    }
                }
                dt.Rows.Add(c.ColaboradorID, c.DNI, c.Nombres, c.Apellidos, c.Departamento,
                            nombreTurno, c.Estado ? "Activo" : "Inactivo");
            }
            return dt;
        }
        public List<string> Departamentos()
        {
            List<string> lista = new List<string>();
            foreach (Colaborador c in cDAO.ListarTodo())
            {
                if (!lista.Contains(c.Departamento))
                {
                    lista.Add(c.Departamento);
                }
            }
            lista.Sort();
            return lista;
        }
        public Colaborador BuscarColaboradorPorId(int id)
        {
            return cDAO.BuscarColaboradorPorId(id);
        }
        public Colaborador BuscarPorDni(string DNI)
        {
            return cDAO.BuscarPorDni(DNI);
        }
        bool DniExiste(string DNI, int id)
        {
            return cDAO.DniExiste(DNI, id);
        }
        public int Insertar(Colaborador objColaborador)
        {
            if (DniExiste(objColaborador.DNI, -1))
            {
                return -2;
            }
            objColaborador.CreatedAt = DateTime.Now;
            return cDAO.Insertar(objColaborador);
        }
        public int Modificar(Colaborador objColaborador)
        {
            if (DniExiste(objColaborador.DNI, objColaborador.ColaboradorID))
            {
                return -2;
            }
            objColaborador.ModifiedAt = DateTime.Now;
            return cDAO.Modificar(objColaborador);
        }
        public int EliminarLogico(int id, int modificadoPor)
        {
            cDAO.EliminarLogico(id, modificadoPor);
            return id;
        }
        public int AsignarTurno(int id, int turnoId, int modificadoPor)
        {
            Turno turno = tDAO.BuscarTurnoPorId(turnoId);
            if (turno.Estado == false)
            {
                return -3;
            }
            cDAO.AsignarTurno(id, turnoId, modificadoPor);
            return id;
        }
    }
}
