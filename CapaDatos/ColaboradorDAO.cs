using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class ColaboradorDAO
    {
        public List<Colaborador> ListarTodo()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Colaborador.OrderBy(c => c.ColaboradorID).ToList();
            }
        }
        public List<Colaborador> ListarActivos()
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Colaborador.Where(c => c.Estado == true).
                                           OrderBy(c => c.Apellidos).ToList();
            }
        }
        public int Insertar(Colaborador objColaborador)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Colaborador.Add(objColaborador);
                context.SaveChanges();
                return objColaborador.ColaboradorID;
            }
        }
        public int Modificar(Colaborador objColaborador)
        {
            using (var context = new AsisTrackDBContext())
            {
                Colaborador cTemp = context.Colaborador.Find(objColaborador.ColaboradorID);
                cTemp.TurnoID = objColaborador.TurnoID;
                cTemp.Nombres = objColaborador.Nombres;
                cTemp.Apellidos = objColaborador.Apellidos;
                cTemp.DNI = objColaborador.DNI;
                cTemp.Cargo = objColaborador.Cargo;
                cTemp.Departamento = objColaborador.Departamento;
                cTemp.Estado = objColaborador.Estado;
                cTemp.ModifiedBy = objColaborador.ModifiedBy;
                cTemp.ModifiedAt = objColaborador.ModifiedAt;
                context.SaveChanges();
                return objColaborador.ColaboradorID;
            }
        }
        public bool DniExiste(string DNI, int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                List<Colaborador> lista = context.Colaborador.
                                    Where(c => c.DNI.Equals(DNI) &&
                                               c.ColaboradorID != id).ToList();
                return lista.Count > 0;
            }
        }
        public Colaborador BuscarColaboradorPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Colaborador.Find(id);
            }
        }
        public Colaborador BuscarPorDni(string DNI)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_BuscarColaboradorPorDni (se usa en la marcación)
                return context.Colaborador.FromSqlRaw("EXEC sp_BuscarColaboradorPorDni @DNI",
                                                      new SqlParameter("@DNI", DNI)).
                                           AsEnumerable().FirstOrDefault();
            }
        }
        public Colaborador BuscarPorUsuario(int usuarioId)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Colaborador.Where(c => c.UsuarioID == usuarioId).FirstOrDefault();
            }
        }
        public void EliminarLogico(int id, int modificadoPor)
        {
            using (var context = new AsisTrackDBContext())
            {
                Colaborador cTemp = context.Colaborador.Find(id);
                cTemp.Estado = false;
                cTemp.ModifiedBy = modificadoPor;
                cTemp.ModifiedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
        public void AsignarTurno(int id, int turnoId, int modificadoPor)
        {
            using (var context = new AsisTrackDBContext())
            {
                Colaborador cTemp = context.Colaborador.Find(id);
                cTemp.TurnoID = turnoId;
                cTemp.ModifiedBy = modificadoPor;
                cTemp.ModifiedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
        public void AsignarUsuario(int id, int? usuarioId, int modificadoPor)
        {
            using (var context = new AsisTrackDBContext())
            {
                Colaborador cTemp = context.Colaborador.Find(id);
                cTemp.UsuarioID = usuarioId;
                cTemp.ModifiedBy = modificadoPor;
                cTemp.ModifiedAt = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
