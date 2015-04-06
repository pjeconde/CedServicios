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
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
                MensajeLabel.Text = String.Empty;
                Entidades.Persona persona;
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
                    MensajeLabel.Text = "No se han encontrado Contratos que satisfagan la busqueda.";
                }
                else
                {
                    ComprobantesGridView.DataSource = lista;
                    ViewState["Comprobantes"] = lista;
                    ComprobantesGridView.DataBind();
                    GenerarComprobantesButton.Visible = true;
                }
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
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                int cantidadContratosSeleccionados = 0;
                int cantidadComprobantesGenerados = 0;
                List<string> listaErrores = new List<string>();
                for (int i = 0; i < ComprobantesGridView.Rows.Count; i++)
                {
                    if (((CheckBox)ComprobantesGridView.Rows[i].FindControl("SeleccionContratoCheckBox")).Checked)
                    {
                        cantidadContratosSeleccionados++;
                        Entidades.Comprobante contrato = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[i];

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
                            try
                            {
                                #region Generar nuevo comprobante
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FechaTextBox.Text;
                                lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = DateTime.ParseExact(FechaTextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddDays(contrato.CantidadDiasFechaVto).ToString("yyyyMMdd");
                                lote.cabecera_lote.DestinoComprobante = contrato.IdDestinoComprobante;
                                if (lote.comprobante[0].cabecera.informacion_comprobante.codigo_concepto != 1)  //Incluye Servicios
                                {
                                    switch (contrato.PeriodicidadEmision)
                                    {
                                        case "Mensual-A":
                                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.Year, contrato.FechaProximaEmision.Month, 1)).ToString("yyyyMMdd");
                                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd");
                                            break;
                                        case "Mensual-V":
                                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde = (new DateTime(contrato.FechaProximaEmision.AddMonths(-1).Year, contrato.FechaProximaEmision.AddMonths(-1).Month, 1)).ToString("yyyyMMdd");
                                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta = DateTime.ParseExact(lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1).ToString("yyyyMMdd"); ;
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
                                    Entidades.PuntoVta puntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv) { return pv.Nro == contrato.NroPuntoVta; });
                                    switch (puntoVta.IdMetodoGeneracionNumeracionLote)
                                    {
                                        case "Autonumerador":
                                        case "TimeStamp1":
                                        case "TimeStamp2":
                                            RN.PuntoVta.GenerarNuevoNroLote(puntoVta, (Entidades.Sesion)Session["Sesion"]);
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

                                RN.Comprobante.Registrar(lote, null, "Venta", contrato.IdDestinoComprobante, "PteConf", "No Aplica", new DateTime(9999, 12, 31), 0, 0, 0, sesion);
                                #endregion
                                switch (contrato.IdDestinoComprobante)
                                {
                                    case "AFIP":
                                        #region Transmitir comprobante a la AFIP
                                        #endregion
                                        break;
                                    case "ITF":
                                        #region Transmitir comprobante a la Interfacturas
                                        string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                                        if (NroCertif.Equals(string.Empty))
                                        {
                                            throw new Exception("Aún no disponemos de su certificado digital.");
                                        }
                                        else
                                        {
                                            string certificado = "";
                                            string respuesta = "";
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
                                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);
                                            if (respuesta == "Comprobante enviado satisfactoriamente a Interfacturas.")
                                            {
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
                                                Entidades.Comprobante comprobante = new Entidades.Comprobante();
                                                comprobante.Cuit = lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString();
                                                comprobante.TipoComprobante.Id = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                                                comprobante.NroPuntoVta = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                                                comprobante.Nro = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                                                RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                                comprobante.Response = XML;
                                                if (lc.cabecera_lote.resultado == "A")
                                                {
                                                    comprobante.WF.Estado = "Vigente";
                                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                                }
                                                else if (lc.cabecera_lote.resultado == "R")
                                                {
                                                    comprobante.WF.Estado = "Rechazado";
                                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
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
                                cantidadComprobantesGenerados++;
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
                            }
                            catch (Exception ex)
                            {
                                #region Registrar error en la transmisión del comprobante
                                string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + ex.Message;
                                if (ex.InnerException != null)
                                {
                                    a += "  " + ex.InnerException.Message;
                                }
                                listaErrores.Add(a);
                                #endregion
                                #region Eliminar comprobante generado
                                #endregion
                                contrato.FechaProximaEmision = new DateTime(9999, 12, 31); //para forzar el salto al próximo contrato
                            }
                        }
                    }
                }
                if (cantidadContratosSeleccionados == 0)
                {
                    MensajeLabel.Text = "Para la generación automática de comprobantes se debe seleccionar al menos un contrato.";
                }
                else
                {
                    MensajeLabel.Text = "Cantidad de comprobantes generados: " + cantidadComprobantesGenerados + ".";
                    if (listaErrores.Count > 0)
                    {
                        MensajeLabel.Text += "<br />ERRORES:";
                        for (int i = 0; i < listaErrores.Count; i++)
                        {
                            MensajeLabel.Text += "<br />" + listaErrores[i];
                        }
                    }
                }
                GenerarComprobantesButton.Visible = false;
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
    }
}
