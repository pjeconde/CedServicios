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
                string[] segmentosURL = HttpContext.Current.Request.Url.Segments;
                string pagina = segmentosURL[segmentosURL.Length - 1].ToUpper();
                if (pagina != null)
                {
                    Control c;
                    switch (pagina)
                    {
                        case "DEFAULT.ASPX":
                            //c = (Control)this.FindControl("secHeader");
                            //c.Visible = true;
                            //c = (Control)this.FindControl("secAcerca");
                            //c.Visible = true;
                            //c = (Control)this.FindControl("secServicios");
                            //c.Visible = true;
                            break;
                        case "FACTURA.ASPX":
                            if (HttpContext.Current.Request.Url.Query.ToUpper() == "?SALIR")
                            {
                                if (sesion != null && sesion.Usuario.Id != null)
                                {
                                    RN.Sesion.Cerrar(sesion);
                                }
                            }
                            //c = (Control)this.FindControl("secAcerca");
                            //c.Visible = false;
                            //c = (Control)this.FindControl("secServicios");
                            //c.Visible = false;
                            break;
                        default:
                            //c = (Control)this.FindControl("secHeader");
                            //c.Visible = false;
                            //c = (Control)this.FindControl("secAcerca");
                            //c.Visible = false;
                            //c = (Control)this.FindControl("secServicios");
                            //c.Visible = false;
                            break;
                    }
                }
                Funciones.PersonalizarControlesMaster(this, true, sesion);
                IdBusquedaPerfilDropDownList.DataSource = RN.BusquedaPerfil.Lista(sesion);
                IdBusquedaPerfilDropDownList.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.Usuario.Id == null)
                {
                    footerNoLogin.Visible = true;
                }
                else
                {
                    switch (HttpContext.Current.Request.Url.AbsolutePath.ToString())
                    {
                        case "/Inicio.aspx":
                        case "/InicioFEA.aspx":
                        case "/InicioFEAPrecios.aspx":
                            footerNoLogin.Visible = true;
                            break;
                        default:
                            footerNoLogin.Visible = false;
                            break;
                    }
                }
                if (Session["ComprobanteATratar"] == null)
                {
                    Funciones.PersonalizarControlesMaster(this, true, sesion);
                }
                else
                {
                    if (Request.RawUrl == "/Facturacion/Electronica/Lote.aspx" && ((Entidades.ComprobanteATratar)Session["ComprobanteATratar"]).Tratamiento != Entidades.Enum.TratamientoComprobante.Alta)
                    {
                        UsuarioContentPlaceHolder.Visible = false;
                        CedeiraContentPlaceHolder.Visible = false;
                    }
                    else if (Request.RawUrl == "/Facturacion/Electronica/LoteCT.aspx" && ((Entidades.ComprobanteATratar)Session["ComprobanteATratar"]).Tratamiento != Entidades.Enum.TratamientoComprobante.Alta)
                    {
                        UsuarioContentPlaceHolder.Visible = false;
                        CedeiraContentPlaceHolder.Visible = false;
                    }
                    else
                    {
                        Session.Remove("ComprobanteATratar");
                        Funciones.PersonalizarControlesMaster(this, true, sesion);
                    }
                }
                //VersionLabel.Text = "Ver. " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //try
                //{
                //    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.Turismo.comprobante));
                //    System.IO.StringWriter textWriter = new System.IO.StringWriter();
                //}
                //catch (Exception exSerializer)
                //{
                //    Console.WriteLine(exSerializer.Message);
                //}
            }
            //Detectar la ejecución de un UpdatePanel
            if (MasterScriptManager.IsInAsyncPostBack)
            {
                //string someScript = "";
                //someScript = "<script language='javascript'>alert('Called from CodeBehind');</script>";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);
            }
        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            switch (Menu.SelectedItem.ValuePath)
            {
                //case "Administración|CUIT|Alta":
                //    Response.Redirect("~/CuitCrear.aspx");
                //    break;
                //case "Administración|CUIT|Solicitud permiso de administrador de CUIT":
                //    Response.Redirect("~/SolicPermisoAdminCUIT.aspx");
                //    break;
                //case "Administración|CUIT|Baja/Anul.baja":
                //    Response.Redirect("~/CuitBaja.aspx");
                //    break;
                //case "Administración|CUIT|Modificación":
                //    Response.Redirect("~/CuitModificar.aspx");
                //    break;
                //case "Administración|CUIT|Cambio logotipo":
                //    Response.Redirect("~/CuitCambiarLogotipo.aspx");
                //    break;
                //case "Administración|CUIT|Consulta":
                //    Response.Redirect("~/CuitTreeView.aspx?Cuit");
                //    break;
                //case "Administración|Unidad de Negocio|Alta":
                //    Response.Redirect("~/UNCrear.aspx");
                //    break;
                //case "Administración|Unidad de Negocio|Solicitud permiso de administrador de UN":
                //    Response.Redirect("~/SolicPermisoAdminUN.aspx");
                //    break;
                //case "Administración|Unidad de Negocio|Solicitud permiso de operador de servicio de una UN existente":
                //    Response.Redirect("~/SolicPermisoOperServUN.aspx");
                //    break;
                //case "Administración|Unidad de Negocio|Baja/Anul.baja":
                //    Response.Redirect("~/UNBaja.aspx");
                //    break;
                //case "Administración|Unidad de Negocio|Modificación":
                //    Response.Redirect("~/UNModificar.aspx");
                //    break;
                //case "Administración|Unidad de Negocio|Consulta":
                //    Response.Redirect("~/CuitTreeView.aspx?UN");
                //    break;
                //case "Administración|Puntos de Venta|Alta":
                //    Response.Redirect("~/PuntoVtaCrear.aspx");
                //    break;
                //case "Administración|Puntos de Venta|Baja/Anul.baja":
                //    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Baja");
                //    break;
                //case "Administración|Puntos de Venta|Modificación":
                //    Response.Redirect("~/PuntoVtaSeleccionar.aspx?Modificar");
                //    break;
                //case "Administración|Puntos de Venta|Consulta":
                //    Response.Redirect("~/CuitTreeView.aspx?PuntoVta");
                //    break;
                //case "Administración|Usuario|Cambio de Contraseña":
                //    Response.Redirect("~/UsuarioCambiarPassword.aspx");
                //    break;
                //case "Administración|Usuario|Modificación datos de Configuración":
                //    Response.Redirect("~/ConfiguracionModificar.aspx");
                //    break;

                case "Personas|Alta":
                    Response.Redirect("~/PersonaCrear.aspx");
                    break;
                case "Personas|Baja/Anul.baja":
                    Response.Redirect("~/PersonaSeleccionar.aspx?Baja");
                    break;
                case "Personas|Modificación":
                    Response.Redirect("~/PersonaSeleccionar.aspx?Modificar");
                    break;
                case "Personas|Consulta":
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
                case "Artículos|Listas de Precios|Alta":
                    Response.Redirect("~/ListaPrecioCrear.aspx");
                    break;
                case "Artículos|Listas de Precios|Baja/Anul.baja":
                    Response.Redirect("~/ListaPrecioSeleccionar.aspx?Baja");
                    break;
                case "Artículos|Listas de Precios|Modificación":
                    Response.Redirect("~/ListaPrecioSeleccionar.aspx?Modificar");
                    break;
                case "Artículos|Listas de Precios|Clonado":
                    Response.Redirect("~/ListaPrecioSeleccionar.aspx?Clonar");
                    break;
                case "Artículos|Listas de Precios|Reemplazo":
                    Response.Redirect("~/ListaPrecioSeleccionar.aspx?Reemplazar");
                    break;
                case "Artículos|Listas de Precios|Consulta":
                    Response.Redirect("~/ListaPrecioConsulta.aspx");
                    break;
                case "Artículos|Precios|Ingreso Manual":
                    Response.Redirect("~/PrecioIngresoManual.aspx");
                    break;
                case "Artículos|Precios|Importación desde archivo Excel":
                    Response.Redirect("~/PrecioImportacionExcel.aspx");
                    break;
               case "Contratos|Alta":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("VentaContrato");
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx?ComprobanteATratar=VentaContrato");
                    }
                    break;
                case "Contratos|Baja/Anul.baja":
                    Response.Redirect("~/ExploradorComprobante.aspx?Baja/Anul.baja-Contrato");
                    break;
                case "Contratos|Modificación":
                    Response.Redirect("~/ExploradorComprobante.aspx?Modificacion-Contrato");
                    break;
                case "Contratos|Consulta":
                    Response.Redirect("~/ExploradorComprobante.aspx?Consulta-Contrato");
                    break;
                case "Facturación|Común / RG.2904 / Bono Fiscal / Exportación":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("Venta");
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Facturación|Turismo":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("Venta");
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/LoteCT.aspx");
                    }
                    break;
                case "Facturación|Automática de Contratos/Servicios":
                    Response.Redirect("~/ComprobanteGeneracionAutomatica.aspx");
                    break;
                case "Registro de Facturas|Venta Resguardo":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("VentaTradic");
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Registro de Facturas|Compra":
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("Compra");
                    if (sesion.Usuario.FechaOKeFactTyC == "00000000")
                    {
                        Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Facturacion/Electronica/Lote.aspx");
                    }
                    break;
                case "Comprobantes|Baja/Anul.baja":
                    Response.Redirect("~/ExploradorComprobante.aspx?Baja/Anul.baja-Comprobante");
                    break;
                case "Comprobantes|Modificación":
                    Response.Redirect("~/ExploradorComprobante.aspx?Modificacion-Comprobante");
                    break;
                case "Comprobantes|Envio (AFIP/ITF)":
                    Response.Redirect("~/ExploradorComprobante.aspx?Envio-Comprobante");
                    break;
                case "Comprobantes|Consulta":
                    Response.Redirect("~/ExploradorComprobante.aspx?Consulta-Comprobante");
                    break;
                case "Comprobantes|Consulta PDFs":
                    Response.Redirect("~/ExploradorPDFComprobante.aspx");
                    break;
                case "Comprobantes|Otras Consultas|IVA Ventas":
                    Response.Redirect("~/Facturacion/Electronica/Reportes/IvaVentasFiltros.aspx");
                    break;
                case "Comprobantes|Otras Consultas|IVA Compras":
                    Response.Redirect("~/Facturacion/Electronica/Reportes/IvaComprasFiltros.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Interfaz CITI Ventas/Compras RG.3685":
                    Response.Redirect("~/ExploradorComprobanteRG.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Ventas por Artículo":
                    Response.Redirect("~/Facturacion/Electronica/Reportes/VentasXArticuloFiltros.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Compras por Artículo":
                    Response.Redirect("~/Facturacion/Electronica/Reportes/ComprasXArticuloFiltros.aspx");
                    break;
                case "Comprobantes|Otras Consultas|Stock por Artículo":
                    Response.Redirect("~/Facturacion/Electronica/Reportes/StockXArticuloFiltros.aspx");
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
                case "Comprobantes|Otras Consultas|Términos y condiciones":
                    Response.Redirect("~/Facturacion/Electronica/FacturaElectronicaTYC.aspx");
                    break;
                //case "Administración|Autorizaciones|Explorador de Autorizaciones pendientes":
                //    Response.Redirect("~/ExploradorAutorizacion.aspx");
                //    break;
                //case "Administración|Autorizaciones|Explorador de Autorizaciones (histórico)":
                //    Response.Redirect("~/ExploradorAutorizacionLog.aspx");
                //    break;

                //case "Administración Site|Comprobantes":
                //    Response.Redirect("~/ExploradorComprobanteGlobal.aspx");
                //    break;
                //case "Administración Site|Usuarios":
                //    Response.Redirect("~/ExploradorUsuario.aspx");
                //    break;
                //case "Administración Site|CUITs":
                //    Response.Redirect("~/ExploradorCuit.aspx");
                //    break;
                //case "Administración Site|UNs":
                //    Response.Redirect("~/ExploradorUN.aspx");
                //    break;
                //case "Administración Site|Puntos de Venta":
                //    Response.Redirect("~/ExploradorPuntoVta.aspx");
                //    break;
                //case "Administración Site|Personas":
                //    Response.Redirect("~/ExploradorPersona.aspx");
                //    break;
                //case "Administración Site|Artículos":
                //    Response.Redirect("~/ExploradorArticulo.aspx");
                //    break;
                //case "Administración Site|Permisos":
                //    Response.Redirect("~/ExploradorPermiso.aspx");
                //    break;
                //case "Administración Site|Configuraciones":
                //    Response.Redirect("~/ExploradorConfiguracion.aspx");
                //    break;
                //case "Administración Site|Logs":
                //    Response.Redirect("~/ExploradorLog.aspx");
                //    break;
                //case "Administración Site|Administración":
                //    Response.Redirect("~/ExploradorAdministracion.aspx");
                //    break;
                //case "Administración Site|CVs":
                //    Response.Redirect("~/ExploradorCV.aspx");
                //    break;
                //case "Administración Site|Búsqueda Laboral":
                //    Response.Redirect("~/ExploradorBusquedaLaboral.aspx");
                //    break;

                //case "Ayuda|Manual|¿Cómo empiezo a operar con facturas electrónicas?":
                //    sesion.EstoyEnAyuda = true;
                //    Response.Redirect("~/Ayuda/Instructivas/OperarFacturaElectronica001.aspx");
                //    break;
                //case "Ayuda|Novedades":
                //    Response.Redirect("~/Ayuda/ExploradorNovedad.aspx");
                //    break;
                //case "Ayuda|Documentación técnica":
                //    Response.Redirect("~/default.aspx");
                //    break;
                case "Salir":
                    RN.Sesion.Cerrar(sesion);
                    Response.Redirect("~/factura.aspx");
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
        public string EmailValue = "";

        private bool ValidarDatos()
        {
            bool resp = true;
            Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
            bl.Email = Request.Form["EmailBL"];
            bl.BusquedaPerfil.IdBusquedaPerfil = IdBusquedaPerfilDropDownList.SelectedValue;
            if (bl.Email.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar su Email"), false);
                return false;
            }
            if (!RN.Funciones.IsValidEmail(bl.Email))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato de Email inválido"), false);
                return false;
            }
            if (bl.BusquedaPerfil.IdBusquedaPerfil.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar su Perfil"), false);
                return false;
            }
            return resp;
        }
        protected void ButtonEnviarEmailBL_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            //Armo email para enviar al contacto.
            Entidades.ContactoSite contacto = new Entidades.ContactoSite();
            contacto.Nombre = "Sr/Sra.";
            contacto.Email = Request.Form["EmailBL"];
            contacto.Mensaje = "Busquedas Laborales";
            contacto.Motivo = "Otro";
            EmailValue = Request.Form["EmailBL"];
            try
            {
                if (ValidarDatos())
                {
                    Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
                    bl.Email = Request.Form["EmailBL"];
                    bl.BusquedaPerfil.IdBusquedaPerfil = IdBusquedaPerfilDropDownList.SelectedValue;
                    bl.Suscribe = true;
                    Entidades.BusquedaLaboral blAux = new Entidades.BusquedaLaboral();
                    blAux.Email = bl.Email;
                    try
                    {
                        RN.BusquedaLaboral.Leer(blAux, sesion);
                    }
                    catch (EX.Validaciones.ElementoInexistente)
                    {
                    }
                    if (blAux.BusquedaPerfil.IdBusquedaPerfil == null)
                    {
                        bl.Estado = "Vigente";
                        RN.BusquedaLaboral.Crear(bl, sesion);
                    }
                    else
                    {
                        RN.BusquedaLaboral.ModificarCV(blAux, bl, sesion);
                    }
                    RN.ContactoSite.Registrar(contacto);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Email enviado satisfactoriamente');", true);
                    IdBusquedaPerfilDropDownList.SelectedValue = "";
                    EmailValue = "";
                }
            }
            catch (Exception ex)
            {
                string MensajeLabel = EX.Funciones.Detalle(ex);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.ToString().Replace("'", "") + "');", true);
            }
        }
    }
}