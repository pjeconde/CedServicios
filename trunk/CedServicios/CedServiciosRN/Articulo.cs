using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Articulo
    {
        public static List<Entidades.Articulo> ListaPorCuit(Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            return db.ListaPorCuit();
        }
        public static void Crear(Entidades.Articulo Articulo, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            Articulo.WF.Estado = "Vigente";
            db.Crear(Articulo);
        }
    }
}
