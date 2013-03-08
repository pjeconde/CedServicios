using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class TipoPermiso
    {
        public static List<Entidades.TipoPermiso> ListaPorUN(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            CedServicios.DB.TipoPermiso db = new DB.TipoPermiso(Sesion);
            return db.LeerListaPorUN(UN);
        }
        public static void Leer(Entidades.TipoPermiso TipoPermiso, Entidades.Sesion Sesion)
        {
            CedServicios.DB.TipoPermiso db = new DB.TipoPermiso(Sesion);
            db.Leer(TipoPermiso);
        }
    }
}
