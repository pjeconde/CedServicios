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
    }
}
