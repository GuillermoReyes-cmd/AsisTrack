using System;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        public bool CerrarSesionSolicitado { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
                if (c is MdiClient) c.BackColor = System.Drawing.Color.FromArgb(160, 160, 160);

            tslUsuario.Text = "Usuario: " + Sesion.UsuarioActual.NombreUsuario + "  ·  Rol: " + Sesion.RolActual.NombreRol;
            AplicarPermisos();
            tmrReloj.Start();
            tmrReloj_Tick(null, EventArgs.Empty);
        }

        private void AplicarPermisos()
        {
            bool colaboradores = Sesion.TienePermiso("MANT_COLABORADORES");
            bool turnos = Sesion.TienePermiso("MANT_TURNOS");
            bool usuarios = Sesion.TienePermiso("MANT_USUARIOS");
            bool marcacion = Sesion.TienePermiso("MARCACION");
            bool justificaciones = Sesion.TienePermiso("JUSTIFICACIONES");
            bool reportes = Sesion.TienePermiso("REPORTES");
            bool historial = Sesion.TienePermiso("HISTORIAL");

            mnuColaboradores.Visible = colaboradores;
            tsbColaboradores.Visible = colaboradores;
            mnuTurnos.Visible = turnos;
            mnuUsuariosRoles.Visible = usuarios;
            mnuMantenimiento.Visible = colaboradores || turnos || usuarios;

            mnuRegistrarAsistencia.Visible = marcacion;
            tsbMarcacion.Visible = marcacion;
            mnuJustificaciones.Visible = justificaciones;
            tsbJustificaciones.Visible = justificaciones;
            mnuMarcacion.Visible = marcacion || justificaciones;

            mnuRepTardanzas.Visible = reportes;
            mnuRepAusentismo.Visible = reportes;
            mnuRepHorasExtras.Visible = reportes;
            tsbReportes.Visible = reportes;
            mnuRepHistorial.Visible = historial;
            mnuReportes.Visible = reportes || historial;
        }

        private void Abrir<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    return;
                }
            }
            T nuevo = new T();
            nuevo.MdiParent = this;
            nuevo.StartPosition = FormStartPosition.CenterScreen;
            nuevo.Show();
        }

        private void mnuColaboradores_Click(object sender, EventArgs e) { Abrir<FrmColaboradores>(); }
        private void mnuTurnos_Click(object sender, EventArgs e) { Abrir<FrmTurnos>(); }
        private void mnuUsuariosRoles_Click(object sender, EventArgs e) { Abrir<FrmUsuariosRoles>(); }
        private void mnuRegistrarAsistencia_Click(object sender, EventArgs e) { Abrir<FrmMarcacion>(); }
        private void mnuJustificaciones_Click(object sender, EventArgs e) { Abrir<FrmJustificaciones>(); }
        private void mnuRepTardanzas_Click(object sender, EventArgs e) { Abrir<FrmReporteTardanzas>(); }
        private void mnuRepAusentismo_Click(object sender, EventArgs e) { Abrir<FrmReporteAusentismo>(); }
        private void mnuRepHorasExtras_Click(object sender, EventArgs e) { Abrir<FrmHorasExtras>(); }
        private void mnuRepHistorial_Click(object sender, EventArgs e) { Abrir<FrmHistorial>(); }

        private void mnuAcercaDe_Click(object sender, EventArgs e)
        {
            Estilos.Info("AsisTrack - Sistema de Gestión de Control de Asistencia del Personal" + Environment.NewLine +
                "Fundamentos de Sistemas de Información - UPC" + Environment.NewLine +
                "Desarrollado en C# (Windows Forms) en capas con Entity Framework Core 8 y SQL Server.");
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (!Estilos.Confirmar("¿Desea cerrar la sesión?")) return;
            CerrarSesionSolicitado = true;
            Close();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrReloj.Stop();
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            tslFecha.Text = DateTime.Now.ToString("dd/MM/yyyy  hh:mm tt");
        }
    }
}
