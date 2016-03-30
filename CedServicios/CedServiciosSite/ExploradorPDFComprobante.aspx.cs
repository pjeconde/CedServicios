using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Net;

namespace CedServicios.Site
{
    public partial class ExploradorPDFComprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    FechaDesdeTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    BuscarButton_Click(BuscarButton, EventArgs.Empty);
                }
            }
        }
        protected void PDFsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MensajeLabel.Text = string.Empty;
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.PDF> lista = (List<Entidades.PDF>)ViewState["PDFs"];
            Entidades.PDF pDF = lista[item];
            if (e.CommandName == "Descargar")
            {
                string script = "window.open('DescargaTemporarios.aspx?archivo=" + pDF.NombreArchivo + "&path=~/PDFs/', '');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            }
        }
        private bool ValidacionFiltrosOK()
        {
            MensajeLabel.Text = string.Empty;
            if (!RN.Funciones.ValidarFechaYYYYMMDD(FechaDesdeTextBox.Text))
            {
                MensajeLabel.Text = "Fecha Desde inválida. Formato correcto de 8 dígitos (YYYYMMDD).";
                return false;
            }
            if (!RN.Funciones.ValidarFechaYYYYMMDD(FechaHastaTextBox.Text))
            {
                MensajeLabel.Text = "Fecha Hasta inválida. Formato correcto de 8 dígitos (YYYYMMDD).";
                return false;
            }
            return true;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if ( ValidacionFiltrosOK()) 
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    String path = Master.Server.MapPath("~/PDFs/");
                    string[] archivos = System.IO.Directory.GetFiles(path, sesion.Cuit.Nro + "*.pdf", System.IO.SearchOption.TopDirectoryOnly);
                    List<Entidades.PDF> pDFs = new List<Entidades.PDF>();
                    for (int i = 0; i < archivos.Length; i++)
                    {
                        DateTime fechaCreacion = System.IO.Directory.GetCreationTime(archivos[i]);
                        if (Convert.ToInt32(fechaCreacion.ToString("yyyyMMdd")) >= Convert.ToInt32(FechaDesdeTextBox.Text) && Convert.ToInt32(fechaCreacion.ToString("yyyyMMdd")) <= Convert.ToInt32(FechaHastaTextBox.Text))
                        {
                            char[] separadorArchivo = { '\\' };
                            string[] nombreArchivo = archivos[i].Split(separadorArchivo);
                            pDFs.Add(new Entidades.PDF(archivos[i], DescrPDF(archivos[i].Replace(path, string.Empty).Replace(".pdf", string.Empty).Replace(".PDF", string.Empty)), fechaCreacion.ToString("dd/MM/yyyy"), nombreArchivo[nombreArchivo.Length - 1]));
                        }
                    }
                    ViewState["PDFs"] = pDFs;
                    PDFsGridView.DataSource = pDFs;
                    PDFsGridView.DataBind();
                }
            }
        }
        private string DescrPDF(string NombreArchivo)
        {
            char[] separador = { '-' };
            string[] a = NombreArchivo.Split(separador);
            FeaEntidades.TiposDeComprobantes.TipoComprobante tipoComprobante = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIP().Find(delegate(FeaEntidades.TiposDeComprobantes.TipoComprobante d) { return Convert.ToInt16(a[2]).ToString() == d.Codigo.ToString(); });
            string b = string.Empty;
            if (tipoComprobante != null)
            {
                b = tipoComprobante.Descr.Replace("s ", " ");
            }
            else
            {
                b = "Comprobante desconocido";
            }

            b += " Nº " + a[1] + "-" + a[3];
            return b;
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void DescargarTodosButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = string.Empty;
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            List<Entidades.PDF> lista = (List<Entidades.PDF>)ViewState["PDFs"];
            if (lista.Count == 0)
            {
                MensajeLabel.Text = "No hay archivos PDFs para agregar al ZIP que intenta descargar.";
            }
            else
            {
                ZipFile zip = new ZipFile();
                for (int i = 0; i < lista.Count; i++)
                {
                    zip.AddFile(lista[i].Path, "");
                }
                string nombreZip = sesion.Cuit.Nro + "-" + "PDFs del " + FechaDesdeTextBox.Text + " al " + FechaHastaTextBox.Text + ".zip";
                string pathZip = @"~/Temp/";
                zip.Save(Server.MapPath(pathZip + nombreZip));
                string script = "window.open('DescargaTemporarios.aspx?archivo=" + nombreZip + "&path=" + pathZip + "', '');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            }
        }
    }
}
