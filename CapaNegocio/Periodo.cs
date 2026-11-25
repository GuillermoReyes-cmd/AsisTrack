using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Periodo
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public Periodo(int anio, int mes)
        {
            Desde = new DateTime(anio, mes, 1);
            Hasta = Desde.AddMonths(1).AddDays(-1);
        }
        public static string NombreMes(int mes)
        {
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio",
                               "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
            return meses[mes - 1];
        }
        public override string ToString()
        {
            return NombreMes(Desde.Month) + " " + Desde.Year;
        }
        public static List<Periodo> UltimosMeses(DateTime hoy)
        {
            List<Periodo> lista = new List<Periodo>();
            DateTime d = new DateTime(hoy.Year, hoy.Month, 1);
            for (int i = 0; i < 12; i++)
            {
                lista.Add(new Periodo(d.Year, d.Month));
                d = d.AddMonths(-1);
            }
            return lista;
        }
        public static int IndicePorDefecto(DateTime hoy)
        {
            if (hoy.Day < 10)
            {
                return 1;
            }
            return 0;
        }
        public static string FechaLarga(DateTime fecha)
        {
            string[] dias = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            return dias[(int)fecha.DayOfWeek] + ", " + fecha.Day + " de " + NombreMes(fecha.Month).ToLower() + " de " + fecha.Year;
        }
        public static string HorasMinutos(double horas)
        {
            int totalMin = (int)Math.Round(horas * 60);
            return (totalMin / 60).ToString("00") + ":" + (totalMin % 60).ToString("00");
        }
    }
}
