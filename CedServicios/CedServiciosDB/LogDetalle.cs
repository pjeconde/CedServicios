using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class LogDetalle : db
    {
        public LogDetalle(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.LogDetalle> ListaPorIdLog(int IdLog)
        {
            List<Entidades.LogDetalle> lista = new List<Entidades.LogDetalle>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("LogDetalle.IdLogDetalle, LogDetalle.IdLog, LogDetalle.TipoDetalle, LogDetalle.Detalle ");
                a.Append("from LogDetalle ");
                a.Append("where LogDetalle.IdLog = " + IdLog + " ");
                a.Append("order by LogDetalle.IdLog asc, IdLogDetalle asc ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.LogDetalle elem = new Entidades.LogDetalle();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.LogDetalle Hasta)
        {
            Hasta.Id = Convert.ToInt32(Desde["IdLogDetalle"]);
            Hasta.IdLog = Convert.ToInt32(Desde["IdLog"]);
            Hasta.TipoDetalle = Convert.ToString(Desde["TipoDetalle"]);
            Hasta.Detalle = Convert.ToString(Desde["Detalle"]);
        }
    }
}
