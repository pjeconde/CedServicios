using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Permiso
    {
        public static List<Entidades.Permiso> LeerListaPermisosVigentesPorUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            return db.LeerListaPermisosVigentesPorUsuario(Usuario);
        }
        public static List<Entidades.Permiso> LeerListaPermisosPteAutoriz(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            return db.LeerListaPermisosPteAutoriz(Usuario);
        }
    }
}
