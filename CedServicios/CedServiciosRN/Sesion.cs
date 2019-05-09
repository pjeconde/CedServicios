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
            Sesion.ClientesDelCuit = new List<Entidades.Persona>();
            Sesion.ProveedoresDelCuit = new List<Entidades.Persona>();
            Sesion.Opciones = Opciones(Sesion);
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }

        public static List<Entidades.Opcion> Opciones(Entidades.Sesion Sesion)
        {
            List<CedServicios.Entidades.Opcion> opciones = new List<CedServicios.Entidades.Opcion>();
            if (Sesion.Usuario.Id != null)
            {

                opciones.Add(new Entidades.Opcion("AdminCUITAlta", true, "/CuitCrear.aspx"));
                opciones.Add(new Entidades.Opcion("AdminCUITSolPermisoAdmCUIT", true, "/SolicPermisoAdminCUIT.aspx"));

                opciones.Add(new Entidades.Opcion("AdminUNAlta", true, "/UNCrear.aspx"));
                opciones.Add(new Entidades.Opcion("AdminUNSolPermisoOpeUN", true, "/SolicPermisoOperServUN.aspx"));
                opciones.Add(new Entidades.Opcion("AdminUNSolPermisoAdmUN", true, "/SolicPermisoAdminUN.aspx"));

                opciones.Add(new Entidades.Opcion("AdminUserCambioClave", true, "/UsuarioCambiarPassword.aspx"));
                opciones.Add(new Entidades.Opcion("AdminUserModifDatosConfig", true, "/ConfiguracionModificar.aspx"));

                opciones.Add(new Entidades.Opcion("AyudaManual", true, "/Ayuda/Instructivas/OperarFacturaElectronica001.aspx"));
                opciones.Add(new Entidades.Opcion("AyudaNovedades", true, "/Ayuda/ExploradorNovedad.aspx"));
                List<Entidades.Permiso> permisoAdminSITEVigente = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.WF.Estado == "Vigente";
                });
                if (permisoAdminSITEVigente.Count != 0)
                {
                    opciones.Add(new Entidades.Opcion("AdminSite", true, "#"));
                    opciones.Add(new Entidades.Opcion("AdminSiteComprobantes", true, "/ExploradorComprobanteGlobal.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteUsuarios", true, "/ExploradorUsuario.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteCUITs", true, "/ExploradorCuit.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteUNs", true, "/ExploradorUN.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSitePtoVenta", true, "/ExploradorPuntoVta.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSitePersonas", true, "/ExploradorPersona.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteArtículos", true, "/ExploradorArticulo.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSitePermisos", true, "/ExploradorPermiso.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteConfiguraciones", true, "/ExploradorConfiguracion.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteAdministracion", true, "/ExploradorAdministracion.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteLogs", true, "/ExploradorLog.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteAdmin", true, "/ExploradorAdministracion.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteCVs", true, "/ExploradorCV.aspx"));
                    opciones.Add(new Entidades.Opcion("AdminSiteBusquedaLaboral", true, "/ExploradorBusquedaLaboral.aspx"));
                }
                if (Sesion.Cuit.Nro != null)
                {
                    opciones.Add(new Entidades.Opcion("AdminCUITConsulta", true, "/CuitTreeView.aspx?Cuit"));
                    opciones.Add(new Entidades.Opcion("AdminUNConsulta", true, "/CuitTreeView.aspx?UN"));
                    List<Entidades.Permiso> esAdminCUITdeCUITseleccionado = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == Sesion.Cuit.Nro && p.WF.Estado == "Vigente";
                    });
                    if (esAdminCUITdeCUITseleccionado.Count != 0)
                    {
                        opciones.Add(new Entidades.Opcion("AdminCUITBajaYAnulBaja", true, "/CuitBaja.aspx"));
                        opciones.Add(new Entidades.Opcion("AdminCUITModif", true, "/CuitModificar.aspx"));
                        opciones.Add(new Entidades.Opcion("AdminCUITCambioLogo", true, "/CuitCambiarLogotipo.aspx"));
                    }
                }
                List<Entidades.Permiso> esAutorizador = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                {
                    return (p.TipoPermiso.Id == "AdminCUIT" || p.TipoPermiso.Id == "AdminUN" || p.TipoPermiso.Id == "AdminSITE") && p.WF.Estado == "Vigente";
                });
                if (esAutorizador.Count != 0)
                {
                    opciones.Add(new Entidades.Opcion("AdminAutorizHis", true, "/ExploradorAutorizacionLog.aspx"));
                    if (RN.Permiso.LeerListaPermisosPteAutoriz(Sesion.Usuario, Sesion).Count != 0)
                    {
                        opciones.Add(new Entidades.Opcion("AdminAutorizPtes", true, "/ExploradorAutorizacion.aspx"));
                    }
                }
                if (Sesion.UN.Id != 0)
                {
                    List<Entidades.Permiso> elUsuarioEsAdministradorDeLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminUN" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                    {
                        opciones.Add(new Entidades.Opcion("AdminUNBajaYAnulBaja", true, "/UNBaja.aspx"));
                        opciones.Add(new Entidades.Opcion("AdminUNModif", true, "/UNModificar.aspx"));
                    }
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFact" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTCONSULTAParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFactConsulta" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada.Count != 0 && Sesion.Cuit.WF.Estado == "Vigente" && Sesion.UN.WF.Estado == "Vigente")
                    {
                        opciones.Add(new Entidades.Opcion("PersonasAlta", true, "/PersonaCrear.aspx"));
                        opciones.Add(new Entidades.Opcion("PersonasBajaYAnulBaja", true, "/PersonaSeleccionar.aspx?Baja"));
                        opciones.Add(new Entidades.Opcion("PersonasModif", true, "/PersonaSeleccionar.aspx?Modificar"));
                        opciones.Add(new Entidades.Opcion("PersonasConsulta", true, "/PersonaConsulta.aspx"));

                        opciones.Add(new Entidades.Opcion("ArticulosAlta", true, "/ArticuloCrear.aspx"));
                        opciones.Add(new Entidades.Opcion("ArticulosBajaYAnulBaja", true, "/ArticuloSeleccionar.aspx?Baja"));
                        opciones.Add(new Entidades.Opcion("ArticulosModif", true, "/ArticuloSeleccionar.aspx?Modificar"));
                        opciones.Add(new Entidades.Opcion("ArticulosConsulta", true, "/ArticuloConsulta.aspx"));

                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosAlta", true, "/ListaPrecioCrear.aspx"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosBajaYAnulBaja", true, "/ListaPrecioSeleccionar.aspx?Baja"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosModif", true, "/ListaPrecioSeleccionar.aspx?Modificar"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosClonado", true, "/ListaPrecioSeleccionar.aspx?Clonar"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosReemplazo", true, "/ListaPrecioSeleccionar.aspx?Reemplazar"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosConsulta", true, "/ListaPrecioConsulta.aspx"));

                        opciones.Add(new Entidades.Opcion("ArticulosPreciosIngresoManual", true, "/PrecioIngresoManual.aspx"));
                        opciones.Add(new Entidades.Opcion("ArticulosPreciosImportExcel", true, "/PrecioImportacionExcel.aspx"));

                        //Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("VentaContrato");
                        if (Sesion.Usuario.FechaOKeFactTyC == "00000000")
                        {
                            opciones.Add(new Entidades.Opcion("ContratosAlta", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));
                        }
                        else
                        {
                            opciones.Add(new Entidades.Opcion("ContratosAlta", true, "/Facturacion/Electronica/Lote.aspx?CaT=VentaContrato"));
                        }

                        opciones.Add(new Entidades.Opcion("ContratosBajaYAnulBaja", true, "/ExploradorComprobante.aspx?Baja/Anul.baja-Contrato"));
                        opciones.Add(new Entidades.Opcion("ContratosModif", true, "/ExploradorComprobante.aspx?Modificacion-Contrato"));
                        opciones.Add(new Entidades.Opcion("ContratosConsulta", true, "/ExploradorComprobante.aspx?Consulta-Contrato"));

                        if (Sesion.Usuario.FechaOKeFactTyC == "00000000")
                        {
                            opciones.Add(new Entidades.Opcion("FactComun", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));
                        }
                        else
                        {
                            opciones.Add(new Entidades.Opcion("FactComun", true, "/Facturacion/Electronica/Lote.aspx?CaT=Venta"));
                        }
                        List<Entidades.PuntoVta> lpv = Sesion.UN.PuntosVtaVigentes.FindAll(delegate (Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "Turismo";
                        });
                        if (lpv.Count != 0)
                        {
                            if (Sesion.Usuario.FechaOKeFactTyC == "00000000")
                            {
                                opciones.Add(new Entidades.Opcion("FactTurismo", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));
                            }
                            else
                            {
                                opciones.Add(new Entidades.Opcion("FactTurismo", true, "/Facturacion/Electronica/LoteCT.aspx?CaT=Venta"));
                            }
                        }
                        opciones.Add(new Entidades.Opcion("FactAutContratosServicios", true, "/Facturacion/ComprobanteGeneracionAutomatica.aspx"));
                        if (Sesion.Usuario.FechaOKeFactTyC == "00000000")
                        {
                            opciones.Add(new Entidades.Opcion("RegistroFacturasVenta", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));
                        }
                        else
                        {
                            opciones.Add(new Entidades.Opcion("RegistroFacturasVenta", true, "/Facturacion/Electronica/Lote.aspx?CaT=VentaTradic"));
                        }
                        if (Sesion.Usuario.FechaOKeFactTyC == "00000000")
                        {
                            opciones.Add(new Entidades.Opcion("RegistroFacturasCompra", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));
                        }
                        else
                        {
                            opciones.Add(new Entidades.Opcion("RegistroFacturasCompra", true, "/Facturacion/Electronica/Lote.aspx?CaT=Compra"));
                        }

                        opciones.Add(new Entidades.Opcion("ComprobantesBajaYAnulBaja", true, "/ExploradorComprobante.aspx?Baja/Anul.baja-Comprobante"));
                        opciones.Add(new Entidades.Opcion("ComprobantesModif", true, "/ExploradorComprobante.aspx?Modificacion-Comprobante"));
                        opciones.Add(new Entidades.Opcion("ComprobantesEnvioAFIPyITF", true, "/ExploradorComprobante.aspx?Envio-Comprobante"));
                        opciones.Add(new Entidades.Opcion("ComprobantesConsulta", true, "/ExploradorComprobante.aspx?Consulta-Comprobante"));
                        opciones.Add(new Entidades.Opcion("ComprobantesConsultaPDFs", true, "/ExploradorPDFComprobante.aspx"));

                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsIVAVentas", true, "/Facturacion/Electronica/Reportes/IvaVentasFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsIVACompras", true, "/Facturacion/Electronica/Reportes/IvaComprasFiltros.aspx"));

                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsInterfazCITI", true, "/ExploradorComprobanteRG.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsVentasXArticulo", true, "/Facturacion/Electronica/Reportes/VentasXArticuloFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsComprasXArticulo", true, "/Facturacion/Electronica/Reportes/ComprasXArticuloFiltros.aspx"));

                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsStockXArticulo", true, "/Facturacion/Electronica/Reportes/StockXArticuloFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineITFComprobantes", true, "/ExploradorComprobanteOnLineInterfacturas.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineITFComprobante", true, "/ComprobanteSeleccionOnlineInterfacturas.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineAFIP", true, "/ComprobanteSeleccionOnlineAFIP.aspx"));

                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsultasArchivoXML", true, "/ComprobanteSeleccionArchivoXML.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsTYC", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));

                        if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                        {
                            opciones.Add(new Entidades.Opcion("AdminPtoVentaAlta", true, "/PuntoVtaCrear.aspx"));
                            opciones.Add(new Entidades.Opcion("AdminPtoVentaBajaYAnulBaja", true, "/PuntoVtaSeleccionar.aspx"));
                            opciones.Add(new Entidades.Opcion("AdminPtoVentaModif", true, "/PuntoVtaSeleccionar.aspx"));
                        }
                        opciones.Add(new Entidades.Opcion("AdminPtoVentaConsulta", true, "/CuitTreeView.aspx?PuntoVta.aspx"));
                    }
                    else if (elUsuarioTieneHabilitadoElServicioEFACTCONSULTAParaLaUNSeleccionada.Count != 0 && Sesion.Cuit.WF.Estado == "Vigente" && Sesion.UN.WF.Estado == "Vigente")
                    {
                        opciones.Add(new Entidades.Opcion("PersonasConsulta", true, "/PersonaConsulta.aspx"));

                        opciones.Add(new Entidades.Opcion("ArticulosConsulta", true, "/ArticuloConsulta.aspx"));
                        opciones.Add(new Entidades.Opcion("ArticulosListaPreciosConsulta", true, "/ListaPrecioConsulta.aspx"));

                        opciones.Add(new Entidades.Opcion("ContratosConsulta", true, "/ExploradorComprobante.aspx?Consulta-Contrato"));

                        opciones.Add(new Entidades.Opcion("ComprobantesConsulta", true, "/ExploradorComprobante.aspx?Consulta-Comprobante"));
                        opciones.Add(new Entidades.Opcion("ComprobantesConsultaPDFs", true, "/ExploradorPDFComprobante.aspx"));

                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsIVAVentas", true, "/Facturacion/Electronica/Reportes/IvaVentasFiltros.aspx"));
                        //opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsIVACompras", true, "/Facturacion/Electronica/Reportes/IvaComprasFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsInterfazCITI", true, "/ExploradorComprobanteRG.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsVentasXArticulo", true, "/Facturacion/Electronica/Reportes/VentasXArticuloFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsComprasXArticulo", true, "/Facturacion/Electronica/Reportes/ComprasXArticuloFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsStockXArticulo", true, "/Facturacion/Electronica/Reportes/StockXArticuloFiltros.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineITFComprobantes", true, "/ExploradorComprobanteOnLineInterfacturas.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineITFComprobante", true, "/ComprobanteSeleccionOnlineInterfacturas.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsOnlineAFIP", true, "/ComprobanteSeleccionOnlineAFIP.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsultasArchivoXML", true, "/ComprobanteSeleccionArchivoXML.aspx"));
                        opciones.Add(new Entidades.Opcion("ComprobantesOtrasConsTYC", true, "/Facturacion/Electronica/FacturaElectronicaTYC.aspx"));

                        opciones.Add(new Entidades.Opcion("AdminPtoVentaConsulta", true, "/CuitTreeView.aspx?PuntoVta.aspx"));
                    }
                }
            }
            return opciones;
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
                //opcionesHabilitadas.Add("AyudaManual");
                //opcionesHabilitadas.Add("AyudaNovedades");
                opcionesHabilitadas.Add("Salir");

                List<Entidades.Permiso> permisoAdminSITEVigente = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                {
                    return p.TipoPermiso.Id == "AdminSITE" && p.WF.Estado == "Vigente";
                });
                if (permisoAdminSITEVigente.Count != 0)
                {
                    //opcionesHabilitadas.Add("AdminSiteComprobantes");
                    //opcionesHabilitadas.Add("AdminSiteUsuarios");
                    //opcionesHabilitadas.Add("AdminSiteCUITs");
                    //opcionesHabilitadas.Add("AdminSiteUNs");
                    //opcionesHabilitadas.Add("AdminSitePuntosDeVenta");
                    //opcionesHabilitadas.Add("AdminSitePersonas");
                    //opcionesHabilitadas.Add("AdminSiteArtículos");
                    //opcionesHabilitadas.Add("AdminSitePermisos");
                    //opcionesHabilitadas.Add("AdminSiteConfiguraciones");
                    //opcionesHabilitadas.Add("AdminSiteLogs");
                    //opcionesHabilitadas.Add("AdminSiteAdministracion");
                    //opcionesHabilitadas.Add("AdminSiteCVs");
                    //opcionesHabilitadas.Add("AdminSiteBusquedaLaboral");
                }
                if (Sesion.Cuit.Nro != null)
                {
                    //opcionesHabilitadas.Add("Administración|CUIT|Consulta");
                    //opcionesHabilitadas.Add("Administración|Unidad de Negocio|Consulta");
                    List<Entidades.Permiso> esAdminCUITdeCUITseleccionado = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminCUIT" && p.Cuit == Sesion.Cuit.Nro && p.WF.Estado == "Vigente";
                    });
                    if (esAdminCUITdeCUITseleccionado.Count != 0)
                    {
                        //opcionesHabilitadas.Add("Administración|CUIT|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Administración|CUIT|Modificación");
                        //opcionesHabilitadas.Add("Administración|CUIT|Cambio logotipo");
                    }
                }
                List<Entidades.Permiso> esAutorizador = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
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
                    List<Entidades.Permiso> elUsuarioEsAdministradorDeLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "AdminUN" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                    {
                        opcionesHabilitadas.Add("Administración|Unidad de Negocio|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Administración|Unidad de Negocio|Modificación");
                    }
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFact" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    List<Entidades.Permiso> elUsuarioTieneHabilitadoElServicioEFACTCONSULTAParaLaUNSeleccionada = Sesion.Usuario.Permisos.FindAll(delegate (Entidades.Permiso p)
                    {
                        return p.TipoPermiso.Id == "eFactConsulta" && p.UN.Id == Sesion.UN.Id && p.Cuit == Sesion.UN.Cuit && p.WF.Estado == "Vigente";
                    });
                    if (elUsuarioTieneHabilitadoElServicioEFACTParaLaUNSeleccionada.Count != 0 && Sesion.Cuit.WF.Estado == "Vigente" && Sesion.UN.WF.Estado == "Vigente")
                    {
                        opcionesHabilitadas.Add("Personas|Alta");
                        opcionesHabilitadas.Add("Personas|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Personas|Modificación");
                        opcionesHabilitadas.Add("Personas|Consulta");
                        opcionesHabilitadas.Add("Artículos|Alta");
                        opcionesHabilitadas.Add("Artículos|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Artículos|Modificación");
                        opcionesHabilitadas.Add("Artículos|Consulta");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Alta");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Modificación");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Clonado");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Reemplazo");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Consulta");
                        opcionesHabilitadas.Add("Artículos|Precios|Ingreso Manual");
                        opcionesHabilitadas.Add("Artículos|Precios|Importación desde archivo Excel");
                        opcionesHabilitadas.Add("Contratos|Alta");
                        opcionesHabilitadas.Add("Contratos|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Contratos|Modificación");
                        opcionesHabilitadas.Add("Contratos|Consulta");

                        opcionesHabilitadas.Add("Facturación|Común / RG.2904 / Bono Fiscal / Exportación");
                        List<Entidades.PuntoVta> lpv = Sesion.UN.PuntosVtaVigentes.FindAll(delegate (Entidades.PuntoVta pv)
                        {
                            return pv.IdTipoPuntoVta == "Turismo";
                        });
                        if (lpv.Count != 0)
                        {
                            opcionesHabilitadas.Add("Facturación|Turismo");
                        }
                        opcionesHabilitadas.Add("Facturación|Automática de Contratos/Servicios");

                        opcionesHabilitadas.Add("Registro de Facturas|Venta Resguardo");
                        opcionesHabilitadas.Add("Registro de Facturas|Compra");

                        opcionesHabilitadas.Add("Comprobantes|Baja/Anul.baja");
                        opcionesHabilitadas.Add("Comprobantes|Modificación");
                        opcionesHabilitadas.Add("Comprobantes|Envio (AFIP/ITF)");
                        opcionesHabilitadas.Add("Comprobantes|Consulta");
                        opcionesHabilitadas.Add("Comprobantes|Consulta PDFs");

                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|IVA Ventas");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|IVA Compras");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Interfaz CITI Ventas/Compras RG.3685");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Ventas por Artículo");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Compras por Artículo");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Stock por Artículo");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online Interfacturas|Varios comprobantes");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online Interfacturas|Un comprobante");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online AFIP");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Archivo XML");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Términos y condiciones");

                        if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                        {
                            opcionesHabilitadas.Add("Administración|Puntos de Venta|Alta");
                            opcionesHabilitadas.Add("Administración|Puntos de Venta|Baja/Anul.baja");
                            opcionesHabilitadas.Add("Administración|Puntos de Venta|Modificación");
                        }
                        opcionesHabilitadas.Add("Administración|Puntos de Venta|Consulta");
                    }
                    else if (elUsuarioTieneHabilitadoElServicioEFACTCONSULTAParaLaUNSeleccionada.Count != 0 && Sesion.Cuit.WF.Estado == "Vigente" && Sesion.UN.WF.Estado == "Vigente")
                    {
                        //opcionesHabilitadas.Add("Personas|Alta");
                        //opcionesHabilitadas.Add("Personas|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Personas|Modificación");
                        opcionesHabilitadas.Add("Personas|Consulta");
                        //opcionesHabilitadas.Add("Artículos|Alta");
                        //opcionesHabilitadas.Add("Artículos|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Artículos|Modificación");
                        opcionesHabilitadas.Add("Artículos|Consulta");
                        //opcionesHabilitadas.Add("Artículos|Listas de Precios|Alta");
                        //opcionesHabilitadas.Add("Artículos|Listas de Precios|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Artículos|Listas de Precios|Modificación");
                        //opcionesHabilitadas.Add("Artículos|Listas de Precios|Clonado");
                        //opcionesHabilitadas.Add("Artículos|Listas de Precios|Reemplazo");
                        opcionesHabilitadas.Add("Artículos|Listas de Precios|Consulta");
                        //opcionesHabilitadas.Add("Artículos|Precios|Ingreso Manual");
                        //opcionesHabilitadas.Add("Artículos|Precios|Importación desde archivo Excel");
                        //opcionesHabilitadas.Add("Contratos|Alta");
                        //opcionesHabilitadas.Add("Contratos|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Contratos|Modificación");
                        opcionesHabilitadas.Add("Contratos|Consulta");
                        //opcionesHabilitadas.Add("Comprobantes|Alta manual|Venta|Electrónica");
                        ////opcionesHabilitadas.Add("Comprobantes|Alta manual|Venta|Tradicional");    //Nuevo
                        //opcionesHabilitadas.Add("Comprobantes|Alta manual|Compra");                 //Nuevo
                        //opcionesHabilitadas.Add("Comprobantes|Baja/Anul.baja");
                        //opcionesHabilitadas.Add("Comprobantes|Modificación");
                        //opcionesHabilitadas.Add("Comprobantes|Envio (AFIP/ITF)");                   //Nuevo
                        opcionesHabilitadas.Add("Comprobantes|Consulta");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|IVA Ventas");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Ventas por Artículo");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Interfaz RG.3685");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Compras por Artículo");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online Interfacturas|Varios comprobantes");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online Interfacturas|Un comprobante");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Online AFIP");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Archivo XML");
                        opcionesHabilitadas.Add("Comprobantes|Otras Consultas|Términos y condiciones");
                        //opcionesHabilitadas.Add("Comprobantes|Generación automática (contratos)");  //Nuevo
                        opcionesHabilitadas.Add("Comprobantes|Consulta PDFs");  //Nuevo
                        //if (elUsuarioEsAdministradorDeLaUNSeleccionada.Count != 0)
                        //{
                        //    opcionesHabilitadas.Add("Administración|Puntos de Venta|Alta");
                        //    opcionesHabilitadas.Add("Administración|Puntos de Venta|Baja/Anul.baja");
                        //    opcionesHabilitadas.Add("Administración|Puntos de Venta|Modificación");
                        //}
                        opcionesHabilitadas.Add("Administración|Puntos de Venta|Consulta");
                    }

                }
            }
            else
            {
                //opcionesHabilitadas.Add("Iniciar sesión");
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
                        estaElCuitEnLaLista = Sesion.CuitsDelUsuario.FindAll(delegate (Entidades.Cuit p) { return p.Nro == Sesion.Usuario.CuitPredef; });
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
                    estaElCuitEnLaLista = Sesion.CuitsDelUsuario.FindAll(delegate (Entidades.Cuit p) { return p.Nro == Sesion.Cuit.Nro; });
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
            Sesion.Opciones = Opciones(Sesion);
            Sesion.OpcionesHabilitadas = OpcionesHabilitadas(Sesion);
        }
        public static void AsignarCuit(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            Sesion.Cuit = Cuit;
            Sesion.Cuit.UNs = RN.UN.ListaPorCuitParaElUsuarioLogueado(Sesion);
            Sesion.ClientesDelCuit = RN.Persona.ListaPorCuit(false, CedServicios.Entidades.Enum.TipoPersona.Cliente, Sesion);
            Sesion.ProveedoresDelCuit = RN.Persona.ListaPorCuit(false, CedServicios.Entidades.Enum.TipoPersona.Proveedor, Sesion);
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
                        estaLaUNEnLaLista = Sesion.Cuit.UNs.FindAll(delegate (Entidades.UN p) { return p.Id == Sesion.Usuario.IdUNPredef; });
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
                    estaLaUNEnLaLista = Sesion.Cuit.UNs.FindAll(delegate (Entidades.UN p) { return p.Id == Sesion.UN.Id; });
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
            Sesion.ClientesDelCuit = new List<Entidades.Persona>();
            Sesion.ProveedoresDelCuit = new List<Entidades.Persona>();
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