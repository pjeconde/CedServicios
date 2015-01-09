﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class CedServicios : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Object o = Cache.Get("ComprobanteAClonar");
                if (o == null)
                {
                    Funciones.PersonalizarControlesMaster(this, true, sesion);
                }
                else
                {
                    if (Request.RawUrl != "/Facturacion/Electronica/Lote.aspx")
                    {
                        Cache.Remove("ComprobanteAClonar");
                        Funciones.PersonalizarControlesMaster(this, true, sesion);
                    }
                    else
                    {
                        UsuarioContentPlaceHolder.Visible = false;
                    }
                }
            }
        }
        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            switch (Menu.SelectedItem.ValuePath)
            {
                case "Iniciar sesión":
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
                case "Administración|CUIT|Alta":
                    Response.Redirect("~/CuitCrear.aspx");
                    break;
                case "Administración|CUIT|Solicitud permiso de administrador de CUIT":
                    Response.Redirect("~/SolicPermisoAdminCUIT.aspx");
                    break;
                case "Administración|CUIT|Baja/Anul.baja":
                    Response.Redirect("~/CuitBaja.aspx");
                    break;
                case "Administración|CUIT|Modificación":
                    Response.Redirect("~/CuitModificar.aspx");
                    break;
                case "Administración|CUIT|Cambio logotipo":
                    Response.Redirect("~/CuitCambiarLogotipo.aspx");
                    break;
                case "Administración|CUIT|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?Cuit");
                    break;
                case "Administración|Unidad de Negocio|Alta":
                    Response.Redirect("~/UNCrear.aspx");
                    break;
                case "Administración|Unidad de Negocio|Solicitud permiso de administrador de UN":
                    Response.Redirect("~/SolicPermisoAdminUN.aspx");
                    break;
                case "Administración|Unidad de Negocio|Solicitud permiso de operador de servicio de una UN existente":
                    Response.Redirect("~/SolicPermisoOperServUN.aspx");
                    break;
                case "Administración|Unidad de Negocio|Baja/Anul.baja":
                    Response.Redirect("~/UNBaja.aspx");
                    break;
                case "Administración|Unidad de Negocio|Modificación":
                    Response.Redirect("~/UNModificar.aspx");
                    break;
                case "Administración|Unidad de Negocio|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?UN");
                    break;
                case "Administración|Puntos de Venta|Alta":
                    Response.Redirect("~/PuntoVtaCrear.aspx");
                    break;
                case "Administración|Puntos de Venta|Baja/Anul.baja":
                    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Baja");
                    break;
                case "Administración|Puntos de Venta|Modificación":
                    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Modificar");
                    break;
                case "Administración|Puntos de Venta|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?PuntoVta");
                    break;
                case "Personas(clientes/proveedores)|Alta":
                    Response.Redirect("~/PersonaCrear.aspx");
                    break;
                case "Personas(clientes/proveedores)|Baja/Anul.baja":
                    Response.Redirect("~/PersonaSeleccionar.aspx?Baja");
                    break;
                case "Personas(clientes/proveedores)|Modificación":
                    Response.Redirect("~/PersonaSeleccionar.aspx?Modificar");
                    break;
                case "Personas(clientes/proveedores)|Consulta":
                    Response.Redirect("~/PersonaConsulta.aspx");
                    break;
                case "Artículos|Alta":
                    Response.Redirect("~/ArticuloCrear.aspx");
                    break;
                case "Artículos|Modificación":
                    Response.Redirect("~/ArticuloSeleccionar.aspx?Modificar");
                    break;
                case "Artículos|Baja/Anul.baja":
                    Response.Redirect("~/ArticuloSeleccionar.aspx?Baja");
                    break;
                case "Artículos|Consulta":
                    Response.Redirect("~/ArticuloConsulta.aspx");
                    break;
                case "Comprobantes|Alta|Venta|Electrónica":
                    Session["IdNaturalezaComprobante"] = "Venta";
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Comprobantes|Alta|Venta|Manual":
                    Session["IdNaturalezaComprobante"] = "VentaM";
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Comprobantes|Alta|Compra":
                    Session["IdNaturalezaComprobante"] = "Compra";
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Comprobantes|Consulta":
                    Response.Redirect("~/ExploradorComprobante.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Online Interfacturas|Varios comprobantes":
                    Response.Redirect("~/ExploradorComprobanteOnLineInterfacturas.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Online Interfacturas|Un comprobante":
                    Response.Redirect("~/ComprobanteSeleccionOnlineInterfacturas.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Online AFIP":
                    Response.Redirect("~/ComprobanteSeleccionOnlineAFIP.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Archivo XML":
                    Response.Redirect("~/ComprobanteSeleccionArchivoXML.aspx");
                    break;
                case "Comprobantes|TyC":
                    Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    break;
                case "Administración|Autorizaciones|Explorador de Autorizaciones pendientes":
                    Response.Redirect("~/ExploradorAutorizacion.aspx");
                    break;
                case "Administración|Autorizaciones|Explorador de Autorizaciones (histórico)":
                    Response.Redirect("~/ExploradorAutorizacionLog.aspx");
                    break;
                case "Administración Site|Comprobantes":
                    Response.Redirect("~/ExploradorComprobanteGlobal.aspx");
                    break;
                case "Administración Site|Usuarios":
                    Response.Redirect("~/ExploradorUsuario.aspx");
                    break;
                case "Administración Site|CUITs":
                    Response.Redirect("~/ExploradorCuit.aspx");
                    break;
                case "Administración Site|UNs":
                    Response.Redirect("~/ExploradorUN.aspx");
                    break;
                case "Administración Site|Puntos de Venta":
                    Response.Redirect("~/ExploradorPuntoVta.aspx");
                    break;
                case "Administración Site|Personas":
                    Response.Redirect("~/ExploradorPersona.aspx");
                    break;
                case "Administración Site|Artículos":
                    Response.Redirect("~/ExploradorArticulo.aspx");
                    break;
                case "Administración Site|Permisos":
                    Response.Redirect("~/ExploradorPermiso.aspx");
                    break;
                case "Administración Site|Configuraciones":
                    Response.Redirect("~/ExploradorConfiguracion.aspx");
                    break;
                case "Administración Site|Logs":
                    Response.Redirect("~/ExploradorLog.aspx");
                    break;
                case "Administración Site|Administración":
                    Response.Redirect("~/ExploradorAdministracion.aspx");
                    break;
                case "Administración|Usuario|Cambio de Contraseña":
                    Response.Redirect("~/UsuarioCambiarPassword.aspx");
                    break;
                case "Administración|Usuario|Modificación datos de Configuración":
                    Response.Redirect("~/ConfiguracionModificar.aspx");
                    break;
                case "Ayuda|Manual|¿Cómo empiezo a operar con facturas electrónicas?":
                    sesion.EstoyEnAyuda = true;
                    Response.Redirect("~/Ayuda/Instructivas/OperarFacturaElectronica001.aspx");
                    break;
                case "Ayuda|Novedades":
                    Response.Redirect("~/Ayuda/ExploradorNovedad.aspx");
                    break;
                case "Ayuda|Documentación técnica":
                    Response.Redirect("~/default.aspx");
                    break;
                case "Cerrar sesión":
                    RN.Sesion.Cerrar(sesion);
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
            }
        }
        public Color GetItemColor(MenuItemTemplateContainer container)
        {
            MenuItem item = (MenuItem)container.DataItem;
            if (item.Selectable || item.ChildItems.Count>0)
                return Color.DarkBlue;
            else
                return Color.Red;
        }
        protected void CUITDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CUITDropDownList.SelectedItem != null)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    RN.Sesion.AsignarCuit(sesion.CuitsDelUsuario[CUITDropDownList.SelectedIndex], sesion);
                    //Funciones.PersonalizarControlesMaster(this, true, sesion);
                    Response.Redirect(sesion.Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
                }
            }
        }
        protected void EmpresaImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/InstitucionalEmpresa.aspx");
        }
        protected void UsuarioImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UsuarioConsulta.aspx");
        }
        protected void UNDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UNDropDownList.SelectedItem != null)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    RN.Sesion.AsignarUN(sesion.Cuit.UNs[UNDropDownList.SelectedIndex], sesion);
                    //Funciones.PersonalizarControlesMaster(this, true, sesion);
                    Response.Redirect(sesion.Usuario.PaginaDefault(sesion));
                }
            }
        }
    }
}