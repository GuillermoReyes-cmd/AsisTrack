using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmReporteTardanzas : Form
    {
        private ReporteNegocio repNegocio = new ReporteNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private DataTable datos;

        public FrmReporteTardanzas()
        {
            InitializeComponent();
        }

        private void FrmReporteTardanzas_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
            try
            {
                DateTime hoy = DateTime.Now;
                cboPeriodo.DataSource = Periodo.UltimosMeses(hoy);
                cboPeriodo.SelectedIndex = Periodo.IndicePorDefecto(hoy);
                List<string> areas = new List<string> { "Todas" };
                areas.AddRange(cNegocio.Departamentos());
                cboArea.DataSource = areas;
                btnGenerar_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los filtros.", ex);
            }
        }

        private void ConfigurarGrafico()
        {
            ChartArea area = chartTardanzas.ChartAreas[0];
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.Title = "N.° de tardanzas";
            area.AxisX.Interval = 1;
            Series s = chartTardanzas.Series[0];
            s.Color = Estilos.Azul;
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            s["PointWidth"] = "0.6";
            s.IsXValueIndexed = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Periodo p = cboPeriodo.SelectedItem as Periodo;
            if (p == null) return;
            try
            {
                string area = cboArea.SelectedIndex > 0 ? cboArea.Text : "";
                datos = repNegocio.TardanzasPorArea(p.Desde, p.Hasta, area);
                Series s = chartTardanzas.Series[0];
                s.Points.Clear();
                int total = 0;
                foreach (DataRow r in datos.Rows)
                {
                    int n = Convert.ToInt32(r["Tardanzas"]);
                    int i = s.Points.AddY(n);
                    s.Points[i].AxisLabel = Convert.ToString(r["Área"]);
                    total += n;
                }
                lblTitulo.Text = "Tardanzas acumuladas por área — " + p;
                lblResumen.Text = datos.Rows.Count == 0
                    ? "No hay tardanzas registradas en el periodo."
                    : "Total de tardanzas en el periodo: " + total + "   ·   Área más impuntual: " + datos.Rows[0]["Área"];
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo generar el reporte.", ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarCsv(datos, "ReporteTardanzas");
        }
    }
}
