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

namespace CedServicios.Site
{
    public partial class ExploradorComprobante : System.Web.UI.Page
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
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];
                FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                byte[] bytes;
                System.IO.MemoryStream ms;
                try
                {
                    comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                    bytes = new byte[comprobante.Response.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                }
                catch 
                {
                    bytes = new byte[comprobante.Request.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                }
                Cache["ComprobanteAConsultar"] = lote;
                string script = "window.open('/ComprobanteConsulta.aspx', '');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
            }
            else if (e.CommandName == "ConsultarOnLine")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];
                try
                {
                    string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Consulta de Lote CUIT: " + comprobante.Cuit + "  Nro.Lote: " + comprobante.NroLote + "  Nro. Punto de Vta.: " + comprobante.NroPuntoVta);
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "NroSerieCertifITF: " + NroCertif);
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }

                    string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    org.dyndns.cedweb.consulta.ConsultaIBK clcdyndns = new org.dyndns.cedweb.consulta.ConsultaIBK();
                    string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                    if (ConsultaIBKUtilizarServidorExterno == "SI")
                    {
                        clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                    }
                    org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                    clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(comprobante.Cuit), comprobante.NroLote, comprobante.NroPuntoVta, certificado);
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
            else if (e.CommandName == "ActualizarOnLine")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];
                try
                {
                    if (comprobante.Estado == "Vigente")
                    {
                        MensajeLabel.Text = "El comprobante ya está vigente. No es posible actualizar su estado.";
                        return;
                    }
                    string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Consulta de Lote CUIT: " + comprobante.Cuit + "  Nro.Lote: " + comprobante.NroLote + "  Nro. Punto de Vta.: " + comprobante.NroPuntoVta);
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "NroSerieCertifITF: " + NroCertif);
                    if (NroCertif.Equals(string.Empty))
                    {
                        MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                        return;
                    }

                    string certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                    org.dyndns.cedweb.consulta.ConsultaIBK clcdyndns = new org.dyndns.cedweb.consulta.ConsultaIBK();
                    string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                    if (ConsultaIBKUtilizarServidorExterno == "SI")
                    {
                        clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                    }
                    org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                    clcrdyndns = clcdyndns.Consultar(Convert.ToInt64(comprobante.Cuit), comprobante.NroLote, comprobante.NroPuntoVta, certificado);
                    FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lc = Ws2Fea(clcrdyndns);
                    Cache["ComprobanteAConsultar"] = lc;
                    string XML = "";
                    RN.Comprobante.SerializarLc(out XML, lc);
                    comprobante.Response = XML;
                    if (lc.cabecera_lote.resultado == "A")
                    {
                        //Controlar que sea el mismo comprobante (local vs on-line)
                        if (comprobante.Nro != lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante)
                        {
                            MensajeLabel.Text = "(Campo: Nro. de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                            return;
                        }
                        if (comprobante.TipoComprobante.Id != lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)
                        {
                            MensajeLabel.Text = "(Campo: Tipo de Comprobante). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                            return;
                        }
                        if (comprobante.Importe != lc.comprobante[0].resumen.importe_total_factura)
                        {
                            MensajeLabel.Text = "(Campo: Importe Total). Hay diferencias entre en comprobante local y el registrado en Interfacturas / AFIP. No se puede actualizar el estado.";
                            return;
                        }
                        comprobante.WF.Estado = "Vigente";
                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                        string script = "window.open('/ComprobanteConsulta.aspx', '');";
                        BuscarButton_Click(sender, new EventArgs());
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    }
                    else if (lc.cabecera_lote.resultado == "R")
                    {
                        comprobante.WF.Estado = "Rechazado";
                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                        string script = "<SCRIPT LANGUAGE='javascript'>alert('Respuesta de ITF / AFIP.\\n" + "Resultado: " + lc.cabecera_lote.resultado + "  Motivo: " + lc.cabecera_lote.motivo + "');</script>";
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", script, true);
                    }
                    else
                    {
                        MensajeLabel.Text = "No se puede realizar la actualización, cuando el comprobante se encuentra en el siguiente estado en Interfacturas ( Estado: " + clcrdyndns.comprobante[0].cabecera.informacion_comprobante.resultado + ").";
                        return;
                    }
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
                        MensajeLabel.Text = soapEx.Actor + "\\n" + errorMessage.Replace("\r", "").Replace("\n", "");
                    }
                    catch (Exception)
                    {
                        throw soapEx;
                    }
                }
            }
            else if (e.CommandName == "ExportarRG2485")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];
                FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                byte[] bytes;
                System.IO.MemoryStream ms;
                try
                {
                    comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                    bytes = new byte[comprobante.Response.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                    //Crear nombre de archivo default sin extensión
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(lote.cabecera_lote.cuit_vendedor);
                    sb.Append("-");
                    sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                    sb.Append("-");
                    sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
                    
                    //Crear nombre de archivo ZIP
                    System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                    sbZIP.Append(sb.ToString() + ".zip");

                    //Crear archivo CABECERA EMISOR
                    System.Text.StringBuilder sbCabeceraE = new System.Text.StringBuilder();
                    sbCabeceraE.Append(sb.ToString() + "-CABECERA_EMISOR.txt");
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCabeceraE.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    //Guardar info en archivo CABECERA EMISOR
                    System.Text.StringBuilder sbDataCabeceraE = new System.Text.StringBuilder();
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    string Campo2 = String.Format("{0,11}", sesion.Cuit.Nro);
                    string Campo3 = String.Format("{0,-30}", Truncate(sesion.Cuit.RazonSocial, 30));
                    string Campo4 = String.Format("{0,-30}", sesion.Cuit.DatosImpositivos.NroIngBrutos);
                    string Campo5 = sesion.Cuit.DatosImpositivos.IdCondIVA.ToString("00");
                    string Campo6 = String.Format("{0,-30}", ""); 
                    try
                    {
                        string RespAux6 = FeaEntidades.CondicionesIVA.CondicionIVA.Lista().Find(delegate(FeaEntidades.CondicionesIVA.CondicionIVA ci)
                        {
                            return (ci.Codigo == sesion.Cuit.DatosImpositivos.IdCondIVA);
                        }).Descr;
                        Campo6 = String.Format("{0,-27}", Truncate(RespAux6, 27));
                    }
                    catch 
                    {
                    }
                    string Campo7 = String.Format("{0,-8}", sesion.Cuit.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd"));
                    string Campo8 = String.Format("{0,-30}", sesion.Cuit.Domicilio.Calle);
                    string Campo9 = String.Format("{0,-6}", sesion.Cuit.Domicilio.Nro);
                    string Campo10 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Piso);
                    string Campo11 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Depto);
                    string Campo12 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Sector);
                    string Campo13 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Torre);
                    string Campo14 = String.Format("{0,-5}", sesion.Cuit.Domicilio.Manzana);
                    string Campo15 = Convert.ToInt32(sesion.Cuit.Domicilio.Provincia.Id).ToString("00");
                    string Campo16 = String.Format("{0,-8}", sesion.Cuit.Domicilio.CodPost);
                    string Campo17 = String.Format("{0,-25}", Truncate(sesion.Cuit.Domicilio.Localidad, 25));
                    sbDataCabeceraE.AppendLine("1" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17);
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCabeceraE.ToString())))
                    {
                        outfile.Write(sbDataCabeceraE.ToString());
                    }

                    //Crear archivo CABECERA COMPROBANTE 
                    System.Text.StringBuilder sbCabeceraC = new System.Text.StringBuilder();
                    sbCabeceraC.Append(sb.ToString() + "-CABECERA_COMPROBANTE.txt");
                    m = new System.IO.MemoryStream();
                    fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbCabeceraC.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    //Guardar info en archivo CABECERA COMPROBANTE
                    System.Text.StringBuilder sbDataCabeceraC = new System.Text.StringBuilder();
                    Campo2 = "ORIGINAL";
                    Campo3 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
                    Campo4 = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00");
                    if (Campo4 == "01" || Campo4 == "02" || Campo4 == "03" || Campo4 == "04" || Campo4 == "05" || Campo4 == "39" || Campo4 == "60" || Campo4 == "63")
                    {
                        Campo5 = "A";
                    }
                    else if (Campo4 == "06" || Campo4 == "07" || Campo4 == "08" || Campo4 == "09" || Campo4 == "10" || Campo4 == "40" || Campo4 == "61" || Campo4 == "64")
                    {
                        Campo5 = "B";
                    }
                    else
                    {
                        Campo5 = " ";
                    }
                    Campo6 = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("0000");
                    Campo7 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000");
                    Campo8 = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000");
                    Campo9 = lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString("00");
                    Campo10 = lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString("00000000000");
                    Campo11 = String.Format("{0,-30}", lote.comprobante[0].cabecera.informacion_comprador.denominacion);
                    Campo12 = lote.comprobante[0].cabecera.informacion_comprador.condicion_IVA.ToString("00");
                    Campo13 = String.Format("{0,-30}", Truncate(lote.comprobante[0].cabecera.informacion_comprador.domicilio_calle, 30));
                    Campo14 = String.Format("{0,-6}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
                    Campo15 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
                    Campo16 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
                    Campo17 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
                    string Campo18 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
                    string Campo19 = String.Format("{0,-5}", lote.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
                    string Campo20 = String.Format("{0,2}", lote.comprobante[0].cabecera.informacion_comprador.provincia);
                    string Campo21 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprador.cp);
                    string Campo22 = String.Format("{0,-25}", Truncate(lote.comprobante[0].cabecera.informacion_comprador.localidad, 25));
                    string Campo23 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_factura.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo24 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_concepto_no_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo25 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_neto_gravado.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo26 = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo27 = String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.impuesto_liq_rni.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo28 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_operaciones_exentas.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo29 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_nacionales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo30 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_ingresos_brutos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo31 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_municipales.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo32 = String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].resumen.importe_total_impuestos_internos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                    string Campo33 = String.Format("{0,-3}", lote.comprobante[0].resumen.codigo_moneda);
                    string Campo34 = String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 8) + ".00")).Substring(0, 8) + String.Format("{0,11}", lote.comprobante[0].resumen.tipo_de_cambio.ToString(new string(Convert.ToChar("0"), 8) + ".00")).Substring(9, 2);
                    int CantAlicuotas = 0;
                    if (lote.comprobante[0].resumen.cant_alicuotas_iva == 0)
                    {
                        for (int z = 0; z < lote.comprobante[0].resumen.impuestos.Length; z++)
                        {
                            if (lote.comprobante[0].resumen.impuestos[z].codigo_impuesto == 1)
                            {
                                CantAlicuotas += 1;
                            }
                        }
                    }
                    else
                    {
                        CantAlicuotas = lote.comprobante[0].resumen.cant_alicuotas_iva;
                    }
                    string Campo35 = String.Format("{0,1}", CantAlicuotas);
                    string Campo36 = String.Format("{0,1}", lote.comprobante[0].cabecera.informacion_comprobante.codigo_operacion);
                    string Campo37 = String.Format("{0,-14}", lote.comprobante[0].cabecera.informacion_comprobante.cae);
                    string Campo38 = String.Format("{0,-8}", lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae);
                    string Campo39 = String.Format("{0,8}", "        ");

                    sbDataCabeceraC.AppendLine("1" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11 + Campo12 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19 + Campo20 + Campo21 + Campo22 + Campo23 + Campo24 + Campo25 + Campo26 + Campo27 + Campo28 + Campo29 + Campo30 + Campo31 + Campo32 + Campo33 + Campo34 + Campo35 + Campo36 + Campo37 + Campo38 + Campo39); 
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbCabeceraC.ToString())))
                    {
                        outfile.Write(sbDataCabeceraC.ToString());
                    }

                    //Crear archivo DETALLE
                    System.Text.StringBuilder sbDetalle = new System.Text.StringBuilder();
                    sbDetalle.Append(sb.ToString() + "-DETALLE.txt");
                    m = new System.IO.MemoryStream();
                    fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbDetalle.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();
                    //Guardar info en archivo DETALLE
                    System.Text.StringBuilder sbDataDetalle = new System.Text.StringBuilder();
                    for (int i = 0; i < lote.comprobante[0].detalle.linea.Length; i++)
                    {
                        string descr = lote.comprobante[0].detalle.linea[i].descripcion;
                        if (descr.Length > 0 && descr.Substring(0, 1) == "%")
                        {
                            descr = HexToString(descr);
                        }
                        Campo2 = String.Format("{0,-100}", Truncate(descr, 100));
                        //cantidad de 12 (7 + 5)
                        Campo3 = String.Format("{0,13}", lote.comprobante[0].detalle.linea[i].cantidad.ToString(new string(Convert.ToChar("0"), 7) + ".00000")).Substring(0, 7) + String.Format("{0,13}", lote.comprobante[0].detalle.linea[i].cantidad.ToString(new string(Convert.ToChar("0"), 7) + ".00000")).Substring(8, 5);
                        //ojo format
                        Campo4 = Convert.ToInt32(lote.comprobante[0].detalle.linea[i].unidad).ToString("00");
                        Campo5 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].precio_unitario.ToString(new string(Convert.ToChar("0"), 13) +".000")).Substring(0, 13) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].precio_unitario.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(14, 3);
                        Campo6 = String.Format("{0,16}", lote.comprobante[0].detalle.linea[i].importe_total_descuentos.ToString(new string(Convert.ToChar("0"), 13) +".00")).Substring(0, 13) + String.Format("{0,16}", lote.comprobante[0].detalle.linea[i].importe_total_descuentos.ToString(new string(Convert.ToChar("0"), 13) + ".00")).Substring(14, 2);
                        //importe ajuste
                        Campo7 = String.Format("{0,16}", new string(Convert.ToChar("0"), 16));
                        Campo8 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_total_articulo.ToString(new string(Convert.ToChar("0"), 13) +".000")).Substring(0, 13) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_total_articulo.ToString(new string(Convert.ToChar("0"), 13) + ".000")).Substring(14, 3);
                        Campo9 = String.Format("{0,5}", lote.comprobante[0].detalle.linea[i].alicuota_iva.ToString("00.00")).Substring(0, 2) + String.Format("{0,5}", lote.comprobante[0].detalle.linea[i].alicuota_iva.ToString("00.00")).Substring(3, 2);
                        Campo10 = String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_iva.ToString(new string(Convert.ToChar("0"), 14) + ".00")).Substring(0, 14) + String.Format("{0,17}", lote.comprobante[0].detalle.linea[i].importe_iva.ToString(new string(Convert.ToChar("0"), 14) + ".00")).Substring(15, 2);
                        Campo11 = String.Format("{0,1}", lote.comprobante[0].detalle.linea[i].indicacion_exento_gravado);
                        sbDataDetalle.AppendLine("3" + Campo2 + Campo3 + Campo4 + Campo5 + Campo6 + Campo7 + Campo8 + Campo9 + Campo10 + Campo11);
                    }
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbDetalle.ToString())))
                    {
                        outfile.Write(sbDataDetalle.ToString());
                    }

                    //Descargar ZIP ( Cabecera Emisor, Cabecera Comprobante y Detalle )
                    string filename = sbZIP.ToString();
                    String dlDir = @"~/Temp/";
                    String path = Server.MapPath(dlDir + filename);
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    System.IO.FileInfo toCabeceraE = new System.IO.FileInfo(Server.MapPath(dlDir + sbCabeceraE.ToString()));
                    System.IO.FileInfo toCabeceraC = new System.IO.FileInfo(Server.MapPath(dlDir + sbCabeceraC.ToString()));
                    System.IO.FileInfo toDetalle = new System.IO.FileInfo(Server.MapPath(dlDir + sbDetalle.ToString()));

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddFile(Server.MapPath(dlDir + sbCabeceraE.ToString()), "");
                        zip.AddFile(Server.MapPath(dlDir + sbCabeceraC.ToString()), "");
                        zip.AddFile(Server.MapPath(dlDir + sbDetalle.ToString()), "");
                        zip.Save(Server.MapPath(dlDir + filename));
                    }
                    if (toDownload.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                        Response.AddHeader("Content-Length", toDownload.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(dlDir + filename);
                        Response.Flush();
                        Response.Close();
                        //Response.End();

                        toDownload.Delete();
                        toCabeceraE.Delete();
                        toCabeceraC.Delete();
                        toDetalle.Delete();
                    }
                    else
                    {
                        WebForms.Excepciones.Redireccionar(new EX.Validaciones.ArchivoInexistente(filename), "~/NotificacionDeExcepcion.aspx");
                    }
                    //Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + sb.ToString(), false);
                }
                catch (Exception ex)
                {
                    string script = "Problemas para generar la interfaz.\\n" + ex.Message;
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                    MensajeLabel.Text = script;
                }
            }
            else if (e.CommandName == "PDF-InfoLocal")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];
                FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                byte[] bytes;
                System.IO.MemoryStream ms;
                try
                {
                    comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                    bytes = new byte[comprobante.Response.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                    
                    string comprobanteXML = "";
                    RN.Comprobante.SerializarC(out comprobanteXML, lote.comprobante[0]);
                    System.Text.StringBuilder sbXMLData = new System.Text.StringBuilder();
                    sbXMLData.AppendLine(comprobanteXML);

                    //Crear nombre de archivo default sin extensión
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(lote.cabecera_lote.cuit_vendedor);
                    sb.Append("-");
                    sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                    sb.Append("-");
                    sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));

                    //Crear nombre de archivo ZIP
                    System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                    sbXML.Append(sb.ToString() + ".xml");
                    System.Text.StringBuilder sbPDF = new System.Text.StringBuilder();
                    sbPDF.Append(sb.ToString() + ".pdf");

                    //Crear archivo comprobante XML
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbXML.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();

                    //Grabar información comprobante XML
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbXML.ToString())))
                    {
                        outfile.Write(sbXMLData.ToString());
                    }

                    ExecuteCommand(sbXML.ToString(), sbPDF.ToString());
                }
                catch (Exception ex)
                {
                    string script = "Problemas para generar el PDF.\\n" + ex.Message;
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                    MensajeLabel.Text = script;
                }
            }
            else if (e.CommandName == "PDF")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];

                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> listaR = new List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();
                MensajeLabel.Text = String.Empty;
                Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                string resp = RN.Comprobante.ComprobanteDetalleIBK(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro, comprobante.NroPuntoVta.ToString(), comprobante.TipoComprobante.Id.ToString(), comprobante.Nro, 0, ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF);
                try
                {
                    string comprobanteXML = resp;
                    System.Text.StringBuilder sbXMLData = new System.Text.StringBuilder();
                    sbXMLData.AppendLine(comprobanteXML);

                    //Crear nombre de archivo default sin extensión
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(comprobante.Cuit);
                    sb.Append("-");
                    sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                    sb.Append("-");
                    sb.Append(comprobante.Nro.ToString("00000000"));

                    //Crear nombre de archivo ZIP / PDF / XML
                    System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                    sbZIP.Append(sb.ToString() + ".zip");
                    System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                    sbXML.Append(sb.ToString() + ".xml");
                    System.Text.StringBuilder sbPDF = new System.Text.StringBuilder();
                    sbPDF.Append(sb.ToString() + ".pdf");

                    //Crear archivo comprobante XML
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbXML.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();

                    //Grabar información comprobante XML
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbXML.ToString())))
                    {
                        outfile.Write(sbXMLData.ToString());
                    }

                    ExecuteCommand(sbXML.ToString(), sbPDF.ToString());

                    //Descargar ZIP ( Cabecera Emisor, Cabecera Comprobante y Detalle )
                    string filename = sbZIP.ToString();
                    String dlDir = @"~/Temp/";
                    String path = Server.MapPath(dlDir + filename);
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    System.IO.FileInfo toXML = new System.IO.FileInfo(Server.MapPath(dlDir + sbXML.ToString()));
                    System.IO.FileInfo toPDF = new System.IO.FileInfo(Server.MapPath(dlDir + sbPDF.ToString()));

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddFile(Server.MapPath(dlDir + sbXML.ToString()), "");
                        zip.AddFile(Server.MapPath(dlDir + sbPDF.ToString()), "");
                        zip.Save(Server.MapPath(dlDir + filename));
                    }
                    if (toDownload.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                        Response.AddHeader("Content-Length", toDownload.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(dlDir + filename);
                        Response.Flush();
                        Response.Close();
                        //Response.End();

                        //toDownload.Delete();
                        //toXML.Delete();
                        //toPDF.Delete();
                    }
                }
                catch (Exception ex)
                {
                    string script = "Problemas para generar el PDF.\\n" + ex.Message;
                    script += ex.StackTrace;
                    if (ex.InnerException != null)
                    {
                        script = ex.InnerException.Message;
                    }
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                    MensajeLabel.Text = script;
                }
            }
            else if (e.CommandName == "XMLOnLine")
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Comprobante> lista = (List<Entidades.Comprobante>)ViewState["Comprobantes"];
                Entidades.Comprobante comprobante = lista[item];

                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado> listaR = new List<FeaEntidades.InterFacturas.Listado.emisor_comprobante_listado>();
                MensajeLabel.Text = String.Empty;
                Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                string resp = RN.Comprobante.ComprobanteDetalleIBK(((Entidades.Sesion)Session["Sesion"]).Cuit.Nro, comprobante.NroPuntoVta.ToString(), comprobante.TipoComprobante.Id.ToString(), comprobante.Nro, 0, ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF);
                try
                {
                    string comprobanteXML = resp;
                    System.Text.StringBuilder sbXMLData = new System.Text.StringBuilder();
                    sbXMLData.AppendLine(comprobanteXML);

                    //Crear nombre de archivo default sin extensión
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(comprobante.Cuit);
                    sb.Append("-");
                    sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                    sb.Append("-");
                    sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                    sb.Append("-");
                    sb.Append(comprobante.Nro.ToString("00000000"));

                    //Crear nombre de archivo ZIP / PDF / XML
                    //System.Text.StringBuilder sbZIP = new System.Text.StringBuilder();
                    //sbZIP.Append(sb.ToString() + ".zip");
                    System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                    sbXML.Append(sb.ToString() + ".xml");

                    //Crear archivo comprobante XML
                    System.IO.MemoryStream m = new System.IO.MemoryStream();
                    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sbXML.ToString()), System.IO.FileMode.Create);
                    m.WriteTo(fs);
                    fs.Close();

                    //Grabar información comprobante XML
                    using (StreamWriter outfile = new StreamWriter(Server.MapPath(@"~/Temp/" + sbXML.ToString())))
                    {
                        outfile.Write(sbXMLData.ToString());
                    }

                    //Descargar ZIP ( XML On-Line )
                    //string filename = sbZIP.ToString();
                    //String dlDir = @"~/Temp/";
                    //String path = Server.MapPath(dlDir + filename);
                    //System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    //System.IO.FileInfo toXML = new System.IO.FileInfo(Server.MapPath(dlDir + sbXML.ToString()));

                    //using (ZipFile zip = new ZipFile())
                    //{
                    //    zip.AddFile(Server.MapPath(dlDir + sbXML.ToString()), "");
                    //    zip.Save(Server.MapPath(dlDir + filename));
                    //}

                    string filename = sbXML.ToString();
                    String dlDir = @"~/Temp/";
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(Server.MapPath(dlDir + filename));
                    if (toDownload.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                        Response.AddHeader("Content-Length", toDownload.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(dlDir + filename);
                        Response.Flush();
                        Response.Close();
                        //Response.End();

                        toDownload.Delete();
                        //toXML.Delete();
                    }
                }
                catch (Exception ex)
                {
                    string script = "Problemas para generar el XML.\\n" + ex.Message;
                    script += ex.StackTrace;
                    if (ex.InnerException != null)
                    {
                        script = ex.InnerException.Message;
                    }
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                    MensajeLabel.Text = script;
                }
            }
        }

        public void ExecuteCommand(string NombreArchivosbXML, string NombreArchivosbPDF)
        {
            int exitcode;
            ProcessStartInfo ProcessInfo;
            Process process;
            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "java.exe");
            ProcessInfo = new ProcessStartInfo("java.exe");
            ProcessInfo.Arguments = @"-cp " + Server.MapPath("~/cfe-factura-render-2.57-ejecutable.jar") + " ar.com.ib.cfe.render.GenerarPDF " + Server.MapPath("~/Temp/" + NombreArchivosbXML) + " " + Server.MapPath("~/Temp/" + NombreArchivosbPDF) + " ORIGINAL";
            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Argumentos: " + "-cp " + Server.MapPath("~/cfe-factura-render-2.57-ejecutable.jar") + " ar.com.ib.cfe.render.GenerarPDF " + Server.MapPath("~/Temp/" + NombreArchivosbXML) + " " + Server.MapPath("~/Temp/" + NombreArchivosbPDF) + " ORIGINAL");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            // redirecting standard output and error
            ProcessInfo.RedirectStandardError = true;
            ProcessInfo.RedirectStandardOutput = true;

            process = Process.Start(ProcessInfo);
  
            process.WaitForExit();

           //Reading output and error
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitcode = process.ExitCode;
            MensajeLabel.Text = "";
            //Exit code '0' denotes success and '1' denotes failure
            if (exitcode != 0)
            {
                MensajeLabel.Text += "Exit Code:" + exitcode + "  ";
            }
            if (error != "")
            {
                MensajeLabel.Text += "Error:" + error + "  ";
            }
            if (output != "")
            {
                MensajeLabel.Text += output + " ";
            }
            process.Close();
        }

        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        protected void ComprobantesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[13].Text != "Vigente")
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
                List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
                MensajeLabel.Text = String.Empty;
                Entidades.Cliente cliente = ((List<Entidades.Cliente>)ViewState["Clientes"])[ClienteDropDownList.SelectedIndex];
                lista = RN.Comprobante.ListaFiltrada(SoloVigentesCheckBox.Checked, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, cliente, sesion);
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

        private FeaEntidades.InterFacturas.lote_comprobantes Ws2Fea(org.dyndns.cedweb.consulta.ConsultarResult lcIBK)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lcFEA = new FeaEntidades.InterFacturas.lote_comprobantes();

            lcFEA.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lcFEA.cabecera_lote.cantidad_reg = lcIBK.cabecera_lote.cantidad_reg;
            lcFEA.cabecera_lote.cod_interno_canal = lcIBK.cabecera_lote.cod_interno_canal;
            lcFEA.cabecera_lote.cuit_canal = lcIBK.cabecera_lote.cuit_canal;
            lcFEA.cabecera_lote.cuit_vendedor = lcIBK.cabecera_lote.cuit_vendedor;
            lcFEA.cabecera_lote.fecha_envio_lote = lcIBK.cabecera_lote.fecha_envio_lote;
            lcFEA.cabecera_lote.id_lote = lcIBK.cabecera_lote.id_lote;
            lcFEA.cabecera_lote.motivo = lcIBK.cabecera_lote.motivo;
            lcFEA.cabecera_lote.presta_serv = lcIBK.cabecera_lote.presta_serv;
            lcFEA.cabecera_lote.presta_servSpecified = lcIBK.cabecera_lote.presta_servSpecified;
            lcFEA.cabecera_lote.punto_de_venta = lcIBK.cabecera_lote.punto_de_venta;
            lcFEA.cabecera_lote.resultado = lcIBK.cabecera_lote.resultado;

            lcFEA.comprobante = new FeaEntidades.InterFacturas.comprobante[lcIBK.comprobante.Length];

            for (int i = 0; i < lcIBK.comprobante.Length; i++)
            {
                FeaEntidades.InterFacturas.comprobante cIBK = new FeaEntidades.InterFacturas.comprobante();

                cIBK.cabecera = new FeaEntidades.InterFacturas.cabecera();

                //Comprador
                cIBK.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lcIBK.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lcIBK.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lcIBK.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lcIBK.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lcIBK.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lcIBK.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lcIBK.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lcIBK.comprobante[i].cabecera.informacion_comprador.telefono;

                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.cae != null && cIBK.cabecera.informacion_comprobante.cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lcIBK.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lcIBK.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != null && cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != null && cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.iva_computable = lcIBK.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lcIBK.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lcIBK.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
                cIBK.cabecera.informacion_comprobante.codigo_concepto = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_concepto;
                cIBK.cabecera.informacion_comprobante.codigo_conceptoSpecified = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_conceptoSpecified;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.razon_social = lcIBK.comprobante[i].cabecera.informacion_vendedor.razon_social;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lcIBK.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lcIBK.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lcIBK.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lcIBK.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lcIBK.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lcIBK.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lcIBK.comprobante[i].cabecera.informacion_vendedor.telefono;

                //Info Comprobantes de Referencia
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias[lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.S.ToString())
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "S";
                            }
                            else if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.N.ToString())
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "N";
                            }
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }

                //Info Informacion Adicional Comprobante
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante = new FeaEntidades.InterFacturas.informacion_adicional_comprobante[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length; j++)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j] = new FeaEntidades.InterFacturas.informacion_adicional_comprobante();
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo;
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor;
                    }
                }

                //Info Exportación
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new FeaEntidades.InterFacturas.informacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null && lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                    }
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new FeaEntidades.InterFacturas.permisos[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new FeaEntidades.InterFacturas.permisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                FeaEntidades.InterFacturas.detalle d = new FeaEntidades.InterFacturas.detalle();
                org.dyndns.cedweb.consulta.ConsultarResultComprobanteDetalle detalle = lcIBK.comprobante[i].detalle;
                d.linea = new FeaEntidades.InterFacturas.linea[detalle.linea.Length];
                d.comentarios = detalle.comentarios;
                for (int j = 0; j < detalle.linea.Length; j++)
                {
                    if (detalle.linea[j] != null)
                    {
                        d.linea[j] = new FeaEntidades.InterFacturas.linea();
                        d.linea[j].alicuota_iva = detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = detalle.linea[j].codigo_producto_vendedor;
                        d.linea[j].descripcion = detalle.linea[j].descripcion;

                        d.linea[j].GTIN = detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = detalle.linea[j].importe_total_impuestosSpecified;

                        if (detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new FeaEntidades.InterFacturas.lineaImpuestos[detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new FeaEntidades.InterFacturas.lineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (detalle.linea[j].descuentos != null)
                        {
                            d.linea[j].lineaDescuentos = new FeaEntidades.InterFacturas.lineaDescuentos[detalle.linea[j].descuentos.Length];
                            for (int k = 0; k < d.linea[j].lineaDescuentos.Length; k++)
                            {
                                d.linea[j].lineaDescuentos[k] = new FeaEntidades.InterFacturas.lineaDescuentos();
                                d.linea[j].lineaDescuentos[k].descripcion_descuento = detalle.linea[j].descuentos[k].descripcion_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento = detalle.linea[j].descuentos[k].importe_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen = detalle.linea[j].descuentos[k].importe_descuento_moneda_origen;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified = detalle.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuento = detalle.linea[j].descuentos[k].porcentaje_descuento;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified = detalle.linea[j].descuentos[k].porcentaje_descuentoSpecified;
                            }
                        }
                        if (detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                d.linea[j].informacion_adicional[k] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                                d.linea[j].informacion_adicional[k].tipo = detalle.linea[j].informacion_adicional[k].tipo;
                                d.linea[j].informacion_adicional[k].valor = detalle.linea[j].informacion_adicional[k].valor;
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.detalle = d;

                //Info Extensiones
                cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                cIBK.extensionesSpecified = false;
                if (lcIBK.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                    cIBK.extensionesSpecified = true;
                    if (lcIBK.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturasSpecified = true;
                        cIBK.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                        cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion;
                        cIBK.extensiones.extensiones_camara_facturas.id_idioma = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma;
                        cIBK.extensiones.extensiones_camara_facturas.id_template = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_template;
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
                        {

                            string aux = lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.ToString();
                            if (aux.Length > 0 && aux.Substring(0, 1) == "%")
                            {
                                aux = HexToString(aux);
                            }
                            cIBK.extensiones.extensiones_datos_comerciales = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_marketing != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.Equals(string.Empty))
                        {
                            string aux = lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.ToString();
                            if (aux.Length > 0 && aux.Substring(0, 1) == "%")
                            {
                                aux = HexToString(aux);
                            }
                            cIBK.extensiones.extensiones_datos_marketing = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_destinatarios != null)
                    {
                        cIBK.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lcIBK.comprobante[i].extensiones.extensiones_destinatarios.email;
                    }
                }

                cIBK.resumen = new FeaEntidades.InterFacturas.resumen();
                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lcIBK.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importe_total_neto_gravado;

                if (lcIBK.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lcIBK.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.impuesto_liq_rni;

                if (lcIBK.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[lcIBK.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new FeaEntidades.InterFacturas.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lcIBK.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                            cIBK.resumen.descuentos[l].indicacion_exento_gravado_descuento = lcIBK.comprobante[i].resumen.descuentos[l].indicacion_exento_gravado_descuento;
                        }
                    }
                }

                if (lcIBK.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[lcIBK.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new FeaEntidades.InterFacturas.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lcIBK.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lcIBK.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lcIBK.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lcIBK.comprobante[i].resumen.tipo_de_cambio;

                lcFEA.comprobante[i] = cIBK;
            }
            return lcFEA;
        }

        public string HexToString(string Hex)
        {
            Hex = Hex.Replace("%", "");
            int numberChars = Hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(Hex.Substring(i, 2), 16);
            }
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(bytes);
            str = SacarEntityName(str);
            return str;
        }

        private string SacarEntityName(string texto)
        {
            texto = texto.Replace("&aacute;", "á");
            texto = texto.Replace("&eacute;", "é");
            texto = texto.Replace("&iacute;", "í");
            texto = texto.Replace("&oacute;", "ó");
            texto = texto.Replace("&uacute;", "ú");
            texto = texto.Replace("&ordm;", "º");
            texto = texto.Replace("&agrave;", "à");
            texto = texto.Replace("&egrave;", "è");
            texto = texto.Replace("&igrave;", "ì");
            texto = texto.Replace("&ograve;", "ò");
            texto = texto.Replace("&ugrave;", "ù");
            texto = texto.Replace("&ntilde;", "ñ");
            texto = texto.Replace("&#36", "$");
            //Mayúsculas
            texto = texto.Replace("&Aacute;", "Á");
            texto = texto.Replace("&Eacute;", "É");
            texto = texto.Replace("&Iacute;", "Í");
            texto = texto.Replace("&Oacute;", "Ó");
            texto = texto.Replace("&Uacute;", "Ú");
            texto = texto.Replace("&Agrave;", "À");
            texto = texto.Replace("&Egrave;", "È");
            texto = texto.Replace("&Igrave;", "Ì");
            texto = texto.Replace("&Ograve;", "Ò");
            texto = texto.Replace("&Ugrave;", "Ù");
            texto = texto.Replace("&Ntilde;", "Ñ");
            return texto;
        }
    }
}