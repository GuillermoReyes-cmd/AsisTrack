using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmJustificaciones : Form
    {
        private JustificacionNegocio jNegocio = new JustificacionNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private UsuarioNegocio uNegocio = new UsuarioNegocio();
        private Justificacion seleccionada;
        private bool cargando;

        public FrmJustificaciones()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvJustificaciones);
        }

        private void FrmJustificaciones_Load(object sender, EventArgs e)
        {
            cboEstadoFiltro.Items.AddRange(new object[] { "Todos", "Pendiente", "Aprobado", "Rechazado" });
            cboEstadoFiltro.SelectedIndex = 1;
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today.AddDays(30);
            try
            {
                MostrarColaboradores(cNegocio.ListarActivos());
                CargarGrid();
                Nueva();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar las justificaciones.", ex);
            }
        }

        private void MostrarColaboradores(List<Colaborador> lista)
        {
            cboColaborador.DataSource = lista;
            cboColaborador.ValueMember = "ColaboradorID";
            cboColaborador.DisplayMember = "NombreCompleto";
            cboColaborador.SelectedIndex = -1;
        }

        private bool PuedeResolver()
        {
            return Sesion.RolActual != null &&
                   (Sesion.RolActual.NombreRol.StartsWith("Administrador") || Sesion.RolActual.NombreRol.StartsWith("Jefatura"));
        }

        private void CargarGrid()
        {
            cargando = true;
            string estado = cboEstadoFiltro.SelectedIndex > 0 ? cboEstadoFiltro.Text : "";
            dgvJustificaciones.DataSource = jNegocio.ListarTabla(estado, dtpDesde.Value, dtpHasta.Value);
            dgvJustificaciones.Columns["ID"].DefaultCellStyle.Format = "000";
            dgvJustificaciones.Columns["ID"].FillWeight = 40;
            dgvJustificaciones.Columns["Colaborador"].FillWeight = 170;
            dgvJustificaciones.Columns["Motivo"].FillWeight = 170;
            Estilos.ColorearEstado(dgvJustificaciones, "Estado");
            dgvJustificaciones.ClearSelection();
            cargando = false;
        }

        private void Nueva()
        {
            seleccionada = null;
            cboColaborador.Enabled = true;
            cboColaborador.SelectedIndex = -1;
            txtMotivo.ReadOnly = false;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;
            txtMotivo.Clear();
            dtpInicio.Value = DateTime.Today;
            dtpFin.Value = DateTime.Today;
            MostrarEstado("Nueva");
            lblAprobadoPor.Text = "—";
            ucAuditoria.Limpiar();
            btnGuardar.Enabled = true;
            btnAprobar.Enabled = false;
            btnRechazar.Enabled = false;
        }

        private void MostrarEstado(string estado)
        {
            lblEstado.Text = estado;
            Color fondo = SystemColors.Control;
            Color texto = Color.Black;
            if (estado == "Pendiente")
            {
                fondo = Color.FromArgb(255, 243, 205);
                texto = Estilos.Ambar;
            }
            else if (estado == "Aprobado")
            {
                fondo = Color.FromArgb(222, 245, 226);
                texto = Estilos.Verde;
            }
            else if (estado == "Rechazado")
            {
                fondo = Color.FromArgb(253, 222, 222);
                texto = Estilos.Rojo;
            }
            lblEstado.BackColor = fondo;
            lblEstado.ForeColor = texto;
        }

        private void MostrarInformacionJustificacionEnPantalla(Justificacion justificacion)
        {
            Colaborador colaborador = cNegocio.BuscarColaboradorPorId(justificacion.ColaboradorID);
            List<Colaborador> lista = cNegocio.ListarActivos();
            bool encontrado = false;
            foreach (Colaborador c in lista)
            {
                if (c.ColaboradorID == colaborador.ColaboradorID)
                {
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                lista.Add(colaborador);
            }
            MostrarColaboradores(lista);
            cboColaborador.SelectedValue = justificacion.ColaboradorID;
            txtMotivo.Text = justificacion.Motivo;
            dtpInicio.Value = justificacion.FechaInicio;
            dtpFin.Value = justificacion.FechaFin;
            MostrarEstado(justificacion.EstadoAprobacion);
            if (justificacion.AprobadoPor == null)
            {
                lblAprobadoPor.Text = "— (sin revisar)";
            }
            else
            {
                lblAprobadoPor.Text = uNegocio.NombreDeUsuario(justificacion.AprobadoPor);
            }
            ucAuditoria.Mostrar(justificacion.CreatedBy, justificacion.CreatedAt, justificacion.ModifiedBy, justificacion.ModifiedAt);
        }

        private void dgvJustificaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvJustificaciones.CurrentRow == null || !dgvJustificaciones.CurrentRow.Selected) return;
            try
            {
                int Id = Convert.ToInt32(dgvJustificaciones.CurrentRow.Cells["ID"].Value);
                seleccionada = jNegocio.BuscarJustificacionPorId(Id);
                MostrarInformacionJustificacionEnPantalla(seleccionada);
                cboColaborador.Enabled = false;
                txtMotivo.ReadOnly = true;
                dtpInicio.Enabled = false;
                dtpFin.Enabled = false;
                btnGuardar.Enabled = false;
                bool pendiente = seleccionada.EstadoAprobacion == "Pendiente";
                btnAprobar.Enabled = pendiente && PuedeResolver();
                btnRechazar.Enabled = pendiente && PuedeResolver();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo cargar la justificación.", ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarGrid();
                Nueva();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo filtrar.", ex);
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            dgvJustificaciones.ClearSelection();
            Nueva();
            MostrarColaboradores(cNegocio.ListarActivos());
            txtMotivo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboColaborador.SelectedIndex == -1 || txtMotivo.Text.Trim() == "")
            {
                Estilos.Aviso("Seleccione el colaborador y escriba el motivo.");
                return;
            }
            try
            {
                Justificacion jObj = new Justificacion();
                jObj.ColaboradorID = (int)cboColaborador.SelectedValue;
                jObj.Motivo = txtMotivo.Text.Trim();
                jObj.FechaInicio = dtpInicio.Value.Date;
                jObj.FechaFin = dtpFin.Value.Date;
                jObj.CreatedBy = Sesion.UsuarioID;

                int resultado = jNegocio.SolicitarPermiso(jObj);
                if (resultado == -4)
                {
                    Estilos.Aviso("La fecha fin no puede ser menor que la fecha de inicio.");
                    return;
                }
                Estilos.Info("Solicitud registrada en estado Pendiente.");
                Recargar(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo registrar la solicitud.", ex);
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            Resolver("Aprobado");
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            Resolver("Rechazado");
        }

        private void Resolver(string estado)
        {
            if (seleccionada == null) return;
            string texto = estado == "Aprobado" ? "aprobada" : "rechazada";
            if (!Estilos.Confirmar("¿Marcar la solicitud como " + texto + "?")) return;
            try
            {
                int resultado = jNegocio.Resolver(seleccionada.JustificacionID, estado, Sesion.UsuarioID);
                if (resultado == -3)
                {
                    Estilos.Aviso("La solicitud ya fue revisada, no se puede cambiar.");
                    return;
                }
                Estilos.Info("Solicitud " + texto + ".");
                Recargar(seleccionada.JustificacionID);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo actualizar la solicitud.", ex);
            }
        }

        private void Recargar(int id)
        {
            cboEstadoFiltro.SelectedIndex = 0;
            CargarGrid();
            foreach (DataGridViewRow fila in dgvJustificaciones.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ID"].Value) == id)
                {
                    fila.Selected = true;
                    dgvJustificaciones.CurrentCell = fila.Cells[1];
                    dgvJustificaciones_SelectionChanged(null, EventArgs.Empty);
                    return;
                }
            }
            Nueva();
        }
    }
}
