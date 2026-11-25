using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmTurnos : Form
    {
        private TurnoNegocio tNegocio = new TurnoNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private Turno seleccionado;
        private bool cargando;

        public FrmTurnos()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvTurnos);
        }

        private void FrmTurnos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarGrid();
                CargarCombos();
                Limpiar();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los turnos.", ex);
            }
        }

        private void CargarGrid()
        {
            cargando = true;
            dgvTurnos.DataSource = tNegocio.ListarTabla();
            dgvTurnos.Columns["ID"].DefaultCellStyle.Format = "000";
            dgvTurnos.Columns["ID"].FillWeight = 50;
            dgvTurnos.Columns["Nombre"].FillWeight = 160;
            Estilos.ColorearEstado(dgvTurnos, "Estado");
            dgvTurnos.ClearSelection();
            cargando = false;
        }

        private void MostrarColaboradores(List<Colaborador> lista)
        {
            cboColaborador.DataSource = lista;
            cboColaborador.ValueMember = "ColaboradorID";
            cboColaborador.DisplayMember = "NombreCompleto";
            cboColaborador.SelectedIndex = -1;
        }

        private void MostrarTurnos(List<Turno> lista)
        {
            cboTurnoAsignar.DataSource = lista;
            cboTurnoAsignar.ValueMember = "TurnoID";
            cboTurnoAsignar.DisplayMember = "NombreTurno";
            cboTurnoAsignar.SelectedIndex = -1;
        }

        private void CargarCombos()
        {
            MostrarColaboradores(cNegocio.ListarActivos());
            MostrarTurnos(tNegocio.ListarActivos());
        }

        private void Limpiar()
        {
            seleccionado = null;
            txtNombre.Clear();
            dtpInicio.Value = DateTime.Today.AddHours(8);
            dtpFin.Value = DateTime.Today.AddHours(17);
            nudTolerancia.Value = 10;
            chkActivo.Checked = true;
            ucAuditoria.Limpiar();
            btnCrear.Enabled = true;
            btnEditar.Enabled = false;
            btnInhabilitar.Enabled = false;
        }

        private void MostrarInformacionTurnoEnPantalla(Turno turno)
        {
            txtNombre.Text = turno.NombreTurno;
            dtpInicio.Value = DateTime.Today + turno.HoraInicio;
            dtpFin.Value = DateTime.Today + turno.HoraFin;
            nudTolerancia.Value = turno.ToleranciaMinutos;
            chkActivo.Checked = turno.Estado;
            ucAuditoria.Mostrar(turno.CreatedBy, turno.CreatedAt, turno.ModifiedBy, turno.ModifiedAt);
        }

        private void dgvTurnos_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvTurnos.CurrentRow == null || !dgvTurnos.CurrentRow.Selected) return;
            try
            {
                int Id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["ID"].Value);
                seleccionado = tNegocio.BuscarTurnoPorId(Id);
                MostrarInformacionTurnoEnPantalla(seleccionado);
                btnCrear.Enabled = false;
                btnEditar.Enabled = true;
                btnInhabilitar.Enabled = seleccionado.Estado;
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo cargar el turno.", ex);
            }
        }

        private bool Validar()
        {
            if (txtNombre.Text.Trim() == "")
            {
                Estilos.Aviso("Ingrese el nombre del turno.");
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void LlenarDesdePantalla(Turno t)
        {
            t.NombreTurno = txtNombre.Text.Trim();
            t.HoraInicio = new TimeSpan(dtpInicio.Value.Hour, dtpInicio.Value.Minute, 0);
            t.HoraFin = new TimeSpan(dtpFin.Value.Hour, dtpFin.Value.Minute, 0);
            t.ToleranciaMinutos = (int)nudTolerancia.Value;
            t.Estado = chkActivo.Checked;
        }

        private bool MostrarError(int resultado)
        {
            if (resultado == -2)
            {
                Estilos.Aviso("Ya existe un turno con ese nombre.");
                return true;
            }
            if (resultado == -3)
            {
                Estilos.Aviso("El turno tiene colaboradores activos asignados, no se puede inhabilitar.");
                return true;
            }
            if (resultado == -4)
            {
                Estilos.Aviso("La hora de inicio y la hora de fin no pueden ser iguales.");
                return true;
            }
            return false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvTurnos.ClearSelection();
            Limpiar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                Turno tObj = new Turno();
                LlenarDesdePantalla(tObj);
                tObj.CreatedBy = Sesion.UsuarioID;

                int resultado = tNegocio.Insertar(tObj);
                if (MostrarError(resultado)) return;
                Estilos.Info("Turno creado correctamente.");
                Recargar(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo crear el turno.", ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
            {
                Estilos.Aviso("Seleccione un turno.");
                return;
            }
            if (!Validar()) return;
            try
            {
                Turno tObj = new Turno();
                tObj.TurnoID = seleccionado.TurnoID;
                LlenarDesdePantalla(tObj);
                tObj.ModifiedBy = Sesion.UsuarioID;

                int resultado = tNegocio.Modificar(tObj);
                if (MostrarError(resultado)) return;
                Estilos.Info("Turno actualizado correctamente.");
                Recargar(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo editar el turno.", ex);
            }
        }

        private void btnInhabilitar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;
            if (!Estilos.Confirmar("¿Inhabilitar el turno " + seleccionado.NombreTurno + "?")) return;
            try
            {
                int resultado = tNegocio.EliminarLogico(seleccionado.TurnoID, Sesion.UsuarioID);
                if (MostrarError(resultado)) return;
                Estilos.Info("Turno inhabilitado.");
                Recargar(seleccionado.TurnoID);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo inhabilitar el turno.", ex);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cboColaborador.SelectedIndex == -1 || cboTurnoAsignar.SelectedIndex == -1)
            {
                Estilos.Aviso("Seleccione el colaborador y el turno.");
                return;
            }
            try
            {
                int colaboradorId = (int)cboColaborador.SelectedValue;
                int turnoId = (int)cboTurnoAsignar.SelectedValue;
                int resultado = cNegocio.AsignarTurno(colaboradorId, turnoId, Sesion.UsuarioID);
                if (resultado == -3)
                {
                    Estilos.Aviso("El turno está inactivo.");
                    return;
                }
                Estilos.Info("Se asignó el turno " + cboTurnoAsignar.Text + " a " + cboColaborador.Text + ".");
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo asignar el turno.", ex);
            }
        }

        private void Recargar(int id)
        {
            CargarGrid();
            CargarCombos();
            foreach (DataGridViewRow fila in dgvTurnos.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ID"].Value) == id)
                {
                    fila.Selected = true;
                    dgvTurnos.CurrentCell = fila.Cells[1];
                    dgvTurnos_SelectionChanged(null, EventArgs.Empty);
                    return;
                }
            }
            Limpiar();
        }
    }
}
