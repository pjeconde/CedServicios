using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class ListaPrecio
    {
        public static List<Entidades.ListaPrecio> ListaPorCuit(bool SoloVigentes, bool IncluirVacio, bool ClasificadoPorOrden, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            return db.ListaPorCuit(SoloVigentes, IncluirVacio, ClasificadoPorOrden);
        }
        public static List<Entidades.ListaPrecio> ListaPorCuityTipoLista(bool SoloVigentes, bool IncluirVacio, bool ClasificadoPorOrden, string IdTipoListaPrecio, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            return db.ListaPorCuityTipoLista(SoloVigentes, IncluirVacio, ClasificadoPorOrden, IdTipoListaPrecio);
        }
        public static string ListaPorCuitString(bool SoloVigentes, bool IncluirVacio, bool ClasificadoPorOrden, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            return db.ListaPorCuitString(SoloVigentes, IncluirVacio, ClasificadoPorOrden);
        }
        public static void Crear(Entidades.ListaPrecio ListaPrecio, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            ListaPrecio.WF.Estado = "Vigente";
            db.Crear(ListaPrecio);
        }
        public static List<Entidades.ListaPrecio> ListaPorCuityId(string Cuit, string Id, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            return db.ListaPorCuityId(Cuit, Id);
        }
        public static List<Entidades.ListaPrecio> ListaPorCuityDescr(string Cuit, string Descr, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            return db.ListaPorCuityDescr(Cuit, Descr);
        }
        public static void Modificar(Entidades.ListaPrecio ListaPrecioDesde, Entidades.ListaPrecio ListaPrecioHasta, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            db.Modificar(ListaPrecioDesde, ListaPrecioHasta);
        }
        public static void CambiarEstado(Entidades.ListaPrecio ListaPrecio, string Estado, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            db.CambiarEstado(ListaPrecio, Estado);
        }
        public static Entidades.ListaPrecio ObternerCopia(Entidades.ListaPrecio Desde)
        {
            Entidades.ListaPrecio hasta = new Entidades.ListaPrecio();
            hasta.Cuit = Desde.Cuit;
            hasta.Id = Desde.Id;
            hasta.Descr = Desde.Descr;
            hasta.UltActualiz = Desde.UltActualiz;
            hasta.WF.Id = Desde.WF.Id;
            hasta.WF.Estado = Desde.WF.Estado;
            hasta.Orden = Desde.Orden;
            return hasta;
        }
        public static List<Entidades.ListaPrecio> ListaSegunFiltros(string Cuit, string IdListaPrecio, string DescrListaPrecio, string Estado, Entidades.Sesion Sesion)
        {
            DB.ListaPrecio ListaPrecio = new DB.ListaPrecio(Sesion);
            return ListaPrecio.ListaSegunFiltros(Cuit, IdListaPrecio, DescrListaPrecio, Estado);
        }
        public static List<Entidades.ListaPrecio> ListaPaging(out int CantidadFilas, int IndicePagina, string OrderBy, string Cuit, string IdListaPrecio, string DescrListaPrecio, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.ListaPrecio> listaListaPrecio = new List<Entidades.ListaPrecio>();
            DB.ListaPrecio db = new DB.ListaPrecio(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdListaPrecio desc";
            }
            listaListaPrecio = db.ListaSegunFiltros(Cuit, IdListaPrecio, DescrListaPrecio, Estado);
            int cantidadFilas = listaListaPrecio.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, OrderBy, SessionID, listaListaPrecio);
        }
    }
}
