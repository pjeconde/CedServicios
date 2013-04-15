using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class MetodoGeneracionNumeracionLote
    {
        public static List<Entidades.MetodoGeneracionNumeracionLote> Lista(Entidades.Sesion Sesion)
        {
            CedServicios.DB.MetodoGeneracionNumeracionLote db = new DB.MetodoGeneracionNumeracionLote(Sesion);
            return db.LeerLista();
        }
    }
}