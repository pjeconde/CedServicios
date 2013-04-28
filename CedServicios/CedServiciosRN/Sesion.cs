using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Sesion
    {
        public static void Cerrar(Entidades.Sesion Sesion)
        {
            Sesion.Usuario = new Entidades.Usuario();
            Sesion.Cuit = new Entidades.Cuit();
            Sesion.UN = new Entidades.UN();
            Sesion.CuitsDelUsuario = new List<Entidades.Cuit>();
            Sesion.ClientesDelCuit = new List<Entidades.Cliente>();
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
        public static List<string> OpcionesHabilitadas(Entidades.Sesion Sesion)
        {
            List<string> opcionesHabilitadas = new List<string>();
            if (Sesion.Usuario.Id != null)
            {
                opcionesHabilitadas.Add("CUIT/Alta");
                opcionesHabilitadas.Add("CUIT/Solicitud permiso de administrador de CUIT");
                opcionesHabilitadas.Add("Unidad de Negocio/Alta");
                opcionesHabilitadas.Add("Unidad de Negocio/Solicitud permiso de operador de servicio de una UN existente");
                opcionesHabilitadas.Add("Unidad de Negocio/Solicitud permiso de administrador de UN");
                opcionesHabilitadas.Add("Configuración/Cambio de Contraseña de Usuario");
                opcionesHabilitadas.Add("Configuración/Modificación datos de Configuración");
                opcionesHabilitadas.Add("Cerrar sesión");

                List<Entidades.Permiso> permisoAdminSITEVigente = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.WF.Estado == "Vigente";
                });
                if (permisoAdminSITEVigente.Count != 0)
                {
                    opcionesHabilitadas.Add("Administración Site/Explorador de Usuarios");
                    opcionesHabilitadas.Add("Administración Site/Explorador de CUITs");
                    opcionesHabilitadas.Add("Administración Site/Explorador de UNs");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Puntos de Venta");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Clientes");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Artículos");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Permisos");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Configuraciones");
                    opcionesHabilitadas.Add("Administración Site/Explorador de Logs");
                }
                if (Sesion.Cuit.Nro != null)
                {
                    opcionesHabilitadas.Add("CUIT/Consulta");
                    opcionesHabilitadas.Add("Unidad de Negocio/Consulta");
                    opcionesHabilitadas.Add("Puntos de Venta/Consulta");
                    opcionesHabilitadas.Add("Clientes/Alta");
                    opcionesHabilitadas.Add("Clientes/Modificación");
                    opcionesHabilitadas.Add("Clientes/Consulta");
                    //Ojo: no estoy condicionando el tema de Artículos al servicio eFact !!!
                    opcionesHabilitadas.Add("Artículos/Alta");
                    opcionesHabilitadas.Add("Artículos/Modificación");
                    opcionesHabilitadas.Add("Artículos/Consulta");
                    
                    List<Entidades.Permiso> esAdminCUITdeCUITseleccionado = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == Sesion.Cuit.Nro && p.WF.Estado == "Vigente";
                    });
                    if (esAdminCUITdeCUITseleccionado.Count != 0)
                    {
                        opcionesHabilitadas.Add("CUIT/Modificación");
                    }
                }
                List<Entidades.Permiso> esAutorizador = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                {
                    return (p.TipoPermiso.Id == "AdminCUIT" || p.TipoPermiso.Id == "AdminUN" || p.TipoPermiso.Id == "AdminSITE") && p.WF.Estado == "Vigente";
                });
                if (esAutorizador.Count != 0)
                {
                    opcionesHabilitadas.Add("Autorizaciones/Explorador de Autorizaciones");
                    if (RN.Permiso.LeerListaPermisosPteAutoriz(Sesion.Usuario, Sesion).Count != 0)
                    {
                        opcionesHabilitadas.Add("Autorizaciones/Explorador de Autorizaciones pendientes");
                    }
                }
                if (Sesion.UN.Id != 0)
                {
                    List<Entidades.Permiso> elUsuarioEsAdministradorDeLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminUN" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                    {
                        opcionesHabilitadas.Add("Unidad de Negocio/Modificación");
                        opcionesHabilitadas.Add("Puntos de Venta/Alta");
                        opcionesHabilitadas.Add("Puntos de Venta/Modificación");
                    }
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFact" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    //Ojo: no estoy chequeando que la UN siga teniendo el permiso vigente sobre el servicio eFact !!!
                    if (elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada.Count != 0)
                    {
                        opcionesHabilitadas.Add("Facturación");
                    }
                }
            }
            else
            {
                opcionesHabilitadas.Add("Iniciar sesión");
            }
            return opcionesHabilitadas;
        }
        public static void AsignarUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            Sesion.Usuario = Usuario;
        }
        public static void RefrescarDatosUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            Sesion.Usuario.Permisos = RN.Permiso.LeerListaPermisosPorUsuario(Sesion.Usuario, Sesion);
            Sesion.CuitsDelUsuario = RN.Cuit.LeerListaCuitsPorUsuario(Sesion);
            if (Sesion.CuitsDelUsuario.Count != 0)
            {
                if (Sesion.Cuit.Nro == null)
                {
                    AsignarCuit(Sesion.CuitsDelUsuario[0], Sesion);
                }
                else
                {
                    List<Entidades.Cuit> estaElCuitEnLaLista = Sesion.CuitsDelUsuario.FindAll(delegate(Entidades.Cuit p) { return p.Nro == Sesion.Cuit.Nro; });
                    if (estaElCuitEnLaLista.Count != 1)
                    {
                        AsignarCuit(Sesion.CuitsDelUsuario[0], Sesion);
                    }
                }
            }
            else
            {
                BorrarCuit(Sesion);
            } 
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
        public static void AsignarCuit(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            Sesion.Cuit = Cuit;
            Sesion.Cuit.UNs = RN.UN.ListaPorCuitParaElUsuarioLogueado(Sesion);
            Sesion.ClientesDelCuit = RN.Cliente.ListaPorCuit(Sesion);
            if (Sesion.Cuit.UNs.Count != 0)
            {
                if (Sesion.UN.Id == 0)
                {
                    AsignarUN(Sesion.Cuit.UNs[0], Sesion);
                }
                else
                {
                    List<Entidades.UN> estaLaUNEnLaLista = Sesion.Cuit.UNs.FindAll(delegate(Entidades.UN p) { return p.Id == Sesion.UN.Id; });
                    if (estaLaUNEnLaLista.Count != 1)
                    {
                        AsignarUN(Sesion.Cuit.UNs[0], Sesion);
                    }
                }
            }
            else
            {
                BorrarUN(Sesion);
            }
        }
        public static void AsignarUN(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            Sesion.UN = UN;
            Sesion.UN.PuntosVta = RN.PuntoVta.ListaPorUN(Sesion);
        }
        public static void BorrarCuit(Entidades.Sesion Sesion)
        {
            Sesion.Cuit = new Entidades.Cuit();
            Sesion.ClientesDelCuit = new List<Entidades.Cliente>();
            BorrarUN(Sesion);
        }
        public static void BorrarUN(Entidades.Sesion Sesion)
        {
            Sesion.UN = new Entidades.UN();
        }
    }
}