using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmUsuariosRoles : Form
    {
        private UsuarioNegocio uNegocio = new UsuarioNegocio();
        private RolNegocio rNegocio = new RolNegocio();
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private Usuario usuarioSel;
        private Rol rolSel;
        private bool cargando;

        public FrmUsuariosRoles()
        {
            InitializeComponent();
            Estilos.AplicarGrid(dgvUsuarios);
            Estilos.AplicarGrid(dgvRoles);
        }

        private void FrmUsuariosRoles_Load(object sender, EventArgs e)
        {
            try
            {
                CargarRoles();
                CargarColaboradores();
                CargarUsuarios();
                LimpiarUsuario();
                LimpiarRol();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudieron cargar los datos.", ex);
            }
        }

        private void MostrarRoles(List<Rol> lista)
        {
            cboRol.DataSource = lista;
            cboRol.ValueMember = "RolID";
            cboRol.DisplayMember = "NombreRol";
            cboRol.SelectedIndex = -1;
        }

        private void CargarRoles()
        {
            cargando = true;
            List<Rol> roles = rNegocio.ListarActivos();
            MostrarRoles(roles);

            List<ItemCombo> filtro = new List<ItemCombo>();
            filtro.Add(new ItemCombo(0, "Todos"));
            foreach (Rol r in roles)
            {
                filtro.Add(new ItemCombo(r.RolID, r.NombreRol));
            }
            cboRolFiltro.DataSource = filtro;

            dgvRoles.DataSource = rNegocio.ListarTabla();
            dgvRoles.Columns["ID"].DefaultCellStyle.Format = "00";
            dgvRoles.Columns["ID"].FillWeight = 35;
            dgvRoles.Columns["Descripción"].FillWeight = 180;
            Estilos.ColorearEstado(dgvRoles, "Estado");
            dgvRoles.ClearSelection();
            cargando = false;
        }

        private void CargarColaboradores()
        {
            List<ItemCombo> items = new List<ItemCombo>();
            items.Add(new ItemCombo(0, "(Ninguno)"));
            foreach (Colaborador c in cNegocio.ListarTodo())
            {
                items.Add(new ItemCombo(c.ColaboradorID, c.NombreCompleto));
            }
            cboColaborador.DataSource = items;
        }

        private void CargarUsuarios()
        {
            cargando = true;
            int rolId = 0;
            ItemCombo rol = cboRolFiltro.SelectedItem as ItemCombo;
            if (rol != null)
            {
                rolId = rol.Id;
            }
            dgvUsuarios.DataSource = uNegocio.ListarTabla(txtBuscar.Text.Trim(), rolId);
            dgvUsuarios.Columns["ID"].DefaultCellStyle.Format = "000";
            dgvUsuarios.Columns["ID"].FillWeight = 40;
            dgvUsuarios.Columns["Nombre completo"].FillWeight = 170;
            Estilos.ColorearEstado(dgvUsuarios, "Estado");
            dgvUsuarios.ClearSelection();
            cargando = false;
        }

        private void LimpiarUsuario()
        {
            usuarioSel = null;
            txtNombreCompleto.Clear();
            txtUsuario.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            cboRol.SelectedIndex = -1;
            cboColaborador.SelectedIndex = 0;
            chkActivo.Checked = true;
            ucAuditoria.Limpiar();
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnDarBaja.Enabled = false;
        }

        private void MostrarInformacionUsuarioEnPantalla(Usuario usuario)
        {
            txtNombreCompleto.Text = usuario.NombreCompleto;
            txtUsuario.Text = usuario.NombreUsuario;
            txtCorreo.Text = usuario.Correo;
            txtContrasena.Clear();
            cboRol.SelectedValue = usuario.RolID;
            int colab = uNegocio.ColaboradorVinculado(usuario.UsuarioID);
            cboColaborador.SelectedIndex = 0;
            foreach (object item in cboColaborador.Items)
            {
                if (((ItemCombo)item).Id == colab)
                {
                    cboColaborador.SelectedItem = item;
                }
            }
            chkActivo.Checked = usuario.Estado;
            ucAuditoria.Mostrar(usuario.CreatedBy, usuario.CreatedAt, usuario.ModifiedBy, usuario.ModifiedAt);
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvUsuarios.CurrentRow == null || !dgvUsuarios.CurrentRow.Selected) return;
            try
            {
                int Id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value);
                usuarioSel = uNegocio.BuscarUsuarioPorId(Id);
                MostrarInformacionUsuarioEnPantalla(usuarioSel);
                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnDarBaja.Enabled = usuarioSel.Estado && usuarioSel.UsuarioID != Sesion.UsuarioID;
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo cargar el usuario.", ex);
            }
        }

        private bool ValidarUsuario(bool nuevo)
        {
            if (txtNombreCompleto.Text.Trim() == "" || txtUsuario.Text.Trim() == "" || cboRol.SelectedIndex == -1)
            {
                Estilos.Aviso("Complete el nombre completo, el usuario y el rol.");
                return false;
            }
            if (nuevo && txtContrasena.Text.Length < 6)
            {
                Estilos.Aviso("La contraseña debe tener al menos 6 caracteres.");
                return false;
            }
            if (!nuevo && txtContrasena.Text.Length > 0 && txtContrasena.Text.Length < 6)
            {
                Estilos.Aviso("La nueva contraseña debe tener al menos 6 caracteres.");
                return false;
            }
            return true;
        }

        private void LlenarUsuario(Usuario u)
        {
            u.NombreCompleto = txtNombreCompleto.Text.Trim();
            u.NombreUsuario = txtUsuario.Text.Trim();
            if (txtCorreo.Text.Trim() == "")
            {
                u.Correo = null;
            }
            else
            {
                u.Correo = txtCorreo.Text.Trim();
            }
            u.RolID = (int)cboRol.SelectedValue;
            u.Estado = chkActivo.Checked;
            u.Contrasena = txtContrasena.Text;
        }

        private int ColaboradorElegido()
        {
            ItemCombo item = cboColaborador.SelectedItem as ItemCombo;
            if (item == null)
            {
                return 0;
            }
            return item.Id;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            LimpiarUsuario();
            txtNombreCompleto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarUsuario(true)) return;
            try
            {
                Usuario uObj = new Usuario();
                LlenarUsuario(uObj);
                uObj.CreatedBy = Sesion.UsuarioID;

                int resultado = uNegocio.Insertar(uObj);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ese nombre de usuario ya existe.");
                    return;
                }
                uNegocio.VincularColaborador(resultado, ColaboradorElegido(), Sesion.UsuarioID);
                Estilos.Info("Usuario registrado correctamente.");
                RecargarUsuario(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo registrar el usuario.", ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuarioSel == null)
            {
                Estilos.Aviso("Seleccione un usuario.");
                return;
            }
            if (!ValidarUsuario(false)) return;
            try
            {
                bool cambiarClave = txtContrasena.Text.Length > 0;
                Usuario uObj = new Usuario();
                uObj.UsuarioID = usuarioSel.UsuarioID;
                LlenarUsuario(uObj);
                uObj.ModifiedBy = Sesion.UsuarioID;

                int resultado = uNegocio.Modificar(uObj, cambiarClave);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ese nombre de usuario ya existe.");
                    return;
                }
                if (resultado == -3)
                {
                    Estilos.Aviso("No puede desactivar su propia cuenta.");
                    return;
                }
                uNegocio.VincularColaborador(resultado, ColaboradorElegido(), Sesion.UsuarioID);
                Estilos.Info("Usuario actualizado correctamente.");
                RecargarUsuario(resultado);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo actualizar el usuario.", ex);
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (usuarioSel == null) return;
            if (!Estilos.Confirmar("¿Dar de baja la cuenta " + usuarioSel.NombreUsuario + "?")) return;
            try
            {
                int resultado = uNegocio.EliminarLogico(usuarioSel.UsuarioID, Sesion.UsuarioID);
                if (resultado == -3)
                {
                    Estilos.Aviso("No puede dar de baja su propia cuenta.");
                    return;
                }
                Estilos.Info("Cuenta dada de baja.");
                RecargarUsuario(usuarioSel.UsuarioID);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo dar de baja la cuenta.", ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            LimpiarUsuario();
        }

        private void RecargarUsuario(int id)
        {
            CargarUsuarios();
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (Convert.ToInt32(fila.Cells["ID"].Value) == id)
                {
                    fila.Selected = true;
                    dgvUsuarios.CurrentCell = fila.Cells[1];
                    dgvUsuarios_SelectionChanged(null, EventArgs.Empty);
                    return;
                }
            }
            LimpiarUsuario();
        }

        private void LimpiarRol()
        {
            rolSel = null;
            txtNombreRol.Clear();
            txtDescripcionRol.Clear();
            chkRolActivo.Checked = true;
            btnGuardarRol.Enabled = true;
            btnModificarRol.Enabled = false;
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (cargando || dgvRoles.CurrentRow == null || !dgvRoles.CurrentRow.Selected) return;
            try
            {
                int Id = Convert.ToInt32(dgvRoles.CurrentRow.Cells["ID"].Value);
                rolSel = rNegocio.BuscarRolPorId(Id);
                txtNombreRol.Text = rolSel.NombreRol;
                txtDescripcionRol.Text = rolSel.Descripcion;
                chkRolActivo.Checked = rolSel.Estado;
                ucAuditoria.Mostrar(rolSel.CreatedBy, rolSel.CreatedAt, rolSel.ModifiedBy, rolSel.ModifiedAt);
                btnGuardarRol.Enabled = false;
                btnModificarRol.Enabled = true;
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo cargar el rol.", ex);
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            dgvRoles.ClearSelection();
            LimpiarRol();
            txtNombreRol.Focus();
        }

        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (txtNombreRol.Text.Trim() == "")
            {
                Estilos.Aviso("Ingrese el nombre del rol.");
                return;
            }
            try
            {
                Rol rObj = new Rol();
                rObj.NombreRol = txtNombreRol.Text.Trim();
                rObj.Descripcion = txtDescripcionRol.Text.Trim();
                rObj.Estado = chkRolActivo.Checked;
                rObj.CreatedBy = Sesion.UsuarioID;

                int resultado = rNegocio.Insertar(rObj);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ya existe un rol con ese nombre.");
                    return;
                }
                Estilos.Info("Rol registrado correctamente.");
                CargarRoles();
                LimpiarRol();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo registrar el rol.", ex);
            }
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            if (rolSel == null || txtNombreRol.Text.Trim() == "") return;
            try
            {
                Rol rObj = new Rol();
                rObj.RolID = rolSel.RolID;
                rObj.NombreRol = txtNombreRol.Text.Trim();
                rObj.Descripcion = txtDescripcionRol.Text.Trim();
                rObj.Estado = chkRolActivo.Checked;
                rObj.ModifiedBy = Sesion.UsuarioID;

                int resultado = rNegocio.Modificar(rObj);
                if (resultado == -2)
                {
                    Estilos.Aviso("Ya existe un rol con ese nombre.");
                    return;
                }
                Estilos.Info("Rol actualizado correctamente.");
                CargarRoles();
                CargarUsuarios();
                LimpiarRol();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo actualizar el rol.", ex);
            }
        }
    }
}
