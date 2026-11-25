using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public class MarcacionDAO
    {
        public int Insertar(Marcacion objMarcacion)
        {
            using (var context = new AsisTrackDBContext())
            {
                context.Marcacion.Add(objMarcacion);
                context.SaveChanges();
                return objMarcacion.MarcacionID;
            }
        }
        public Marcacion BuscarMarcacionPorId(int id)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Marcacion.Find(id);
            }
        }
        public Marcacion UltimaDesde(int colaboradorId, DateTime desde)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_UltimaMarcacion (valida si toca ingreso o salida)
                return context.Marcacion.FromSqlRaw("EXEC sp_UltimaMarcacion @ColaboradorID, @Desde",
                                                    new SqlParameter("@ColaboradorID", colaboradorId),
                                                    new SqlParameter("@Desde", desde)).
                                         AsEnumerable().FirstOrDefault();
            }
        }
        public List<Marcacion> ListarPorRango(DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_ListarMarcacionesPorRango (base de los reportes)
                return context.Marcacion.FromSqlRaw("EXEC sp_ListarMarcacionesPorRango @Desde, @Hasta",
                                                    new SqlParameter("@Desde", desde),
                                                    new SqlParameter("@Hasta", hasta)).ToList();
            }
        }
        public List<Marcacion> ListarPorColaborador(int colaboradorId, DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                return context.Marcacion.Where(m => m.ColaboradorID == colaboradorId &&
                                                    m.FechaHora >= desde &&
                                                    m.FechaHora < hasta).
                                         OrderBy(m => m.FechaHora).ToList();
            }
        }
        public List<Marcacion> ListarTardanzas(DateTime desde, DateTime hasta)
        {
            using (var context = new AsisTrackDBContext())
            {
                // Procedimiento almacenado: sp_ListarTardanzas (reporte de tardanzas por área)
                return context.Marcacion.FromSqlRaw("EXEC sp_ListarTardanzas @Desde, @Hasta",
                                                    new SqlParameter("@Desde", desde),
                                                    new SqlParameter("@Hasta", hasta)).ToList();
            }
        }
    }
}
