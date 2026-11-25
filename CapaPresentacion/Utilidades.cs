using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }
        public static Rol RolActual { get; set; }

        public static int UsuarioID
        {
            get { return UsuarioActual == null ? 1 : UsuarioActual.UsuarioID; }
        }

        public static bool TienePermiso(string permiso)
        {
            RolNegocio rNegocio = new RolNegocio();
            return rNegocio.ObtenerPermisos(RolActual).Contains(permiso);
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
            RolActual = null;
        }
    }

    public static class Estilos
    {
        public static readonly Color Azul = Color.FromArgb(0, 120, 215);
        public static readonly Color Verde = Color.FromArgb(46, 139, 62);
        public static readonly Color Rojo = Color.FromArgb(200, 50, 40);
        public static readonly Color Ambar = Color.FromArgb(190, 130, 0);

        public static void AplicarGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(243, 243, 243);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 228, 247);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 26;
            dgv.DataBindingComplete += delegate { ColorearEstado(dgv, "Estado"); };
        }

        public static void ColorearEstado(DataGridView dgv, string columna)
        {
            if (!dgv.Columns.Contains(columna)) return;
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                string valor = Convert.ToString(fila.Cells[columna].Value);
                Color color = Color.Black;
                switch (valor)
                {
                    case "Activo":
                    case "Aprobado":
                    case "Puntual":
                        color = Verde; break;
                    case "Rechazado":
                    case "Tarde":
                    case "Falta":
                        color = Rojo; break;
                    case "Pendiente":
                        color = Ambar; break;
                    case "Inactivo":
                    case "Falta (justif.)":
                        color = Color.Gray; break;
                }
                fila.Cells[columna].Style.ForeColor = color;
                if (valor == "Inactivo") fila.DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        public static void Info(string mensaje)
        {
            MessageBox.Show(mensaje, "AsisTrack", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Aviso(string mensaje)
        {
            MessageBox.Show(mensaje, "AsisTrack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string mensaje, Exception ex)
        {
            Exception interna = ex;
            while (interna.InnerException != null)
            {
                interna = interna.InnerException;
            }
            MessageBox.Show(mensaje + Environment.NewLine + Environment.NewLine + "Detalle: " + interna.Message,
                "AsisTrack", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "AsisTrack", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }

    public static class Exportador
    {
        public static void ExportarCsv(DataTable tabla, string nombreSugerido)
        {
            if (tabla == null || tabla.Rows.Count == 0)
            {
                Estilos.Aviso("Primero genere el reporte.");
                return;
            }
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Archivo CSV (*.csv)|*.csv";
                dlg.FileName = nombreSugerido + ".csv";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                StringBuilder sb = new StringBuilder();
                List<string> cabecera = new List<string>();
                foreach (DataColumn c in tabla.Columns) cabecera.Add(Escapar(c.ColumnName));
                sb.AppendLine(string.Join(";", cabecera.ToArray()));
                foreach (DataRow r in tabla.Rows)
                {
                    List<string> celdas = new List<string>();
                    foreach (DataColumn c in tabla.Columns) celdas.Add(Escapar(Convert.ToString(r[c])));
                    sb.AppendLine(string.Join(";", celdas.ToArray()));
                }
                File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                Estilos.Info("Reporte exportado en:" + Environment.NewLine + dlg.FileName);
            }
        }

        private static string Escapar(string valor)
        {
            if (valor == null) return "";
            if (valor.Contains(";") || valor.Contains("\"") || valor.Contains("\n"))
                return "\"" + valor.Replace("\"", "\"\"") + "\"";
            return valor;
        }
    }

    public class ItemCombo
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        public ItemCombo(int id, string texto)
        {
            Id = id;
            Texto = texto;
        }

        public override string ToString()
        {
            return Texto;
        }
    }
}
