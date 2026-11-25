using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class JustificacionNegocio
    {
        private JustificacionDAO jDAO = new JustificacionDAO();
        private ColaboradorDAO cDAO = new ColaboradorDAO();

        public DataTable ListarTabla(string estado, DateTime desde, DateTime hasta)
        {
            List<Justificacion> lista;
            if (estado == "")
            {
                lista = jDAO.ListarPorFechas(desde.Date, hasta.Date);
            }
            else
            {
                lista = jDAO.ListarPorEstado(estado, desde.Date, hasta.Date);
            }
            List<Colaborador> colaboradores = cDAO.ListarTodo();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Colaborador");
            dt.Columns.Add("Motivo");
            dt.Columns.Add("Fecha inicio");
            dt.Columns.Add("Fecha fin");
            dt.Columns.Add("Estado");
            foreach (Justificacion j in lista)
            {
                if (j.EstadoAprobacion == "Pendiente")
                {
                    AgregarFila(dt, j, colaboradores);
                }
            }
            foreach (Justificacion j in lista)
            {
                if (j.EstadoAprobacion != "Pendiente")
                {
                    AgregarFila(dt, j, colaboradores);
                }
            }
            return dt;
        }
        void AgregarFila(DataTable dt, Justificacion j, List<Colaborador> colaboradores)
        {
            string nombre = "";
            foreach (Colaborador c in colaboradores)
            {
                if (c.ColaboradorID == j.ColaboradorID)
                {
                    nombre = c.Apellidos.ToUpper() + ", " + c.Nombres;
                }
            }
            dt.Rows.Add(j.JustificacionID, nombre, j.Motivo, j.FechaInicio.ToString("dd/MM/yyyy"),
                        j.FechaFin.ToString("dd/MM/yyyy"), j.EstadoAprobacion);
        }
        public Justificacion BuscarJustificacionPorId(int id)
        {
            return jDAO.BuscarJustificacionPorId(id);
        }
        public int SolicitarPermiso(Justificacion objJustificacion)
        {
            if (objJustificacion.FechaFin < objJustificacion.FechaInicio)
            {
                return -4;
            }
            objJustificacion.EstadoAprobacion = "Pendiente";
            objJustificacion.AprobadoPor = null;
            objJustificacion.CreatedAt = DateTime.Now;
            return jDAO.Insertar(objJustificacion);
        }
        bool EstaPendiente(int id)
        {
            Justificacion justificacion = jDAO.BuscarJustificacionPorId(id);
            return justificacion.EstadoAprobacion == "Pendiente";
        }
        public int Resolver(int id, string estado, int usuarioId)
        {
            if (!EstaPendiente(id))
            {
                return -3;
            }
            Justificacion jObj = new Justificacion();
            jObj.JustificacionID = id;
            jObj.EstadoAprobacion = estado;
            jObj.AprobadoPor = usuarioId;
            jObj.ModifiedBy = usuarioId;
            jObj.ModifiedAt = DateTime.Now;
            return jDAO.Resolver(jObj);
        }
    }
}
