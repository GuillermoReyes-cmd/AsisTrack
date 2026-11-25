using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmReporteAusentismo : Form
    {
        private ReporteNegocio repNegocio = new ReporteNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private ResultadoAusentismo resultado;

        public FrmReporteAusentismo()
        {
            InitializeComponent();
        }

        private void FrmReporteAusentismo_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
            try
            {
                DateTime hoy = DateTime.Now;
                cboPeriodo.DataSource = Periodo.UltimosMeses(hoy);
                cboPeriodo.SelectedIndex = Periodo.IndicePorDefecto(hoy);
                List<string> deps = new List<string> { "Todos" };
                deps.AddRange(cNegocio.Departamentos());
                cboDepartamento.DataSource = deps;
                btnGenerar_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los filtros.", ex);
            }
        }

        private void ConfigurarGrafico()
        {
            Series s = chartAusentismo.Series[0];
            s.IsValueShownAsLabel = true;
            s.Label = "#PERCENT{P0}";
            s.LegendText = "#VALX: #VAL (#PERCENT{P0})";
            s.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            s.LabelForeColor = Color.White;
            Legend l = chartAusentismo.Legends[0];
            l.Docking = Docking.Right;
            l.Font = new Font("Segoe UI", 10.5F);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Periodo p = cboPeriodo.SelectedItem as Periodo;
            if (p == null) return;
            try
            {
                string dep = cboDepartamento.SelectedIndex > 0 ? cboDepartamento.Text : "";
                resultado = repNegocio.Ausentismo(p.Desde, p.Hasta, dep);
                Series s = chartAusentismo.Series[0];
                s.Points.Clear();
                if (resultado.Justificadas > 0)
                {
                    int a = s.Points.AddY(resultado.Justificadas);
                    s.Points[a].AxisLabel = "Justificadas";
                    s.Points[a].LegendText = "Justificadas: #VAL (#PERCENT{P0})";
                    s.Points[a].Color = Estilos.Verde;
                }
                if (resultado.NoJustificadas > 0)
                {
                    int b = s.Points.AddY(resultado.NoJustificadas);
                    s.Points[b].AxisLabel = "No justificadas";
                    s.Points[b].LegendText = "No justificadas: #VAL (#PERCENT{P0})";
                    s.Points[b].Color = Estilos.Rojo;
                }
                lblTitulo.Text = "Ausentismo del periodo — " + p;
                lblResumen.Text = resultado.Total == 0
                    ? "No hay inasistencias en el periodo."
                    : "Total de inasistencias: " + resultado.Total + "   ·   Justificadas: " + resultado.Justificadas +
                      "   ·   No justificadas: " + resultado.NoJustificadas + "   (días hábiles hasta ayer)";
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo generar el reporte.", ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarCsv(resultado == null ? null : resultado.Detalle, "ReporteAusentismo");
        }
    }
}
