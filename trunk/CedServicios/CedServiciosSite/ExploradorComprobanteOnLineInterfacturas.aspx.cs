using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;
using System.IO;

namespace CedServicios.Site
{
    public partial class ExploradorComprobanteOnLineInterfacturas : System.Web.UI.Page
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
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    if (sesion.UsuarioDemo == true)
                    {
                        FechaDesdeTextBox.Text = "20130101";
                        FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    }
                    else
                    {
                        FechaDesdeTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                        FechaHastaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    }
                    ViewState["Clientes"] = RN.Cliente.ListaPorCuit(false, true, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Cliente>)ViewState["Clientes"];
                    DataBind();
                    ClienteDropDownList.SelectedValue = "0";
                }
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                //int item = Convert.ToInt32(e.CommandArgument);
                //List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                //Entidades.Comprobante comprobante = lista[item];
                //FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                //byte[] bytes = new byte[comprobante.Request.Length * sizeof(char)];
                //System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                //ms.Seek(0, System.IO.SeekOrigin.Begin);
                //lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                //Cache["ComprobanteAConsultar"] = lote;
                //string script = "window.open('/ComprobanteConsulta.aspx', '');";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            }
            else if (e.CommandName == "ConsultaOnLine")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> lista = (List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>)ViewState["Comprobantes"];
                FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado comprobante = lista[item];
                try
                {
                    string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Lote CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "  Nro.Lote: " + comprobante.id_lote + "  Nro. Punto de Vta.: " + comprobante.punto_de_venta);
                    GrabarLogTexto("~/Consultar.txt", "NroSerieCertifITF: " + NroCertif);
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }

                    string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    org.dyndns.cedweb.consulta.ConsultaIBK clcdyndns = new org.dyndns.cedweb.consulta.ConsultaIBK();
                    string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                    GrabarLogTexto("~/Consultar.txt", "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                    if (ConsultaIBKUtilizarServidorExterno == "SI")
                    {
                        clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                        GrabarLogTexto("~/Consultar.txt", "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                    }
                    org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                    clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro), comprobante.id_lote, comprobante.punto_de_venta, certificado);
                    Cache["ComprobanteAConsultar"] = clcrdyndns;
                    string script = "window.open('/ComprobanteConsulta.aspx', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                }
                catch (System.Web.Services.Protocols.SoapException soapEx)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(soapEx.Detail.OuterXml);
                        XmlNamespaceManager nsManager = new
                            XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("errorNS",
                            "http://www.cedeira.com.ar/webservices");
                        XmlNode Node =
                            doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
                        string errorNumber =
                            Node.SelectSingleNode("errorNS:ErrorNumber",
                            nsManager).InnerText;
                        string errorMessage =
                            Node.SelectSingleNode("errorNS:ErrorMessage",
                            nsManager).InnerText;
                        string errorSource =
                            Node.SelectSingleNode("errorNS:ErrorSource",
                            nsManager).InnerText;
                        MensajeLabel.Text = soapEx.Actor + " : " + errorMessage.Replace("\r", "").Replace("\n", "");
                    }
                    catch (Exception)
                    {
                        throw soapEx;
                    }
                }
            }
        }
        private void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text != "PR")
                {
                    e.Row.ForeColor = Color.Red;
                }
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
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> lista = new List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();
                MensajeLabel.Text = String.Empty;
                Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                string resp = RN.Comprobante.ComprobantesListadoIBK(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, cliente.DocumentoIdTipoDoc, cliente.DocumentoNro, ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF);
                try
                {
                    //Deserializar
                    FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response lr = new FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response();
                    string xml = resp;
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response));
                    using (TextReader reader = new StringReader(xml))
                    {
                        lr = (FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response)serializer.Deserialize(reader);
                    }
                    if (lr.emisor_comprobante_response != null && lr.emisor_comprobante_response.emisor_comprobante_listado != null && lr.emisor_comprobante_response.emisor_comprobante_listado.Length != 0)
                    {
                        lista = lr.emisor_comprobante_response.emisor_comprobante_listado.ToList<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();
                    }
                }
                catch
                {
                }
                if (lista.Count == 0)
                {
                    ComprobantesGridView.DataSource = null;
                    ComprobantesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Comprobantes que satisfagan la busqueda";
                }
                else
                {
                    ComprobantesGridView.DataSource = lista;
                    ViewState["Comprobantes"] = lista;
                    ComprobantesGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}