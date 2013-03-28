using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Medio
    {
        public static List<Entidades.Medio> Lista(Entidades.Sesion Sesion)
        {
            CedServicios.DB.Medio db = new DB.Medio(Sesion);
            return db.LeerLista();
        }
    }
}
