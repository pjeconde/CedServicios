using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Permiso
    {
        public static List<Entidades.Permiso> LeerListaPermisosPorUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            return db.LeerListaPermisosPorUsuario(Usuario);
        }
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
        public static void Solicitar(Entidades.Cuit Cuit, out string ReferenciaAAprobadores, Entidades.Sesion Sesion)
        {
            List<Entidades.Permiso> esAdminCUITdeCUITsolicitado = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == Cuit.Nro;
            });
            if (esAdminCUITdeCUITsolicitado.Count != 0)
            {
                throw new EX.Permiso.Existente(esAdminCUITdeCUITsolicitado[0].WF.Estado);
            }
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.IdUsuario = Sesion.Usuario.Id;
            permiso.Cuit = Cuit.Nro;
            permiso.IdUN = String.Empty;
            permiso.TipoPermiso.Id = "AdminCUIT";
            permiso.FechaFinVigencia=new DateTime(2062, 12, 31);
            permiso.IdUsuarioSolicitante = Sesion.Usuario.Id;
            permiso.Accion.Tipo = "SolicAdminCuit";
            permiso.WF.Estado = "PteAutoriz";
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            db.Alta(permiso);
            List<Entidades.Usuario> usuariosAutorizadores = db.LeerListaUsuariosAutorizadores(permiso.Cuit);
            ReferenciaAAprobadores = String.Empty;
            for (int i = 0; i < usuariosAutorizadores.Count; i++)
            {
                ReferenciaAAprobadores += usuariosAutorizadores[i].Nombre;
                if (i + 1 < usuariosAutorizadores.Count) ReferenciaAAprobadores += " / ";

                //Enviar carta de aviso
            }
        }
        public static void Solicitar(Entidades.Cuit Cuit, Entidades.UN UN, out string ReferenciaAAprobadores, Entidades.Sesion Sesion)
        {
            List<Entidades.Permiso> esAdminUNdelaUNsolicitada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminUN" && p.Cuit == Cuit.Nro && p.IdUN == UN.Id;
            });
            if (esAdminUNdelaUNsolicitada.Count != 0)
            {
                throw new EX.Permiso.Existente(esAdminUNdelaUNsolicitada[0].WF.Estado);
            }
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.IdUsuario = Sesion.Usuario.Id;
            permiso.Cuit = Cuit.Nro;
            permiso.IdUN = UN.Id;
            permiso.TipoPermiso.Id = "AdminUN";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.IdUsuarioSolicitante = Sesion.Usuario.Id;
            permiso.Accion.Tipo = "SolicAdminUN";
            permiso.WF.Estado = "PteAutoriz";
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            db.Alta(permiso);
            List<Entidades.Usuario> usuariosAutorizadores = db.LeerListaUsuariosAutorizadores(permiso.Cuit);
            ReferenciaAAprobadores = String.Empty;
            for (int i = 0; i < usuariosAutorizadores.Count; i++)
            {
                ReferenciaAAprobadores += usuariosAutorizadores[i].Nombre;
                if (i + 1 < usuariosAutorizadores.Count) ReferenciaAAprobadores += " / ";

                //Enviar carta de aviso
            }
        }
        public static void Solicitar(Entidades.Cuit Cuit, Entidades.UN UN, Entidades.TipoPermiso TipoPermiso, string ReferenciaAAprobadores, Entidades.Sesion Sesion)
        {
        }
        private static List<Entidades.Usuario> UsuariosAprobadores(Entidades.Permiso Permiso, Entidades.Sesion Sesion)
        {
            List<Entidades.Usuario> usuariosAprobadores = new List<Entidades.Usuario>();
            switch (Permiso.TipoPermiso.Id)
            {
                case "AdminCUIT":
                    break;
                case "AdminUN":
                    break;
                case "eFact":
                    break;
            }
            return usuariosAprobadores;
        }
    }
}
