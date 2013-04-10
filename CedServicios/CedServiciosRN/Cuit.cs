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
        public static void Crear(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            string permisoAdminCUITParaUsuarioAprobadoHandler = RN.Permiso.PermisoAdminCUITParaUsuarioAprobadoHandler(Cuit, Sesion);
            DB.UN dbUN = new DB.UN(Sesion);
            Entidades.UN uN = new Entidades.UN();
            uN.Cuit = Cuit.Nro;
            uN.Id = 1;
            uN.Descr = "Predefinida";
            uN.WF.Estado = "Vigente";
            string crearUNHandler = dbUN.CrearHandler(uN);
            string permisoUsoCUITxUNAprobadoHandler = RN.Permiso.PermisoUsoCUITxUNAprobadoHandler(uN, Sesion);
            string permisoAdminUNParaUsuarioAprobadoHandler = RN.Permiso.PermisoAdminUNParaUsuarioAprobadoHandler(uN, Sesion);
            DB.Cuit db = new DB.Cuit(Sesion);
            Cuit.WF.Estado = "Vigente";
            db.Crear(Cuit, permisoAdminCUITParaUsuarioAprobadoHandler, crearUNHandler, permisoUsoCUITxUNAprobadoHandler, permisoAdminUNParaUsuarioAprobadoHandler);
        }
        public static void Modificar(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            DB.Cuit db = new DB.Cuit(Sesion);
            db.Modificar(Sesion.Cuit, Cuit);
            Sesion.Cuit = Cuit;
        }
    }
}
