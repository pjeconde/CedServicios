using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Rubro
    {
        public static void LeerEsquemaContable(Entidades.EsquemaContable EsquemaContable, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Rubro db = new DB.Rubro(Sesion);
            db.LeerEsquemaContable(EsquemaContable);
        }
    }
}