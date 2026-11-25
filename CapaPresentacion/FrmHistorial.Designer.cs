namespace CapaPresentacion
{
    partial class FrmHistorial
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
            this.lblColaborador = new System.Windows.Forms.Label();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblColaborador
            // 
            this.lblColaborador.Location = new System.Drawing.Point(12, 16);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.TabIndex = 0;
            this.lblColaborador.Text = "Colaborador:";
            this.lblColaborador.AutoSize = true;
            // 
            // cboColaborador
            // 
            this.cboColaborador.Location = new System.Drawing.Point(95, 12);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(250, 25);
            this.cboColaborador.TabIndex = 1;
            this.cboColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColaborador.FormattingEnabled = true;
            // 
            // lblDesde
            // 
            this.lblDesde.Location = new System.Drawing.Point(358, 16);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.AutoSize = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(405, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 25);
            this.dtpDesde.TabIndex = 3;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(525, 16);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.TabIndex = 4;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.AutoSize = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(570, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 25);
            this.dtpHasta.TabIndex = 5;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(690, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(95, 27);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(793, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(95, 27);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(12, 48);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(876, 24);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.Location = new System.Drawing.Point(12, 76);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(876, 450);
            this.dgvHistorial.TabIndex = 9;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // lblResumen
            // 
            this.lblResumen.Location = new System.Drawing.Point(12, 535);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(876, 22);
            this.lblResumen.TabIndex = 10;
            this.lblResumen.Text = "";
            this.lblResumen.ForeColor = System.Drawing.Color.Gray;
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 566);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.cboColaborador);
            this.Controls.Add(this.lblColaborador);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmHistorial";
            this.Text = "AsisTrack — Historial de asistencia individual";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblResumen;
    }
}
