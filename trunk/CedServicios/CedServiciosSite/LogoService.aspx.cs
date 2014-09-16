using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class LogoService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?idlogo=", String.Empty);
                Img1.Src = "ImagenesSubidas/" + a + ".gif";
            }
        }
    }
}