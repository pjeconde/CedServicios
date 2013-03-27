using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Cuit
    {
        public static List<Entidades.Cuit> LeerListaCuitsPorUsuario(Entidades.Sesion Sesion)
        {
            CedServicios.DB.Cuit db = new DB.Cuit(Sesion);
            return db.LeerListaCuitsPorUsuario();
        }
        public static void Leer(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Cuit db = new DB.Cuit(Sesion);
            db.Leer(Cuit);
        }
        public static void Registrar(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            string permisoAdminCUITParaUsuarioHandler = RN.Permiso.PermisoAdminCUITParaUsuarioAprobadoHandler(Cuit, Sesion);
            DB.UN dbUN= new DB.UN(Sesion);
            Entidades.UN uN = new Entidades.UN();
            uN.Cuit = Cuit.Nro;
            uN.Id = "";
            uN.Descr = "";
            uN.WF.Estado = "Vigente";
            string crearUNHandler = dbUN.CrearHandler(uN);
            string permisoUsoCUITxUNHandler = RN.Permiso.PermisoUsoCUITxUNAprobadoHandler(uN, Sesion);
            string permisoAdminUNParaUsuarioHandler = RN.Permiso.PermisoAdminUNParaUsuarioHandler(uN, Sesion);
            DB.Cuit db = new DB.Cuit(Sesion);
            Cuit.WF.Estado = "Vigente";
            db.Crear(Cuit, permisoAdminCUITParaUsuarioHandler, crearUNHandler, permisoUsoCUITxUNHandler, permisoAdminUNParaUsuarioHandler);
        }
    }
}
