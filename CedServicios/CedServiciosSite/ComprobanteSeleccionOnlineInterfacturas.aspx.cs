using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace CedServicios.Site
{
    public partial class ComprobanteSeleccionOnlineInterfacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                System.Collections.Generic.List<Entidades.PuntoVta> listaPuntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta;
                System.Collections.Generic.List<Entidades.PuntoVta> puntoVtalist = new System.Collections.Generic.List<Entidades.PuntoVta>();
                Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                puntoVta.Nro = 0;
                puntoVtalist.Add(puntoVta);
                if (listaPuntoVta != null)
                {
                    puntoVtalist.AddRange(listaPuntoVta);
                }
                PtoVtaConsultaDropDownList.DataValueField = "Nro";
                PtoVtaConsultaDropDownList.DataTextField = "DescrCombo";
                PtoVtaConsultaDropDownList.DataSource = puntoVtalist;
                PtoVtaConsultaDropDownList.DataBind();
                DataBind();
                CuitConsultaTextBox.Text = ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro;
            }
        }
        protected void ConsultarLoteIBKButton_Click(object sender, EventArgs e)
        {
            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
            {
                MensajeLabel.Text = "Su sesión ha caducado por inactividad. Por favor vuelva a loguearse";
            }
            else
            {
                try
                {
                    string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }
                    if (CuitConsultaTextBox.Text.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el CUIT del vendedor";
                        return;
                    }
                    if (NroLoteConsultaTextBox.Text.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el nro de lote";
                        return;
                    }
                    if (PtoVtaConsultaDropDownList.SelectedValue.Equals("0") || PtoVtaConsultaDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Falta ingresar el punto de venta";
                        return;
                    }
                    GrabarLogTexto("~/Consultar.txt", "Consulta de Lote CUIT: " + CuitConsultaTextBox.Text + "  Nro.Lote: " + NroLoteConsultaTextBox.Text + "  Nro. Punto de Vta.: " + PtoVtaConsultaDropDownList.SelectedValue);
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
                    clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(CuitConsultaTextBox.Text), Convert.ToInt64(NroLoteConsultaTextBox.Text), Convert.ToInt32(PtoVtaConsultaDropDownList.SelectedValue), certificado);
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
                catch (System.Security.Cryptography.CryptographicException ex)
                {
                    using (FileStream fs = File.Open(Server.MapPath("~/ConsultarErrores.txt"), FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("Consulta de:" + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro.ToString());
                            sw.WriteLine(ex.Message);
                            sw.WriteLine(ex.StackTrace);
                            if (ex.InnerException != null)
                            {
                                sw.WriteLine(ex.InnerException.Message);
                            }
                        }
                    }
                    MensajeLabel.Text = ex.Message.Replace("\r", "").Replace("\n", "");
                }
                catch (Exception ex)
                {
                    string errormsg = ex.Message.Replace("\n", "");
                    if (ex.InnerException != null)
                    {
                        try
                        {
                            errormsg = errormsg + " " + ((System.Net.Sockets.SocketException)ex.InnerException).ErrorCode;
                        }
                        catch
                        {
                        }
                        errormsg = errormsg + " " + ex.InnerException.Message.Replace("\n", "");

                    }
                    errormsg = errormsg.Replace("'", "").Replace("\r", " ");
                    MensajeLabel.Text = "Problemas al consultar a Interfacturas.\\n " + errormsg;
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
    }
}