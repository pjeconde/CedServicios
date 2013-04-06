using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InstitucionalSolucionesCedFCI : System.Web.UI.Page
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
        protected void EmpresaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalEmpresa.aspx");
        }
        protected void ContactoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalContacto.aspx");
        }
    }
}