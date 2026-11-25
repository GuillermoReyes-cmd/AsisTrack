namespace CapaPresentacion
{
    partial class FrmReporteTardanzas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartTardanzasArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend chartTardanzasLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series chartTardanzasSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chartTardanzas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblResumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTardanzas)).BeginInit();
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
            // lblArea
            // 
            this.lblArea.Location = new System.Drawing.Point(250, 16);
            this.lblArea.Name = "lblArea";
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Área:";
            this.lblArea.AutoSize = true;
            // 
            // cboArea
            // 
            this.cboArea.Location = new System.Drawing.Point(292, 12);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(150, 25);
            this.cboArea.TabIndex = 3;
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.FormattingEnabled = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(455, 11);
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
            this.btnExportar.Location = new System.Drawing.Point(558, 11);
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
            // chartTardanzas
            // 
            chartTardanzasArea.Name = "ChartArea1";
            this.chartTardanzas.ChartAreas.Add(chartTardanzasArea);
            chartTardanzasLegend.Name = "Legend1";
            chartTardanzasLegend.Enabled = false;
            this.chartTardanzas.Legends.Add(chartTardanzasLegend);
            chartTardanzasSeries.ChartArea = "ChartArea1";
            chartTardanzasSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chartTardanzasSeries.Legend = "Legend1";
            chartTardanzasSeries.Name = "Tardanzas";
            this.chartTardanzas.Series.Add(chartTardanzasSeries);
            this.chartTardanzas.Location = new System.Drawing.Point(12, 76);
            this.chartTardanzas.Name = "chartTardanzas";
            this.chartTardanzas.Size = new System.Drawing.Size(876, 450);
            this.chartTardanzas.TabIndex = 7;
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
            // FrmReporteTardanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 566);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.chartTardanzas);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.cboPeriodo);
            this.Controls.Add(this.lblPeriodo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmReporteTardanzas";
            this.Text = "AsisTrack — Reporte de tardanzas por área";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmReporteTardanzas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTardanzas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTardanzas;
        private System.Windows.Forms.Label lblResumen;
    }
}
