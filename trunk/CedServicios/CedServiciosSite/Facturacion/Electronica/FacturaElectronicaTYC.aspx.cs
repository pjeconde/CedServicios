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
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    if (sesion.Usuario.FechaOKeFactTyC != "00000000")
                    {
                        CheckBoxAceptarTYC.Visible = false;
                        ButtonAceptar.Visible = false;
                        ButtonRechazar.Text = "Salir";
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
        protected void ButtonRechazar_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}
