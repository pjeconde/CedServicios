﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public partial class ComprasXArticuloWebForm : System.Web.UI.Page
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

                string lcomp = Server.MapPath("~/Facturacion/Electronica/Reportes/Compras_XArticulo.xsd");
                System.IO.File.Copy(lcomp, @System.IO.Path.GetTempPath() + "Compras_XArticulo.xsd", true);

                oRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                bool HayME = false;
                string reportPath = "";
                if (Session["monedasExtranjeras"] != null)
                {
                    HayME = (bool)Session["monedasExtranjeras"];
                }
                if (!HayME)
                {
                    reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/ComprasXArticulo.rpt");
                }
                else
                {
                    reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/ComprasXArticuloME.rpt");
                }
                oRpt.Load(reportPath);
                Entidades.ComprasXArticulo comprasXArticulo = new Entidades.ComprasXArticulo();
                if (Session["comprasXArticulo"] != null)
                {
                    comprasXArticulo = (Entidades.ComprasXArticulo)Session["comprasXArticulo"];
                    DataSet ds = new DataSet();
                    XmlSerializer objXS = new XmlSerializer(comprasXArticulo.GetType());
                    StringWriter objSW = new StringWriter();
                    objXS.Serialize(objSW, comprasXArticulo);
                    StringReader objSR = new StringReader(objSW.ToString());
                    ds.ReadXml(objSR);
                    oRpt.SetDataSource(ds);
                }
                else
                {
                    Response.Redirect("~/Facturacion/Electronica/Reportes/ComprasXArticuloFiltros.aspx", true);
                }
                string formatoRptExportar = "";
                if (Session["formatoRptExportar"] != null)
                {
                    formatoRptExportar = (string)Session["formatoRptExportar"];
                }
                if (Session["mostrarFechaYHora"] != null)
                {
                    if ((bool)Session["mostrarFechaYHora"] == false)
                    {
                        oRpt.DataDefinition.FormulaFields["MostrarFechaYHora"].Text = "'N'";
                    }
                }
                if (Session["mostrarDetalleComprobantes"] != null)
                {
                    if ((bool)Session["mostrarDetalleComprobantes"] == false)
                    {
                        oRpt.DataDefinition.FormulaFields["MostrarDetalleComprobantes"].Text = "'N'";
                    }
                }
                oRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                oRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                //oRpt.DataDefinition.FormulaFields["RazSoc"].Text = "'" + ((Entidades.Sesion)Session["Sesion"]).Cuit.RazonSocial + "'";
                if (formatoRptExportar == "")
                {
                    CrystalReportViewer1.GroupTreeStyle.ShowLines = false;
                    CrystalReportViewer1.HasToggleGroupTreeButton = false;
                    CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
                    CrystalReportViewer1.ReportSource = oRpt;
                    CrystalReportViewer1.HasPrintButton = true;
                }
                else
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(comprasXArticulo.Cuit);
                    sb.Append("-");
                    sb.Append(Convert.ToDateTime(comprasXArticulo.PeriodoDsd).ToString("yyyyMMdd"));
                    sb.Append("-");
                    sb.Append(Convert.ToDateTime(comprasXArticulo.PeriodoHst).ToString("yyyyMMdd"));

                    if (formatoRptExportar == "PDF")
                    {
                        CrystalDecisions.Shared.ExportOptions exportOpts = new CrystalDecisions.Shared.ExportOptions();
                        CrystalDecisions.Shared.PdfRtfWordFormatOptions pdfOpts = CrystalDecisions.Shared.ExportOptions.CreatePdfRtfWordFormatOptions();
                        exportOpts.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                        exportOpts.ExportFormatOptions = pdfOpts;
                        oRpt.ExportToHttpResponse(exportOpts, Response, true, sb.ToString());
                    }
                    if (formatoRptExportar == "Excel")
                    {
                        CrystalDecisions.Shared.ExportOptions exportOpts = new CrystalDecisions.Shared.ExportOptions();
                        CrystalDecisions.Shared.ExcelFormatOptions pdfOpts = CrystalDecisions.Shared.ExportOptions.CreateExcelFormatOptions();
                        exportOpts.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                        exportOpts.ExportFormatOptions = pdfOpts;
                        oRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, Server.MapPath("~/TempExcel/") + sb.ToString() + ".xls");
                        
                        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                        response.ClearContent();
                        response.Clear();
                        response.ContentType = "application/vnd.ms-excel";
                        response.AddHeader("Content-Disposition", "attachment; filename=" + sb.ToString() + ".xls" + ";");
                        response.TransmitFile(Server.MapPath("~/TempExcel/" + sb.ToString() + ".xls"));
                        response.Flush();
                        response.End();  
                    }
                }
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