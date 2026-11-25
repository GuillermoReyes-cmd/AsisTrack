using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmHorasExtras : Form
    {
        private ReporteNegocio repNegocio = new ReporteNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private DataTable datos;

        public FrmHorasExtras()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvHoras);
            dgvHoras.DataBindingComplete += dgvHoras_DataBindingComplete;
        }

        private void dgvHoras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn c in dgvHoras.Columns)
            {
                if (c.ValueType == typeof(decimal) || c.ValueType == typeof(int))
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (c.ValueType == typeof(decimal)) c.DefaultCellStyle.Format = "0.0";
            }
            foreach (DataGridViewRow r in dgvHoras.Rows)
            {
                if (Convert.ToString(r.Cells[0].Value) == "TOTAL")
                {
                    r.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
                    r.DefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);
                }
            }
            dgvHoras.ClearSelection();
        }

        private void FrmHorasExtras_Load(object sender, EventArgs e)
        {
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Periodo p = cboPeriodo.SelectedItem as Periodo;
            if (p == null) return;
            try
            {
                string dep = cboDepartamento.SelectedIndex > 0 ? cboDepartamento.Text : "";
                datos = repNegocio.HorasExtras(p.Desde, p.Hasta, dep);
                dgvHoras.DataSource = datos;
                dgvHoras.ClearSelection();
                lblTitulo.Text = "Consolidado de horas extras por departamento — " + p;
                lblResumen.Text = "Horas trabajadas después del fin del turno (se cuentan desde 30 min). Datos para la planilla mensual (RR.HH.).";
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo generar el reporte.", ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarCsv(datos, "ConsolidadoHorasExtras");
        }
    }
}
