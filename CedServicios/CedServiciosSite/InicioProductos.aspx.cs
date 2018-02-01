using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InicioProductos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string panel = Page.Request.QueryString["Valor"];
            panCedST.Visible = false;
            panCedFCI.Visible = false;
            panCedSTfooter.Visible = false;
            panCedFCIfooter.Visible = false;
            panCedCCT.Visible = false;
            panCedAPC.Visible = false;
            if (panel == "panCedST")
            {
                panCedST.Visible = true;
                panCedSTfooter.Visible = true;
            }
            else if (panel == "panCedFCI")
            {
                panCedFCI.Visible = true;
                panCedFCIfooter.Visible = true;
            }
            else if (panel == "panCedCCT")
            {
                panCedCCT.Visible = true;
            }
            else if (panel == "panCedAPC")
            {
                panCedAPC.Visible = true;
            }
        }
    }
}