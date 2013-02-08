using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Cuit
    {
        public static List<Entidades.Cuit> LeerListaCuitsPorUsuario(Entidades.Sesion Sesion)
        {
            CedServicios.DB.Cuit db = new DB.Cuit(Sesion);
            return db.LeerListaCuitsPorUsuario();
        }
    }
}
