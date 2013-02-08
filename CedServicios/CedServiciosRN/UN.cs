using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class UN
    {
        public static List<Entidades.UN> LeerListaUNsPorCuit(Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            return db.LeerListaUNsPorCuit();
        }
    }
}
