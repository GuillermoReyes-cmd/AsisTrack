namespace CapaPresentacion
{
    partial class FrmTurnos
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblTolerancia = new System.Windows.Forms.Label();
            this.nudTolerancia = new System.Windows.Forms.NumericUpDown();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnInhabilitar = new System.Windows.Forms.Button();
            this.grpAsignar = new System.Windows.Forms.GroupBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.lblTurnoAsignar = new System.Windows.Forms.Label();
            this.cboTurnoAsignar = new System.Windows.Forms.ComboBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.ucAuditoria = new CapaPresentacion.UcAuditoria();
            this.lblTurnos = new System.Windows.Forms.Label();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerancia)).BeginInit();
            this.grpAsignar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblInicio);
            this.grpDatos.Controls.Add(this.dtpInicio);
            this.grpDatos.Controls.Add(this.lblFin);
            this.grpDatos.Controls.Add(this.dtpFin);
            this.grpDatos.Controls.Add(this.lblTolerancia);
            this.grpDatos.Controls.Add(this.nudTolerancia);
            this.grpDatos.Controls.Add(this.chkActivo);
            this.grpDatos.Location = new System.Drawing.Point(12, 10);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(410, 215);
            this.grpDatos.TabIndex = 0;
            this.grpDatos.Text = "Datos del turno";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(12, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del turno:";
            this.lblNombre.AutoSize = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 25);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.MaxLength = 50;
            // 
            // lblInicio
            // 
            this.lblInicio.Location = new System.Drawing.Point(12, 68);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.TabIndex = 3;
            this.lblInicio.Text = "Hora de inicio:";
            this.lblInicio.AutoSize = true;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(150, 64);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(110, 25);
            this.dtpInicio.TabIndex = 4;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.CustomFormat = "HH:mm";
            this.dtpInicio.ShowUpDown = true;
            // 
            // lblFin
            // 
            this.lblFin.Location = new System.Drawing.Point(12, 104);
            this.lblFin.Name = "lblFin";
            this.lblFin.TabIndex = 5;
            this.lblFin.Text = "Hora de fin:";
            this.lblFin.AutoSize = true;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(150, 100);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(110, 25);
            this.dtpFin.TabIndex = 6;
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.CustomFormat = "HH:mm";
            this.dtpFin.ShowUpDown = true;
            // 
            // lblTolerancia
            // 
            this.lblTolerancia.Location = new System.Drawing.Point(12, 140);
            this.lblTolerancia.Name = "lblTolerancia";
            this.lblTolerancia.TabIndex = 7;
            this.lblTolerancia.Text = "Tolerancia (min):";
            this.lblTolerancia.AutoSize = true;
            // 
            // nudTolerancia
            // 
            this.nudTolerancia.Location = new System.Drawing.Point(150, 136);
            this.nudTolerancia.Name = "nudTolerancia";
            this.nudTolerancia.Size = new System.Drawing.Size(80, 25);
            this.nudTolerancia.TabIndex = 8;
            this.nudTolerancia.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(150, 176);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.TabIndex = 9;
            this.chkActivo.Text = "Activo";
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(12, 235);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 30);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(97, 235);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(110, 30);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Crear turno";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(212, 235);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(95, 30);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInhabilitar
            // 
            this.btnInhabilitar.Location = new System.Drawing.Point(312, 235);
            this.btnInhabilitar.Name = "btnInhabilitar";
            this.btnInhabilitar.Size = new System.Drawing.Size(110, 30);
            this.btnInhabilitar.TabIndex = 13;
            this.btnInhabilitar.Text = "Inhabilitar";
            this.btnInhabilitar.UseVisualStyleBackColor = true;
            this.btnInhabilitar.Click += new System.EventHandler(this.btnInhabilitar_Click);
            // 
            // grpAsignar
            // 
            this.grpAsignar.Controls.Add(this.lblColaborador);
            this.grpAsignar.Controls.Add(this.cboColaborador);
            this.grpAsignar.Controls.Add(this.lblTurnoAsignar);
            this.grpAsignar.Controls.Add(this.cboTurnoAsignar);
            this.grpAsignar.Controls.Add(this.btnAsignar);
            this.grpAsignar.Location = new System.Drawing.Point(12, 278);
            this.grpAsignar.Name = "grpAsignar";
            this.grpAsignar.Size = new System.Drawing.Size(410, 110);
            this.grpAsignar.TabIndex = 14;
            this.grpAsignar.Text = "Asignar turno a colaborador";
            // 
            // lblColaborador
            // 
            this.lblColaborador.Location = new System.Drawing.Point(12, 34);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.TabIndex = 15;
            this.lblColaborador.Text = "Colaborador:";
            this.lblColaborador.AutoSize = true;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Location = new System.Drawing.Point(110, 30);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(285, 25);
            this.cboColaborador.TabIndex = 16;
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.FormattingEnabled = true;
            // 
            // lblTurnoAsignar
            // 
            this.lblTurnoAsignar.Location = new System.Drawing.Point(12, 70);
            this.lblTurnoAsignar.Name = "lblTurnoAsignar";
            this.lblTurnoAsignar.TabIndex = 17;
            this.lblTurnoAsignar.Text = "Turno:";
            this.lblTurnoAsignar.AutoSize = true;
            // 
            // cboTurnoAsignar
            // 
            this.cboTurnoAsignar.Location = new System.Drawing.Point(110, 66);
            this.cboTurnoAsignar.Name = "cboTurnoAsignar";
            this.cboTurnoAsignar.Size = new System.Drawing.Size(180, 25);
            this.cboTurnoAsignar.TabIndex = 18;
            this.cboTurnoAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnoAsignar.FormattingEnabled = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(300, 65);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(95, 28);
            this.btnAsignar.TabIndex = 19;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // ucAuditoria
            // 
            this.ucAuditoria.Location = new System.Drawing.Point(12, 398);
            this.ucAuditoria.Name = "ucAuditoria";
            this.ucAuditoria.Size = new System.Drawing.Size(410, 118);
            this.ucAuditoria.TabIndex = 20;
            // 
            // lblTurnos
            // 
            this.lblTurnos.Location = new System.Drawing.Point(440, 12);
            this.lblTurnos.Name = "lblTurnos";
            this.lblTurnos.TabIndex = 21;
            this.lblTurnos.Text = "Turnos registrados";
            this.lblTurnos.AutoSize = true;
            this.lblTurnos.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.Location = new System.Drawing.Point(440, 40);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.Size = new System.Drawing.Size(508, 476);
            this.dgvTurnos.TabIndex = 22;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.SelectionChanged += new System.EventHandler(this.dgvTurnos_SelectionChanged);
            // 
            // FrmTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.lblTurnos);
            this.Controls.Add(this.ucAuditoria);
            this.Controls.Add(this.grpAsignar);
            this.Controls.Add(this.btnInhabilitar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmTurnos";
            this.Text = "AsisTrack — Gestión y asignación de turnos";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.grpAsignar.ResumeLayout(false);
            this.grpAsignar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTolerancia)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblTolerancia;
        private System.Windows.Forms.NumericUpDown nudTolerancia;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnInhabilitar;
        private System.Windows.Forms.GroupBox grpAsignar;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.Label lblTurnoAsignar;
        private System.Windows.Forms.ComboBox cboTurnoAsignar;
        private System.Windows.Forms.Button btnAsignar;
        private CapaPresentacion.UcAuditoria ucAuditoria;
        private System.Windows.Forms.Label lblTurnos;
        private System.Windows.Forms.DataGridView dgvTurnos;
    }
}
