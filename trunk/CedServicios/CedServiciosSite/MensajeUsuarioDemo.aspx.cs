using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class MensajeUsuarioDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BotonContinuar.Visible = false;
                    BotonContinuarBack.Visible = true;
                    string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                    switch (a)
                    {
                        case "Alta":
                            //MensajeLabel.Text = "";
                            break;
                        case "ConfiguracionModificar":
                            BotonContinuar.Visible = true;
                            BotonContinuarBack.Visible = false;
                            break;
                        case "Baja":
                            //MensajeLabel.Text = "";
                            break;
                    }
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }

        protected void BotonContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}