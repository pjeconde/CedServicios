using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class FacturaElectronicaTYC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CheckBoxAceptarTYC.Checked)
                {
                    if (Page.Request.QueryString.ToString() == "Link=VerTYC")
                    {
                        //PanelAceptaTYC.Visible = false;
                    }
                    else
                    {
                        if (Page.Request.UrlReferrer.LocalPath.ToString() == "/CedWeb/FacturaElectronica.aspx" || Page.Request.UrlReferrer.LocalPath.ToString() == "/Cedeira/FacturaElectronica.aspx")
                        {
                            Response.Redirect("~/Facturacion/Electronica/Lote.aspx", true);
                        }
                    }
                }
            }
        }
        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            if (CheckBoxAceptarTYC.Checked)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    RN.Usuario.RegistrarAceptacioneFactTyC(sesion);
                    sesion.Usuario.FechaOKeFactTyC = DateTime.Now.ToString("yyyyMMdd");
				    Response.Redirect("~/Facturacion/Electronica/Lote.aspx", true);
                }
            }
            else
            {
                MensajeLabel.Text = "Debe marcar que acepta los términos y condiciones";
            }
        }
    }
}
