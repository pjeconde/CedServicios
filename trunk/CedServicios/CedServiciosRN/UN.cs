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
        public static void Registrar(Entidades.UN UN, out string ReferenciaAAprobadores, out string EstadoPermisoUsoCUITxUN, Entidades.Sesion Sesion)
        {
            List<Entidades.Usuario> usuariosAutorizadores = new List<Entidades.Usuario>();
            string permisoUsoCUITxUNHandler = RN.Permiso.PermisoUsoCUITxUNHandler(UN, out usuariosAutorizadores, out ReferenciaAAprobadores, out EstadoPermisoUsoCUITxUN, Sesion);
            string permisoAdminUNParaUsuarioHandler = RN.Permiso.PermisoAdminUNParaUsuarioHandler(UN, Sesion);
            DB.UN dbUN = new DB.UN(Sesion);
            UN.WF.Estado = "Vigente";   //la UN siempre queda vigente, lo que, en todo caso, puede quedar PteAutoriz
            //es su relación con el Cuit, que se explicita a través del Permiso UsoCuitXUN
            dbUN.Crear(UN, permisoUsoCUITxUNHandler, permisoAdminUNParaUsuarioHandler);
            if (EstadoPermisoUsoCUITxUN == "PteAutoriz")
            {
                Entidades.Permiso permiso = new Entidades.Permiso();
                permiso.TipoPermiso.Id = "UsoCUITXUN";
                permiso.UN = UN;
                RN.EnvioCorreo.SolicitudAutorizacion(RN.Permiso.DescrPermiso(permiso), Sesion.Usuario, usuariosAutorizadores);
            }
        }
    }
}
