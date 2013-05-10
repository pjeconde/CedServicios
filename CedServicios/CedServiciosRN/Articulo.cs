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
        public static List<Entidades.Articulo> ListaPorCuityId(string Cuit, string Id, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            return db.ListaPorCuityId(Cuit, Id);
        }
        public static List<Entidades.Articulo> ListaPorCuityDescr(string Cuit, string Descr, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            return db.ListaPorCuityDescr(Cuit, Descr);
        }
        public static void Modificar(Entidades.Articulo ArticuloDesde, Entidades.Articulo ArticuloHasta, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            db.Modificar(ArticuloDesde, ArticuloHasta);
        }
        public static void CambiarEstado(Entidades.Articulo Articulo, string Estado, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            db.CambiarEstado(Articulo, Estado);
        }
        public static Entidades.Articulo ObternerCopia(Entidades.Articulo Desde)
        {
            Entidades.Articulo hasta = new Entidades.Articulo();
            hasta.Cuit = Desde.Cuit;
            hasta.Id = Desde.Id;
            hasta.Descr = Desde.Descr;
            hasta.GTIN = Desde.GTIN;
            hasta.Unidad.Id = Desde.Unidad.Id;
            hasta.Unidad.Descr = Desde.Unidad.Descr;
            hasta.IndicacionExentoGravado = Desde.IndicacionExentoGravado;
            hasta.AlicuotaIVA = Desde.AlicuotaIVA;
            hasta.UltActualiz = Desde.UltActualiz;
            hasta.WF.Id = Desde.WF.Id;
            hasta.WF.Estado = Desde.WF.Estado;
            return hasta;
        }
    }
}
