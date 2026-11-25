using System;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        private UsuarioNegocio uNegocio = new UsuarioNegocio();
        private RolNegocio rNegocio = new RolNegocio();
        private int intentos = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                rNegocio.ListarTodo();
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo conectar a la base de datos AsisTrackDB." + Environment.NewLine +
                    "1. Ejecute el script AsisTrackDB.sql en SQL Server." + Environment.NewLine +
                    "2. Revise el Server de la cadena de conexión en CapaDatos\\AsisTrackDBContext.cs.", ex);
            }
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "" || txtContrasena.Text == "")
            {
                Estilos.Aviso("Ingrese su usuario y contraseña.");
                return;
            }
            try
            {
                Usuario usuario = uNegocio.Autenticar(txtUsuario.Text.Trim(), txtContrasena.Text);
                if (usuario == null)
                {
                    intentos++;
                    Estilos.Aviso("Usuario o contraseña incorrectos, o la cuenta está inactiva.");
                    txtContrasena.Clear();
                    txtContrasena.Focus();
                    if (intentos >= 3)
                    {
                        Estilos.Aviso("Se superó el número de intentos permitidos.");
                        DialogResult = DialogResult.Cancel;
                    }
                    return;
                }
                Sesion.UsuarioActual = usuario;
                Sesion.RolActual = rNegocio.BuscarRolPorId(usuario.RolID);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Estilos.Error("No se pudo validar el usuario.", ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
