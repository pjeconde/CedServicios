using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Configuracion
    {
        public static void EstablecerCUITUNpredef(string Cuit, int IdUN, Entidades.Sesion Sesion)
        {
            DB.Configuracion db = new DB.Configuracion(Sesion);
            db.ElimninarCUITUNpredef(Sesion.Usuario.Id);
            Entidades.Configuracion configuracion = new Entidades.Configuracion();
            configuracion.IdUsuario = Sesion.Usuario.Id;
            configuracion.Cuit = Cuit;
            configuracion.IdUN = IdUN;
            configuracion.TipoPermiso.Id = String.Empty;
            configuracion.IdItemConfig = "CUITUNpredef";
            configuracion.Valor = String.Empty;
            db.Crear(configuracion);
        }
        public static void EstablecerCantidadFilasXPagina(int CantidadFilasXPagina, Entidades.Sesion Sesion)
        {
            DB.Configuracion db = new DB.Configuracion(Sesion);
            db.ElimninarCantidadFilasXPagina(Sesion.Usuario.Id);
            Entidades.Configuracion configuracion = new Entidades.Configuracion();
            configuracion.IdUsuario = Sesion.Usuario.Id;
            configuracion.Cuit = String.Empty;
            configuracion.IdUN = 0;
            configuracion.TipoPermiso.Id = String.Empty;
            configuracion.IdItemConfig = "CantidadFilasXPagina";
            configuracion.Valor = CantidadFilasXPagina.ToString();
            db.Crear(configuracion);
            Sesion.Usuario.CantidadFilasXPagina = CantidadFilasXPagina;
        }
        public static List<Entidades.Configuracion> ListaSegunFiltros(string Cuit, string IdUN, string IdUsuario, string IdTipoPermiso, string IdItemConfig, Entidades.Sesion Sesion)
        {
            DB.Configuracion Configuracion = new DB.Configuracion(Sesion);
            return Configuracion.ListaSegunFiltros(Cuit, IdUN, IdUsuario, IdTipoPermiso, IdItemConfig);
        }
        public static List<Entidades.Configuracion> ListaPaging(out int CantidadFilas, int IndicePagina, string OrderBy, string Cuit, string IdUN, string IdUsuario, string IdTipoPermiso, string IdItemConfig, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.Configuracion> listaConfiguracion = new List<Entidades.Configuracion>();
            DB.Configuracion db = new DB.Configuracion(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdItemConfig asc";
            }
            listaConfiguracion = db.ListaSegunFiltros(Cuit, IdUN, IdUsuario, IdTipoPermiso, IdItemConfig);
            int cantidadFilas = listaConfiguracion.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, OrderBy, SessionID, listaConfiguracion);
        }
        public static Entidades.Configuracion LeerUsuarioDEMO(Entidades.Sesion Sesion)
        {
            Entidades.Configuracion usuarioDEMO = new Entidades.Configuracion();
            DB.Configuracion db = new DB.Configuracion(Sesion);
            List<Entidades.Configuracion> listaConf = db.ListaSegunFiltros("", "", "", "", "UsuarioDEMO");
            if (listaConf.Count != 0)
            {
                usuarioDEMO = listaConf[0];
            }
            return usuarioDEMO;
        }
        public static string CuitConsultaAFIP(Entidades.Sesion Sesion)
        {
            Entidades.Configuracion elem = new Entidades.Configuracion("CuitConsultaAFIP");
            DB.Configuracion db = new DB.Configuracion(Sesion);
            try
            {
                db.Leer(elem);
                return elem.Valor;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
