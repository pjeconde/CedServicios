using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Log: db
    {
        public Log(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        private void Copiar(DataRow Desde, Entidades.Log Hasta)
        {
            Hasta.Id = Convert.ToInt32(Desde["IdLog"]);
            Hasta.IdWF = Convert.ToInt32(Desde["IdWF"]);
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            Hasta.Entidad = Convert.ToString(Desde["Entidad"]);
            Hasta.Evento = Convert.ToString(Desde["Evento"]);
            Hasta.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
            Hasta.CantRegLogDetalle = Convert.ToInt32(Desde["CantRegLogDetalle"]);
        }
        public List<Entidades.Log> ListaSegunFiltros(string IdLog, string IdWF, string FechaDesde, string FechaHasta, string IdUsuario, string Entidad, string Evento, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Log.IdLog, Log.IdWF, Log.Fecha, Log.IdUsuario, Log.Entidad, Log.Evento, Log.Estado, Log.Comentario, IsNull((select count(*) from LogDetalle where LogDetalle.IdLog = Log.IdLog group by IdLog), '0') as CantRegLogDetalle ");
            a.AppendLine("from Log ");
            a.AppendLine("where 1=1 ");
            if (IdLog != String.Empty) a.AppendLine("and IdLog = " + IdLog + " ");
            if (IdWF != String.Empty) a.AppendLine("and IdWF = " + IdWF + " ");
            if (FechaDesde != String.Empty && FechaHasta != String.Empty) a.AppendLine("and Fecha >= '" + Convert.ToDateTime(FechaDesde, new System.Globalization.CultureInfo("es-AR")).ToString("yyyyMMdd") + "' and Fecha < '" + Convert.ToDateTime(FechaHasta, new System.Globalization.CultureInfo("es-AR")).AddDays(1).ToString("yyyyMMdd") + "' ");
            if (IdUsuario != String.Empty) a.AppendLine("and IdUsuario like '%" + IdUsuario + "%' ");
            if (Entidad != String.Empty) a.AppendLine("and Entidad like '%" + Entidad + "%' ");
            if (Evento != String.Empty) a.AppendLine("and Evento like '%" + Evento + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado like '%" + Estado + "%' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Log> lista = new List<Entidades.Log>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Log Log = new Entidades.Log();
                    Copiar(dt.Rows[i], Log);
                    lista.Add(Log);
                }
            }
            return lista;
        }
        public List<Entidades.Log> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.Log> LogLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Log" + SessionID + "( ");
            a.Append("[IdLog] [int] NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
	        a.Append("[Fecha] [datetime] NOT NULL, ");
	        a.Append("[IdUsuario] [varchar](50) NOT NULL, ");
	        a.Append("[Entidad] [varchar](15) NOT NULL, ");
	        a.Append("[Evento] [varchar](15) NOT NULL, ");
	        a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[Comentario] [varchar](256) NOT NULL, ");
            a.Append("[CantRegLogDetalle] [int] NOT NULL, ");
            a.Append("CONSTRAINT [PK_Log" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[IdLog] DESC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.AppendLine(") ON [PRIMARY] ");
            foreach (Entidades.Log Log in LogLista)
            {
                a.Append("Insert #Log" + SessionID + " values (" + Log.Id + ", ");
                a.Append(Log.IdWF + ", '");
                a.Append(Log.Fecha.ToString("yyyyMMdd HH:mm:ss") + "', '");
                a.Append(Log.IdUsuario + "', '");
                a.Append(Log.Entidad + "', '");
                a.Append(Log.Evento + "', '");
                a.Append(Log.Estado + "', '");
                a.Append(Log.Comentario + "', ");
                a.AppendLine(Log.CantRegLogDetalle + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdLog, IdWF, Fecha, IdUsuario, Entidad, Evento, Estado, Comentario, CantRegLogDetalle ");
            a.Append("from #Log" + SessionID + " ");
            a.AppendLine("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.AppendLine("DROP TABLE #Log" + SessionID);
            if (OrderBy.Trim().ToUpper() == "ID" || OrderBy.Trim().ToUpper() == "ID DESC" || OrderBy.Trim().ToUpper() == "ID ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy.Replace("Id", "IdLog");
            }
            if (OrderBy.Trim().ToUpper() == "IDWF" || OrderBy.Trim().ToUpper() == "IDWF DESC" || OrderBy.Trim().ToUpper() == "IDWF ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "FECHA" || OrderBy.Trim().ToUpper() == "FECHA DESC" || OrderBy.Trim().ToUpper() == "FECHA ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "IDUSUARIO" || OrderBy.Trim().ToUpper() == "IDUSUARIO DESC" || OrderBy.Trim().ToUpper() == "IDUSUARIO ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "ENTIDAD" || OrderBy.Trim().ToUpper() == "ENTIDAD DESC" || OrderBy.Trim().ToUpper() == "ENTIDAD ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "EVENTO" || OrderBy.Trim().ToUpper() == "EVENTO DESC" || OrderBy.Trim().ToUpper() == "EVENTO ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#Log" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Log> lista = new List<Entidades.Log>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Log Log = new Entidades.Log();
                    Copiar(dt.Rows[i], Log);
                    lista.Add(Log);
                }
            }
            return lista;
        }
    }
}
