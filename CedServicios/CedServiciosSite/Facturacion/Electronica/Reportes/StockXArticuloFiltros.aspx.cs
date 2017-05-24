using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

namespace CedServicios.Site.Facturacion.Electronica.Reportes
{
    public partial class StockXArticuloFiltros : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FechaDesdeTextBox.Text = DateTime.Now.ToString("yyyyMM01");
                FechaHastaTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
                FormatosRptExportarDropDownList.DataValueField = "Codigo";
                FormatosRptExportarDropDownList.DataTextField = "Descr";
                FormatosRptExportarDropDownList.DataSource = Entidades.FormatosRptExportar.FormatoRptExportar.Lista();
                FormatosRptExportarDropDownList.DataBind();
                DataBind();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                try
                {
                    MensajeLabel.Text = "";
                    bool monedasExtranjeras = false;
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    List<Entidades.StockXArticuloDetalle> listaS = new List<Entidades.StockXArticuloDetalle>();

                    listaS = RN.Comprobante.ListaStock(FechaHastaTextBox.Text, sesion);

                    Entidades.StockXArticulo stock = new Entidades.StockXArticulo();

                    stock.Cuit = sesion.Cuit.Nro;
                    stock.RazSoc = sesion.Cuit.RazonSocial;
                    //stock.PeriodoDsd = FechaDesdeTextBox.Text.Substring(6, 2) + "/" + FechaDesdeTextBox.Text.Substring(4, 2) + "/" + FechaDesdeTextBox.Text.Substring(0, 4);
                    stock.PeriodoHst = FechaHastaTextBox.Text.Substring(6, 2) + "/" + FechaHastaTextBox.Text.Substring(4, 2) + "/" + FechaHastaTextBox.Text.Substring(0, 4);

                    stock.StockXArticuloDetalle = listaS;
                    
                    Session["formatoRptExportar"] = FormatosRptExportarDropDownList.SelectedValue;
                    Session["mostrarFechaYHora"] = FechaYHoraCheckBox.Checked;
                    Session["mostrarDetalleComprobantes"] = DetalleComprobanteCheckBox.Checked;
                    Session["monedasExtranjeras"] = monedasExtranjeras;
                    if (stock.StockXArticuloDetalle.Count != 0)
                    {
                        Session["stockXArticulo"] = stock;
                        Response.Redirect("~/Facturacion/Electronica/Reportes/StockXArticuloWebForm.aspx", true);
                    }
                    else
                    {
                        MensajeLabel.Text = "No hay información.";
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