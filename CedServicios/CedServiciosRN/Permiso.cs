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
        public static void SolicitarPermisoParaUsuario(Entidades.Cuit Cuit, out string ReferenciaAAprobadores, Entidades.Sesion Sesion)
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
            permiso.Usuario = Sesion.Usuario;
            permiso.Cuit = Cuit.Nro;
            permiso.UN.Id = String.Empty;
            permiso.TipoPermiso.Id = "AdminCUIT";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
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
            }
            RN.EnvioCorreo.SolicitudAutorizacion(DescrPermiso(permiso), Sesion.Usuario, usuariosAutorizadores);
        }
        public static void SolicitarPermisoParaUsuario(Entidades.Cuit Cuit, Entidades.UN UN, out string ReferenciaAAprobadores, Entidades.Sesion Sesion)
        {
            List<Entidades.Permiso> esAdminUNdelaUNsolicitada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminUN" && p.Cuit == Cuit.Nro && p.UN.Id == UN.Id;
            });
            if (esAdminUNdelaUNsolicitada.Count != 0)
            {
                throw new EX.Permiso.Existente(esAdminUNdelaUNsolicitada[0].WF.Estado);
            }
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Usuario = Sesion.Usuario;
            permiso.Cuit = Cuit.Nro;
            permiso.UN = UN;
            permiso.TipoPermiso.Id = "AdminUN";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            permiso.Accion.Tipo = "SolicAdminUN";
            permiso.WF.Estado = "PteAutoriz";
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            db.Alta(permiso);
            List<Entidades.Usuario> usuariosAutorizadores = db.LeerListaUsuariosAutorizadores(permiso.Cuit, permiso.UN.Id);
            ReferenciaAAprobadores = String.Empty;
            for (int i = 0; i < usuariosAutorizadores.Count; i++)
            {
                ReferenciaAAprobadores += usuariosAutorizadores[i].Nombre;
                if (i + 1 < usuariosAutorizadores.Count) ReferenciaAAprobadores += " / ";
            }
            RN.EnvioCorreo.SolicitudAutorizacion(DescrPermiso(permiso), Sesion.Usuario, usuariosAutorizadores);
        }
        public static string PermisoAdminUNParaUsuarioAprobadoHandler(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            List<Entidades.Permiso> esAdminUNdelaUNsolicitada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminUN" && p.Cuit == UN.Cuit && p.UN.Id == UN.Id;
            });
            if (esAdminUNdelaUNsolicitada.Count != 0)
            {
                throw new EX.Permiso.Existente(esAdminUNdelaUNsolicitada[0].WF.Estado);
            }
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Usuario = Sesion.Usuario;
            permiso.Cuit = UN.Cuit;
            permiso.UN = UN;
            permiso.TipoPermiso.Id = "AdminUN";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            permiso.WF.Estado = "Vigente";
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            return db.AltaHandler(permiso, false, false);
        }
        public static void SolicitarPermisoParaUsuario(Entidades.Cuit Cuit, Entidades.UN UN, Entidades.TipoPermiso TipoPermiso, out string ReferenciaAAprobadores, Entidades.Sesion Sesion)
        {
            List<Entidades.Permiso> yaTieneHabilitadoElServicioParaLaUN = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminUN" && p.Cuit == Cuit.Nro && p.UN.Id == UN.Id && p.TipoPermiso.Id == TipoPermiso.Id;
            });
            if (yaTieneHabilitadoElServicioParaLaUN.Count != 0)
            {
                throw new EX.Permiso.Existente(yaTieneHabilitadoElServicioParaLaUN[0].WF.Estado);
            }
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Usuario = Sesion.Usuario;
            permiso.Cuit = Cuit.Nro;
            permiso.UN = UN;
            permiso.TipoPermiso = TipoPermiso;
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            permiso.Accion.Tipo = "SolicOperServUN";
            List<Entidades.Permiso> esAdminUNdelaUN = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminUN" && p.Cuit == Cuit.Nro && p.UN.Id == UN.Id && p.WF.Estado == "Vigente";
            });
            ReferenciaAAprobadores = String.Empty;
            if (esAdminUNdelaUN.Count != 0)
            {
                permiso.WF.Estado = "Vigente";
            }
            else
            {
                permiso.WF.Estado = "PteAutoriz";
                CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
                db.Alta(permiso);
                List<Entidades.Usuario> usuariosAutorizadores = db.LeerListaUsuariosAutorizadores(permiso.Cuit);
                for (int i = 0; i < usuariosAutorizadores.Count; i++)
                {
                    ReferenciaAAprobadores += usuariosAutorizadores[i].Nombre;
                    if (i + 1 < usuariosAutorizadores.Count) ReferenciaAAprobadores += " / ";
                }
                RN.EnvioCorreo.SolicitudAutorizacion(DescrPermiso(permiso), Sesion.Usuario, usuariosAutorizadores);
            }
        }
        public static string PermisoUsoCUITxUNHandler(Entidades.UN UN, out List<Entidades.Usuario> UsuariosAutorizadores, out string ReferenciaAAprobadores, out string EstadoPermisoUsoCUITxUN, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Cuit = UN.Cuit;
            permiso.UN = UN;
            permiso.TipoPermiso.Id = "UsoCUITxUN";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            List<Entidades.Permiso> usuarioEsAdminCUIT = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
            {
                return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == UN.Cuit && p.WF.Estado == "Vigente";
            });
            if (usuarioEsAdminCUIT.Count != 0)
            {
                permiso.WF.Estado = "Vigente";
                UsuariosAutorizadores = new List<Entidades.Usuario>();
                ReferenciaAAprobadores = String.Empty;
            }
            else
            {
                permiso.WF.Estado = "PteAutoriz";
                UsuariosAutorizadores = db.LeerListaUsuariosAutorizadores(permiso.Cuit);
                ReferenciaAAprobadores = String.Empty;
                for (int i = 0; i < UsuariosAutorizadores.Count; i++)
                {
                    ReferenciaAAprobadores += UsuariosAutorizadores[i].Nombre;
                    if (i + 1 < UsuariosAutorizadores.Count) ReferenciaAAprobadores += " / ";
                }
            }
            EstadoPermisoUsoCUITxUN = permiso.WF.Estado;
            return db.AltaHandler(permiso, false, false);
        }
        public static void Autorizar(Entidades.Permiso Permiso, Entidades.Sesion Sesion)
        {
            DB.Permiso db = new DB.Permiso(Sesion);
            db.CambioEstado(Permiso, "Vigente");
            RN.EnvioCorreo.RespuestaAutorizacion(Permiso, Sesion.Usuario);
        }
        public static void Rechazar(Entidades.Permiso Permiso, Entidades.Sesion Sesion)
        {
            DB.Permiso db = new DB.Permiso(Sesion);
            db.CambioEstado(Permiso, "Rech");
            RN.EnvioCorreo.RespuestaAutorizacion(Permiso, Sesion.Usuario);
        }
        public static string DescrPermiso(Entidades.Permiso Permiso)
        {
            string descripcion = String.Empty;
            switch (Permiso.TipoPermiso.Id)
            {
                case "AdminCUIT":
                    descripcion = "Administrador del CUIT " + Permiso.Cuit;
                    break;
                case "AdminUN":
                    descripcion = "Administrador de la Unidad de Negocio '" + Permiso.UN.Descr + "' del CUIT " + Permiso.Cuit;
                    break;
                case "UsoCUITXUN":
                    descripcion = "Relación entre la nueva Unidad de Negocio '" + Permiso.UN.Descr + "' y el CUIT " + Permiso.UN.Cuit;
                    break;
                default:
                    descripcion = "Operador del servicio '" + Permiso.TipoPermiso.Descr.Replace("Operador servicio ", String.Empty) + "' de la Unidad de Negocio '" + Permiso.UN.Descr + "' del CUIT " + Permiso.UN.Cuit;
                    break;
            }
            return descripcion;
        }
        public static string PermisoAdminCUITParaUsuarioAprobadoHandler(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Usuario = Sesion.Usuario;
            permiso.Cuit = Cuit.Nro;
            permiso.UN.Id = String.Empty;
            permiso.TipoPermiso.Id = "AdminCUIT";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            permiso.WF.Estado = "Vigente";
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            return db.AltaHandler(permiso, false, false);
        }
        public static string PermisoUsoCUITxUNAprobadoHandler(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Permiso db = new DB.Permiso(Sesion);
            Entidades.Permiso permiso = new Entidades.Permiso();
            permiso.Cuit = UN.Cuit;
            permiso.UN = UN;
            permiso.TipoPermiso.Id = "UsoCUITxUN";
            permiso.FechaFinVigencia = new DateTime(2062, 12, 31);
            permiso.UsuarioSolicitante = Sesion.Usuario;
            permiso.WF.Estado = "Vigente";
            return db.AltaHandler(permiso, false, false);
        }
    }
}