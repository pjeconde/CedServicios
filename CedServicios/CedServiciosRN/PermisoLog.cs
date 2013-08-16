using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class PermisoLog
    {
        public static List<Entidades.PermisoLog> LeerListaIntervencionesDelAutorizador(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.PermisoLog db = new DB.PermisoLog(Sesion);
            return db.LeerListaIntervencionesDelAutorizador(Usuario);
        }
    }
}
