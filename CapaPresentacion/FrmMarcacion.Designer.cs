namespace CapaPresentacion
{
    partial class FrmMarcacion
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
            this.components = new System.ComponentModel.Container();
            this.grpMarcacion = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblColaboradorT = new System.Windows.Forms.Label();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.lblTurnoT = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.grpUltimo = new System.Windows.Forms.GroupBox();
            this.lblTipoT = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblRegistrado = new System.Windows.Forms.Label();
            this.lblEstadoT = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblMinutosT = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.ucAuditoria = new CapaPresentacion.UcAuditoria();
            this.tmrReloj = new System.Windows.Forms.Timer(this.components);
            this.grpMarcacion.SuspendLayout();
            this.grpUltimo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMarcacion
            // 
            this.grpMarcacion.Controls.Add(this.lblDni);
            this.grpMarcacion.Controls.Add(this.txtDni);
            this.grpMarcacion.Controls.Add(this.btnBuscar);
            this.grpMarcacion.Controls.Add(this.lblColaboradorT);
            this.grpMarcacion.Controls.Add(this.lblColaborador);
            this.grpMarcacion.Controls.Add(this.lblTurnoT);
            this.grpMarcacion.Controls.Add(this.lblTurno);
            this.grpMarcacion.Controls.Add(this.lblHora);
            this.grpMarcacion.Controls.Add(this.lblFecha);
            this.grpMarcacion.Location = new System.Drawing.Point(15, 10);
            this.grpMarcacion.Name = "grpMarcacion";
            this.grpMarcacion.Size = new System.Drawing.Size(530, 235);
            this.grpMarcacion.TabIndex = 0;
            this.grpMarcacion.Text = "Marcación de asistencia";
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(15, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "DNI / Código:";
            this.lblDni.AutoSize = true;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(130, 29);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(250, 25);
            this.txtDni.TabIndex = 2;
            this.txtDni.MaxLength = 8;
            this.txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(390, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 29);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblColaboradorT
            // 
            this.lblColaboradorT.Location = new System.Drawing.Point(15, 72);
            this.lblColaboradorT.Name = "lblColaboradorT";
            this.lblColaboradorT.TabIndex = 4;
            this.lblColaboradorT.Text = "Colaborador:";
            this.lblColaboradorT.AutoSize = true;
            // 
            // lblColaborador
            // 
            this.lblColaborador.Location = new System.Drawing.Point(130, 72);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.TabIndex = 5;
            this.lblColaborador.Text = "—";
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // lblTurnoT
            // 
            this.lblTurnoT.Location = new System.Drawing.Point(15, 100);
            this.lblTurnoT.Name = "lblTurnoT";
            this.lblTurnoT.TabIndex = 6;
            this.lblTurnoT.Text = "Turno:";
            this.lblTurnoT.AutoSize = true;
            // 
            // lblTurno
            // 
            this.lblTurno.Location = new System.Drawing.Point(130, 100);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.TabIndex = 7;
            this.lblTurno.Text = "—";
            this.lblTurno.AutoSize = true;
            // 
            // lblHora
            // 
            this.lblHora.Location = new System.Drawing.Point(5, 128);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(520, 58);
            this.lblHora.TabIndex = 8;
            this.lblHora.Text = "00:00:00";
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(5, 190);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(520, 25);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "";
            this.lblFecha.ForeColor = System.Drawing.Color.Gray;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIngreso
            // 
            this.btnIngreso.Location = new System.Drawing.Point(15, 255);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(260, 52);
            this.btnIngreso.TabIndex = 10;
            this.btnIngreso.Text = "Registrar INGRESO";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(285, 255);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(260, 52);
            this.btnSalida.TabIndex = 11;
            this.btnSalida.Text = "Registrar SALIDA";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // grpUltimo
            // 
            this.grpUltimo.Controls.Add(this.lblTipoT);
            this.grpUltimo.Controls.Add(this.lblTipo);
            this.grpUltimo.Controls.Add(this.lblRegistrado);
            this.grpUltimo.Controls.Add(this.lblEstadoT);
            this.grpUltimo.Controls.Add(this.lblEstado);
            this.grpUltimo.Controls.Add(this.lblMinutosT);
            this.grpUltimo.Controls.Add(this.lblMinutos);
            this.grpUltimo.Location = new System.Drawing.Point(15, 318);
            this.grpUltimo.Name = "grpUltimo";
            this.grpUltimo.Size = new System.Drawing.Size(530, 140);
            this.grpUltimo.TabIndex = 12;
            this.grpUltimo.Text = "Último registro";
            // 
            // lblTipoT
            // 
            this.lblTipoT.Location = new System.Drawing.Point(15, 32);
            this.lblTipoT.Name = "lblTipoT";
            this.lblTipoT.TabIndex = 13;
            this.lblTipoT.Text = "Tipo de marcación:";
            this.lblTipoT.AutoSize = true;
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(180, 32);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.TabIndex = 14;
            this.lblTipo.Text = "—";
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // lblRegistrado
            // 
            this.lblRegistrado.Location = new System.Drawing.Point(300, 32);
            this.lblRegistrado.Name = "lblRegistrado";
            this.lblRegistrado.Size = new System.Drawing.Size(215, 20);
            this.lblRegistrado.TabIndex = 15;
            this.lblRegistrado.Text = "";
            this.lblRegistrado.ForeColor = System.Drawing.Color.Gray;
            this.lblRegistrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstadoT
            // 
            this.lblEstadoT.Location = new System.Drawing.Point(15, 66);
            this.lblEstadoT.Name = "lblEstadoT";
            this.lblEstadoT.TabIndex = 16;
            this.lblEstadoT.Text = "Estado:";
            this.lblEstadoT.AutoSize = true;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(180, 63);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 26);
            this.lblEstado.TabIndex = 17;
            this.lblEstado.Text = "—";
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinutosT
            // 
            this.lblMinutosT.Location = new System.Drawing.Point(15, 102);
            this.lblMinutosT.Name = "lblMinutosT";
            this.lblMinutosT.TabIndex = 18;
            this.lblMinutosT.Text = "Minutos de tardanza:";
            this.lblMinutosT.AutoSize = true;
            // 
            // lblMinutos
            // 
            this.lblMinutos.Location = new System.Drawing.Point(180, 102);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.TabIndex = 19;
            this.lblMinutos.Text = "—";
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            // 
            // ucAuditoria
            // 
            this.ucAuditoria.Location = new System.Drawing.Point(15, 468);
            this.ucAuditoria.Name = "ucAuditoria";
            this.ucAuditoria.Size = new System.Drawing.Size(530, 118);
            this.ucAuditoria.TabIndex = 20;
            // 
            // tmrReloj
            // 
            this.tmrReloj.Interval = 1000;
            this.tmrReloj.Tick += new System.EventHandler(this.tmrReloj_Tick);
            // 
            // FrmMarcacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Controls.Add(this.ucAuditoria);
            this.Controls.Add(this.grpUltimo);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.grpMarcacion);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmMarcacion";
            this.Text = "AsisTrack — Registro de asistencia";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMarcacion_Load);
            this.grpUltimo.ResumeLayout(false);
            this.grpUltimo.PerformLayout();
            this.grpMarcacion.ResumeLayout(false);
            this.grpMarcacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpMarcacion;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblColaboradorT;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Label lblTurnoT;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.GroupBox grpUltimo;
        private System.Windows.Forms.Label lblTipoT;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblRegistrado;
        private System.Windows.Forms.Label lblEstadoT;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMinutosT;
        private System.Windows.Forms.Label lblMinutos;
        private CapaPresentacion.UcAuditoria ucAuditoria;
        private System.Windows.Forms.Timer tmrReloj;
    }
}
