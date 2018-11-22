using System;
using System.Data;
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
using System.Xml.Serialization;
using CedServicios.Site.Facturacion.Electronica.Reportes;

namespace CedServicios.Site
{
    public partial class ComprobanteGeneracionAutomatica : System.Web.UI.Page
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument facturaRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument imagenRpt;
        CrystalDecisions.CrystalReports.Engine.ReportDocument codigobarrasRpt;
        DataSet dsImages = new DataSet();
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
            try
            {
                MensajeLabel.Text = "";
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
                    List<string> listaComprobantesEnviadosXEmail = new List<string>();
                    for (int i = 0; i < ComprobantesGridView.Rows.Count; i++)
                    {
                        if (((CheckBox)ComprobantesGridView.Rows[i].FindControl("SeleccionContratoCheckBox")).Checked)
                        {
                            EmitirComprobantesContrato(i, ref cantidadContratosSeleccionados, ref cantidadComprobantesGenerados, ref cantidadComprobantesEnviados, ref cantidadComprobantesConfirmados, ref cantidadComprobantesRechazados, ref listaErrores, ref listaComprobantesGenerados, ref listaComprobantesEnviadosXEmail);
                        }
                    }
                    if (cantidadContratosSeleccionados == 0)
                    {
                        MensajeLabel.Text = "Para la generación automática de comprobantes se debe seleccionar al menos un contrato.";
                    }
                    else
                    {
                        MostrarResultadoEmision(cantidadContratosSeleccionados, cantidadComprobantesGenerados, cantidadComprobantesEnviados, cantidadComprobantesConfirmados, cantidadComprobantesRechazados, listaErrores, listaComprobantesGenerados, listaComprobantesEnviadosXEmail);
                        BuscarContratos(false);
                        GenerarComprobantesButton.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: " + ex.Message + " " + ex.StackTrace);
                MensajeLabel.Text = ex.Message;
            }
        }
        private void EmitirComprobantesContrato(int NroItemContrato, ref int CantidadContratosSeleccionados, ref int CantidadComprobantesGenerados, ref int CantidadComprobantesEnviados, ref int CantidadComprobantesConfirmados, ref int CantidadComprobantesRechazados, ref List<string> ListaErrores, ref List<string> ListaComprobantesGenerados, ref List<string> listaComprobantesEnviadosXEmail)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            CantidadContratosSeleccionados++;
            Entidades.Comprobante contrato = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[NroItemContrato];

