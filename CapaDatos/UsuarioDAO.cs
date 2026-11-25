using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class UsuarioDAO
    {
        public List<Usuario> ListarTodo()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Usuario.OrderBy(u => u.UsuarioID).ToList();
            }
        }
        public int Insertar(Usuario objUsuario)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Usuario.Add(objUsuario);
                context.SaveChanges();
                return objUsuario.UsuarioID;
            }
        }
        public int Modificar(Usuario objUsuario)
        {
            using (var context = new AsisTrackDBContext())
            {
                Usuario uTemp = context.Usuario.Find(objUsuario.UsuarioID);
                uTemp.RolID = objUsuario.RolID;
                uTemp.NombreCompleto = objUsuario.NombreCompleto;
                uTemp.NombreUsuario = objUsuario.NombreUsuario;
                uTemp.Correo = objUsuario.Correo;
                uTemp.Contrasena = objUsuario.Contrasena;
                uTemp.Estado = objUsuario.Estado;
                uTemp.ModifiedBy = objUsuario.ModifiedBy;
                uTemp.ModifiedAt = objUsuario.ModifiedAt;
                context.SaveChanges();
                return objUsuario.UsuarioID;
            }
        }
        public bool NombreUsuarioExiste(string NombreUsuario, int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                List<Usuario> lista = context.Usuario.
                                    Where(u => u.NombreUsuario.Equals(NombreUsuario) &&
                                               u.UsuarioID != id).ToList();
                return lista.Count > 0;
            }
        }
        public Usuario BuscarUsuarioPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Usuario.Find(id);
            }
        }
        public Usuario BuscarPorNombreUsuario(string NombreUsuario)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_BuscarUsuarioPorNombre (se usa en el inicio de sesión)
                return context.Usuario.FromSqlRaw("EXEC sp_BuscarUsuarioPorNombre @NombreUsuario",
                                                  new SqlParameter("@NombreUsuario", NombreUsuario)).
                                       AsEnumerable().FirstOrDefault();
            }
        }
        public void EliminarLogico(int id, int modificadoPor)
        {
            using (var context = new AsisTrackDBContext())
            {
                Usuario uTemp = context.Usuario.Find(id);
                uTemp.Estado = false;
                uTemp.ModifiedBy = modificadoPor;
                uTemp.ModifiedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
