using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // .NET 8 usa Segoe UI 9 por defecto; se mantiene la fuente de .NET Framework
            // para que los formularios conserven el tamaño con el que fueron diseñados.
            Application.SetDefaultFont(new Font("Microsoft Sans Serif", 8.25F));

            while (true)
            {
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() != DialogResult.OK)
                {
                    break;
                }
                FrmPrincipal principal = new FrmPrincipal();
                Application.Run(principal);
                Sesion.Cerrar();
                if (!principal.CerrarSesionSolicitado)
                {
                    break;
                }
            }
        }
    }
}
