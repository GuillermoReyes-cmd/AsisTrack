using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class UcAuditoria : UserControl
    {
        private UsuarioNegocio uNegocio = new UsuarioNegocio();

        public UcAuditoria()
        {
            InitializeComponent();
        }

        public void Mostrar(int? createdBy, DateTime? createdAt, int? modifiedBy, DateTime? modifiedAt)
        {
            lblCreatedBy.Text = createdBy.HasValue ? uNegocio.NombreDeUsuario(createdBy) : "—";
            lblCreatedAt.Text = Formato(createdAt);
            lblModifiedBy.Text = modifiedBy.HasValue ? uNegocio.NombreDeUsuario(modifiedBy) : "—";
            lblModifiedAt.Text = Formato(modifiedAt);
        }

        public void Limpiar()
        {
            lblCreatedBy.Text = "—";
            lblCreatedAt.Text = "—";
            lblModifiedBy.Text = "—";
            lblModifiedAt.Text = "—";
        }

        private static string Formato(DateTime? fecha)
        {
            return fecha.HasValue ? fecha.Value.ToString("dd/MM/yyyy HH:mm:ss") : "—";
        }
    }
}
