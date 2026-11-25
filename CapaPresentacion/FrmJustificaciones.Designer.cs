namespace CapaPresentacion
{
    partial class FrmJustificaciones
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
            this.lblEstadoFiltro = new System.Windows.Forms.Label();
            this.cboEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.dgvJustificaciones = new System.Windows.Forms.DataGridView();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.lblColaboradorT = new System.Windows.Forms.Label();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.lblEstadoT = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMotivoT = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblFechaInicioT = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinT = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblAprobadoPorT = new System.Windows.Forms.Label();
            this.lblAprobadoPor = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.ucAuditoria = new CapaPresentacion.UcAuditoria();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustificaciones)).BeginInit();
            this.grpDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEstadoFiltro
            // 
            this.lblEstadoFiltro.Location = new System.Drawing.Point(12, 16);
            this.lblEstadoFiltro.Name = "lblEstadoFiltro";
            this.lblEstadoFiltro.TabIndex = 0;
            this.lblEstadoFiltro.Text = "Estado:";
            this.lblEstadoFiltro.AutoSize = true;
            // 
            // cboEstadoFiltro
            // 
            this.cboEstadoFiltro.Location = new System.Drawing.Point(68, 12);
            this.cboEstadoFiltro.Name = "cboEstadoFiltro";
            this.cboEstadoFiltro.Size = new System.Drawing.Size(120, 25);
            this.cboEstadoFiltro.TabIndex = 1;
            this.cboEstadoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoFiltro.FormattingEnabled = true;
            // 
            // lblDesde
            // 
            this.lblDesde.Location = new System.Drawing.Point(205, 16);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.AutoSize = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(255, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(115, 25);
            this.dtpDesde.TabIndex = 3;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(385, 16);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.AutoSize = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(432, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(115, 25);
            this.dtpHasta.TabIndex = 5;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(560, 11);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 27);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(660, 11);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(140, 27);
            this.btnNueva.TabIndex = 7;
            this.btnNueva.Text = "Nueva solicitud";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // dgvJustificaciones
            // 
            this.dgvJustificaciones.Location = new System.Drawing.Point(12, 46);
            this.dgvJustificaciones.Name = "dgvJustificaciones";
            this.dgvJustificaciones.Size = new System.Drawing.Size(936, 230);
            this.dgvJustificaciones.TabIndex = 8;
            this.dgvJustificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJustificaciones.SelectionChanged += new System.EventHandler(this.dgvJustificaciones_SelectionChanged);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.lblColaboradorT);
            this.grpDetalle.Controls.Add(this.cboColaborador);
            this.grpDetalle.Controls.Add(this.lblEstadoT);
            this.grpDetalle.Controls.Add(this.lblEstado);
            this.grpDetalle.Controls.Add(this.lblMotivoT);
            this.grpDetalle.Controls.Add(this.txtMotivo);
            this.grpDetalle.Controls.Add(this.lblFechaInicioT);
            this.grpDetalle.Controls.Add(this.dtpInicio);
            this.grpDetalle.Controls.Add(this.lblFechaFinT);
            this.grpDetalle.Controls.Add(this.dtpFin);
            this.grpDetalle.Controls.Add(this.lblAprobadoPorT);
            this.grpDetalle.Controls.Add(this.lblAprobadoPor);
            this.grpDetalle.Controls.Add(this.btnGuardar);
            this.grpDetalle.Controls.Add(this.btnAprobar);
            this.grpDetalle.Controls.Add(this.btnRechazar);
            this.grpDetalle.Location = new System.Drawing.Point(12, 285);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(936, 185);
            this.grpDetalle.TabIndex = 9;
            this.grpDetalle.Text = "Detalle de la justificación";
            // 
            // lblColaboradorT
            // 
            this.lblColaboradorT.Location = new System.Drawing.Point(12, 32);
            this.lblColaboradorT.Name = "lblColaboradorT";
            this.lblColaboradorT.TabIndex = 10;
            this.lblColaboradorT.Text = "Colaborador:";
            this.lblColaboradorT.AutoSize = true;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Location = new System.Drawing.Point(110, 28);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(320, 25);
            this.cboColaborador.TabIndex = 11;
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.FormattingEnabled = true;
            // 
            // lblEstadoT
            // 
            this.lblEstadoT.Location = new System.Drawing.Point(12, 66);
            this.lblEstadoT.Name = "lblEstadoT";
            this.lblEstadoT.TabIndex = 12;
            this.lblEstadoT.Text = "Estado:";
            this.lblEstadoT.AutoSize = true;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(110, 63);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(110, 26);
            this.lblEstado.TabIndex = 13;
            this.lblEstado.Text = "—";
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMotivoT
            // 
            this.lblMotivoT.Location = new System.Drawing.Point(12, 98);
            this.lblMotivoT.Name = "lblMotivoT";
            this.lblMotivoT.TabIndex = 14;
            this.lblMotivoT.Text = "Motivo:";
            this.lblMotivoT.AutoSize = true;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(12, 118);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(500, 58);
            this.txtMotivo.TabIndex = 15;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.MaxLength = 250;
            // 
            // lblFechaInicioT
            // 
            this.lblFechaInicioT.Location = new System.Drawing.Point(540, 32);
            this.lblFechaInicioT.Name = "lblFechaInicioT";
            this.lblFechaInicioT.TabIndex = 16;
            this.lblFechaInicioT.Text = "Fecha inicio:";
            this.lblFechaInicioT.AutoSize = true;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(650, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(120, 25);
            this.dtpInicio.TabIndex = 17;
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblFechaFinT
            // 
            this.lblFechaFinT.Location = new System.Drawing.Point(540, 66);
            this.lblFechaFinT.Name = "lblFechaFinT";
            this.lblFechaFinT.TabIndex = 18;
            this.lblFechaFinT.Text = "Fecha fin:";
            this.lblFechaFinT.AutoSize = true;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(650, 62);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(120, 25);
            this.dtpFin.TabIndex = 19;
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblAprobadoPorT
            // 
            this.lblAprobadoPorT.Location = new System.Drawing.Point(540, 100);
            this.lblAprobadoPorT.Name = "lblAprobadoPorT";
            this.lblAprobadoPorT.TabIndex = 20;
            this.lblAprobadoPorT.Text = "AprobadoPor:";
            this.lblAprobadoPorT.AutoSize = true;
            this.lblAprobadoPorT.ForeColor = System.Drawing.Color.Gray;
            // 
            // lblAprobadoPor
            // 
            this.lblAprobadoPor.Location = new System.Drawing.Point(650, 100);
            this.lblAprobadoPor.Name = "lblAprobadoPor";
            this.lblAprobadoPor.TabIndex = 21;
            this.lblAprobadoPor.Text = "—";
            this.lblAprobadoPor.AutoSize = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(540, 135);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 36);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar solicitud";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(680, 135);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(120, 36);
            this.btnAprobar.TabIndex = 23;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.ForeColor = System.Drawing.Color.FromArgb(46, 139, 62);
            this.btnAprobar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(808, 135);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(115, 36);
            this.btnRechazar.TabIndex = 24;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.ForeColor = System.Drawing.Color.FromArgb(200, 50, 40);
            this.btnRechazar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // ucAuditoria
            // 
            this.ucAuditoria.Location = new System.Drawing.Point(12, 478);
            this.ucAuditoria.Name = "ucAuditoria";
            this.ucAuditoria.Size = new System.Drawing.Size(460, 118);
            this.ucAuditoria.TabIndex = 25;
            // 
            // FrmJustificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 606);
            this.Controls.Add(this.ucAuditoria);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.dgvJustificaciones);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.cboEstadoFiltro);
            this.Controls.Add(this.lblEstadoFiltro);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmJustificaciones";
            this.Text = "AsisTrack — Justificaciones y permisos";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmJustificaciones_Load);
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblEstadoFiltro;
        private System.Windows.Forms.ComboBox cboEstadoFiltro;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.DataGridView dgvJustificaciones;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblColaboradorT;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.Label lblEstadoT;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMotivoT;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblFechaInicioT;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblFechaFinT;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblAprobadoPorT;
        private System.Windows.Forms.Label lblAprobadoPor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private CapaPresentacion.UcAuditoria ucAuditoria;
    }
}
