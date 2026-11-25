using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class ResultadoAusentismo
    {
        public int Justificadas { get; set; }
        public int NoJustificadas { get; set; }
        public DataTable Detalle { get; set; }
        public int Total
        {
            get { return Justificadas + NoJustificadas; }
        }
    }

    public class ResultadoHistorial
    {
        public DataTable Detalle { get; set; }
        public double HorasEfectivas { get; set; }
        public int Tardanzas { get; set; }
        public int MinutosTardanza { get; set; }
        public int Inasistencias { get; set; }
        public int InasistenciasJustificadas { get; set; }
    }

    public class ReporteNegocio
    {
        private MarcacionDAO mDAO = new MarcacionDAO();
        private ColaboradorDAO cDAO = new ColaboradorDAO();
        private TurnoDAO tDAO = new TurnoDAO();
        private JustificacionDAO jDAO = new JustificacionDAO();
        private TurnoNegocio tNegocio = new TurnoNegocio();

        public DataTable TardanzasPorArea(DateTime desde, DateTime hasta, string area)
        {
            List<Colaborador> colaboradores = cDAO.ListarTodo();
            List<Marcacion> tardanzas = mDAO.ListarTardanzas(desde.Date, hasta.Date.AddDays(1));
            List<string> areas = new List<string>();
            List<int> cantidades = new List<int>();
            List<int> minutos = new List<int>();
            foreach (Marcacion m in tardanzas)
            {
                Colaborador c = BuscarEnLista(colaboradores, m.ColaboradorID);
                if (c == null || (area != "" && c.Departamento != area))
                {
                    continue;
                }
                int pos = areas.IndexOf(c.Departamento);
                if (pos == -1)
                {
                    areas.Add(c.Departamento);
                    cantidades.Add(0);
                    minutos.Add(0);
                    pos = areas.Count - 1;
                }
                cantidades[pos] = cantidades[pos] + 1;
                minutos[pos] = minutos[pos] + m.MinutosTardanza;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Área");
            dt.Columns.Add("Tardanzas", typeof(int));
            dt.Columns.Add("Minutos acumulados", typeof(int));
            while (areas.Count > 0)
            {
                int mayor = 0;
                for (int i = 1; i < areas.Count; i++)
                {
                    if (cantidades[i] > cantidades[mayor])
                    {
                        mayor = i;
                    }
                }
                dt.Rows.Add(areas[mayor], cantidades[mayor], minutos[mayor]);
                areas.RemoveAt(mayor);
                cantidades.RemoveAt(mayor);
                minutos.RemoveAt(mayor);
            }
            return dt;
        }

        public ResultadoAusentismo Ausentismo(DateTime desde, DateTime hasta, string departamento)
        {
            DateTime hoy = DateTime.Today;
            DateTime fin = hasta.Date;
            if (fin >= hoy)
            {
                fin = hoy.AddDays(-1);
            }
            DataTable detalle = new DataTable();
            detalle.Columns.Add("Fecha");
            detalle.Columns.Add("Colaborador");
            detalle.Columns.Add("Departamento");
            detalle.Columns.Add("Tipo");
            ResultadoAusentismo res = new ResultadoAusentismo();
            res.Detalle = detalle;
            if (fin < desde.Date)
            {
                return res;
            }

            List<Marcacion> marcaciones = mDAO.ListarPorRango(desde.Date, fin.AddDays(1));
            List<Justificacion> aprobadas = jDAO.ListarAprobadas(desde.Date, fin);
            foreach (Colaborador c in cDAO.ListarActivos())
            {
                if (departamento != "" && c.Departamento != departamento)
                {
                    continue;
                }
                for (DateTime d = desde.Date; d <= fin; d = d.AddDays(1))
                {
                    if (!EsDiaHabil(d) || d < c.CreatedAt.Date)
                    {
                        continue;
                    }
                    if (TieneIngreso(marcaciones, c.ColaboradorID, d))
                    {
                        continue;
                    }
                    bool justificada = EstaJustificada(aprobadas, c.ColaboradorID, d);
                    if (justificada)
                    {
                        res.Justificadas++;
                    }
                    else
                    {
                        res.NoJustificadas++;
                    }
                    detalle.Rows.Add(d.ToString("dd/MM/yyyy"), c.NombreCompleto, c.Departamento,
                                     justificada ? "Justificada" : "No justificada");
                }
            }
            return res;
        }

        public DataTable HorasExtras(DateTime desde, DateTime hasta, string departamento)
        {
            List<Colaborador> colaboradores = cDAO.ListarActivos();
            List<Turno> turnos = tDAO.ListarTodo();
            List<Marcacion> marcaciones = mDAO.ListarPorRango(desde.Date, hasta.Date.AddDays(2));

            List<string> deps = new List<string>();
            List<int> cantidad = new List<int>();
            List<double> horas = new List<double>();
            foreach (Colaborador c in colaboradores)
            {
                if (departamento != "" && c.Departamento != departamento)
                {
                    continue;
                }
                Turno turno = BuscarTurno(turnos, c.TurnoID);
                double extra = 0;
                for (int i = 0; i < marcaciones.Count; i++)
                {
                    Marcacion ing = marcaciones[i];
                    if (ing.ColaboradorID != c.ColaboradorID || ing.TipoMarcacion != "Ingreso" || ing.FechaHora.Date > hasta.Date)
                    {
                        continue;
                    }
                    Marcacion sal = BuscarSalida(marcaciones, i);
                    if (sal == null)
                    {
                        continue;
                    }
                    DateTime finOficial = InicioOficial(ing.FechaHora, turno).Date + turno.HoraFin;
                    if (tNegocio.CruzaMedianoche(turno))
                    {
                        finOficial = finOficial.AddDays(1);
                    }
                    double h = (sal.FechaHora - finOficial).TotalHours;
                    if (h * 60 >= MarcacionNegocio.MinutosMinimosHoraExtra)
                    {
                        extra = extra + h;
                    }
                }
                int pos = deps.IndexOf(c.Departamento);
                if (pos == -1)
                {
                    deps.Add(c.Departamento);
                    cantidad.Add(0);
                    horas.Add(0);
                    pos = deps.Count - 1;
                }
                cantidad[pos] = cantidad[pos] + 1;
                horas[pos] = horas[pos] + extra;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Departamento");
            dt.Columns.Add("N.° colaboradores", typeof(int));
            dt.Columns.Add("Horas extras (h)", typeof(decimal));
            dt.Columns.Add("Promedio (h)", typeof(decimal));
            List<string> ordenados = new List<string>(deps);
            ordenados.Sort();
            int totalColab = 0;
            double totalHoras = 0;
            foreach (string dep in ordenados)
            {
                int pos = deps.IndexOf(dep);
                dt.Rows.Add(dep, cantidad[pos], Math.Round((decimal)horas[pos], 1),
                            Math.Round((decimal)(horas[pos] / cantidad[pos]), 1));
                totalColab = totalColab + cantidad[pos];
                totalHoras = totalHoras + horas[pos];
            }
            if (totalColab > 0)
            {
                dt.Rows.Add("TOTAL", totalColab, Math.Round((decimal)totalHoras, 1),
                            Math.Round((decimal)(totalHoras / totalColab), 1));
            }
            return dt;
        }

        public ResultadoHistorial Historial(int colaboradorId, DateTime desde, DateTime hasta)
        {
            Colaborador col = cDAO.BuscarColaboradorPorId(colaboradorId);
            Turno turno = tDAO.BuscarTurnoPorId(col.TurnoID);
            DateTime hoy = DateTime.Today;
            List<Marcacion> marcaciones = mDAO.ListarPorColaborador(colaboradorId, desde.Date, hasta.Date.AddDays(2));
            List<Justificacion> aprobadas = jDAO.ListarAprobadas(desde.Date, hasta.Date);

            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Ingreso");
            dt.Columns.Add("Salida");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Min. tardanza");
            dt.Columns.Add("Horas efectivas");
            ResultadoHistorial res = new ResultadoHistorial();
            res.Detalle = dt;

            for (DateTime d = desde.Date; d <= hasta.Date; d = d.AddDays(1))
            {
                int idx = -1;
                for (int i = 0; i < marcaciones.Count; i++)
                {
                    if (idx == -1 && marcaciones[i].TipoMarcacion == "Ingreso" &&
                        InicioOficial(marcaciones[i].FechaHora, turno).Date == d)
                    {
                        idx = i;
                    }
                }
                if (idx != -1)
                {
                    Marcacion ing = marcaciones[idx];
                    Marcacion sal = BuscarSalida(marcaciones, idx);
                    string horasTxt = "—";
                    string salidaTxt = "—";
                    if (sal != null)
                    {
                        double h = (sal.FechaHora - ing.FechaHora).TotalHours;
                        res.HorasEfectivas = res.HorasEfectivas + h;
                        horasTxt = Periodo.HorasMinutos(h);
                        salidaTxt = sal.FechaHora.ToString("HH:mm");
                    }
                    if (ing.Estado == "Tarde")
                    {
                        res.Tardanzas++;
                        res.MinutosTardanza = res.MinutosTardanza + ing.MinutosTardanza;
                    }
                    dt.Rows.Add(d.ToString("dd/MM/yyyy"), ing.FechaHora.ToString("HH:mm"), salidaTxt, ing.Estado,
                                ing.MinutosTardanza.ToString(), horasTxt);
                }
                else if (EsDiaHabil(d) && d < hoy && d >= col.CreatedAt.Date)
                {
                    bool justificada = EstaJustificada(aprobadas, colaboradorId, d);
                    res.Inasistencias++;
                    if (justificada)
                    {
                        res.InasistenciasJustificadas++;
                    }
                    dt.Rows.Add(d.ToString("dd/MM/yyyy"), "—", "—", justificada ? "Falta (justif.)" : "Falta", "—", "—");
                }
            }
            return res;
        }

        public bool EsDiaHabil(DateTime d)
        {
            return d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday;
        }
        Colaborador BuscarEnLista(List<Colaborador> lista, int id)
        {
            foreach (Colaborador c in lista)
            {
                if (c.ColaboradorID == id)
                {
                    return c;
                }
            }
            return null;
        }
        Turno BuscarTurno(List<Turno> lista, int id)
        {
            foreach (Turno t in lista)
            {
                if (t.TurnoID == id)
                {
                    return t;
                }
            }
            return null;
        }
        bool TieneIngreso(List<Marcacion> marcaciones, int colaboradorId, DateTime d)
        {
            foreach (Marcacion m in marcaciones)
            {
                if (m.ColaboradorID == colaboradorId && m.TipoMarcacion == "Ingreso" && m.FechaHora.Date == d)
                {
                    return true;
                }
            }
            return false;
        }
        bool EstaJustificada(List<Justificacion> aprobadas, int colaboradorId, DateTime d)
        {
            foreach (Justificacion j in aprobadas)
            {
                if (j.ColaboradorID == colaboradorId && d >= j.FechaInicio.Date && d <= j.FechaFin.Date)
                {
                    return true;
                }
            }
            return false;
        }
        DateTime InicioOficial(DateTime ingreso, Turno turno)
        {
            DateTime inicio = ingreso.Date + turno.HoraInicio;
            if (tNegocio.CruzaMedianoche(turno) && ingreso.TimeOfDay < turno.HoraFin)
            {
                inicio = inicio.AddDays(-1);
            }
            return inicio;
        }
        Marcacion BuscarSalida(List<Marcacion> lista, int indiceIngreso)
        {
            if (indiceIngreso + 1 >= lista.Count)
            {
                return null;
            }
            Marcacion ing = lista[indiceIngreso];
            Marcacion sig = lista[indiceIngreso + 1];
            if (sig.ColaboradorID != ing.ColaboradorID || sig.TipoMarcacion != "Salida")
            {
                return null;
            }
            if ((sig.FechaHora - ing.FechaHora).TotalHours > 20)
            {
                return null;
            }
            return sig;
        }
    }
}
