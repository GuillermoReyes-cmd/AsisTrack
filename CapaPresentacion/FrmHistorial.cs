using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmHistorial : Form
    {
        private ReporteNegocio repNegocio = new ReporteNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private TurnoNegocio tNegocio = new TurnoNegocio();
        private UsuarioNegocio uNegocio = new UsuarioNegocio();
        private ResultadoHistorial resultado;

        public FrmHistorial()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvHistorial);
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime hoy = DateTime.Now.Date;
                dtpHasta.Value = hoy;
                dtpDesde.Value = hoy.AddDays(-14);

                bool soloPropio = !Sesion.TienePermiso("REPORTES");
                if (soloPropio)
                {
                    List<Colaborador> lista = new List<Colaborador>();
                    int propio = uNegocio.ColaboradorVinculado(Sesion.UsuarioID);
                    if (propio > 0)
                    {
                        lista.Add(cNegocio.BuscarColaboradorPorId(propio));
                    }
                    MostrarColaboradores(lista);
                    cboColaborador.Enabled = false;
                }
                else
                {
                    MostrarColaboradores(cNegocio.ListarTodo());
                }
                if (cboColaborador.Items.Count > 0)
                {
                    cboColaborador.SelectedIndex = 0;
                }
                if (cboColaborador.Items.Count > 0) btnGenerar_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los datos.", ex);
            }
        }

        private void MostrarColaboradores(List<Colaborador> lista)
        {
            cboColaborador.DataSource = lista;
            cboColaborador.ValueMember = "ColaboradorID";
            cboColaborador.DisplayMember = "NombreCompleto";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Colaborador c = cboColaborador.SelectedItem as Colaborador;
            if (c == null)
            {
                Estilos.Aviso("Seleccione un colaborador.");
                return;
            }
            if (dtpHasta.Value.Date < dtpDesde.Value.Date)
            {
                Estilos.Aviso("La fecha 'Hasta' no puede ser menor que 'Desde'.");
                return;
            }
            try
            {
                resultado = repNegocio.Historial(c.ColaboradorID, dtpDesde.Value, dtpHasta.Value);
                dgvHistorial.DataSource = resultado.Detalle;
                Estilos.ColorearEstado(dgvHistorial, "Estado");
                dgvHistorial.ClearSelection();
                Turno t = tNegocio.BuscarTurnoPorId(c.TurnoID);
                lblTitulo.Text = "DNI: " + c.DNI + "   ·   Turno: " + tNegocio.TextoTurno(t) + "   ·   Departamento: " + c.Departamento;
                lblResumen.Text = "Total horas efectivas: " + Periodo.HorasMinutos(resultado.HorasEfectivas) + " h   ·   Tardanzas: " +
                                  resultado.Tardanzas + " (" + resultado.MinutosTardanza + " min)   ·   Inasistencias: " +
                                  resultado.Inasistencias + " (" + resultado.InasistenciasJustificadas + " justificadas)";
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo generar el historial.", ex);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Colaborador c = cboColaborador.SelectedItem as Colaborador;
            Exportador.ExportarCsv(resultado == null ? null : resultado.Detalle, "Historial_" + (c == null ? "" : c.DNI));
        }
    }
}
