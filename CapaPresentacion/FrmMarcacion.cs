using System;
using System.Drawing;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmMarcacion : Form
    {
        private ColaboradorNegocio cNegocio = new ColaboradorNegocio();
        private TurnoNegocio tNegocio = new TurnoNegocio();
        private MarcacionNegocio mNegocio = new MarcacionNegocio();
        private Colaborador colaborador;

        public FrmMarcacion()
        {
            InitializeComponent();
        }

        private void FrmMarcacion_Load(object sender, EventArgs e)
        {
            LimpiarColaborador();
            tmrReloj.Start();
            tmrReloj_Tick(null, EventArgs.Empty);
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            lblHora.Text = ahora.ToString("hh:mm:ss tt");
            lblFecha.Text = Periodo.FechaLarga(ahora);
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar_Click(sender, EventArgs.Empty);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (dni.Length != 8)
            {
                Estilos.Aviso("Ingrese un DNI válido de 8 dígitos.");
                return;
            }
            try
            {
                Colaborador c = cNegocio.BuscarPorDni(dni);
                if (c == null || c.Estado == false)
                {
                    LimpiarColaborador();
                    Estilos.Aviso("No existe un colaborador activo con ese DNI.");
                    return;
                }
                colaborador = c;
                Turno turno = tNegocio.BuscarTurnoPorId(c.TurnoID);
                lblColaborador.Text = c.NombreCompleto;
                lblTurno.Text = turno.NombreTurno + "   (" + turno.HoraInicio.ToString(@"hh\:mm") + " – " +
                                turno.HoraFin.ToString(@"hh\:mm") + ")   ·   Tolerancia: " + turno.ToleranciaMinutos + " min";

                Marcacion ultima = mNegocio.UltimaReciente(c.ColaboradorID);
                MostrarUltima(ultima);
                HabilitarBotones(ultima == null || ultima.TipoMarcacion == "Salida");
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo buscar al colaborador.", ex);
            }
        }

        private void HabilitarBotones(bool tocaIngreso)
        {
            btnIngreso.Enabled = tocaIngreso;
            btnSalida.Enabled = !tocaIngreso;
            if (tocaIngreso)
            {
                btnIngreso.Focus();
            }
            else
            {
                btnSalida.Focus();
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Registrar("Ingreso");
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            Registrar("Salida");
        }

        private void Registrar(string tipo)
        {
            if (colaborador == null)
            {
                Estilos.Aviso("Primero busque al colaborador por su DNI.");
                return;
            }
            try
            {
                Marcacion mObj = new Marcacion();
                mObj.ColaboradorID = colaborador.ColaboradorID;
                mObj.TipoMarcacion = tipo;
                mObj.CreatedBy = Sesion.UsuarioID;

                int resultado = mNegocio.Registrar(mObj);
                if (resultado == -3)
                {
                    Estilos.Aviso("El colaborador no está activo.");
                    return;
                }
                if (resultado == -4)
                {
                    Estilos.Aviso("La marcación de " + tipo.ToLower() + " no corresponde. Vuelva a buscar al colaborador por su DNI.");
                    return;
                }
                Marcacion registrada = mNegocio.BuscarMarcacionPorId(resultado);
                MostrarUltima(registrada);
                HabilitarBotones(tipo == "Salida");
                string mensaje = "Salida registrada a las " + registrada.FechaHora.ToString("hh:mm:ss tt") +
                                 Environment.NewLine + mNegocio.DescribirSalida(mNegocio.MinutosDespuesDelFin);
                if (tipo == "Ingreso")
                {
                    mensaje = "Ingreso registrado a las " + registrada.FechaHora.ToString("hh:mm:ss tt") +
                              Environment.NewLine + "Estado: " + registrada.Estado;
                }
                Estilos.Info(mensaje);
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo registrar la marcación.", ex);
            }
        }

        private void MostrarUltima(Marcacion m)
        {
            if (m == null)
            {
                lblTipo.Text = "—";
                lblRegistrado.Text = "Sin marcaciones recientes";
                lblEstado.Text = "—";
                lblEstado.BackColor = SystemColors.Control;
                lblEstado.ForeColor = Color.Black;
                lblMinutos.Text = "—";
                ucAuditoria.Limpiar();
                return;
            }
            lblTipo.Text = m.TipoMarcacion;
            lblRegistrado.Text = "Registrado: " + m.FechaHora.ToString("dd/MM hh:mm:ss tt");
            bool esIngreso = m.TipoMarcacion == "Ingreso";
            bool tarde = esIngreso && m.Estado == "Tarde";
            if (esIngreso)
            {
                lblEstado.Text = m.Estado;
                lblMinutos.Text = m.MinutosTardanza + " min";
            }
            else
            {
                lblEstado.Text = "—";
                lblMinutos.Text = "—";
            }
            if (tarde)
            {
                lblEstado.BackColor = Color.FromArgb(253, 222, 222);
                lblEstado.ForeColor = Estilos.Rojo;
                lblMinutos.ForeColor = Estilos.Rojo;
            }
            else
            {
                lblEstado.BackColor = esIngreso ? Color.FromArgb(222, 245, 226) : SystemColors.Control;
                lblEstado.ForeColor = Estilos.Verde;
                lblMinutos.ForeColor = Color.Black;
            }
            ucAuditoria.Mostrar(m.CreatedBy, m.CreatedAt, m.ModifiedBy, m.ModifiedAt);
        }

        private void LimpiarColaborador()
        {
            colaborador = null;
            lblColaborador.Text = "—";
            lblTurno.Text = "—";
            btnIngreso.Enabled = false;
            btnSalida.Enabled = false;
            MostrarUltima(null);
            lblRegistrado.Text = "";
        }
    }
}
