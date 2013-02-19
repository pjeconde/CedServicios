using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class UN
    {
        public static List<Entidades.UN> ListaPorCuitParaElUsuarioLogueado(Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            return db.LeerListaUNsPorCuitParaElUsuarioLogueado();
        }
        public static List<Entidades.UN> ListaVigentesPorCuit(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            return db.LeerListaUNsVigentesPorCuit(Cuit);
        }
        public static void Leer(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            db.Leer(UN);
        }
    }
}
