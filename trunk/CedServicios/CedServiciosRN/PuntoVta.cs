using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class PuntoVta
    {
        public static List<Entidades.PuntoVta> ListaPorUN(Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            return db.ListaPorUN();
        }
    }
}
