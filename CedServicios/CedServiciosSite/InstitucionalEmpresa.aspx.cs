using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InstitucionalEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SolucionesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalSoluciones.aspx");
        }
        protected void RefeComButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalRefeCom.aspx");
        }
        protected void ContactoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalContacto.aspx");
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}