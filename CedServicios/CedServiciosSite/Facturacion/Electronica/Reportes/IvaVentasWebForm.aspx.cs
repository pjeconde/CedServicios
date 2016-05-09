using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System;
using System.IO;
using System.Xml.Serialization;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public partial class IvaVentasWebForm : System.Web.UI.Page
    {
        private CrystalDecisions.CrystalReports.Engine.ReportDocument oRpt;

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (oRpt != null)
            {
                oRpt.Dispose();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                culture.NumberFormat.CurrencySymbol = string.Empty;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                base.InitializeCulture();
                
                string lcomp = Server.MapPath("~/Facturacion/Electronica/Reportes/Iva_Ventas.xsd");
                System.IO.File.Copy(lcomp, @System.IO.Path.GetTempPath() + "Iva_Ventas.xsd", true);

                oRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                string reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/IvaVentasCR.rpt");
                oRpt.Load(reportPath);
                if (Session["ivaVentas"] != null)
                {
                    Entidades.IvaVentas ivaVentas = (Entidades.IvaVentas)Session["ivaVentas"];
                    DataSet ds = new DataSet();
                    XmlSerializer objXS = new XmlSerializer(ivaVentas.GetType());
                    StringWriter objSW = new StringWriter();
                    objXS.Serialize(objSW, ivaVentas);
                    StringReader objSR = new StringReader(objSW.ToString());
                    ds.ReadXml(objSR);
                    oRpt.SetDataSource(ds);
                }
                else
                {
                    Response.Redirect("~/Facturacion/Electronica/Reportes/IvaVentasFiltros.aspx", true);
                }
                oRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                oRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                oRpt.DataDefinition.FormulaFields["RazSoc"].Text = "'" + ((Entidades.Sesion)Session["Sesion"]).Cuit.RazonSocial + "'"; 
                CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                CrystalReportViewer1.ReportSource = oRpt;
                CrystalReportViewer1.HasPrintButton = true;
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                WebForms.Excepciones.Redireccionar(ex, "~/NotificacionDeExcepcion.aspx");
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
            }
        }
    }
}