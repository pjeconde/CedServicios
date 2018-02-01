using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InicioTYC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ContentPlaceHolder contentPlaceDefault = ((ContentPlaceHolder)Master.FindControl("ContentPlaceDefault"));
            //LinkButton verLinkButton = ((LinkButton)contentPlaceDefault.FindControl("Link1"));
            //LinkButton verLinkButton = ((LinkButton)Master.FindControl("Link1"));
            string panel = Page.Request.QueryString["Valor"];
            pan1.Visible = false;
            pan2.Visible = false;
            if (panel == "pan1")
            {
                pan1.Visible = true;
            }
            else if (panel == "pan2")
            {
                pan2.Visible = true;
            }
         }
    }
}