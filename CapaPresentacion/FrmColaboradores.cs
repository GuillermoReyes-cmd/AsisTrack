using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmColaboradores : Form
    {
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private TurnoNegocio tNegocio = new TurnoNegocio();
        private Colaborador seleccionado;
        private bool cargando;

        public FrmColaboradores()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvColaboradores);
        }

        private void FrmColaboradores_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarTurnos(tNegocio.ListarActivos());
                List<string> deps = cNegocio.Departamentos();
                cboDepartamento.Items.Clear();
                cboDepartamento.Items.AddRange(deps.ToArray());
                cboFiltroDep.Items.Clear();
                cboFiltroDep.Items.Add("Todos");
                cboFiltroDep.Items.AddRange(deps.ToArray());
                cboFiltroDep.SelectedIndex = 0;
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los datos.", ex);
            }
        }

        private void MostrarTurnos(List<Turno> lista)
        {
            cboTurno.DataSource = lista;
            cboTurno.ValueMember = "TurnoID";
            cboTurno.DisplayMember = "NombreTurno";
            cboTurno.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            cargando = true;
            string dep = cboFiltroDep.SelectedIndex > 0 ? cboFiltroDep.Text : "";
            dgvColaboradores.DataSource = cNegocio.ListarTabla(txtBuscar.Text.Trim(), dep);
            dgvColaboradores.Columns["ID"].DefaultCellStyle.Format = "000";
            dgvColaboradores.Columns["ID"].FillWeight = 45;
            dgvColaboradores.Columns["Apellidos"].FillWeight = 140;
            dgvColaboradores.Columns["Departamento"].FillWeight = 125;
            dgvColaboradores.Columns["Turno"].FillWeight = 110;
            Estilos.ColorearEstado(dgvColaboradores, "Estado");
            lblTotal.Text = dgvColaboradores.Rows.Count + " registros encontrados";
            dgvColaboradores.ClearSelection();
            cargando = false;
        }

        private void Limpiar()
        {
            seleccionado = null;
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCargo.Clear();
            cboDepartamento.Text = "";
            MostrarTurnos(tNegocio.ListarActivos());
            chkActivo.Checked = true;
            ucAuditoria.Limpiar();
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnDarBaja.Enabled = false;
            txtDni.Focus();
        }

        private void MostrarInformacionColaboradorEnPantalla(Colaborador colaborador)
        {
            txtDni.Text = colaborador.DNI;
            txtNombres.Text = colaborador.Nombres;
            txtApellidos.Text = colaborador.Apellidos;
            txtCargo.Text = colaborador.Cargo;
            cboDepartamento.Text = colaborador.Departamento;
            SeleccionarTurno(colaborador.TurnoID);
            chkActivo.Checked = colaborador.Estado;
            ucAuditoria.Mostrar(colaborador.CreatedBy, colaborador.CreatedAt, colaborador.ModifiedBy, colaborador.ModifiedAt);
        }

        private void dgvColaboradores_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvColaboradores.CurrentRow == null || !dgvColaboradores.CurrentRow.Selected) return;
            try
            {
                int Id = Convert.ToInt32(dgvColaboradores.CurrentRow.Cells["ID"].Value);
                seleccionado = cNegocio.BuscarColaboradorPorId(Id);
                MostrarInformacionColaboradorEnPantalla(seleccionado);
                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnDarBaja.Enabled = seleccionado.Estado;
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo cargar el colaborador.", ex);
            }
        }

        private void SeleccionarTurno(int turnoId)
        {
            List<Turno> lista = tNegocio.ListarActivos();
            bool encontrado = false;
            foreach (Turno t in lista)
            {
                if (t.TurnoID == turnoId)
                {
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                lista.Add(tNegocio.BuscarTurnoPorId(turnoId));
            }
            MostrarTurnos(lista);
            cboTurno.SelectedValue = turnoId;
        }

        private bool Validar()
        {
            string dni = txtDni.Text.Trim();
            long numero;
            if (dni.Length != 8 || !long.TryParse(dni, out numero))
            {
                Estilos.Aviso("El DNI debe tener 8 dígitos.");
                txtDni.Focus();
                return false;
            }
            if (txtNombres.Text.Trim() == "" || txtApellidos.Text.Trim() == "" || txtCargo.Text.Trim() == "" ||
                cboDepartamento.Text.Trim() == "" || cboTurno.SelectedIndex == -1)
            {
                Estilos.Aviso("Complete todos los datos del colaborador.");
                return false;
            }
            return true;
        }

        private void LlenarDesdePantalla(Colaborador c)
        {
            c.DNI = txtDni.Text.Trim();
            c.Nombres = txtNombres.Text.Trim();
            c.Apellidos = txtApellidos.Text.Trim();
            c.Cargo = txtCargo.Text.Trim();
            c.Departamento = cboDepartamento.Text.Trim();
            c.TurnoID = (int)cboTurno.SelectedValue;
            c.Estado = chkActivo.Checked;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvColaboradores.ClearSelection();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                Colaborador cObj = new Colaborador();
                LlenarDesdePantalla(cObj);
                cObj.CreatedBy = Sesion.UsuarioID;

                int resultado = cNegocio.Insertar(cObj);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ya existe un colaborador con ese DNI.");
                    return;
                }
                Estilos.Info("Colaborador registrado correctamente.");
                Recargar(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo registrar el colaborador.", ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (seleccionado == null)
            {
                Estilos.Aviso("Seleccione un colaborador.");
                return;
            }
            if (!Validar()) return;
            try
            {
                Colaborador cObj = new Colaborador();
                cObj.ColaboradorID = seleccionado.ColaboradorID;
                LlenarDesdePantalla(cObj);
                cObj.ModifiedBy = Sesion.UsuarioID;

                int resultado = cNegocio.Modificar(cObj);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ya existe otro colaborador con ese DNI.");
                    return;
                }
                Estilos.Info("Datos actualizados correctamente.");
                Recargar(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo actualizar el colaborador.", ex);
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (seleccionado == null) return;
            if (!Estilos.Confirmar("¿Dar de baja a " + seleccionado.NombreCompleto + "?" + Environment.NewLine +
                                   "Su historial de asistencia se conservará.")) return;
            try
            {
                cNegocio.EliminarLogico(seleccionado.ColaboradorID, Sesion.UsuarioID);
                Estilos.Info("Colaborador dado de baja.");
                Recargar(seleccionado.ColaboradorID);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo dar de baja al colaborador.", ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarGrid();
            Limpiar();
        }

        private void Recargar(int id)
        {
            CargarGrid();
            foreach (DataGridViewRow fila in dgvColaboradores.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ID"].Value) == id)
                {
                    fila.Selected = true;
                    dgvColaboradores.CurrentCell = fila.Cells[1];
                    dgvColaboradores_SelectionChanged(null, EventArgs.Empty);
                    return;
                }
            }
            Limpiar();
        }
    }
}
