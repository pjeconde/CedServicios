using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ModalPopupExtender1.Show();
        }

        protected void SalirButton_Click(object sender, EventArgs e)
        {
            //ModalPopupExtender1.Hide();
        }
        protected void MultiCuitLinkButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            RN.Migracion.CopiarCuenta("fcedeira", sesion);
        }
    }
}