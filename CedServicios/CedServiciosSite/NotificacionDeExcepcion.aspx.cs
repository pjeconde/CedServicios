using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CedServicios.WebForms;

namespace CedServicios.Site
{
    public partial class NotificacionDeExcepcion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UrlParameterPasser urlWrapper = new UrlParameterPasser();
                string exString = urlWrapper["ex"];
                Exception ex = new Exception(exString);
                EX.ExceptionManager.Publish(ex);
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
            catch
            {
                string auxEx = "Excepción tratando de mostrar o publicar la excepción original";
                EX.ExceptionManager.Publish(new Exception(auxEx));
                MensajeLabel.Text = auxEx;
            }
        }
    }
}