using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class JustificacionDAO
    {
        public List<Justificacion> ListarPorFechas(DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Justificacion.Where(j => j.FechaFin >= desde &&
                                                        j.FechaInicio <= hasta).
                                             OrderByDescending(j => j.FechaInicio).ToList();
            }
        }
        public List<Justificacion> ListarPorEstado(string estado, DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Justificacion.Where(j => j.EstadoAprobacion == estado &&
                                                        j.FechaFin >= desde &&
                                                        j.FechaInicio <= hasta).
                                             OrderByDescending(j => j.FechaInicio).ToList();
            }
        }
        public int Insertar(Justificacion objJustificacion)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Justificacion.Add(objJustificacion);
                context.SaveChanges();
                return objJustificacion.JustificacionID;
            }
        }
        public int Resolver(Justificacion objJustificacion)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_ResolverJustificacion (aprobar o rechazar)
                context.Database.ExecuteSqlRaw("EXEC sp_ResolverJustificacion @JustificacionID, @EstadoAprobacion, @UsuarioID",
                                               new SqlParameter("@JustificacionID", objJustificacion.JustificacionID),
                                               new SqlParameter("@EstadoAprobacion", objJustificacion.EstadoAprobacion),
                                               new SqlParameter("@UsuarioID", objJustificacion.AprobadoPor));
                return objJustificacion.JustificacionID;
            }
        }
        public Justificacion BuscarJustificacionPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Justificacion.Find(id);
            }
        }
        public List<Justificacion> ListarAprobadas(DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Justificacion.Where(j => j.EstadoAprobacion == "Aprobado" &&
                                                        j.FechaFin >= desde &&
                                                        j.FechaInicio <= hasta).ToList();
            }
        }
    }
}
