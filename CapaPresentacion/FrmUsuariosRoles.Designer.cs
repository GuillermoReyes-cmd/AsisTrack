namespace CapaPresentacion
{
    partial class FrmUsuariosRoles
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.ucAuditoria = new CapaPresentacion.UcAuditoria();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblRolFiltro = new System.Windows.Forms.Label();
            this.cboRolFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblRoles = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.grpRol = new System.Windows.Forms.GroupBox();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.lblDescripcionRol = new System.Windows.Forms.Label();
            this.txtDescripcionRol = new System.Windows.Forms.TextBox();
            this.chkRolActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.grpRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblNombreCompleto);
            this.grpDatos.Controls.Add(this.txtNombreCompleto);
            this.grpDatos.Controls.Add(this.lblUsuario);
            this.grpDatos.Controls.Add(this.txtUsuario);
            this.grpDatos.Controls.Add(this.lblCorreo);
            this.grpDatos.Controls.Add(this.txtCorreo);
            this.grpDatos.Controls.Add(this.lblContrasena);
            this.grpDatos.Controls.Add(this.txtContrasena);
            this.grpDatos.Controls.Add(this.lblRol);
            this.grpDatos.Controls.Add(this.cboRol);
            this.grpDatos.Controls.Add(this.lblColaborador);
            this.grpDatos.Controls.Add(this.cboColaborador);
            this.grpDatos.Controls.Add(this.chkActivo);
            this.grpDatos.Location = new System.Drawing.Point(12, 10);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(350, 262);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Text = "Datos del usuario";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.Location = new System.Drawing.Point(12, 31);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "Nombre completo:";
            this.lblNombreCompleto.AutoSize = true;
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(130, 28);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(205, 25);
            this.txtNombreCompleto.TabIndex = 2;
            this.txtNombreCompleto.MaxLength = 100;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(12, 65);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.AutoSize = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(130, 62);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(205, 25);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.MaxLength = 30;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Location = new System.Drawing.Point(12, 99);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.TabIndex = 5;
            this.lblCorreo.Text = "Correo:";
            this.lblCorreo.AutoSize = true;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(130, 96);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(205, 25);
            this.txtCorreo.TabIndex = 6;
            this.txtCorreo.MaxLength = 100;
            // 
            // lblContrasena
            // 
            this.lblContrasena.Location = new System.Drawing.Point(12, 133);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.TabIndex = 7;
            this.lblContrasena.Text = "Contraseña:";
            this.lblContrasena.AutoSize = true;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(130, 130);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(205, 25);
            this.txtContrasena.TabIndex = 8;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(12, 167);
            this.lblRol.Name = "lblRol";
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol:";
            this.lblRol.AutoSize = true;
            // 
            // cboRol
            // 
            this.cboRol.Location = new System.Drawing.Point(130, 164);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(205, 25);
            this.cboRol.TabIndex = 10;
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.FormattingEnabled = true;
            // 
            // lblColaborador
            // 
            this.lblColaborador.Location = new System.Drawing.Point(12, 201);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.TabIndex = 11;
            this.lblColaborador.Text = "Colaborador:";
            this.lblColaborador.AutoSize = true;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Location = new System.Drawing.Point(130, 198);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(205, 25);
            this.cboColaborador.TabIndex = 12;
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.FormattingEnabled = true;
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(130, 232);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.TabIndex = 13;
            this.chkActivo.Text = "Activo";
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 282);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 30);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(92, 282);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 30);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(179, 282);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(88, 30);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Location = new System.Drawing.Point(272, 282);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(90, 30);
            this.btnDarBaja.TabIndex = 17;
            this.btnDarBaja.Text = "Dar de baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // ucAuditoria
            // 
            this.ucAuditoria.Location = new System.Drawing.Point(12, 322);
            this.ucAuditoria.Name = "ucAuditoria";
            this.ucAuditoria.Size = new System.Drawing.Size(350, 118);
            this.ucAuditoria.TabIndex = 18;
            // 
            // lblAyuda
            // 
            this.lblAyuda.Location = new System.Drawing.Point(12, 446);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Size = new System.Drawing.Size(350, 40);
            this.lblAyuda.TabIndex = 19;
            this.lblAyuda.Text = "Al modificar un usuario, deje la contraseña vacía para conservar la actual.";
            this.lblAyuda.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Location = new System.Drawing.Point(380, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 20;
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.AutoSize = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(435, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(160, 25);
            this.txtBuscar.TabIndex = 21;
            // 
            // lblRolFiltro
            // 
            this.lblRolFiltro.Location = new System.Drawing.Point(608, 16);
            this.lblRolFiltro.Name = "lblRolFiltro";
            this.lblRolFiltro.TabIndex = 22;
            this.lblRolFiltro.Text = "Rol:";
            this.lblRolFiltro.AutoSize = true;
            // 
            // cboRolFiltro
            // 
            this.cboRolFiltro.Location = new System.Drawing.Point(642, 12);
            this.cboRolFiltro.Name = "cboRolFiltro";
            this.cboRolFiltro.Size = new System.Drawing.Size(190, 25);
            this.cboRolFiltro.TabIndex = 23;
            this.cboRolFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRolFiltro.FormattingEnabled = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(842, 11);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(106, 27);
            this.btnFiltrar.TabIndex = 24;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Location = new System.Drawing.Point(380, 46);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(568, 200);
            this.dgvUsuarios.TabIndex = 25;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // lblRoles
            // 
            this.lblRoles.Location = new System.Drawing.Point(380, 256);
            this.lblRoles.Name = "lblRoles";
            this.lblRoles.TabIndex = 26;
            this.lblRoles.Text = "Roles registrados";
            this.lblRoles.AutoSize = true;
            this.lblRoles.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            // 
            // dgvRoles
            // 
            this.dgvRoles.Location = new System.Drawing.Point(380, 280);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.Size = new System.Drawing.Size(568, 160);
            this.dgvRoles.TabIndex = 27;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.SelectionChanged += new System.EventHandler(this.dgvRoles_SelectionChanged);
            // 
            // grpRol
            // 
            this.grpRol.Controls.Add(this.lblNombreRol);
            this.grpRol.Controls.Add(this.txtNombreRol);
            this.grpRol.Controls.Add(this.lblDescripcionRol);
            this.grpRol.Controls.Add(this.txtDescripcionRol);
            this.grpRol.Controls.Add(this.chkRolActivo);
            this.grpRol.Controls.Add(this.btnNuevoRol);
            this.grpRol.Controls.Add(this.btnGuardarRol);
            this.grpRol.Controls.Add(this.btnModificarRol);
            this.grpRol.Location = new System.Drawing.Point(380, 448);
            this.grpRol.Name = "grpRol";
            this.grpRol.Size = new System.Drawing.Size(568, 105);
            this.grpRol.TabIndex = 28;
            this.grpRol.Text = "Datos del rol";
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.Location = new System.Drawing.Point(12, 32);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.TabIndex = 29;
            this.lblNombreRol.Text = "Rol:";
            this.lblNombreRol.AutoSize = true;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(60, 28);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(190, 25);
            this.txtNombreRol.TabIndex = 30;
            this.txtNombreRol.MaxLength = 50;
            // 
            // lblDescripcionRol
            // 
            this.lblDescripcionRol.Location = new System.Drawing.Point(262, 32);
            this.lblDescripcionRol.Name = "lblDescripcionRol";
            this.lblDescripcionRol.TabIndex = 31;
            this.lblDescripcionRol.Text = "Descripción:";
            this.lblDescripcionRol.AutoSize = true;
            // 
            // txtDescripcionRol
            // 
            this.txtDescripcionRol.Location = new System.Drawing.Point(350, 28);
            this.txtDescripcionRol.Name = "txtDescripcionRol";
            this.txtDescripcionRol.Size = new System.Drawing.Size(205, 25);
            this.txtDescripcionRol.TabIndex = 32;
            this.txtDescripcionRol.MaxLength = 150;
            // 
            // chkRolActivo
            // 
            this.chkRolActivo.Location = new System.Drawing.Point(12, 68);
            this.chkRolActivo.Name = "chkRolActivo";
            this.chkRolActivo.TabIndex = 33;
            this.chkRolActivo.Text = "Activo";
            this.chkRolActivo.AutoSize = true;
            this.chkRolActivo.Checked = true;
            this.chkRolActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(110, 64);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(90, 30);
            this.btnNuevoRol.TabIndex = 34;
            this.btnNuevoRol.Text = "Nuevo rol";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Location = new System.Drawing.Point(208, 64);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(110, 30);
            this.btnGuardarRol.TabIndex = 35;
            this.btnGuardarRol.Text = "Guardar rol";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnModificarRol
            // 
            this.btnModificarRol.Location = new System.Drawing.Point(326, 64);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(120, 30);
            this.btnModificarRol.TabIndex = 36;
            this.btnModificarRol.Text = "Modificar rol";
            this.btnModificarRol.UseVisualStyleBackColor = true;
            this.btnModificarRol.Click += new System.EventHandler(this.btnModificarRol_Click);
            // 
            // FrmUsuariosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 566);
            this.Controls.Add(this.grpRol);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.lblRoles);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cboRolFiltro);
            this.Controls.Add(this.lblRolFiltro);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.ucAuditoria);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmUsuariosRoles";
            this.Text = "AsisTrack — Gestión de usuarios y roles";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUsuariosRoles_Load);
            this.grpRol.ResumeLayout(false);
            this.grpRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDarBaja;
        private CapaPresentacion.UcAuditoria ucAuditoria;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblRolFiltro;
        private System.Windows.Forms.ComboBox cboRolFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.GroupBox grpRol;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label lblDescripcionRol;
        private System.Windows.Forms.TextBox txtDescripcionRol;
        private System.Windows.Forms.CheckBox chkRolActivo;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.Button btnModificarRol;
    }
}
