using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Articulo
    {
        public static List<Entidades.Articulo> ListaPorCuit(bool SoloVigentes, Entidades.Sesion Sesion)
        {
            DB.Articulo db = new DB.Articulo(Sesion);
            return db.ListaPorCuit(SoloVigentes);
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
        public static List<Entidades.Articulo> ListaSegunFiltros(string Cuit, string IdArticulo, string DescrArticulo, string Estado, Entidades.Sesion Sesion)
        {
            DB.Articulo Articulo = new DB.Articulo(Sesion);
            return Articulo.ListaSegunFiltros(Cuit, IdArticulo, DescrArticulo, Estado);
        }
        public static List<Entidades.Articulo> ListaPaging(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string Cuit, string IdArticulo, string DescrArticulo, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.Articulo> listaArticulo = new List<Entidades.Articulo>();
            DB.Articulo db = new DB.Articulo(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdArticulo desc";
            }
            listaArticulo = db.ListaSegunFiltros(Cuit, IdArticulo, DescrArticulo, Estado);
            int cantidadFilas = listaArticulo.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, TamañoPagina, OrderBy, SessionID, listaArticulo);
        }
    }
}
