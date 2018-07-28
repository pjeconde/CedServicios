using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class BusquedaLaboral
    {
        public static List<Entidades.BusquedaLaboral> Lista(Entidades.Sesion Sesion)
        {
            CedServicios.DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            return db.LeerLista();
        }
        public static void Leer(Entidades.BusquedaLaboral BusquedaLaboral, Entidades.Sesion Sesion)
        {
            CedServicios.DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            db.Leer(BusquedaLaboral);
        }
        public static void Crear(Entidades.BusquedaLaboral BusquedaLaboral, Entidades.Sesion Sesion)
        {
            DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            db.Crear(BusquedaLaboral);
        }
        public static void Modificar(Entidades.BusquedaLaboral BusquedaLaboralDesde, Entidades.BusquedaLaboral BusquedaLaboralHasta, Entidades.Sesion Sesion)
        {
            DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            db.Modificar(BusquedaLaboralDesde, BusquedaLaboralHasta);
        }
        public static void ModificarCV(Entidades.BusquedaLaboral BusquedaLaboralDesde, Entidades.BusquedaLaboral BusquedaLaboralHasta, Entidades.Sesion Sesion)
        {
            DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            db.ModificarCV(BusquedaLaboralDesde, BusquedaLaboralHasta);
        }
        public static void ModificarSuscripcion(Entidades.BusquedaLaboral BusquedaLaboralDesde, Entidades.BusquedaLaboral BusquedaLaboralHasta, Entidades.Sesion Sesion)
        {
            DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            db.ModificarSuscripcion(BusquedaLaboralDesde, BusquedaLaboralHasta);
        }
        public static List<Entidades.BusquedaLaboral> ListaSegunFiltros(string Email, string Nombre, string IdBusquedaPerfil, string Estado, Entidades.Sesion Sesion)
        {
            DB.BusquedaLaboral bl = new DB.BusquedaLaboral(Sesion);
            return bl.ListaSegunFiltros(Email, Nombre, IdBusquedaPerfil, Estado);
        }
        public static List<Entidades.BusquedaLaboral> ListaPaging(out int CantidadFilas, int IndicePagina, string OrderBy, string Email, string Nombre, string IdBusquedaPerfil, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.BusquedaLaboral> listaBL = new List<Entidades.BusquedaLaboral>();
            DB.BusquedaLaboral db = new DB.BusquedaLaboral(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Email asc";
            }
            listaBL = db.ListaSegunFiltros(Email, Nombre, IdBusquedaPerfil, Estado);
            int cantidadFilas = listaBL.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, OrderBy, SessionID, listaBL);
        }
    }
}
