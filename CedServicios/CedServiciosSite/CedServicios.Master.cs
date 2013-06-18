using System;
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
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Funciones.PersonalizarControlesMaster(this, true, sesion);
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
                case "CUIT|Alta":
                    Response.Redirect("~/CuitCrear.aspx");
                    break;
                case "CUIT|Solicitud permiso de administrador de CUIT":
                    Response.Redirect("~/SolicPermisoAdminCUIT.aspx");
                    break;
                case "CUIT|Baja/Anul.baja":
                    Response.Redirect("~/CuitBaja.aspx");
                    break;
                case "CUIT|Modificación":
                    Response.Redirect("~/CuitModificar.aspx");
                    break;
                case "CUIT|Cambio logotipo":
                    Response.Redirect("~/CuitCambiarLogotipo.aspx");
                    break;
                case "CUIT|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?Cuit");
                    break;
                case "Unidad de Negocio|Alta":
                    Response.Redirect("~/UNCrear.aspx");
                    break;
                case "Unidad de Negocio|Solicitud permiso de administrador de UN":
                    Response.Redirect("~/SolicPermisoAdminUN.aspx");
                    break;
                case "Unidad de Negocio|Solicitud permiso de operador de servicio de una UN existente":
                    Response.Redirect("~/SolicPermisoOperServUN.aspx");
                    break;
                case "Unidad de Negocio|Baja/Anul.baja":
                    Response.Redirect("~/UNBaja.aspx");
                    break;
                case "Unidad de Negocio|Modificación":
                    Response.Redirect("~/UNModificar.aspx");
                    break;
                case "Unidad de Negocio|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?UN");
                    break;
                case "Puntos de Venta|Alta":
                    Response.Redirect("~/PuntoVtaCrear.aspx");
                    break;
                case "Puntos de Venta|Baja/Anul.baja":
                    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Baja");
                    break;
                case "Puntos de Venta|Modificación":
                    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Modificar");
                    break;
                case "Puntos de Venta|Consulta":
                    Response.Redirect("~/CuitTreeView.aspx?PuntoVta");
                    break;
                case "Clientes|Alta":
                    Response.Redirect("~/ClienteCrear.aspx");
                    break;
                case "Clientes|Baja/Anul.baja":
                    Response.Redirect("~/ClienteSeleccionar.aspx?Baja");
                    break;
                case "Clientes|Modificación":
                    Response.Redirect("~/ClienteSeleccionar.aspx?Modificar");
                    break;
                case "Clientes|Consulta":
                    Response.Redirect("~/ClienteConsulta.aspx");
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
                case "Factura Electrónica|Alta":
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Factura Electrónica|Consulta (archivo XML)":
                    Response.Redirect("~/Facturacion/Electronica/LoteConsulta.aspx");
                    break;
                case "Factura Electrónica|Términos y Condiciones":
                    Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    break;
                case "Autorizaciones|Explorador de Autorizaciones pendientes":
                    Response.Redirect("~/ExploradorAutorizacion.aspx?pendientes");
                    break;
                case "Autorizaciones|Explorador de Autorizaciones":
                    Response.Redirect("~/ExploradorAutorizacion.aspx");
                    break;
                case "Administración Site|Migración de Cuentas (desde CedWeb)":
                    Response.Redirect("~/Migracion.aspx");
                    break;
                case "Administración Site|Explorador de Usuarios":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de CUITs":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de UNs":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de Puntos de Venta":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de Clientes":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de Artículos":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de Permisos":
                    Response.Redirect("~/ExploradorPermiso.aspx");
                    break;
                case "Administración Site|Explorador de Configuraciones":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Administración Site|Explorador de Logs":
                    Response.Redirect("~/PaginaEnConstruccion.aspx");
                    break;
                case "Configuración|Cambio de Contraseña de Usuario":
                    Response.Redirect("~/UsuarioCambiarPassword.aspx");
                    break;
                case "Configuración|Modificación datos de Configuración":
                    Response.Redirect("~/ConfiguracionModificar.aspx");
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
                    Response.Redirect("~/Default.aspx");
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
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}