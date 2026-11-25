using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RolDAO
    {
        public List<Rol> ListarTodo()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Rol.OrderBy(r => r.RolID).ToList();
            }
        }
        public List<Rol> ListarActivos()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Rol.Where(r => r.Estado == true).OrderBy(r => r.RolID).ToList();
            }
        }
        public int Insertar(Rol objRol)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Rol.Add(objRol);
                context.SaveChanges();
                return objRol.RolID;
            }
        }
        public int Modificar(Rol objRol)
        {
            using (var context = new AsisTrackDBContext())
            {
                Rol rTemp = context.Rol.Find(objRol.RolID);
                rTemp.NombreRol = objRol.NombreRol;
                rTemp.Descripcion = objRol.Descripcion;
                rTemp.Estado = objRol.Estado;
                rTemp.ModifiedBy = objRol.ModifiedBy;
                rTemp.ModifiedAt = objRol.ModifiedAt;
                context.SaveChanges();
                return objRol.RolID;
            }
        }
        public bool NombreRolExiste(string NombreRol, int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                List<Rol> lista = context.Rol.
                                    Where(r => r.NombreRol.Equals(NombreRol) &&
                                               r.RolID != id).ToList();
                return lista.Count > 0;
            }
        }
        public Rol BuscarRolPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Rol.Find(id);
            }
        }
    }
}
