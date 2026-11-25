using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class RolNegocio
    {
        private RolDAO rDAO = new RolDAO();

        public List<Rol> ListarTodo()
        {
            return rDAO.ListarTodo();
        }
        public List<Rol> ListarActivos()
        {
            return rDAO.ListarActivos();
        }
        public DataTable ListarTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Rol");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Estado");
            foreach (Rol r in rDAO.ListarTodo())
            {
                dt.Rows.Add(r.RolID, r.NombreRol, r.Descripcion, r.Estado ? "Activo" : "Inactivo");
            }
            return dt;
        }
        public Rol BuscarRolPorId(int id)
        {
            return rDAO.BuscarRolPorId(id);
        }
        bool NombreRolExiste(string NombreRol, int id)
        {
            return rDAO.NombreRolExiste(NombreRol, id);
        }
        public int Insertar(Rol objRol)
        {
            if (NombreRolExiste(objRol.NombreRol, -1))
            {
                return -2;
            }
            objRol.CreatedAt = DateTime.Now;
            return rDAO.Insertar(objRol);
        }
        public int Modificar(Rol objRol)
        {
            if (NombreRolExiste(objRol.NombreRol, objRol.RolID))
            {
                return -2;
            }
            objRol.ModifiedAt = DateTime.Now;
            return rDAO.Modificar(objRol);
        }
        public List<string> ObtenerPermisos(Rol rol)
        {
            List<string> permisos = new List<string>();
            if (rol == null)
            {
                return permisos;
            }
            string nombre = rol.NombreRol.ToLower();
            if (nombre.StartsWith("administrador"))
            {
                permisos.Add("MANT_COLABORADORES");
                permisos.Add("MANT_TURNOS");
                permisos.Add("MANT_USUARIOS");
                permisos.Add("MARCACION");
                permisos.Add("JUSTIFICACIONES");
                permisos.Add("REPORTES");
                permisos.Add("HISTORIAL");
            }
            else if (nombre.StartsWith("jefatura"))
            {
                permisos.Add("MARCACION");
                permisos.Add("JUSTIFICACIONES");
                permisos.Add("REPORTES");
                permisos.Add("HISTORIAL");
            }
            else if (nombre.StartsWith("marcaci"))
            {
                permisos.Add("MARCACION");
            }
            else
            {
                permisos.Add("MARCACION");
                permisos.Add("HISTORIAL");
            }
            return permisos;
        }
    }
}
