using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace CedServicios.Site.Facturacion.Electronica
{
    public partial class FacturaElectronicaFecha : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Globalization.CultureInfo culture;
            //culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
            //culture.NumberFormat.CurrencySymbol = string.Empty;
            //culture.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
            //System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            //Page.Culture = cultureString;
            //Page.UICulture = cultureString;

            //CultureInfo oldCulture = Thread.CurrentThread.CurrentCulture;
            //CultureInfo oldUICulture = Thread.CurrentThread.CurrentUICulture;
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"]);
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"]);
            ////try
            ////{
            ////    Controls.Add(LoadControl("FacturaElectronicaFecha.ascx"));
            ////}
            ////finally
            ////{
            ////    Thread.CurrentThread.CurrentCulture = oldCulture;
            ////    Thread.CurrentThread.CurrentUICulture = oldUICulture;
            ////}
        }
    }
}