using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CedServicios.WebForms;

namespace CedServicios.Site.Excepciones
{
    public partial class Excepciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UrlParameterPasser urlWrapper = new UrlParameterPasser();
                string exString = urlWrapper["ex"];
                Exception ex = new Exception(exString);
                EX.ExceptionManager.Publish(ex);
                ExLabel.Text = WebForms.Excepciones.Detalle(ex);
            }
            catch
            {
                string auxEx = "Excepción tratando de mostrar o publicar la excepción original";
                EX.ExceptionManager.Publish(new Exception(auxEx));
                ExLabel.Text = auxEx;
            }
        }
    }
}