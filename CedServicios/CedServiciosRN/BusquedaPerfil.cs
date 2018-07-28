using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class BusquedaPerfil
    {
        public static List<Entidades.BusquedaPerfil> Lista(Entidades.Sesion Sesion)
        {
            CedServicios.DB.BusquedaPerfil db = new DB.BusquedaPerfil(Sesion);
            return db.LeerLista();
        }
    }
}
