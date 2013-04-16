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
        protected void Page_Load(object sender, EventArgs e)
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
            switch (Menu.SelectedValue.ToString())
            {
                case "Iniciar sesión":
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
                case "Alta de CUIT":
                    Response.Redirect("~/CuitCrear.aspx");
                    break;
                case "Solicitud permiso de administrador de CUIT":
                    Response.Redirect("~/SolicPermisoAdminCUIT.aspx");
                    break;
                case "Modificación datos CUIT":
                    Response.Redirect("~/CuitModificar.aspx");
                    break;
                case "Consulta de CUIT(s)":
                    Response.Redirect("~/CuitTreeView.aspx?Cuit");
                    break;
                case "Alta de Unidad de Negocio":
                    Response.Redirect("~/UNCrear.aspx");
                    break;
                case "Solicitud permiso de administrador de UN":
                    Response.Redirect("~/SolicPermisoAdminUN.aspx");
                    break;
                case "Solicitud permiso de operador de servicio de una UN existente":
                    Response.Redirect("~/SolicPermisoOperServUN.aspx");
                    break;
                case "Modificación datos UN":
                    Response.Redirect("~/UNModificar.aspx");
                    break;
                case "Consulta de Unidad(es) de Negocio":
                    Response.Redirect("~/CuitTreeView.aspx?UN");
                    break;
                case "Alta de Punto de Venta":
                    Response.Redirect("~/PuntoVtaCrear.aspx");
                    break;
                case "Modificación de Punto de Venta":
                    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Modificar");
                    break;
                case "Consulta de Punto(s) de Venta":
                    Response.Redirect("~/CuitTreeView.aspx?PuntoVta");
                    break;
                case "Explorador de Autorizaciones pendientes":
                    Response.Redirect("~/ExploradorAutorizacion.aspx?pendientes");
                    break;
                case "Explorador de Autorizaciones":
                    Response.Redirect("~/ExploradorAutorizacion.aspx");
                    break;
                case "Cerrar sesión":
                    RN.Sesion.Cerrar(sesion);
                    Response.Redirect("~/UsuarioLogin.aspx");
                    break;
                case "Facturación":
                    Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    break;
                case "Cambio de Contraseña de Usuario":
                    Response.Redirect("~/UsuarioCambiarPassword.aspx");
                    break;
            }
        }
        public Color GetItemColor(MenuItemTemplateContainer container)
        {
            MenuItem item = (MenuItem)container.DataItem;
            if (!(item.Selectable || item.ChildItems.Count>0))
                return Color.Red;
            else
                return Color.DarkBlue;
        }
        protected void CUITDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CUITDropDownList.SelectedItem != null)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Sesion.AsignarCuit(sesion.CuitsDelUsuario[CUITDropDownList.SelectedIndex], sesion);
                Funciones.PersonalizarControlesMaster(this, true, sesion);
            }
        }
        protected void EmpresaImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/InstitucionalEmpresa.aspx");
        }
    }
}