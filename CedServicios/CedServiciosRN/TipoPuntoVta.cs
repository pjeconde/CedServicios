using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class TipoPuntoVta
    {
        public static List<Entidades.TipoPuntoVta> Lista(Entidades.Sesion Sesion)
        {
            CedServicios.DB.TipoPuntoVta db = new DB.TipoPuntoVta(Sesion);
            return db.LeerLista();
        }
    }
}
