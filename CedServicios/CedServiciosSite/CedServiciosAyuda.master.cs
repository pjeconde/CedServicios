using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CedServiciosAyuda : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (((Entidades.Sesion)Session["Sesion"]).EstoyEnAyuda)
                {
                    NoMostrarAyudaComoPaginaDefaultCheckBox.Visible = false;
                }
            }
        }
        protected void NoMostrarAyudaComoPaginaDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (sesion.UsuarioDemo == true)
            {
                Response.Redirect("~/MensajeUsuarioDEMO.aspx?ConfiguracionModificar");
            }
            RN.Usuario.SetearMostrarAyudaComoPaginaDefault((Entidades.Sesion)Session["Sesion"], !NoMostrarAyudaComoPaginaDefaultCheckBox.Checked);
            if (!((Entidades.Sesion)Session["Sesion"]).Usuario.MostrarAyudaComoPaginaDefault)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}