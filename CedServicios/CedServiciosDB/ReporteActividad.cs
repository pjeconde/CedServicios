using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class ReporteActividad : db
    {
        public ReporteActividad(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.ReporteActividad> Estadistica(DateTime FechaDsd, DateTime FechaHst)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Entidad.OrdenReporteActividad, IdEntidad, DescrEntidad, Evento, Estado, count(*) as Cantidad");
            a.AppendLine("from Log, Entidad ");
            a.AppendLine("where Fecha>='" + FechaDsd.ToString("yyyyMMdd") + "' and Fecha<='" + FechaHst.ToString("yyyyMMdd") + "' and Log.Entidad=Entidad.IdEntidad ");
            a.AppendLine("group by Entidad.OrdenReporteActividad, IdEntidad, DescrEntidad, Evento, Estado ");
            a.AppendLine("order by Entidad.OrdenReporteActividad, Evento, Estado ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.ReporteActividad> lista = new List<Entidades.ReporteActividad>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.ReporteActividad permiso = new Entidades.ReporteActividad();
                    Copiar(dt.Rows[i], permiso);
                    lista.Add(permiso);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.ReporteActividad Hasta)
        {
            Hasta.DescrEntidad = Convert.ToString(Desde["DescrEntidad"]);
            Hasta.Evento = Convert.ToString(Desde["Evento"]);
            Hasta.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.Cantidad = Convert.ToInt32(Desde["Cantidad"]);
        }
    }
}