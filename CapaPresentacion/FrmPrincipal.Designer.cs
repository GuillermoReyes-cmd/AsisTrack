namespace CapaPresentacion
{
    partial class FrmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.sepArchivo = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColaboradores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTurnos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuariosRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarcacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrarAsistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJustificaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRepTardanzas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRepAusentismo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRepHorasExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRepHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBarra = new System.Windows.Forms.ToolStrip();
            this.tsbMarcacion = new System.Windows.Forms.ToolStripButton();
            this.tsbColaboradores = new System.Windows.Forms.ToolStripButton();
            this.tsbJustificaciones = new System.Windows.Forms.ToolStripButton();
            this.tsbReportes = new System.Windows.Forms.ToolStripButton();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.tslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrReloj = new System.Windows.Forms.Timer(this.components);
            this.menuPrincipal.SuspendLayout();
            this.tsBarra.SuspendLayout();
            this.ssEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuArchivo, this.mnuMantenimiento, this.mnuMarcacion, this.mnuReportes, this.mnuAyuda });
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1100, 25);
            this.menuPrincipal.TabIndex = 0;
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuCerrarSesion, this.sepArchivo, this.mnuSalir });
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Text = "&Archivo";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Text = "Cerrar sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // sepArchivo
            // 
            this.sepArchivo.Name = "sepArchivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuColaboradores, this.mnuTurnos, this.mnuUsuariosRoles });
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Text = "&Mantenimiento";
            // 
            // mnuColaboradores
            // 
            this.mnuColaboradores.Name = "mnuColaboradores";
            this.mnuColaboradores.Text = "Colaboradores";
            this.mnuColaboradores.Click += new System.EventHandler(this.mnuColaboradores_Click);
            // 
            // mnuTurnos
            // 
            this.mnuTurnos.Name = "mnuTurnos";
            this.mnuTurnos.Text = "Turnos";
            this.mnuTurnos.Click += new System.EventHandler(this.mnuTurnos_Click);
            // 
            // mnuUsuariosRoles
            // 
            this.mnuUsuariosRoles.Name = "mnuUsuariosRoles";
            this.mnuUsuariosRoles.Text = "Usuarios y roles";
            this.mnuUsuariosRoles.Click += new System.EventHandler(this.mnuUsuariosRoles_Click);
            // 
            // mnuMarcacion
            // 
            this.mnuMarcacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuRegistrarAsistencia, this.mnuJustificaciones });
            this.mnuMarcacion.Name = "mnuMarcacion";
            this.mnuMarcacion.Text = "Mar&cación";
            // 
            // mnuRegistrarAsistencia
            // 
            this.mnuRegistrarAsistencia.Name = "mnuRegistrarAsistencia";
            this.mnuRegistrarAsistencia.Text = "Registrar asistencia";
            this.mnuRegistrarAsistencia.Click += new System.EventHandler(this.mnuRegistrarAsistencia_Click);
            // 
            // mnuJustificaciones
            // 
            this.mnuJustificaciones.Name = "mnuJustificaciones";
            this.mnuJustificaciones.Text = "Justificaciones y permisos";
            this.mnuJustificaciones.Click += new System.EventHandler(this.mnuJustificaciones_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuRepTardanzas, this.mnuRepAusentismo, this.mnuRepHorasExtras, this.mnuRepHistorial });
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Text = "&Reportes";
            // 
            // mnuRepTardanzas
            // 
            this.mnuRepTardanzas.Name = "mnuRepTardanzas";
            this.mnuRepTardanzas.Text = "Reporte de tardanzas por área";
            this.mnuRepTardanzas.Click += new System.EventHandler(this.mnuRepTardanzas_Click);
            // 
            // mnuRepAusentismo
            // 
            this.mnuRepAusentismo.Name = "mnuRepAusentismo";
            this.mnuRepAusentismo.Text = "Reporte comparativo de ausentismo";
            this.mnuRepAusentismo.Click += new System.EventHandler(this.mnuRepAusentismo_Click);
            // 
            // mnuRepHorasExtras
            // 
            this.mnuRepHorasExtras.Name = "mnuRepHorasExtras";
            this.mnuRepHorasExtras.Text = "Consolidado de horas extras";
            this.mnuRepHorasExtras.Click += new System.EventHandler(this.mnuRepHorasExtras_Click);
            // 
            // mnuRepHistorial
            // 
            this.mnuRepHistorial.Name = "mnuRepHistorial";
            this.mnuRepHistorial.Text = "Historial de asistencia individual";
            this.mnuRepHistorial.Click += new System.EventHandler(this.mnuRepHistorial_Click);
            // 
            // mnuAyuda
            // 
            this.mnuAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuAcercaDe });
            this.mnuAyuda.Name = "mnuAyuda";
            this.mnuAyuda.Text = "A&yuda";
            // 
            // mnuAcercaDe
            // 
            this.mnuAcercaDe.Name = "mnuAcercaDe";
            this.mnuAcercaDe.Text = "Acerca de AsisTrack";
            this.mnuAcercaDe.Click += new System.EventHandler(this.mnuAcercaDe_Click);
            // 
            // tsBarra
            // 
            this.tsBarra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbMarcacion, this.tsbColaboradores, this.tsbJustificaciones, this.tsbReportes });
            this.tsBarra.Location = new System.Drawing.Point(0, 25);
            this.tsBarra.Name = "tsBarra";
            this.tsBarra.Size = new System.Drawing.Size(1100, 25);
            this.tsBarra.TabIndex = 1;
            // 
            // tsbMarcacion
            // 
            this.tsbMarcacion.Name = "tsbMarcacion";
            this.tsbMarcacion.Text = "Registrar marcación";
            this.tsbMarcacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbMarcacion.Click += new System.EventHandler(this.mnuRegistrarAsistencia_Click);
            // 
            // tsbColaboradores
            // 
            this.tsbColaboradores.Name = "tsbColaboradores";
            this.tsbColaboradores.Text = "Colaboradores";
            this.tsbColaboradores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbColaboradores.Click += new System.EventHandler(this.mnuColaboradores_Click);
            // 
            // tsbJustificaciones
            // 
            this.tsbJustificaciones.Name = "tsbJustificaciones";
            this.tsbJustificaciones.Text = "Justificaciones";
            this.tsbJustificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbJustificaciones.Click += new System.EventHandler(this.mnuJustificaciones_Click);
            // 
            // tsbReportes
            // 
            this.tsbReportes.Name = "tsbReportes";
            this.tsbReportes.Text = "Reporte de tardanzas";
            this.tsbReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbReportes.Click += new System.EventHandler(this.mnuRepTardanzas_Click);
            // 
            // ssEstado
            // 
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tslUsuario, this.tslConexion, this.tslFecha });
            this.ssEstado.Location = new System.Drawing.Point(0, 656);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Size = new System.Drawing.Size(1100, 24);
            this.ssEstado.TabIndex = 2;
            // 
            // tslUsuario
            // 
            this.tslUsuario.Name = "tslUsuario";
            this.tslUsuario.Text = "Usuario: —";
            // 
            // tslConexion
            // 
            this.tslConexion.Name = "tslConexion";
            this.tslConexion.Text = "Conectado a SQL Server (Entity Framework Core)";
            this.tslConexion.Spring = true;
            this.tslConexion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tslFecha
            // 
            this.tslFecha.Name = "tslFecha";
            this.tslFecha.Text = "";
            // 
            // tmrReloj
            // 
            this.tmrReloj.Interval = 1000;
            this.tmrReloj.Tick += new System.EventHandler(this.tmrReloj_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.ssEstado);
            this.Controls.Add(this.tsBarra);
            this.Controls.Add(this.menuPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Name = "FrmPrincipal";
            this.Text = "AsisTrack — Panel principal";
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.tsBarra.ResumeLayout(false);
            this.tsBarra.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripSeparator sepArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuColaboradores;
        private System.Windows.Forms.ToolStripMenuItem mnuTurnos;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuariosRoles;
        private System.Windows.Forms.ToolStripMenuItem mnuMarcacion;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrarAsistencia;
        private System.Windows.Forms.ToolStripMenuItem mnuJustificaciones;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuRepTardanzas;
        private System.Windows.Forms.ToolStripMenuItem mnuRepAusentismo;
        private System.Windows.Forms.ToolStripMenuItem mnuRepHorasExtras;
        private System.Windows.Forms.ToolStripMenuItem mnuRepHistorial;
        private System.Windows.Forms.ToolStripMenuItem mnuAyuda;
        private System.Windows.Forms.ToolStripMenuItem mnuAcercaDe;
        private System.Windows.Forms.ToolStrip tsBarra;
        private System.Windows.Forms.ToolStripButton tsbMarcacion;
        private System.Windows.Forms.ToolStripButton tsbColaboradores;
        private System.Windows.Forms.ToolStripButton tsbJustificaciones;
        private System.Windows.Forms.ToolStripButton tsbReportes;
        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel tslUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tslConexion;
        private System.Windows.Forms.ToolStripStatusLabel tslFecha;
        private System.Windows.Forms.Timer tmrReloj;
    }
}
