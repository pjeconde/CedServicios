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
    public partial class ComprobanteGeneracionAutomatica : System.Web.UI.Page
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
                    FechaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    ViewState["Personas"] = RN.Persona.ListaPorCuit(false, true, Entidades.Enum.TipoPersona.Ambos, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Persona>)ViewState["Personas"];
                    MonedaDropDownList.DataValueField = "Codigo";
                    MonedaDropDownList.DataTextField = "Descr";
                    MonedaDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.Lista();
                    MonedaDropDownList.DataBind();
                    DataBind();
                    if (ClienteDropDownList.Items.Count > 0)
                    {
                        ClienteDropDownList.SelectedValue = "0";
                        BuscarButton_Click(BuscarButton, EventArgs.Empty);
                    }
                }
            }
        }
        protected void MonedaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo_de_cambioLabel.Visible =  MonedaDropDownList.SelectedValue != "PES";
            Tipo_de_cambioTextBox.Visible = Tipo_de_cambioLabel.Visible;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                BuscarContratos(true);
            }
        }
        private void BuscarContratos(bool AsignoMensaje)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
            Entidades.Persona persona;
            if (AsignoMensaje) MensajeLabel.Text = String.Empty;
            if (ClienteDropDownList.SelectedIndex >= 0)
            {
                persona = ((List<Entidades.Persona>)ViewState["Personas"])[ClienteDropDownList.SelectedIndex];
            }
            else
            {
                persona = new Entidades.Persona();
            }
            List<Entidades.Estado> estados = new List<Entidades.Estado>();
            estados.Add(new Entidades.EstadoVigente());
            lista = RN.Comprobante.ListaContratosFiltrada(estados, FechaTextBox.Text, persona, MonedaDropDownList.SelectedValue, sesion);
            if (lista.Count == 0)
            {
                ComprobantesGridView.DataSource = null;
                ComprobantesGridView.DataBind();
                if (AsignoMensaje) MensajeLabel.Text = "No se han encontrado Contratos que satisfagan la busqueda.";
            }
            else
            {
                ComprobantesGridView.DataSource = lista;
                ViewState["Comprobantes"] = lista;
                ComprobantesGridView.DataBind();
                GenerarComprobantesButton.Visible = true;
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void GenerarComprobantesButton_Click(object sender, EventArgs e)
        {
            if (MonedaDropDownList.SelectedValue != "PES" && (!RN.Funciones.IsValidNumericDecimals(Tipo_de_cambioTextBox.Text) || Convert.ToDouble(Tipo_de_cambioTextBox.Text) <= 0))
            {
                MensajeLabel.Text = "En moneda extranjera es obligatorio el ingreso del tipo de cambio.";
            }
            else
            {
                int cantidadContratosSeleccionados = 0;
                int cantidadComprobantesGenerados = 0;
                int cantidadComprobantesEnviados = 0;
                int cantidadComprobantesConfirmados = 0;
                int cantidadComprobantesRechazados = 0;
                List<string> listaErrores = new List<string>();
                List<string> listaComprobantesGenerados = new List<string>();
                for (int i = 0; i < ComprobantesGridView.Rows.Count; i++)
                {
                    if (((CheckBox)ComprobantesGridView.Rows[i].FindControl("SeleccionContratoCheckBox")).Checked)
                    {
                        EmitirComprobantesContrato(i, ref cantidadContratosSeleccionados, ref cantidadComprobantesGenerados, ref cantidadComprobantesEnviados, ref cantidadComprobantesConfirmados, ref cantidadComprobantesRechazados, ref listaErrores, ref listaComprobantesGenerados);
                    }
                }
                if (cantidadContratosSeleccionados == 0)
                {
                    MensajeLabel.Text = "Para la generación automática de comprobantes se debe seleccionar al menos un contrato.";
                }
                else
                {
                    MostrarResultadoEmision(cantidadContratosSeleccionados, cantidadComprobantesGenerados, cantidadComprobantesEnviados, cantidadComprobantesConfirmados, cantidadComprobantesRechazados, listaErrores, listaComprobantesGenerados);
                }
                GenerarComprobantesButton.Visible = false;
            }
        }
        private void EmitirComprobantesContrato(int NroItemContrato, ref int CantidadContratosSeleccionados, ref int CantidadComprobantesGenerados, ref int CantidadComprobantesEnviados, ref int CantidadComprobantesConfirmados, ref int CantidadComprobantesRechazados, ref List<string> ListaErrores, ref List<string> ListaComprobantesGenerados)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            CantidadContratosSeleccionados++;
            Entidades.Comprobante contrato = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[NroItemContrato];

            FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
            #region Obtención del lote desde el comprobante
            System.Xml.Serialization.XmlSerializer x;
            byte[] bytes;
            System.IO.MemoryStream ms;
            x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
            bytes = new byte[contrato.Request.Length * sizeof(char)];
            System.Buffer.BlockCopy(contrato.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
            ms = new System.IO.MemoryStream(bytes);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
            #endregion
            while (Convert.ToInt32(contrato.FechaProximaEmision.ToString("yyyyMMdd")) <= Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
            {
                #region Generar nuevo comprobante
                bool comprobanteGenerado = false;
                try
                {
                    lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FechaTextBox.Text;
                    lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = DateTime.ParseExact(FechaTextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddDays(contrato.CantidadDiasFechaVto).ToString("yyyyMMdd");
                    lote.cabecera_lote.DestinoComprobante = contrato.IdDestinoComprobante;
                    if (lote.comprobante[0].cabecera.informacion_comprobante.codigo_concepto != 1)  //Incluye Servicios
                    {
                        DateTime fechaServicioDesde;
                        switch (contrato.PeriodicidadEmision)
                        {
                            case "Mensual-A":
                                fechaServicioDesde = new DateTime(contrato.FechaProximaEmision.Year, contrato.FechaProximaEmision.Month, 1);
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = fechaServicioDesde.ToString("yyyyMMdd");
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                                ReemplazaNombreClaveEnDescripcionDeArticulo(lote, "@MES", String.Format("{0} de {1}", System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(fechaServicioDesde.ToString("MMMM")), fechaServicioDesde.Year.ToString()));
                                break;
                            case "Mensual-V":
                                fechaServicioDesde = new DateTime(contrato.FechaProximaEmision.AddMonths(-1).Year, contrato.FechaProximaEmision.AddMonths(-1).Month, 1);
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = fechaServicioDesde.ToString("yyyyMMdd");
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd"); ;
                                ReemplazaNombreClaveEnDescripcionDeArticulo(lote, "@MES", String.Format("{0} de {1}", System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(fechaServicioDesde.ToString("MMMM")), fechaServicioDesde.Year.ToString()));
                                break;
                            case "Trimestral-A":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.Year, contrato.FechaProximaEmision.Month, 1)).ToString("yyyyMMdd"); ;
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(3).AddDays(-1).ToString("yyyyMMdd"); ;
                                break;
                            case "Trimestral-V":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.AddMonths(-3).Year, contrato.FechaProximaEmision.AddMonths(-3).Month, 1)).ToString("yyyyMMdd");
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(3).AddDays(-1).ToString("yyyyMMdd"); ;
                                break;
                            case "Anual-A":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.Year, contrato.FechaProximaEmision.Month, 1)).ToString("yyyyMMdd"); ;
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(12).AddDays(-1).ToString("yyyyMMdd"); ;
                                break;
                            case "Anual-V":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.AddMonths(-12).Year, contrato.FechaProximaEmision.AddMonths(-12).Month, 1)).ToString("yyyyMMdd");
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(12).AddDays(-1).ToString("yyyyMMdd"); ;
                                break;
                        }
                    }
                    //Nuevo número de lote
                    if (contrato.IdDestinoComprobante == "ITF")
                    {
                        Entidades.PuntoVta puntoVta = sesion.UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv) { return pv.Nro == contrato.NroPuntoVta; });
                        switch (puntoVta.IdMetodoGeneracionNumeracionLote)
                        {
                            case "Autonumerador":
                            case "TimeStamp1":
                            case "TimeStamp2":
                                RN.PuntoVta.GenerarNuevoNroLote(puntoVta, sesion);
                                lote.cabecera_lote.id_lote = puntoVta.UltNroLote;
                                break;
                            default:
                                throw new Exception("El punto de venta no tiene definido un método de numeración automática de lotes.");
                        }
                    }
                    //Nuevo número de comprobante
                    Entidades.Comprobante ultimoComprobanteEmitido = new Entidades.Comprobante();
                    ultimoComprobanteEmitido.TipoComprobante.Id = contrato.TipoComprobante.Id;
                    ultimoComprobanteEmitido.NroPuntoVta = contrato.NroPuntoVta;
                    ultimoComprobanteEmitido.NaturalezaComprobante.Id = "Venta";
                    RN.Comprobante.LeerUltimoEmitido(ultimoComprobanteEmitido, sesion);
                    lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = ultimoComprobanteEmitido.Nro + 1;

                    RN.Comprobante.Registrar(lote, null, "Venta", contrato.IdDestinoComprobante, "PteEnvio", "No Aplica", new DateTime(9999, 12, 31), 0, 0, 0, "Generación automática", sesion);
                    CantidadComprobantesGenerados++;
                    comprobanteGenerado = true;
                    string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + contrato.NroPuntoVta.ToString("0000") + "-" + lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000");
                    ListaComprobantesGenerados.Add(a);
                }
                catch (Exception ex)
                {
                    #region Registrar error en la generación del comprobante
                    string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + ex.Message;
                    if (ex.InnerException != null)
                    {
                        a += "  " + ex.InnerException.Message;
                    }
                    ListaErrores.Add(a);
                    #endregion
                    comprobanteGenerado = false;
                }
                #endregion
                bool transmisionOk = false;
                if (comprobanteGenerado)
                {
                    Entidades.Comprobante comprobante = new Entidades.Comprobante();
                    try
                    {
                        string respuesta = "";
                        switch (contrato.IdDestinoComprobante)
                        {
                            case "AFIP":
                                #region Transmitir comprobante a la AFIP
                                string caeNro = "";
                                string caeFecVto = "";
                                respuesta = RN.ComprobanteAFIP.EnviarAFIP(out caeNro, out caeFecVto, lote, (Entidades.Sesion)Session["Sesion"]);
                                if (respuesta.Length >= 12 && respuesta.Substring(0, 12) == "Resultado: A")
                                {
                                    CantidadComprobantesEnviados++;
                                    AjustarLoteParaITF(lote);
                                    if (caeNro != "")
                                    {
                                        lote.cabecera_lote.resultado = "A";
                                        lote.comprobante[0].cabecera.informacion_comprobante.resultado = "A";
                                        lote.comprobante[0].cabecera.informacion_comprobante.cae = caeNro;
                                        lote.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
                                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = caeFecVto;
                                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae = DateTime.Now.ToString("yyyyMMdd");
                                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                                    }
                                    string XML = "";
                                    RN.Comprobante.SerializarLc(out XML, lote);
                                    comprobante.Cuit = lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString();
                                    comprobante.TipoComprobante.Id = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                                    comprobante.NroPuntoVta = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                                    comprobante.Nro = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                    comprobante.Response = XML;
                                    comprobante.WF.Estado = "Vigente";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                    CantidadComprobantesConfirmados++;
                                }
                                else
                                {
                                    throw new Exception(respuesta);
                                }
                                #endregion
                                break;
                            case "ITF":
                                #region Transmitir comprobante a la Interfacturas
                                string NroCertif = sesion.Cuit.NroSerieCertifITF;
                                if (NroCertif.Equals(string.Empty))
                                {
                                    throw new Exception("Aún no disponemos de su certificado digital.");
                                }
                                else
                                {
                                    string certificado = "";
                                    certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                                    org.dyndns.cedweb.envio.EnvioIBK edyndns = new org.dyndns.cedweb.envio.EnvioIBK();
                                    string EnvioIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["EnvioIBKUtilizarServidorExterno"];
                                    if (EnvioIBKUtilizarServidorExterno == "SI")
                                    {
                                        edyndns.Url = System.Configuration.ConfigurationManager.AppSettings["EnvioIBKurl"];
                                    }
                                    org.dyndns.cedweb.envio.lc lcIBK = new org.dyndns.cedweb.envio.lc();
                                    AjustarLoteParaITF(lote);
                                    lcIBK = Facturacion.Electronica.Conversor.Entidad2IBK(lote);
                                    respuesta = edyndns.EnviarIBK(lcIBK, certificado);
                                    respuesta = respuesta.Replace("'", "-");
                                    if (respuesta == "Comprobante enviado satisfactoriamente a Interfacturas.")
                                    {
                                        CantidadComprobantesEnviados++;
                                        comprobante.Cuit = lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString();
                                        comprobante.TipoComprobante.Id = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                                        comprobante.NroPuntoVta = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                                        comprobante.Nro = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                                        RN.Comprobante.Leer(comprobante, sesion);
                                        comprobante.WF.Estado = "PteConf";
                                        RN.Comprobante.Actualizar(comprobante, sesion);
                                        RN.Comprobante.Leer(comprobante, sesion);
                                        //Consultar y Actualizar estado on-line.                              
                                        org.dyndns.cedweb.consulta.ConsultaIBK clcdyndnsConsultaIBK = new org.dyndns.cedweb.consulta.ConsultaIBK();
                                        string ConsultaIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKUtilizarServidorExterno"];
                                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKUtilizarServidorExterno: " + ConsultaIBKUtilizarServidorExterno);
                                        if (ConsultaIBKUtilizarServidorExterno == "SI")
                                        {
                                            clcdyndnsConsultaIBK.Url = System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"];
                                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Parametro ConsultaIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["ConsultaIBKurl"]);
                                        }
                                        System.Threading.Thread.Sleep(2000);
                                        org.dyndns.cedweb.consulta.ConsultarResult clcrdyndns = new org.dyndns.cedweb.consulta.ConsultarResult();
                                        clcrdyndns = clcdyndnsConsultaIBK.Consultar(Convert.ToInt64(lote.comprobante[0].cabecera.informacion_vendedor.cuit), lote.cabecera_lote.id_lote, lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta, certificado);
                                        FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                                        lc = Funciones.Ws2Fea(clcrdyndns);
                                        string XML = "";
                                        RN.Comprobante.SerializarLc(out XML, lc);
                                        comprobante.Response = XML;
                                        if (lc.cabecera_lote.resultado == "A")
                                        {
                                            comprobante.WF.Estado = "Vigente";
                                            RN.Comprobante.Actualizar(comprobante, sesion);
                                            RN.Comprobante.Leer(comprobante, sesion);
                                            CantidadComprobantesConfirmados++;
                                        }
                                        else if (lc.cabecera_lote.resultado == "R")
                                        {
                                            comprobante.WF.Estado = "Rechazado";
                                            RN.Comprobante.Actualizar(comprobante, sesion);
                                            RN.Comprobante.Leer(comprobante, sesion);
                                            CantidadComprobantesRechazados++;
                                            ListaErrores.Add("Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): Rechazado por Interfacturas.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception(Funciones.TextoScript("Problemas al enviar el comprobante a Interfacturas. " + Funciones.TextoScript(respuesta)));
                                    }
                                }
                                #endregion
                                break;
                        }
                        transmisionOk = true;
                    }
                    catch (Exception ex)
                    {
                        #region Registrar error en la transmisión del comprobante
                        string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + ex.Message;
                        if (ex.InnerException != null)
                        {
                            a += "  " + ex.InnerException.Message;
                        }
                        ListaErrores.Add(a);
                        #endregion
                    }
                    #region Actualizar, en el Contrato, la fecha de próxima emisión
                    switch (contrato.PeriodicidadEmision)
                    {
                        case "Mensual-A":
                        case "Mensual-V":
                            contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddMonths(1);
                            break;
                        case "Trimestral-A":
                        case "Trimestral-V":
                            contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddMonths(3);
                            break;
                        case "Anual-A":
                        case "Anual-V":
                            contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddYears(1);
                            break;
                    }
                    RN.Comprobante.ActualizarFechaProximaEmision(contrato, sesion);
                    #endregion
                    if (transmisionOk && comprobante.Estado == "Vigente")
                    {
                        string script;
                        if (false && contrato.IdDestinoComprobante == "ITF")
                        {
                            #region Descarga de PDF (InterFacturas)
                            string certificado;
                            string DetalleIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKUtilizarServidorExterno"];
                            try
                            {
                                org.dyndns.cedweb.detalle.DetalleIBK clcdyndns = new org.dyndns.cedweb.detalle.DetalleIBK();
                                org.dyndns.cedweb.detalle.cecd cecd = new org.dyndns.cedweb.detalle.cecd();
                                cecd.cuit_canal = Convert.ToInt64("30690783521");
                                cecd.cuit_vendedor = Convert.ToInt64(comprobante.Cuit);
                                cecd.punto_de_venta = Convert.ToInt32(comprobante.NroPuntoVta);
                                cecd.tipo_de_comprobante = Convert.ToInt32(comprobante.TipoComprobante.Id);
                                cecd.numero_comprobante = comprobante.Nro;
                                cecd.id_Lote = 0;
                                cecd.id_LoteSpecified = false;
                                cecd.estado = "PR";
                                certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                                if (DetalleIBKUtilizarServidorExterno == "SI")
                                {
                                    clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"];
                                }
                                string resp = clcdyndns.DetallarIBK(cecd, certificado);
                                resp = resp.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                                resp = resp.Replace(" xmlns:xsi=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", " xmlns=\"http://lote.schemas.cfe.ib.com.ar/\"");

                                string comprobanteXML = resp;
                                org.dyndns.cedweb.generoPDF.GeneroPDF pdfdyndns = new org.dyndns.cedweb.generoPDF.GeneroPDF();
                                string GenerarPDFUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFUtilizarServidorExterno"];
                                if (GenerarPDFUtilizarServidorExterno == "SI")
                                {
                                    pdfdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFurl"];
                                }
                                string RespPDF = pdfdyndns.GenerarPDF(comprobante.Cuit, comprobante.NroPuntoVta, comprobante.TipoComprobante.Id, comprobante.Nro, comprobante.IdDestinoComprobante, comprobanteXML);
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                sb.Append(comprobante.Cuit);
                                sb.Append("-");
                                sb.Append(comprobante.NroPuntoVta.ToString("0000"));
                                sb.Append("-");
                                sb.Append(comprobante.TipoComprobante.Id.ToString("00"));
                                sb.Append("-");
                                sb.Append(comprobante.Nro.ToString("00000000"));
                                sb.Append(".pdf");
                                string url = RespPDF;
                                string filename = sb.ToString();
                                String dlDir = @"~/TempRender/";
                                new System.Net.WebClient().DownloadFile(url, Server.MapPath(dlDir + filename));
                                script = "window.open('DescargaTemporarios.aspx?archivo=" + sb.ToString() + "&path=" + @"~/TempRender/" + "', '');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                            }
                            catch (Exception ex)
                            {
                                string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): Problemas para generar el PDF.  " + ex.Message;
                                if (ex.InnerException != null) a += ex.InnerException.Message;
                                ListaErrores.Add(a);
                            }
                            #endregion
                        }
                        else
                        {
                            #region Descarga de PDF (AFIP)
                            try
                            {
                                lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                                x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                                comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                                bytes = new byte[comprobante.Response.Length * sizeof(char)];
                                System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                                ms = new System.IO.MemoryStream(bytes);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);
                                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                                RN.Comprobante.AjustarLoteParaImprimirPDF(lote);

                                Session["lote"] = lote;
                                script = "window.open('/Facturacion/Electronica/Reportes/FacturaWebForm.aspx', '');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                            }
                            catch (Exception ex)
                            {
                                ListaErrores.Add("Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): Problemas para generar el PDF.  " + ex.Message);
                            }
                            #endregion
                        }
                    }
                }
                else
                {
                    contrato.FechaProximaEmision = new DateTime(9999, 12, 31); //para forzar el salto al próximo contrato
                }
            }
        }
        private void ReemplazaNombreClaveEnDescripcionDeArticulo(FeaEntidades.InterFacturas.lote_comprobantes Lote, string NombreClave, string Valor)
        {
            for (int i = 0; i < Lote.comprobante[0].detalle.linea.Length; i++)
            {
                string a = RN.Funciones.HexToString(Lote.comprobante[0].detalle.linea[i].descripcion);
                if (a.IndexOf(NombreClave) != -1)
                {
                    Lote.comprobante[0].detalle.linea[i].descripcion = RN.Funciones.ConvertToHex(a.Substring(0, a.IndexOf(NombreClave)) + Valor + a.Substring(a.IndexOf(NombreClave) + NombreClave.Length));
                }
            }
        }
        private void AjustarLoteParaITF(FeaEntidades.InterFacturas.lote_comprobantes lote)
        {
            string TipoCbte = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString();
            switch (TipoCbte)
            {
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "40":
                case "61":
                case "64":
                    FeaEntidades.InterFacturas.detalle det = new FeaEntidades.InterFacturas.detalle();
                    det = lote.comprobante[0].detalle;
                    FeaEntidades.InterFacturas.linea[] listadelineas;
                    listadelineas = det.linea;
                    Double TipoDeCambio = lote.comprobante[0].resumen.tipo_de_cambio;

                    int auxPV = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                    string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;

                    for (int i = 0; i < listadelineas.Length; i++)
                    {
                        if (det.linea[i] == null)
                        {
                            break;
                        }

                        double precio_unitario = det.linea[i].precio_unitario;
                        double alicuota_iva = det.linea[i].alicuota_iva;
                        double importe_iva = det.linea[i].importe_iva;
                        double importe_total_articulo = det.linea[i].importe_total_articulo;

                        //Moneda Local
                        if (lote.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
                        {
                            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
                            if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                            {
                                det.linea[i].precio_unitario = Math.Round(precio_unitario * (1 + alicuota_iva / 100), 3);
                            }
                            else
                            {
                                det.linea[i].precio_unitario = Math.Round(precio_unitario, 3);
                            }
                            if (idtipo.Equals("RG2904"))
                            {
                                det.linea[i].importe_total_articulo = Math.Round(importe_total_articulo, 2);
                            }
                            else
                            {
                                det.linea[i].importe_total_articulo = Math.Round(importe_total_articulo + importe_iva, 2);
                            }
                            //Borrar alicuota e importe
                            det.linea[i].alicuota_ivaSpecified = false;
                            det.linea[i].alicuota_iva = 0;
                            det.linea[i].indicacion_exento_gravado = null;
                            det.linea[i].importe_ivaSpecified = false;
                            det.linea[i].importe_iva = 0;
                        }
                        else
                        {
                            //Moneda Extranjera
                            det.linea[i].precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
                            if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                            {
                                det.linea[i].precio_unitario = Math.Round(precio_unitario * Convert.ToDouble(TipoDeCambio) * (1 + alicuota_iva / 100), 3);
                            }
                            else
                            {
                                det.linea[i].precio_unitario = Math.Round(precio_unitario * Convert.ToDouble(TipoDeCambio), 3);
                            }
                            det.linea[i].importe_total_articulo = Math.Round(((importe_total_articulo) + importe_iva) * Convert.ToDouble(TipoDeCambio), 2);
                            //Borrar alicuota e importe
                            det.linea[i].alicuota_ivaSpecified = false;
                            det.linea[i].alicuota_iva = 0;
                            det.linea[i].indicacion_exento_gravado = null;
                            det.linea[i].importe_ivaSpecified = false;
                            det.linea[i].importe_iva = 0;

                            //importes_moneda_origen
                            FeaEntidades.InterFacturas.lineaImportes_moneda_origen limo = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                            limo.importe_total_articuloSpecified = true;
                            limo.precio_unitarioSpecified = listadelineas[i].precio_unitarioSpecified;
                            if (!listadelineas[i].alicuota_iva.Equals(new FeaEntidades.IVA.SinInformar().Codigo))
                            {
                                limo.precio_unitario = Math.Round(precio_unitario * (1 + alicuota_iva / 100), 3);
                            }
                            else
                            {
                                limo.precio_unitario = Math.Round(precio_unitario, 3);
                            }
                            if (idtipo.Equals("RG2904"))
                            {
                                limo.importe_total_articulo = Math.Round(importe_total_articulo, 2);
                            }
                            else
                            {
                                limo.importe_total_articulo = Math.Round(importe_total_articulo + importe_iva, 2);
                            }
                            limo.importe_ivaSpecified = false;
                            limo.importe_iva = 0;
                            det.linea[i].importes_moneda_origen = limo;
                        }
                    }
                    break;
            }
        }
        protected void ComprobantesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Emision":
                    MensajeLabel.Text = "";
                    int item = Convert.ToInt32(e.CommandArgument);
                    int cantidadContratosSeleccionados = 0;
                    int cantidadComprobantesGenerados = 0;
                    int cantidadComprobantesEnviados = 0;
                    int cantidadComprobantesConfirmados = 0;
                    int cantidadComprobantesRechazados = 0;
                    List<string> listaErrores = new List<string>();
                    List<string> listaComprobantesGenerados = new List<string>();
                    EmitirComprobantesContrato(item, ref cantidadContratosSeleccionados, ref cantidadComprobantesGenerados, ref cantidadComprobantesEnviados, ref cantidadComprobantesConfirmados, ref cantidadComprobantesRechazados, ref listaErrores, ref listaComprobantesGenerados);
                    MostrarResultadoEmision(cantidadContratosSeleccionados, cantidadComprobantesGenerados, cantidadComprobantesEnviados, cantidadComprobantesConfirmados, cantidadComprobantesRechazados, listaErrores, listaComprobantesGenerados);
                    BuscarContratos(false);
                    break;
            }
        }
        private void MostrarResultadoEmision(int CantidadContratosSeleccionados, int CantidadComprobantesGenerados, int CantidadComprobantesEnviados, int CantidadComprobantesConfirmados, int CantidadComprobantesRechazados, List<string> ListaErrores, List<string> ListaComprobantesGenerados)
        {
            MensajeLabel.Text = "Cantidad de comprobantes--> Generados:" + CantidadComprobantesGenerados + ", Enviados:" + CantidadComprobantesEnviados + ", Confirmados:" + CantidadComprobantesConfirmados + ", Rechazados:" + CantidadComprobantesRechazados + ".";
            if (ListaErrores.Count > 0)
            {
                MensajeLabel.Text += "<br />ERRORES:";
                for (int i = 0; i < ListaErrores.Count; i++)
                {
                    MensajeLabel.Text += "<br />&nbsp;&nbsp;&nbsp;&nbsp;" + ListaErrores[i];
                }
            }
            if (ListaComprobantesGenerados.Count > 0)
            {
                MensajeLabel.Text += "<br />COMPROBANTES GENERADOS:";
                for (int i = 0; i < ListaComprobantesGenerados.Count; i++)
                {
                    MensajeLabel.Text += "<br />&nbsp;&nbsp;&nbsp;&nbsp;" + ListaComprobantesGenerados[i];
                }
            }
        }
        protected void TratamientoDeContratosCheckedChanged(object sender, EventArgs e)
        {
            if (TratamientoDeContratos1x1RadioButton.Checked)
            {
                GenerarComprobantesPanel.Visible = false;
                ComprobantesGridView.Columns[0].Visible = false;
                ComprobantesGridView.Columns[1].Visible = true;
            }
            else
            {
                GenerarComprobantesPanel.Visible = true;
                ComprobantesGridView.Columns[0].Visible = true;
                ComprobantesGridView.Columns[1].Visible = false;
            }
        }
    }
}
