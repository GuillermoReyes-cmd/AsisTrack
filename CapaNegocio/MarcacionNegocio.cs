using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class MarcacionNegocio
    {
        private MarcacionDAO mDAO = new MarcacionDAO();
        private ColaboradorDAO cDAO = new ColaboradorDAO();
        private TurnoDAO tDAO = new TurnoDAO();
        private TurnoNegocio tNegocio = new TurnoNegocio();

        // Las horas extra se cuentan solo si el colaborador sale 30 minutos o más después del fin de su turno.
        public const int MinutosMinimosHoraExtra = 30;

        // Minutos de diferencia entre la última salida registrada y el fin oficial del turno
        // (positivo = se quedó después de la hora; negativo = salió antes).
        public int MinutosDespuesDelFin { get; private set; }

        public Marcacion UltimaReciente(int colaboradorId)
        {
            return mDAO.UltimaDesde(colaboradorId, DateTime.Now.AddHours(-20));
        }
        public Marcacion BuscarMarcacionPorId(int id)
        {
            return mDAO.BuscarMarcacionPorId(id);
        }
        public void CalcularTardanza(Marcacion marcacion, Turno turno)
        {
            DateTime inicioOficial = marcacion.FechaHora.Date + turno.HoraInicio;
            if (tNegocio.CruzaMedianoche(turno) && marcacion.FechaHora.TimeOfDay < turno.HoraFin)
            {
                inicioOficial = inicioOficial.AddDays(-1);
            }
            int minutos = (int)Math.Floor((marcacion.FechaHora - inicioOficial).TotalMinutes);
            if (minutos < 0)
            {
                minutos = 0;
            }
            marcacion.MinutosTardanza = minutos;
            if (minutos > turno.ToleranciaMinutos)
            {
                marcacion.Estado = "Tarde";
            }
            else
            {
                marcacion.Estado = "Puntual";
            }
        }
        public DateTime FinOficial(DateTime ingreso, Turno turno)
        {
            DateTime inicio = ingreso.Date + turno.HoraInicio;
            if (tNegocio.CruzaMedianoche(turno) && ingreso.TimeOfDay < turno.HoraFin)
            {
                inicio = inicio.AddDays(-1);
            }
            DateTime fin = inicio.Date + turno.HoraFin;
            if (tNegocio.CruzaMedianoche(turno))
            {
                fin = fin.AddDays(1);
            }
            return fin;
        }
        public string DescribirSalida(int minutosDespuesDelFin)
        {
            if (minutosDespuesDelFin >= MinutosMinimosHoraExtra)
            {
                return "Salida con horas extra: " + (minutosDespuesDelFin / 60) + " h " +
                       (minutosDespuesDelFin % 60).ToString("00") + " min";
            }
            if (minutosDespuesDelFin >= 0)
            {
                return "Salida puntual (sin horas extra)";
            }
            return "Salida antes del fin del turno (" + (-minutosDespuesDelFin) + " min antes)";
        }
        public int Registrar(Marcacion objMarcacion)
        {
            Colaborador colaborador = cDAO.BuscarColaboradorPorId(objMarcacion.ColaboradorID);
            if (colaborador == null || colaborador.Estado == false)
            {
                return -3;
            }
            Marcacion ultima = UltimaReciente(objMarcacion.ColaboradorID);
            if (objMarcacion.TipoMarcacion == "Ingreso" && ultima != null && ultima.TipoMarcacion == "Ingreso")
            {
                return -4;
            }
            if (objMarcacion.TipoMarcacion == "Salida" && (ultima == null || ultima.TipoMarcacion == "Salida"))
            {
                return -4;
            }
            objMarcacion.FechaHora = DateTime.Now;
            if (objMarcacion.TipoMarcacion == "Ingreso")
            {
                Turno turno = tDAO.BuscarTurnoPorId(colaborador.TurnoID);
                CalcularTardanza(objMarcacion, turno);
            }
            else
            {
                objMarcacion.Estado = "Puntual";
                objMarcacion.MinutosTardanza = 0;
                Turno turno = tDAO.BuscarTurnoPorId(colaborador.TurnoID);
                DateTime fin = FinOficial(ultima.FechaHora, turno);
                MinutosDespuesDelFin = (int)Math.Floor((objMarcacion.FechaHora - fin).TotalMinutes);
            }
            objMarcacion.CreatedAt = objMarcacion.FechaHora;
            return mDAO.Insertar(objMarcacion);
        }
    }
}
