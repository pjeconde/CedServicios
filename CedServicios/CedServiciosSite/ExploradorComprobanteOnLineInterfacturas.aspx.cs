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
                    ViewState["Personas"] = RN.Persona.ListaPorCuit(false, true, Entidades.Enum.TipoPersona.Cliente, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Persona>)ViewState["Personas"];
                    DataBind();
                    ClienteDropDownList.SelectedValue = "0";
                }
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ConsultaOnLine")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> lista = (List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>)ViewState["Comprobantes"];
                FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado elem = lista[item];
                try
                {
                    string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Lote CUIT: " + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "  Nro.Lote: " + elem.id_lote + "  Nro. Punto de Vta.: " + elem.punto_de_venta);
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
                    clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro), elem.id_lote, elem.punto_de_venta, certificado);
                    //Entidades.Comprobante comprobante = new Entidades.Comprobante();
                    Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar(Entidades.Enum.TratamientoComprobante.ConsultaITF, clcrdyndns);
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
                Entidades.Persona persona = ((List<Entidades.Persona>)ViewState["Personas"])[ClienteDropDownList.SelectedIndex];
                org.dyndns.cedweb.listado.cecl cecl = new org.dyndns.cedweb.listado.cecl();
                cecl.cuit_canal = Convert.ToInt64("30690783521");
                cecl.cuit_vendedor = Convert.ToInt64(sesion.Cuit.Nro);
                cecl.fecha_emision_desde = FechaDesdeTextBox.Text;
                cecl.fecha_emision_hasta = FechaHastaTextBox.Text;
                if (persona.DocumentoIdTipoDoc != null && persona.DocumentoIdTipoDoc != "")
                {
                    cecl.tipo_doc_comprador = Convert.ToInt32(persona.DocumentoIdTipoDoc);
                    cecl.tipo_doc_compradorSpecified = true;
                    cecl.doc_comprador = Convert.ToInt64(persona.Documento.Nro);
                    cecl.doc_compradorSpecified = true;
                }
                else
                {
                    cecl.tipo_doc_compradorSpecified = false;
                    cecl.doc_compradorSpecified = false;
                }
                cecl.limite = "SCHEMA";

                string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                if (NroCertif.Equals(string.Empty))
                {
                    MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                    return;
                }
                GrabarLogTexto("~/Listar.txt", "Consulta de Lote CUIT: " + sesion.Cuit.Nro + "  Fecha Desde: " + FechaDesdeTextBox.Text + "  Fecha Hasta: " + FechaHastaTextBox.Text);
                GrabarLogTexto("~/Listar.txt", "NroSerieCertifITF: " + NroCertif);
                if (NroCertif.Equals(string.Empty))
                {
                    MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                    return;
                }

                string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                org.dyndns.cedweb.listado.ListadoIBK clcdyndns = new org.dyndns.cedweb.listado.ListadoIBK();
                string ListadoIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ListadoIBKUtilizarServidorExterno"];
                GrabarLogTexto("~/Listar.txt", "Parametro ListadoIBKUtilizarServidorExterno: " + ListadoIBKUtilizarServidorExterno);
                if (ListadoIBKUtilizarServidorExterno == "SI")
                {
                    clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["ListadoIBKurl"];
                    GrabarLogTexto("~/Listar.txt", "Parametro ListadoIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ListadoIBKurl"]);
                }
                string resp = "";
                try
                {
                    resp = clcdyndns.ListarIBK(cecl, certificado);
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = ex.Message;
                }
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
                    if (MensajeLabel.Text != "")
                    {
                        MensajeLabel.Text += "<br />";
                    }
                    MensajeLabel.Text += "No se han encontrado Comprobantes que satisfagan la busqueda";
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
    }
}