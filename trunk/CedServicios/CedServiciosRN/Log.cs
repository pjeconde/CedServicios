using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Log
    {
        public static List<Entidades.Log> ListaSegunFiltros(string IdLog, string IdWF, string FechaDesde, string FechaHasta, string IdUsuario, string Entidad, string Evento, string Estado, Entidades.Sesion Sesion)
        {
            DB.Log Log = new DB.Log(Sesion);
            return Log.ListaSegunFiltros(IdLog, IdWF, FechaDesde, FechaHasta, IdUsuario, Entidad, Evento, Estado);
        }
        public static List<Entidades.Log> ListaPaging(out int CantidadFilas, int IndicePagina, string OrderBy, string IdLog, string IdWF, string FechaDesde, string FechaHasta, string IdUsuario, string Entidad, string Evento, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.Log> listaLog = new List<Entidades.Log>();
            DB.Log db = new DB.Log(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdLog DESC";
            }
            listaLog = db.ListaSegunFiltros(IdLog, IdWF, FechaDesde, FechaHasta, IdUsuario, Entidad, Evento, Estado);
            int cantidadFilas = listaLog.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, OrderBy, SessionID, listaLog);
        }
    }
}
