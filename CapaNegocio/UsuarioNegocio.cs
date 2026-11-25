using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class UsuarioNegocio
    {
        private UsuarioDAO uDAO = new UsuarioDAO();
        private RolDAO rDAO = new RolDAO();
        private ColaboradorDAO cDAO = new ColaboradorDAO();

        public string CifrarContrasena(string texto)
        {
            SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
        public Usuario Autenticar(string nombreUsuario, string contrasena)
        {
            Usuario usuario = uDAO.BuscarPorNombreUsuario(nombreUsuario);
            if (usuario == null || usuario.Estado == false)
            {
                return null;
            }
            if (usuario.Contrasena.ToUpper() != CifrarContrasena(contrasena))
            {
                return null;
            }
            return usuario;
        }
        public DataTable ListarTabla(string filtro, int rolId)
        {
            List<Rol> roles = rDAO.ListarTodo();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Nombre completo");
            dt.Columns.Add("Rol");
            dt.Columns.Add("Estado");
            foreach (Usuario u in uDAO.ListarTodo())
            {
                if (filtro != "" && !u.NombreUsuario.ToLower().Contains(filtro.ToLower()) &&
                    !u.NombreCompleto.ToLower().Contains(filtro.ToLower()))
                {
                    continue;
                }
                if (rolId > 0 && u.RolID != rolId)
                {
                    continue;
                }
                string nombreRol = "";
                foreach (Rol r in roles)
                {
                    if (r.RolID == u.RolID)
                    {
                        nombreRol = r.NombreRol;
                    }
                }
                dt.Rows.Add(u.UsuarioID, u.NombreUsuario, u.NombreCompleto, nombreRol, u.Estado ? "Activo" : "Inactivo");
            }
            return dt;
        }
        public Usuario BuscarUsuarioPorId(int id)
        {
            return uDAO.BuscarUsuarioPorId(id);
        }
        bool NombreUsuarioExiste(string NombreUsuario, int id)
        {
            return uDAO.NombreUsuarioExiste(NombreUsuario, id);
        }
        public int Insertar(Usuario objUsuario)
        {
            if (NombreUsuarioExiste(objUsuario.NombreUsuario, -1))
            {
                return -2;
            }
            objUsuario.Contrasena = CifrarContrasena(objUsuario.Contrasena);
            objUsuario.CreatedAt = DateTime.Now;
            return uDAO.Insertar(objUsuario);
        }
        public int Modificar(Usuario objUsuario, bool cambiarContrasena)
        {
            if (NombreUsuarioExiste(objUsuario.NombreUsuario, objUsuario.UsuarioID))
            {
                return -2;
            }
            if (objUsuario.Estado == false && objUsuario.UsuarioID == objUsuario.ModifiedBy)
            {
                return -3;
            }
            if (cambiarContrasena)
            {
                objUsuario.Contrasena = CifrarContrasena(objUsuario.Contrasena);
            }
            else
            {
                objUsuario.Contrasena = uDAO.BuscarUsuarioPorId(objUsuario.UsuarioID).Contrasena;
            }
            objUsuario.ModifiedAt = DateTime.Now;
            return uDAO.Modificar(objUsuario);
        }
        public int EliminarLogico(int id, int modificadoPor)
        {
            if (id == modificadoPor)
            {
                return -3;
            }
            uDAO.EliminarLogico(id, modificadoPor);
            return id;
        }
        public void VincularColaborador(int usuarioId, int colaboradorId, int modificadoPor)
        {
            Colaborador actual = cDAO.BuscarPorUsuario(usuarioId);
            if (actual != null && actual.ColaboradorID != colaboradorId)
            {
                cDAO.AsignarUsuario(actual.ColaboradorID, null, modificadoPor);
            }
            if (colaboradorId > 0 && (actual == null || actual.ColaboradorID != colaboradorId))
            {
                cDAO.AsignarUsuario(colaboradorId, usuarioId, modificadoPor);
            }
        }
        public int ColaboradorVinculado(int usuarioId)
        {
            Colaborador colaborador = cDAO.BuscarPorUsuario(usuarioId);
            if (colaborador == null)
            {
                return 0;
            }
            return colaborador.ColaboradorID;
        }
        public string NombreDeUsuario(int? usuarioId)
        {
            if (usuarioId == null)
            {
                return "—";
            }
            Usuario usuario = uDAO.BuscarUsuarioPorId((int)usuarioId);
            if (usuario == null)
            {
                return usuarioId.ToString();
            }
            return usuario.NombreUsuario;
        }
    }
}
