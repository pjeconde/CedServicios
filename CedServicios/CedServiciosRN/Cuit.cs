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
        public static void Leer(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Cuit db = new DB.Cuit(Sesion);
            db.Leer(Cuit);
        }
    }
}
