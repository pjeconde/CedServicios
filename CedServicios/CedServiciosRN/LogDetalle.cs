using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class LogDetalle
    {
        public static List<Entidades.LogDetalle> ListaPorIdLog(int IdLog, Entidades.Sesion Sesion)
        {
            DB.LogDetalle LogDetalle = new DB.LogDetalle(Sesion);
            return LogDetalle.ListaPorIdLog(IdLog);
        }
    }
}