            while (Convert.ToInt32(contrato.FechaProximaEmision.ToString("yyyyMMdd")) <= Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
            {
                #region Obtención del lote desde el contrato
                FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType()); ;
                byte[] bytes = new byte[contrato.Request.Length * sizeof(char)];
                System.Buffer.BlockCopy(contrato.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                #endregion

                #region Asignacion campos vendedor
                lote.comprobante[0].cabecera.informacion_vendedor.codigo_interno = sesion.Cuit.DatosIdentificatorios.CodigoInterno;
                lote.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutos = sesion.Cuit.DatosImpositivos.IdCondIngBrutos;
                lote.comprobante[0].cabecera.informacion_vendedor.condicion_IVA = sesion.Cuit.DatosImpositivos.IdCondIVA;
                lote.comprobante[0].cabecera.informacion_vendedor.contacto = sesion.Cuit.Contacto.Nombre;
                lote.comprobante[0].cabecera.informacion_vendedor.cp = sesion.Cuit.Domicilio.CodPost;
                lote.comprobante[0].cabecera.informacion_vendedor.cuit = Convert.ToInt64(sesion.Cuit.Nro);
                //lote.comprobante[0].cabecera.informacion_vendedor.desambiguacionCuitPais = sesion.Cuit.DatosImpositivos.
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_depto = sesion.Cuit.Domicilio.Depto;
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_manzana = sesion.Cuit.Domicilio.Manzana;
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_numero = sesion.Cuit.Domicilio.Nro;
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_piso = sesion.Cuit.Domicilio.Piso;
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_sector = sesion.Cuit.Domicilio.Sector;
                lote.comprobante[0].cabecera.informacion_vendedor.domicilio_torre = sesion.Cuit.Domicilio.Torre;
                //lote.comprobante[0].cabecera.informacion_vendedor.email = sesion.Cuit.DatosIdentificatorios.
                lote.comprobante[0].cabecera.informacion_vendedor.GLN = sesion.Cuit.DatosIdentificatorios.GLN;
                //lote.comprobante[0].cabecera.informacion_vendedor.id = sesion.Cuit.DatosIdentificatorios.
                lote.comprobante[0].cabecera.informacion_vendedor.inicio_de_actividades = sesion.Cuit.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd");
                lote.comprobante[0].cabecera.informacion_vendedor.localidad = sesion.Cuit.Domicilio.Localidad;
                lote.comprobante[0].cabecera.informacion_vendedor.nro_ingresos_brutos = sesion.Cuit.DatosImpositivos.NroIngBrutos;
                lote.comprobante[0].cabecera.informacion_vendedor.provincia = sesion.Cuit.Domicilio.Provincia.Id;
                lote.comprobante[0].cabecera.informacion_vendedor.razon_social = sesion.Cuit.RazonSocial;
                //lote.comprobante[0].cabecera.informacion_vendedor.telefono = sesion.Cuit.Contacto.Telefono
                #endregion

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
                            case "Semestral-A":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.Year, contrato.FechaProximaEmision.Month, 1)).ToString("yyyyMMdd"); ;
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(6).AddDays(-1).ToString("yyyyMMdd"); ;
                                break;
                            case "Semestral-V":
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.AddMonths(-6).Year, contrato.FechaProximaEmision.AddMonths(-6).Month, 1)).ToString("yyyyMMdd");
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(6).AddDays(-1).ToString("yyyyMMdd"); ;
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

                    RN.Comprobante.Registrar(lote, null, "Venta", contrato.IdDestinoComprobante, "PteEnvio", "No Aplica", new DateTime(9999, 12, 31), 0, 0, 0, "Generación automática", false, string.Empty, string.Empty, string.Empty, sesion);
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
                                    comprobante.NaturalezaComprobante.Id = "Venta";
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
                                        comprobante.NaturalezaComprobante.Id = "Venta";
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
                        case "Semestral-A":
                        case "Semestral-V":
                            contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddMonths(6);
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
                        bool GeneracionPDFok = false;
                        string filenamePDF = string.Empty;
                        #region Generar PDF
                        var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
                        culture.NumberFormat.CurrencySymbol = string.Empty;
                        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                        System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
                        base.InitializeCulture(); 
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

                            string lcomp = Server.MapPath("~/Facturacion/Electronica/Reportes/lote_comprobantes.xsd");
                            System.IO.File.Copy(lcomp, @System.IO.Path.GetTempPath() + "lote_comprobantes.xsd", true);
                            string imagen = Server.MapPath("~/Facturacion/Electronica/Reportes/Imagen.xsd");
                            System.IO.File.Copy(imagen, @System.IO.Path.GetTempPath() + "Imagen.xsd", true);
                            facturaRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            string reportPath = Server.MapPath("~/Facturacion/Electronica/Reportes/Factura.rpt");
                            facturaRpt.Load(reportPath);
                            AsignarCamposOpcionales(lote);
                            ReemplarResumenImportesMonedaExtranjera(lote);
                            DataSet ds = new DataSet();
                            XmlSerializer objXS = new XmlSerializer(lote.GetType());
                            StringWriter objSW = new StringWriter();
                            objXS.Serialize(objSW, lote);
                            StringReader objSR = new StringReader(objSW.ToString());
                            ds.ReadXml(objSR);
                            bool original = true;
                            try
                            {
                                original = (bool)Session["EsComprobanteOriginal"];
                                if (original == false)
                                {
                                    facturaRpt.DataDefinition.FormulaFields["Borrador"].Text = "'BORRADOR'";
                                }
                            }
                            catch
                            {
                            }
                            facturaRpt.SetDataSource(ds);
                            facturaRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                            facturaRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            IncrustarLogo(lote.cabecera_lote.cuit_vendedor.ToString());
                            string cae = lote.comprobante[0].cabecera.informacion_comprobante.cae;
                            if (cae.Replace(" ", string.Empty).Equals(string.Empty))
                            {
                                cae = "99999999999999";
                            }
                            GenerarCodigoBarras(lote.cabecera_lote.cuit_vendedor + lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00") + lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString("0000") + cae + System.DateTime.Now.ToString("yyyyMMdd"));
                            AsignarParametros(lote.comprobante[0].resumen.importe_total_factura);
                            facturaRpt.Subreports["impuestos"].DataDefinition.FormulaFields["TipoDeComprobante"].Text = "'" + lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString() + "'";
                            facturaRpt.Subreports["resumen"].DataDefinition.FormulaFields["TipoDeComprobante"].Text = "'" + lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString() + "'";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append(lote.cabecera_lote.cuit_vendedor);
                            sb.Append("-");
                            sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
                            sb.Append("-");
                            sb.Append(lote .comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                            sb.Append("-");
                            sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
                            if (original == false)
                            {
                                sb.Append("-BORRADOR");
                            }
                            filenamePDF = Server.MapPath("PDFs\\" + sb.ToString() + ".pdf");
                            facturaRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, filenamePDF);
                            GeneracionPDFok = true;
                        }
                        catch (Exception ex)
                        {
                            ListaErrores.Add("Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + contrato.NroPuntoVta.ToString("0000") + "-" + lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000") + " Problemas para generar el PDF.  " + ex.Message);
                        }
                        #endregion
                        if (GeneracionPDFok)
                        {
                            try
                            {
                                #region Envio de mail
                                Entidades.Persona persona = new Entidades.Persona();
                                persona.Cuit = contrato.Cuit;
                                persona.Documento.Tipo.Id = contrato.Documento.Tipo.Id;
                                persona.Documento.Nro = contrato.Documento.Nro;
                                persona.IdPersona = contrato.IdPersona;
                                persona.DesambiguacionCuitPais = contrato.DesambiguacionCuitPais;
                                RN.Persona.LeerPorClavePrimaria(persona, sesion);
                                RN.Comprobante.LeerDestinatarioFrecuente(persona, contrato, sesion);
                                if (persona.DatosEmailAvisoComprobantePersona.Activo && contrato.DatosEmailAvisoComprobanteContrato.Activo && persona.DatosEmailAvisoComprobantePersona.De != string.Empty && contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Para != string.Empty && contrato.DatosEmailAvisoComprobanteContrato.Asunto != string.Empty && contrato.DatosEmailAvisoComprobanteContrato.Cuerpo != string.Empty)
                                {
                                    RN.EnvioCorreo.AvisoGeneracionComprobante(persona, contrato, comprobante, lote, filenamePDF, Server.MapPath("~/Imagenes/CedeiraSF_v1.jpg"), sesion);
                                    string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + contrato.NroPuntoVta.ToString("0000") + "-" + lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000") + " Envío de PDF por Email OK.";
                                    listaComprobantesEnviadosXEmail.Add(a);
                                }
                            }
                            catch (Exception ex)
                            {
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Envio PDF por Email: " + ex.Message);
                                ListaErrores.Add("Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + contrato.NroPuntoVta.ToString("0000") + "-" + lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000") + " Problemas para enviar el PDF por Email.  " + ex.Message);
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
            int item = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Emision":
                    MensajeLabel.Text = "";
                    int cantidadContratosSeleccionados = 0;
                    int cantidadComprobantesGenerados = 0;
                    int cantidadComprobantesEnviados = 0;
                    int cantidadComprobantesConfirmados = 0;
                    int cantidadComprobantesRechazados = 0;
                    List<string> listaErrores = new List<string>();
                    List<string> listaComprobantesGenerados = new List<string>();
                    List<string> listaComprobantesEnviadosXEmail = new List<string>();
                    EmitirComprobantesContrato(item, ref cantidadContratosSeleccionados, ref cantidadComprobantesGenerados, ref cantidadComprobantesEnviados, ref cantidadComprobantesConfirmados, ref cantidadComprobantesRechazados, ref listaErrores, ref listaComprobantesGenerados, ref listaComprobantesEnviadosXEmail);
                    MostrarResultadoEmision(cantidadContratosSeleccionados, cantidadComprobantesGenerados, cantidadComprobantesEnviados, cantidadComprobantesConfirmados, cantidadComprobantesRechazados, listaErrores, listaComprobantesGenerados, listaComprobantesEnviadosXEmail);
                    BuscarContratos(false);
                    break;
                case "VerifEnvioEmail":
                    MensajeLabel.Text = "";
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    Entidades.Comprobante contrato = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[item];
                    try
                    {
                        #region Verificar que se pueda enviar PDF por email
                        Entidades.Persona persona = new Entidades.Persona();
                        persona.Cuit = contrato.Cuit;
                        persona.Documento.Tipo.Id = contrato.Documento.Tipo.Id;
                        persona.Documento.Nro = contrato.Documento.Nro;
                        persona.IdPersona = contrato.IdPersona;
                        persona.DesambiguacionCuitPais = contrato.DesambiguacionCuitPais;
                        RN.Persona.LeerPorClavePrimaria(persona, sesion);
                        RN.Comprobante.LeerDestinatarioFrecuente(persona, contrato, sesion);
                        if (!persona.DatosEmailAvisoComprobantePersona.Activo)
                        {
                            MensajeLabel.Text += "No esta habilitado el envío de PDF por Email a nivel Persona.<br />";
                        }
                        if (persona.DatosEmailAvisoComprobantePersona.De == string.Empty)
                        {
                            MensajeLabel.Text += "No esta informado para el envío de PDF por Email a nivel Persona el campo 'De'.<br />";
                        }
                        if (!contrato.DatosEmailAvisoComprobanteContrato.Activo)
                        {
                            MensajeLabel.Text += "No esta habilitado el envío de PDF por Email a nivel Contrato.<br />";
                        }
                        if (contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Para == string.Empty)
                        {
                            MensajeLabel.Text += "No esta informado para el envío de PDF por Email a nivel Contrato el campo 'Destinatario'.<br />";
                        }
                        if (contrato.DatosEmailAvisoComprobanteContrato.Asunto == string.Empty)
                        {
                            MensajeLabel.Text += "No esta informado para el envío de PDF por Email a nivel Contrato el campo 'Asunto'.<br />";
                        }
                        if (contrato.DatosEmailAvisoComprobanteContrato.Cuerpo == string.Empty)
                        {
                            MensajeLabel.Text += "No esta informado para el envío de PDF por Email a nivel Contrato el campo 'Cuerpo'.<br />";
                        }
                        if (MensajeLabel.Text == string.Empty)
                        {
                            MensajeLabel.Text += "Verificación OK.";
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MensajeLabel.Text = "Error al verificar el envío de PDF por email. " + ex.Message;
                    }
                    break;
            }
        }
        private void MostrarResultadoEmision(int CantidadContratosSeleccionados, int CantidadComprobantesGenerados, int CantidadComprobantesEnviados, int CantidadComprobantesConfirmados, int CantidadComprobantesRechazados, List<string> ListaErrores, List<string> ListaComprobantesGenerados, List<string> listaComprobantesEnviadosXEmail)
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
            if (listaComprobantesEnviadosXEmail.Count > 0)
            {
                MensajeLabel.Text += "<br />COMPROBANTES ENVIADOS POR EMAIL:";
                for (int i = 0; i < listaComprobantesEnviadosXEmail.Count; i++)
                {
                    MensajeLabel.Text += "<br />&nbsp;&nbsp;&nbsp;&nbsp;" + listaComprobantesEnviadosXEmail[i];
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
        private void GenerarPDF()
        {


            if (Session["lote"] == null)
            {
                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                try
                {
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: " + ex.Message + " " + ex.StackTrace);
                    throw new Exception(ex.Message);
                    //WebForms.Excepciones.Redireccionar(ex, "~/Excepciones/Excepciones.aspx");
                }
            }
        }
        private void AsignarCamposOpcionales(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae == null)
            {
                lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = string.Empty;
            }
            lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;

            lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = true;
            lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_vendedor.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_vendedor.provincia = string.Empty;
            }

            lc.comprobante[0].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = true;
            lc.comprobante[0].cabecera.informacion_comprador.condicion_IVASpecified = true;
            if (lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle = string.Empty;
            }
            if (lc.comprobante[0].cabecera.informacion_comprador.provincia == null)
            {
                lc.comprobante[0].cabecera.informacion_comprador.provincia = string.Empty;
            }

            lc.comprobante[0].resumen.cant_alicuotas_ivaSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified = true;
            lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified = true;

            if (lc.comprobante[0].resumen.descuentos != null)
            {
                for (int i = 0; i < lc.comprobante[0].resumen.descuentos.Length; i++)
                {
                    if (lc.comprobante[0].resumen.descuentos[i] != null)
                    {
                        if (lc.comprobante[0].resumen.descuentos[i].importe_iva_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].importe_iva_descuentoSpecified = true;
                        }
                        if (lc.comprobante[0].resumen.descuentos[i].alicuota_iva_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].alicuota_iva_descuentoSpecified = true;
                        }
                        if (lc.comprobante[0].resumen.descuentos[i].porcentaje_descuentoSpecified.Equals(false))
                        {
                            lc.comprobante[0].resumen.descuentos[i].porcentaje_descuentoSpecified = true;
                        }
                    }
                }
            }
            for (int i = 0; i < lc.comprobante[0].detalle.linea.Length; i++)
            {
                if (lc.comprobante[0].detalle.linea[i] != null)
                {
                    lc.comprobante[0].detalle.linea[i].precio_unitarioSpecified = true;
                    lc.comprobante[0].detalle.linea[i].importe_ivaSpecified = true;
                    if (lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified.Equals(false))
                    {
                        lc.comprobante[0].detalle.linea[i].alicuota_ivaSpecified = true;
                        lc.comprobante[0].detalle.linea[i].alicuota_iva = 99;
                    }
                    lc.comprobante[0].detalle.linea[i].cantidadSpecified = true;

                    if (lc.comprobante[0].detalle.linea[i].unidad == null)
                    {
                        lc.comprobante[0].detalle.linea[i].unidad = string.Empty;
                    }
                    if (lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado == null)
                    {
                        lc.comprobante[0].detalle.linea[i].indicacion_exento_gravado = string.Empty;
                    }
                    if (lc.comprobante[0].detalle.linea[i].importes_moneda_origen != null)
                    {
                        lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_ivaSpecified = true;
                        lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_articuloSpecified = true;
                        lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_descuentosSpecified = true;
                        lc.comprobante[0].detalle.linea[i].importes_moneda_origen.importe_total_impuestosSpecified = true;
                        lc.comprobante[0].detalle.linea[i].importes_moneda_origen.precio_unitarioSpecified = true;
                    }
                    if (lc.comprobante[0].detalle.linea[i].GTINSpecified.Equals(false))
                    {
                        lc.comprobante[0].detalle.linea[i].GTINSpecified = true;
                        lc.comprobante[0].detalle.linea[i].GTIN = 0;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private static void ReemplarResumenImportesMonedaExtranjera(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (!lc.comprobante[0].resumen.codigo_moneda.Equals("PES"))
            {
                lc.comprobante[0].resumen.importe_total_neto_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado;

                lc.comprobante[0].resumen.importe_total_concepto_no_gravado = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                lc.comprobante[0].resumen.importe_operaciones_exentas = lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas;
                lc.comprobante[0].resumen.impuesto_liq = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq;
                lc.comprobante[0].resumen.impuesto_liq_rni = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni;
                lc.comprobante[0].resumen.importe_total_impuestos_municipales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                lc.comprobante[0].resumen.importe_total_impuestos_nacionales = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                lc.comprobante[0].resumen.importe_total_ingresos_brutos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                lc.comprobante[0].resumen.importe_total_impuestos_internos = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos;

                lc.comprobante[0].resumen.importe_total_factura = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;

                if (lc.comprobante[0].resumen.descuentos != null)
                {
                    for (int i = 0; i < lc.comprobante[0].resumen.descuentos.Length; i++)
                    {
                        if (lc.comprobante[0].resumen.descuentos[i] != null)
                        {
                            lc.comprobante[0].resumen.descuentos[i].importe_descuento = lc.comprobante[0].resumen.descuentos[i].importe_descuento_moneda_origen;
                            lc.comprobante[0].resumen.descuentos[i].importe_iva_descuento = lc.comprobante[0].resumen.descuentos[i].importe_iva_descuento_moneda_origen;
                        }
                    }
                }
            }
        }
        private void IncrustarLogo(string cuit)
        {
            try
            {
                String path = Server.MapPath("~/ImagenesSubidas/");
                string[] archivos = System.IO.Directory.GetFiles(path, cuit + ".*", System.IO.SearchOption.TopDirectoryOnly);
                string imagenCUIT = "";
                if (archivos.Length > 0)
                {
                    imagenCUIT = "~/ImagenesSubidas/" + archivos[0].Replace(Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                }
                if (imagenCUIT != "")
                {
                    FileStream FilStr = new FileStream(Server.MapPath(imagenCUIT), FileMode.Open);
                    CrearTabla();
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DataRow dr = this.dsImages.Tables["images"].NewRow();
                    dr["path"] = Server.MapPath(imagenCUIT);
                    dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    this.dsImages.Tables["images"].Rows.Add(dr);
                    FilStr.Close();
                    BinRed.Close();

                    imagenRpt = facturaRpt.OpenSubreport("Imagen.rpt");
                    imagenRpt.SetDataSource(this.dsImages);
                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: Imagen OK");
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message.ToString().Replace("'", " ");
                a = a.Replace("<", " ");
                a = a.Replace(">", " ");
                a = a.Replace("/", " ");
                a = a.Replace(@"\", " ");
                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "Reporte: Imagen NOT OK " + a);
            }
        }
        private void GenerarCodigoBarras(string code)
        {
            if (code != null)
            {
                Facturacion.Electronica.Reportes.Code39 c39 = new Code39();
                MemoryStream ms = new MemoryStream();
                c39.FontFamilyName = "Free 3 of 9";
                c39.FontFileName = Server.MapPath("Facturacion\\Electronica\\Reportes\\FREE3OF9.TTF");
                c39.FontSize = 30;
                c39.ShowCodeString = true;
                System.Drawing.Bitmap objBitmap = c39.GenerateBarcode(code);
                objBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                codigobarrasRpt = facturaRpt.OpenSubreport("CodigoBarra.rpt");

                CrearTabla();

                DataRow dr = this.dsImages.Tables["images"].NewRow();
                dr["path"] = "ninguno";
                dr["image"] = ms.ToArray();
                this.dsImages.Tables["images"].Rows.Add(dr);

                codigobarrasRpt.SetDataSource(this.dsImages);
            }
        }
        private void CrearTabla()
        {
            this.dsImages = new DataSet();
            DataTable imageTable = new DataTable("Images");
            imageTable.Columns.Add(new DataColumn("path", typeof(string)));
            imageTable.Columns.Add(new DataColumn("image", typeof(System.Byte[])));
            this.dsImages.Tables.Add(imageTable);
        }
        private void AsignarParametros(double p)
        {
            CrystalDecisions.Shared.ParameterValues myVals = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterDiscreteValue myDiscrete = new CrystalDecisions.Shared.ParameterDiscreteValue();
            myDiscrete.Value = NumALet.ToCardinal(Convert.ToDecimal(p));
            myVals.Add(myDiscrete);
            facturaRpt.DataDefinition.ParameterFields[0].ApplyCurrentValues(myVals);

            facturaRpt.Subreports["resumen"].DataDefinition.FormulaFields["ImpTotTexto"].Text = "'" + NumALet.ToCardinal(Convert.ToDecimal(p)) + "'";
        }
    }
}
