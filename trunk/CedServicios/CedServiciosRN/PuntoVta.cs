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
        public static void Crear(Entidades.PuntoVta PuntoVta, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            PuntoVta.WF.Estado = "Vigente";
            db.Crear(PuntoVta);
        }
        public static void Modificar(Entidades.PuntoVta PuntoVtaDesde, Entidades.PuntoVta PuntoVtaHasta, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            db.Modificar(PuntoVtaDesde, PuntoVtaHasta);
        }
    }
}
