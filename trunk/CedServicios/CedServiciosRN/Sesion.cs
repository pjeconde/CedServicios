using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
                opcionesHabilitadas.Add("Administración|CUIT|Alta");
                opcionesHabilitadas.Add("Administración|CUIT|Solicitud permiso de administrador de CUIT");
                opcionesHabilitadas.Add("Administración|Unidad de Negocio|Alta");
                opcionesHabilitadas.Add("Administración|Unidad de Negocio|Solicitud permiso de operador de servicio de una UN existente");
                opcionesHabilitadas.Add("Administración|Unidad de Negocio|Solicitud permiso de administrador de UN");
                opcionesHabilitadas.Add("Administración|Usuario|Cambio de Contraseña");
                opcionesHabilitadas.Add("Administración|Usuario|Modificación datos de Configuración");
                opcionesHabilitadas.Add("Ayuda|Manual|¿ Cómo empiezo a operar con facturas electrónicas ?");
                opcionesHabilitadas.Add("Ayuda|Novedades");
                opcionesHabilitadas.Add("Ayuda|Documentación técnica");
                opcionesHabilitadas.Add("Cerrar sesión");

                List<Entidades.Permiso> permisoAdminSITEVigente = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.WF.Estado == "Vigente";
                });
                if (permisoAdminSITEVigente.Count != 0)
                {
                    opcionesHabilitadas.Add("Administración Site|Explorador de Comprobantes");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Usuarios");
                    opcionesHabilitadas.Add("Administración Site|Explorador de CUITs");
                    opcionesHabilitadas.Add("Administración Site|Explorador de UNs");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Puntos de Venta");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Clientes");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Artículos");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Permisos");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Configuraciones");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Logs");
                    opcionesHabilitadas.Add("Administración Site|Explorador de Administración");
                    opcionesHabilitadas.Add("Administración Site|Migración de Cuentas (desde CedWeb)");
                }
                if (Sesion.Cuit.Nro != null)
                {
                    opcionesHabilitadas.Add("Administración|CUIT|Consulta");
                    opcionesHabilitadas.Add("Administración|Unidad de Negocio|Consulta");
                    opcionesHabilitadas.Add("Administración|Puntos de Venta|Consulta");
                    opcionesHabilitadas.Add("Clientes|Alta");
                    opcionesHabilitadas.Add("Clientes|Baja/Anul.baja");
                    opcionesHabilitadas.Add("Clientes|Modificación");
                    opcionesHabilitadas.Add("Clientes|Consulta");
                    //Ojo: no estoy condicionando el tema de Artículos al servicio eFact !!!
                    opcionesHabilitadas.Add("Artículos|Alta");
                    opcionesHabilitadas.Add("Artículos|Baja/Anul.baja");
                    opcionesHabilitadas.Add("Artículos|Modificación");
                    opcionesHabilitadas.Add("Artículos|Consulta");
                    
                    List<Entidades.Permiso> esAdminCUITdeCUITseleccionado = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == Sesion.Cuit.Nro && p.WF.Estado == "Vigente";
                    });
                    if (esAdminCUITdeCUITseleccionado.Count != 0)
                    {
                        opcionesHabilitadas.Add("Administración|CUIT|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Administración|CUIT|Modificación");
                        opcionesHabilitadas.Add("Administración|CUIT|Cambio logotipo");
                    }
                }
                List<Entidades.Permiso> esAutorizador = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                {
                    return (p.TipoPermiso.Id == "AdminCUIT" || p.TipoPermiso.Id == "AdminUN" || p.TipoPermiso.Id == "AdminSITE") && p.WF.Estado == "Vigente";
                });
                if (esAutorizador.Count != 0)
                {
                    opcionesHabilitadas.Add("Administración|Autorizaciones|Explorador de Autorizaciones (histórico)");
                    if (RN.Permiso.LeerListaPermisosPteAutoriz(Sesion.Usuario, Sesion).Count != 0)
                    {
                        opcionesHabilitadas.Add("Administración|Autorizaciones|Explorador de Autorizaciones pendientes");
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
                        opcionesHabilitadas.Add("Administración|Unidad de Negocio|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Administración|Unidad de Negocio|Modificación");
                        opcionesHabilitadas.Add("Administración|Puntos de Venta|Alta");
                        opcionesHabilitadas.Add("Administración|Puntos de Venta|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Administración|Puntos de Venta|Modificación");
                    }
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate(Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFact" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada.Count != 0 && Sesion.Cuit.WF.Estado == "Vigente" && Sesion.UN.WF.Estado == "Vigente")
                    {
                        opcionesHabilitadas.Add("Factura Electrónica|Alta");
                        opcionesHabilitadas.Add("Factura Electrónica|Consulta de Comprobantes (base de datos)");
                        opcionesHabilitadas.Add("Factura Electrónica|Consulta de Comprobantes (online Interfacturas)");
                        opcionesHabilitadas.Add("Factura Electrónica|Consulta de Comprobante (archivo XML)");
                        opcionesHabilitadas.Add("Factura Electrónica|Consulta de Comprobante (online Interfacturas)");
                        opcionesHabilitadas.Add("Factura Electrónica|Términos y Condiciones");
                    }
                }
            }
            else
            {
                opcionesHabilitadas.Add("Iniciar sesión");
            }
            return opcionesHabilitadas;
        }
        public static void AsignarUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion, string IP)
        {
            Sesion.Usuario = Usuario;
            Entidades.Configuracion registrarIPs = new Entidades.Configuracion("RegistrarInicioSesion");
            DB.Configuracion db = new DB.Configuracion(Sesion);
            db.Leer(registrarIPs);
            if (registrarIPs.Valor == "SI")
            {
                Entidades.InicioSesion inicioSesion = new Entidades.InicioSesion();
                inicioSesion.IdUsuario = Usuario.Id;
                inicioSesion.IP = IP;
                CedServicios.RN.InicioSesion.Registrar(inicioSesion, Sesion);
            }
        }
        public static void RefrescarDatosUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            Sesion.Usuario.Permisos = RN.Permiso.LeerListaPermisosPorUsuario(Sesion.Usuario, Sesion);
            Sesion.CuitsDelUsuario = RN.Cuit.LeerListaCuitsPorUsuario(Sesion);
            List<Entidades.Cuit> estaElCuitEnLaLista = new List<Entidades.Cuit>();
            if (Sesion.CuitsDelUsuario.Count != 0)
            {
                if (Sesion.Cuit.Nro == null)
                {
                    //Todavía no eligió un Cuit ...
                    if (Sesion.Usuario.CuitPredef == String.Empty)
                    {
                        // ... y no tiene Cuit predefinido
                        AsignarCuit(Sesion.CuitsDelUsuario[0], Sesion);
                    }
                    else
                    {
                        // ... y tiene Cuit predefinido
                        estaElCuitEnLaLista = Sesion.CuitsDelUsuario.FindAll(delegate(Entidades.Cuit p) { return p.Nro == Sesion.Usuario.CuitPredef; });
                        if (estaElCuitEnLaLista.Count == 1)
                        {
                            AsignarCuit(estaElCuitEnLaLista[0], Sesion);
                        }
                        else
                        {
                            AsignarCuit(Sesion.CuitsDelUsuario[0], Sesion);
                        }
                    }
                }
                else
                {
                    //Ya eligió el Cuit
                    estaElCuitEnLaLista = Sesion.CuitsDelUsuario.FindAll(delegate(Entidades.Cuit p) { return p.Nro == Sesion.Cuit.Nro; });
                    if (estaElCuitEnLaLista.Count == 1)
                    {
                        AsignarCuit(estaElCuitEnLaLista[0], Sesion);
                    }
                    else
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
            Sesion.ClientesDelCuit = RN.Cliente.ListaPorCuit(false, Sesion);
            List<Entidades.UN> estaLaUNEnLaLista = new List<Entidades.UN>();
            if (Sesion.Cuit.UNs.Count != 0)
            {
                if (Sesion.UN.Id == 0)
                {
                    //Todavía no eligió una UN ...
                    if (Sesion.Usuario.IdUNPredef == 0)
                    {
                        // ... y no tiene UN predefinida
                        AsignarUN(Sesion.Cuit.UNs[0], Sesion);
                    }
                    else
                    {
                        // ... y tiene UN predefinida
                        estaLaUNEnLaLista = Sesion.Cuit.UNs.FindAll(delegate(Entidades.UN p) { return p.Id == Sesion.Usuario.IdUNPredef; });
                        if (estaLaUNEnLaLista.Count == 1)
                        {
                            AsignarUN(estaLaUNEnLaLista[0], Sesion);
                        }
                        else
                        {
                            AsignarUN(Sesion.Cuit.UNs[0], Sesion);
                        }
                    }
                }
                else
                {
                    //Ya eligió la UN
                    estaLaUNEnLaLista = Sesion.Cuit.UNs.FindAll(delegate(Entidades.UN p) { return p.Id == Sesion.UN.Id; });
                    if (estaLaUNEnLaLista.Count == 1)
                    {
                        AsignarUN(estaLaUNEnLaLista[0], Sesion);
                    }
                    else
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
        public static void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(archivo, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
    }
}