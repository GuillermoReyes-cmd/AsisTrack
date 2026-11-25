namespace CapaPresentacion
{
    partial class FrmColaboradores
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
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.ucAuditoria = new CapaPresentacion.UcAuditoria();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblFiltroDep = new System.Windows.Forms.Label();
            this.cboFiltroDep = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblDni);
            this.grpDatos.Controls.Add(this.txtDni);
            this.grpDatos.Controls.Add(this.lblNombres);
            this.grpDatos.Controls.Add(this.txtNombres);
            this.grpDatos.Controls.Add(this.lblApellidos);
            this.grpDatos.Controls.Add(this.txtApellidos);
            this.grpDatos.Controls.Add(this.lblCargo);
            this.grpDatos.Controls.Add(this.txtCargo);
            this.grpDatos.Controls.Add(this.lblDepartamento);
            this.grpDatos.Controls.Add(this.cboDepartamento);
            this.grpDatos.Controls.Add(this.lblTurno);
            this.grpDatos.Controls.Add(this.cboTurno);
            this.grpDatos.Controls.Add(this.chkActivo);
            this.grpDatos.Location = new System.Drawing.Point(12, 10);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(340, 295);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Text = "Datos del colaborador";
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(12, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "DNI:";
            this.lblDni.AutoSize = true;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(120, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(205, 25);
            this.txtDni.TabIndex = 2;
            this.txtDni.MaxLength = 8;
            // 
            // lblNombres
            // 
            this.lblNombres.Location = new System.Drawing.Point(12, 69);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.TabIndex = 3;
            this.lblNombres.Text = "Nombres:";
            this.lblNombres.AutoSize = true;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(120, 66);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(205, 25);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.MaxLength = 50;
            // 
            // lblApellidos
            // 
            this.lblApellidos.Location = new System.Drawing.Point(12, 105);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.TabIndex = 5;
            this.lblApellidos.Text = "Apellidos:";
            this.lblApellidos.AutoSize = true;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(120, 102);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(205, 25);
            this.txtApellidos.TabIndex = 6;
            this.txtApellidos.MaxLength = 50;
            // 
            // lblCargo
            // 
            this.lblCargo.Location = new System.Drawing.Point(12, 141);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.TabIndex = 7;
            this.lblCargo.Text = "Cargo:";
            this.lblCargo.AutoSize = true;
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(120, 138);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(205, 25);
            this.txtCargo.TabIndex = 8;
            this.txtCargo.MaxLength = 50;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.Location = new System.Drawing.Point(12, 177);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.TabIndex = 9;
            this.lblDepartamento.Text = "Departamento:";
            this.lblDepartamento.AutoSize = true;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(120, 174);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(205, 25);
            this.cboDepartamento.TabIndex = 10;
            this.cboDepartamento.MaxLength = 50;
            this.cboDepartamento.FormattingEnabled = true;
            // 
            // lblTurno
            // 
            this.lblTurno.Location = new System.Drawing.Point(12, 213);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.TabIndex = 11;
            this.lblTurno.Text = "Turno:";
            this.lblTurno.AutoSize = true;
            // 
            // cboTurno
            // 
            this.cboTurno.Location = new System.Drawing.Point(120, 210);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(205, 25);
            this.cboTurno.TabIndex = 12;
            this.cboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurno.FormattingEnabled = true;
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(120, 250);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.TabIndex = 13;
            this.chkActivo.Text = "Activo";
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 315);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 30);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(92, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 30);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(177, 315);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(85, 30);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Location = new System.Drawing.Point(267, 315);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(85, 30);
            this.btnDarBaja.TabIndex = 17;
            this.btnDarBaja.Text = "Dar de baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // ucAuditoria
            // 
            this.ucAuditoria.Location = new System.Drawing.Point(12, 358);
            this.ucAuditoria.Name = "ucAuditoria";
            this.ucAuditoria.Size = new System.Drawing.Size(340, 118);
            this.ucAuditoria.TabIndex = 18;
            // 
            // lblBuscar
            // 
            this.lblBuscar.Location = new System.Drawing.Point(370, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.TabIndex = 19;
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.AutoSize = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(425, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(170, 25);
            this.txtBuscar.TabIndex = 20;
            // 
            // lblFiltroDep
            // 
            this.lblFiltroDep.Location = new System.Drawing.Point(608, 16);
            this.lblFiltroDep.Name = "lblFiltroDep";
            this.lblFiltroDep.TabIndex = 21;
            this.lblFiltroDep.Text = "Departamento:";
            this.lblFiltroDep.AutoSize = true;
            // 
            // cboFiltroDep
            // 
            this.cboFiltroDep.Location = new System.Drawing.Point(705, 12);
            this.cboFiltroDep.Name = "cboFiltroDep";
            this.cboFiltroDep.Size = new System.Drawing.Size(140, 25);
            this.cboFiltroDep.TabIndex = 22;
            this.cboFiltroDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroDep.FormattingEnabled = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(855, 11);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(93, 27);
            this.btnFiltrar.TabIndex = 23;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.Location = new System.Drawing.Point(370, 46);
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.Size = new System.Drawing.Size(578, 494);
            this.dgvColaboradores.TabIndex = 24;
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaboradores.SelectionChanged += new System.EventHandler(this.dgvColaboradores_SelectionChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(370, 548);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "";
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            // 
            // FrmColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvColaboradores);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cboFiltroDep);
            this.Controls.Add(this.lblFiltroDep);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.ucAuditoria);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmColaboradores";
            this.Text = "AsisTrack — Gestión de colaboradores";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmColaboradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDarBaja;
        private CapaPresentacion.UcAuditoria ucAuditoria;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroDep;
        private System.Windows.Forms.ComboBox cboFiltroDep;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvColaboradores;
        private System.Windows.Forms.Label lblTotal;
    }
}
