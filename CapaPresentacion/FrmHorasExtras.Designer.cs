namespace CapaPresentacion
{
    partial class FrmHorasExtras
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
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvHoras = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Location = new System.Drawing.Point(12, 16);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo:";
            this.lblPeriodo.AutoSize = true;
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Location = new System.Drawing.Point(75, 12);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(160, 25);
            this.cboPeriodo.TabIndex = 1;
            this.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodo.FormattingEnabled = true;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.Location = new System.Drawing.Point(250, 16);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.TabIndex = 2;
            this.lblDepartamento.Text = "Departamento:";
            this.lblDepartamento.AutoSize = true;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(348, 12);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(150, 25);
            this.cboDepartamento.TabIndex = 3;
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(511, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(95, 27);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(614, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(95, 27);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(12, 48);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(876, 24);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            // 
            // dgvHoras
            // 
            this.dgvHoras.Location = new System.Drawing.Point(12, 76);
            this.dgvHoras.Name = "dgvHoras";
            this.dgvHoras.Size = new System.Drawing.Size(876, 450);
            this.dgvHoras.TabIndex = 7;
            this.dgvHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // lblResumen
            // 
            this.lblResumen.Location = new System.Drawing.Point(12, 535);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(876, 22);
            this.lblResumen.TabIndex = 8;
            this.lblResumen.Text = "";
            this.lblResumen.ForeColor = System.Drawing.Color.Gray;
            // 
            // FrmHorasExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 566);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.dgvHoras);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboDepartamento);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.cboPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmHorasExtras";
            this.Text = "AsisTrack — Consolidado de horas extras";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmHorasExtras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvHoras;
        private System.Windows.Forms.Label lblResumen;
    }
}
