using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using CedServicios.Site.Facturacion.Electronica;

namespace CedServicios.Site
{
    public partial class ComprobanteConsultaTurismo : System.Web.UI.Page
    {
        #region Variables
        string gvUniqueID = String.Empty;
        System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];

                    //VENDEDOR
                    Condicion_IVA_VendedorDropDownList.DataValueField = "Codigo";
                    Condicion_IVA_VendedorDropDownList.DataTextField = "Descr";
                    Condicion_IVA_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                    Condicion_IVA_VendedorDropDownList.DataBind();
                    Condicion_Ingresos_Brutos_VendedorDropDownList.DataValueField = "Codigo";
                    Condicion_Ingresos_Brutos_VendedorDropDownList.DataTextField = "Descr";
                    Condicion_Ingresos_Brutos_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                    Condicion_Ingresos_Brutos_VendedorDropDownList.DataBind();
                    Provincia_VendedorDropDownList.DataValueField = "Codigo";
                    Provincia_VendedorDropDownList.DataTextField = "Descr";
                    Provincia_VendedorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                    Provincia_VendedorDropDownList.DataBind();

                    //COMPRADOR
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                    Condicion_IVA_CompradorDropDownList.DataValueField = "Codigo";
                    Condicion_IVA_CompradorDropDownList.DataTextField = "Descr";
                    Condicion_IVA_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                    Condicion_IVA_CompradorDropDownList.DataBind();
                    Provincia_CompradorDropDownList.DataValueField = "Codigo";
                    Provincia_CompradorDropDownList.DataTextField = "Descr";
                    Provincia_CompradorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                    Provincia_CompradorDropDownList.DataBind();
                    CodigoPaisDropDownList.DataValueField = "Codigo";
                    CodigoPaisDropDownList.DataTextField = "Descr";
                    CodigoPaisDropDownList.DataSource = FeaEntidades.DestinosPais.DestinoPais.Lista();
                    CodigoPaisDropDownList.DataBind();
                    CodigoRelacionReceptorEmisorDropDownList.DataValueField = "Codigo";
                    CodigoRelacionReceptorEmisorDropDownList.DataTextField = "Descr";
                    CodigoRelacionReceptorEmisorDropDownList.DataSource = FeaEntidades.CodigosRelacionReceptorEmisor.CodigoRelacionReceptorEmisor.Lista();
                    CodigoRelacionReceptorEmisorDropDownList.DataBind();

                    //COMPROBANTE
                    Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
                    Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
                    Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaTurismoAFIP();
                    Tipo_De_ComprobanteDropDownList.DataBind();
                    MonedaComprobanteDropDownList.DataValueField = "Codigo";
                    MonedaComprobanteDropDownList.DataTextField = "Descr";
                    MonedaComprobanteDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.ListaNoExportacion();
                    MonedaComprobanteDropDownList.DataBind();

                   

                    System.Collections.Generic.List<Entidades.PuntoVta> listaPuntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta;
                    PuntoVtaDropDownList.DataValueField = "Nro";
                    PuntoVtaDropDownList.DataTextField = "Descr";
                    System.Collections.Generic.List<Entidades.PuntoVta> puntoVtalist = new System.Collections.Generic.List<Entidades.PuntoVta>();
                    Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                    puntoVta.Nro = 0;
                    puntoVtalist.Add(puntoVta);
                    if (listaPuntoVta != null)
                    {
                        puntoVtalist.AddRange(listaPuntoVta);
                    }
                    PuntoVtaDropDownList.DataSource = puntoVtalist;
                    PuntoVtaDropDownList.DataBind();

                    PeriodicidadEmisionDropDownList.DataValueField = "Id";
                    PeriodicidadEmisionDropDownList.DataTextField = "Descr";
                    PeriodicidadEmisionDropDownList.DataSource = RN.PeriodicidadEmision.Lista(true);
                    PeriodicidadEmisionDropDownList.DataBind();

                    IdDestinoComprobanteDropDownList.DataValueField = "Id";
                    IdDestinoComprobanteDropDownList.DataTextField = "Descr";
                    IdDestinoComprobanteDropDownList.DataSource = sesion.Cuit.DestinosComprobante();
                    IdDestinoComprobanteDropDownList.DataBind();

                    //DataBind();
                    BindearDropDownLists();

                    DeshabilitarControles();

                    Entidades.ComprobanteATratar comprobanteATratar = (Entidades.ComprobanteATratar)Session["ComprobanteATratar"];
                    TratamientoTextBox.Text = comprobanteATratar.Tratamiento.ToString();
                    IdNaturalezaComprobanteTextBox.Text = comprobanteATratar.Comprobante.NaturalezaComprobante.Id;
                    CompletarUI(comprobanteATratar.Comprobante);
                    ViewState["ComprobanteATratar"] = comprobanteATratar;

                    string descrTratamiento = String.Empty;
                    if (TratamientoTextBox.Text == "Consulta")
                    {
                        descrTratamiento = "Consulta";
                    }
                    else
                    {
                        WebForms.Excepciones.Redireccionar(new EX.Validaciones.ValorInvalido("Tratamiento del Comprobante"), "~/NotificacionDeExcepcion.aspx");
                    }

                    #region Personalización campos vendedor y comprador para VENTAS
                    //VendedorUpdatePanel.Visible = false;
                    pBody.Enabled = false;
                    TituloPaginaLabel.Text = descrTratamiento + " de Comprobante";
                    DatosComprobanteLabel.Text = "COMPROBANTE DE VENTA (electrónica)";
                    DatosEmisionPanel.Visible = false;
                    #endregion
                }
            }
        }
        private void DeshabilitarControles()
        {
            Tipo_De_ComprobanteDropDownList.Enabled = false;
            Condicion_De_PagoTextBox.ReadOnly = true;
            Numero_ComprobanteTextBox.ReadOnly = true;
            FechaEmisionDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaEmision.Enabled = false;
            FechaVencimientoDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaVencimiento.Enabled = false;
            FechaServDesdeDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaServDesde.Enabled = false;
            FechaServHastaDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaServHasta.Enabled = false;

            Razon_Social_VendedorTextBox.ReadOnly = true;
            Domicilio_Calle_VendedorTextBox.ReadOnly = true;
            Domicilio_Numero_VendedorTextBox.ReadOnly = true;
            Domicilio_Piso_VendedorTextBox.ReadOnly = true;
            Domicilio_Depto_VendedorTextBox.ReadOnly = true;
            Domicilio_Sector_VendedorTextBox.ReadOnly = true;
            Domicilio_Torre_VendedorTextBox.ReadOnly = true;
            Domicilio_Manzana_VendedorTextBox.ReadOnly = true;
            Localidad_VendedorTextBox.ReadOnly = true;
            Provincia_VendedorDropDownList.Enabled = false;
            Cp_VendedorTextBox.ReadOnly = true;
            Contacto_VendedorTextBox.ReadOnly = true;
            Telefono_VendedorTextBox.ReadOnly = true;
            Cuit_VendedorTextBox.ReadOnly = true;
            InicioDeActividadesVendedorDatePickerWebUserControl.ReadOnly = true; ImageCalendarInicioDeActividadesVendedor.Enabled = false;
            Condicion_Ingresos_Brutos_VendedorDropDownList.Enabled = false;
            NroIBVendedorTextBox.ReadOnly = true;
            Condicion_IVA_VendedorDropDownList.Enabled = false;
            GLN_VendedorTextBox.ReadOnly = true;
            Codigo_Interno_VendedorTextBox.ReadOnly = true;
            Email_VendedorTextBox.ReadOnly = true;

            Denominacion_CompradorTextBox.ReadOnly = true;
            Domicilio_Calle_CompradorTextBox.ReadOnly = true;
            Domicilio_Numero_CompradorTextBox.ReadOnly = true;
            Domicilio_Piso_CompradorTextBox.ReadOnly = true;
            Domicilio_Depto_CompradorTextBox.ReadOnly = true;
            Domicilio_Sector_CompradorTextBox.ReadOnly = true;
            Domicilio_Torre_CompradorTextBox.ReadOnly = true;
            Domicilio_Manzana_CompradorTextBox.ReadOnly = true;
            Localidad_CompradorTextBox.ReadOnly = true;
            Provincia_CompradorDropDownList.Enabled = false;
            Cp_CompradorTextBox.ReadOnly = true;
            EmailAvisoVisualizacionTextBox.ReadOnly = true;
            PasswordAvisoVisualizacionTextBox.ReadOnly = true;
            Codigo_Doc_Identificatorio_CompradorDropDownList.Enabled = false;
            Nro_Doc_Identificatorio_CompradorTextBox.ReadOnly = true;
            InicioDeActividadesCompradorDatePickerWebUserControl.ReadOnly = true; ImageCalendarInicioDeActividadesComprador.Enabled = false;
            Condicion_IVA_CompradorDropDownList.Enabled = false;
            GLN_CompradorTextBox.ReadOnly = true;
            Codigo_Interno_CompradorTextBox.ReadOnly = true;
            Contacto_CompradorTextBox.ReadOnly = true;
            Email_CompradorTextBox.ReadOnly = true;
            Telefono_CompradorTextBox.ReadOnly = true;

            DatosComerciales.ReadOnly = true;

            ComentariosTextBox.ReadOnly = true;

            CAETextBox.ReadOnly = true;
            FechaCAEVencimientoDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaCAEVencimiento.Enabled = false;
            FechaCAEObtencionDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaCAEObtencion.Enabled = false;
            ResultadoTextBox.ReadOnly = true;
            MotivoTextBox.ReadOnly = true;

            PeriodicidadEmisionDropDownList.Enabled = false;
            IdDestinoComprobanteDropDownList.Enabled = false;
            FechaProximaEmisionDatePickerWebUserControl.ReadOnly = true; ImageCalendarFechaProximaEmision.Enabled = false;
            CantidadComprobantesAEmitirTextBox.ReadOnly = true;
            CantidadComprobantesEmitidosTextBox.ReadOnly = true;
            CantidadDiasFechaVtoTextBox.ReadOnly = true;

            Importe_Total_Neto_Gravado_ResumenTextBox.ReadOnly = true;
            Importe_Total_Concepto_No_Gravado_ResumenTextBox.ReadOnly = true;
            Importe_Operaciones_Exentas_ResumenTextBox.ReadOnly = true;
            Impuesto_Liq_ResumenTextBox.ReadOnly = true;
            Impuesto_Liq_Rni_ResumenTextBox.ReadOnly = true;
            Importe_Total_Impuestos_Municipales_ResumenTextBox.ReadOnly = true;
            Importe_Total_Impuestos_Nacionales_ResumenTextBox.ReadOnly = true;
            Importe_Total_Ingresos_Brutos_ResumenTextBox.ReadOnly = true;
            Importe_Total_Impuestos_Internos_ResumenTextBox.ReadOnly = true;
            Importe_Total_Factura_ResumenTextBox.ReadOnly = true;
            Tipo_de_cambioTextBox.ReadOnly = true;

            Observaciones_ResumenTextBox.ReadOnly = true;
        }
        private void BindearDropDownLists()
        {
            InfoReferencias.BindearDropDownLists();
            DetalleLinea.BindearDropDownLists();
        }
        private void CompletarUI(Entidades.Comprobante Comprobante)
        {
            FeaEntidades.Turismo.comprobante c = new FeaEntidades.Turismo.comprobante();
            #region Obtención del lote desde el comprobante
            System.Xml.Serialization.XmlSerializer x;
            byte[] bytes;
            System.IO.MemoryStream ms;
            x = new System.Xml.Serialization.XmlSerializer(c.GetType());
            try
            {
                Comprobante.Response = Comprobante.Response.Replace("iso-8859-1", "utf-16");
                bytes = new byte[Comprobante.Response.Length * sizeof(char)];
                System.Buffer.BlockCopy(Comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                ms = new System.IO.MemoryStream(bytes);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                c = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
            }
            catch
            {
                bytes = new byte[Comprobante.Request.Length * sizeof(char)];
                System.Buffer.BlockCopy(Comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                ms = new System.IO.MemoryStream(bytes);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                c = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
            }
            #endregion
            //Cabecera
            CompletarCabecera(c);
            //Comprobante
            CompletarComprobante(c);
            //Referencias
            InfoReferencias.PuntoDeVenta = c.cabecera.informacion_comprobante.punto_de_venta.ToString();
            InfoReferencias.CompletarReferencias(c);
            //Comprador
            CompletarComprador(c);
            //Vendedor
            CompletarVendedor(c);
            //Detalle
            DetalleLinea.CompletarDetalles(c);
            //impuestos globales
            ImpuestosGlobales.Completar(c);
            ComentariosTextBox.Text = c.detalle.comentarios;
            //Resumen
            CompletarResumen(c);
            Observaciones_ResumenTextBox.Text = Convert.ToString(c.resumen.observaciones);
            if (!c.resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Tipo_de_cambioLabel.Visible = true;
                Tipo_de_cambioTextBox.Visible = true;
            }
            else
            {
                Tipo_de_cambioLabel.Visible = false;
                Tipo_de_cambioTextBox.Visible = false;
                Tipo_de_cambioTextBox.Text = null;
            }
            //CAE
            CompletarCAE(c);
            //Datos de emisión
            PeriodicidadEmisionDropDownList.SelectedValue = Comprobante.PeriodicidadEmision;
            IdDestinoComprobanteDropDownList.SelectedValue = Comprobante.IdDestinoComprobante;
            FechaProximaEmisionDatePickerWebUserControl.Text = Comprobante.FechaProximaEmision.ToString("yyyyMMdd");
            CantidadComprobantesAEmitirTextBox.Text = Comprobante.CantidadComprobantesAEmitir.ToString();
            CantidadComprobantesEmitidosTextBox.Text = Comprobante.CantidadComprobantesEmitidos.ToString();
            CantidadDiasFechaVtoTextBox.Text = Comprobante.CantidadDiasFechaVto.ToString();
            //Esquema contable
            EsquemaContable.Completar(Comprobante);

            BindearDropDownLists();
        }
        private void CompletarCAE(FeaEntidades.Turismo.comprobante c)
        {
            CAETextBox.Text = c.cabecera.informacion_comprobante.cae;
            FechaCAEObtencionDatePickerWebUserControl.Text = c.cabecera.informacion_comprobante.fecha_obtencion_cae;
            FechaCAEVencimientoDatePickerWebUserControl.Text = c.cabecera.informacion_comprobante.fecha_vencimiento_cae;
            ResultadoTextBox.Text = c.cabecera.informacion_comprobante.resultado;
            MotivoTextBox.Text = c.cabecera.informacion_comprobante.motivo;
        }
        private void CompletarComprobante(FeaEntidades.Turismo.comprobante c)
        {
            Numero_ComprobanteTextBox.Text = Convert.ToString(c.cabecera.informacion_comprobante.numero_comprobante);
            FechaEmisionDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_comprobante.fecha_emision);
            FechaVencimientoDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_comprobante.fecha_vencimiento);
            FechaServDesdeDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_comprobante.fecha_serv_desde);
            FechaServHastaDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_comprobante.fecha_serv_hasta);
            Condicion_De_PagoTextBox.Text = Convert.ToString(c.cabecera.informacion_comprobante.condicion_de_pago);
        }
        private void CompletarCabecera(FeaEntidades.Turismo.comprobante c)
        {
            try
            {
                PuntoVtaDropDownList.SelectedValue = Convert.ToString(c.cabecera.informacion_comprobante.punto_de_venta);
                int auxPV = Convert.ToInt32(c.cabecera.informacion_comprobante.punto_de_venta);
                ViewState["PuntoVenta"] = auxPV;
                DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprobante.tipo_de_comprobante)));
                Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprobante.tipo_de_comprobante)));
            }
            catch (NullReferenceException)//detalle_factura.xml
            {
                PuntoVtaDropDownList.SelectedValue = Convert.ToString(c.cabecera.informacion_comprobante.punto_de_venta);
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                ViewState["PuntoVenta"] = auxPV;
                DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprobante.tipo_de_comprobante)));
            }
        }
        private void CompletarVendedor(FeaEntidades.Turismo.comprobante c)
        {
            if (c.cabecera.informacion_vendedor.razon_social != null)
            {
                Razon_Social_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.razon_social);
            }
            Localidad_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.localidad);
            if (c.cabecera.informacion_vendedor.GLN != 0)
            {
                GLN_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.GLN);
            }
            Email_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.email);
            Cuit_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.cuit);
            Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_vendedor.provincia)));
            Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_vendedor.condicion_IVA)));
            Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_vendedor.condicion_ingresos_brutos)));
            Cp_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.cp);
            Contacto_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.contacto);
            Telefono_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.telefono);
            Codigo_Interno_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.codigo_interno);
            NroIBVendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.nro_ingresos_brutos);
            InicioDeActividadesVendedorDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_vendedor.inicio_de_actividades);
            Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_calle);
            Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_numero);
            Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_piso);
            Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_depto);
            Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_sector);
            Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_torre);
            Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(c.cabecera.informacion_vendedor.domicilio_manzana);
        }
        private void CompletarComprador(FeaEntidades.Turismo.comprobante c)
        {
            if (c.cabecera.informacion_comprador.GLN != 0)
            {
                GLN_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.GLN);
            }
            Codigo_Interno_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.codigo_interno);
            if (!c.cabecera.informacion_comprador.codigo_doc_identificatorio.Equals(70))
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.nro_doc_identificatorio);
            }
            else
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.nro_doc_identificatorio)));
            }
            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Codigo_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Codigo_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.codigo_doc_identificatorio)));
            Denominacion_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.denominacion);
            Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_calle);
            Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_numero);
            Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_piso);
            Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_depto);
            Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_sector);
            Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_torre);
            Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.domicilio_manzana);
            Localidad_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.localidad);
            Cp_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.cp);
            Contacto_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.contacto);
            Email_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.email);
            Telefono_CompradorTextBox.Text = Convert.ToString(c.cabecera.informacion_comprador.telefono);
            InicioDeActividadesCompradorDatePickerWebUserControl.Text = Convert.ToString(c.cabecera.informacion_comprador.inicio_de_actividades);
            Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.provincia)));
            Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.condicion_IVA)));
            CodigoPaisDropDownList.SelectedIndex = CodigoPaisDropDownList.Items.IndexOf(CodigoPaisDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.codigo_Pais)));
            CodigoRelacionReceptorEmisorDropDownList.SelectedIndex = CodigoRelacionReceptorEmisorDropDownList.Items.IndexOf(CodigoRelacionReceptorEmisorDropDownList.Items.FindByValue(Convert.ToString(c.cabecera.informacion_comprador.codigo_Relacion_Receptor_Emisor)));
            if (c.extensiones != null)
            {
                if (c.extensiones.extensiones_destinatarios != null)
                {
                    EmailAvisoVisualizacionTextBox.Text = c.extensiones.extensiones_destinatarios.email;
                }
            }
        }
        private void CompletarResumen(FeaEntidades.Turismo.comprobante c)
        {
            MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(c.resumen.codigo_moneda)));
            Tipo_de_cambioTextBox.Text = Convert.ToString(c.resumen.tipo_de_cambio);
            if (c.resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(c.resumen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(c.resumen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_factura);
                if (c.resumen.importe_total_impuestos_nacionalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_impuestos_nacionales);
                }
                else
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importe_total_impuestos_municipalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_impuestos_municipales);
                }
                else
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importe_total_impuestos_internosSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_impuestos_internos);
                }
                else
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importe_total_ingresos_brutosSpecified.Equals(true))
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(c.resumen.importe_total_ingresos_brutos);
                }
                else
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
                }
            }
            else
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_factura);
                if (c.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
                }
                else
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_impuestos_municipales);
                }
                else
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_impuestos_internos);
                }
                else
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
                }
                if (c.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified.Equals(true))
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(c.resumen.importes_moneda_origen.importe_total_ingresos_brutos);
                }
                else
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
                }
            }
        }
        protected void MonedaComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private FeaEntidades.Turismo.comprobante GenerarLote()
        {
            FeaEntidades.Turismo.comprobante comp = new FeaEntidades.Turismo.comprobante();
            FeaEntidades.Turismo.cabecera compcab = new FeaEntidades.Turismo.cabecera();

            FeaEntidades.Turismo.informacion_comprador infcompra = new FeaEntidades.Turismo.informacion_comprador();

            if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Tipo_de_cambioLabel.Visible = true;
                Tipo_de_cambioTextBox.Visible = true;
            }
            else
            {
                Tipo_de_cambioLabel.Visible = false;
                Tipo_de_cambioTextBox.Visible = false;
                Tipo_de_cambioTextBox.Text = null;
            }

            GenerarInfoComprador(compcab, infcompra);
            FeaEntidades.Turismo.informacion_comprobante infcomprob = GenerarInfoComprobante();
            GenerarReferencias(infcomprob);
            GenerarInfoExtensionesComerciales(comp);
            GenerarInfoExtensionesCamaraFacturas(comp);
            GenerarInfoExtensionesDestinatarios(comp);
            compcab.informacion_comprobante = infcomprob;
            GenerarInfoVendedor(compcab);
            comp.cabecera = compcab;

            string idtipo = "Turismo";
            FeaEntidades.Turismo.detalle det = DetalleLinea.GenerarDetalles(MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text, idtipo, Tipo_De_ComprobanteDropDownList.SelectedValue, false);

            det.comentarios = ComentariosTextBox.Text;
            comp.detalle = det;

            FeaEntidades.Turismo.resumen r = new FeaEntidades.Turismo.resumen();
            if (Tipo_de_cambioTextBox.Text != string.Empty)
            {
                r.tipo_de_cambio = Convert.ToDouble(Tipo_de_cambioTextBox.Text);
            }
            else
            {
                r.tipo_de_cambio = 1;
            }
            r.codigo_moneda = MonedaComprobanteDropDownList.SelectedValue;

            if (MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            //Moneda local
            {
                GenerarImportesMonedaLocal(r);
            }
            else
            //Moneda extranjera
            {
                GenerarImportesMonedaExtranjera(r);
            }

            r.observaciones = Observaciones_ResumenTextBox.Text;
            comp.resumen = r;
            System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ImpuestosGlobales.Lista;
            ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
            return comp;
        }
        private void GenerarInfoExtensionesDestinatarios(FeaEntidades.Turismo.comprobante comp)
        {
            if (!EmailAvisoVisualizacionTextBox.Text.Equals(string.Empty))
            {
                comp.extensionesSpecified = true;
                if (comp.extensiones == null)
                {
                    comp.extensiones = new FeaEntidades.Turismo.extensiones();
                }
                comp.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                comp.extensiones.extensiones_destinatarios.email = EmailAvisoVisualizacionTextBox.Text;
            }
        }
        private void GenerarInfoExtensionesComerciales(FeaEntidades.Turismo.comprobante comp)
        {
            if (!DatosComerciales.Texto.Equals(string.Empty))
            {
                comp.extensionesSpecified = true;
                if (comp.extensiones == null)
                {
                    comp.extensiones = new FeaEntidades.Turismo.extensiones();
                }
                string textoSinSaltoDeLinea = DatosComerciales.Texto.Replace(System.Environment.NewLine, "<br>");
                comp.extensiones.extensiones_datos_comerciales = RN.Funciones.ConvertToHex(textoSinSaltoDeLinea);
            }
        }
        private void GenerarInfoExtensionesCamaraFacturas(FeaEntidades.Turismo.comprobante comp)
        {
            if (!PasswordAvisoVisualizacionTextBox.Text.Equals(string.Empty))
            {
                comp.extensionesSpecified = true;
                if (comp.extensiones == null)
                {
                    comp.extensiones = new FeaEntidades.Turismo.extensiones();
                }
                if (comp.extensiones.extensiones_camara_facturas == null)
                {
                    comp.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                }
                comp.extensiones.extensiones_camara_facturas.clave_de_vinculacion = RN.Funciones.CreateMD5Hash(PasswordAvisoVisualizacionTextBox.Text);
                comp.extensiones.extensiones_camara_facturasSpecified = true;
            }
        }
        private FeaEntidades.Turismo.informacion_comprobante GenerarInfoComprobante()
        {
            FeaEntidades.Turismo.informacion_comprobante infcomprob = new FeaEntidades.Turismo.informacion_comprobante();
            infcomprob.tipo_de_comprobante = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue);
            infcomprob.numero_comprobante = Convert.ToInt64(Numero_ComprobanteTextBox.Text);
            infcomprob.punto_de_venta = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
            infcomprob.fecha_emision = FechaEmisionDatePickerWebUserControl.Text;
            GenerarInfoFechaVto(infcomprob);
            infcomprob.fecha_serv_desde = FechaServDesdeDatePickerWebUserControl.Text;
            infcomprob.fecha_serv_hasta = FechaServHastaDatePickerWebUserControl.Text;

            if (!Condicion_De_PagoTextBox.Text.Equals(string.Empty))
            {
                infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
                infcomprob.condicion_de_pagoSpecified = true;
            }
            else
            {
                infcomprob.condicion_de_pago = string.Empty;
                infcomprob.condicion_de_pagoSpecified = false;
            }

            if (!CAETextBox.Text.Equals(string.Empty))
            {
                infcomprob.cae = CAETextBox.Text;
                infcomprob.caeSpecified = true;
            }
            else
            {
                infcomprob.cae = null;
                infcomprob.caeSpecified = false;
            }
            if (!FechaCAEObtencionDatePickerWebUserControl.Text.ToString().Equals(string.Empty))
            {
                infcomprob.fecha_obtencion_cae = FechaCAEObtencionDatePickerWebUserControl.Text;
                infcomprob.fecha_obtencion_caeSpecified = true;
            }
            else
            {
                infcomprob.fecha_obtencion_cae = null;
                infcomprob.fecha_obtencion_caeSpecified = false;
            }

            if (!FechaCAEVencimientoDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                infcomprob.fecha_vencimiento_cae = FechaCAEVencimientoDatePickerWebUserControl.Text;
                infcomprob.fecha_vencimiento_caeSpecified = true;
            }
            else
            {
                infcomprob.fecha_vencimiento_cae = null;
                infcomprob.fecha_vencimiento_caeSpecified = true;
            }
            if (!ResultadoTextBox.Text.Equals(string.Empty))
            {
                infcomprob.resultado = ResultadoTextBox.Text;
            }
            if (!MotivoTextBox.Text.Equals(string.Empty))
            {
                infcomprob.motivo = MotivoTextBox.Text;
            }
            return infcomprob;
        }
        private void GenerarInfoFechaVto(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            if (!FechaVencimientoDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                infcomprob.fecha_vencimiento = FechaVencimientoDatePickerWebUserControl.Text;
            }
        }
        private void GenerarReferencias(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            if (this.InfoReferencias.HayReferencias)
            {
                //infcomprob.referencias = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias[5];
                for (int i = 0; i < this.InfoReferencias.ListaReferencias.Count; i++)
                {
                    if (infcomprob.tipo_de_comprobante.Equals(19))
                    {
                        throw new Exception("Las referencias no se deben informar para facturas de exportación(19). Sólo para notas de débito y/o crédito (20 y 21).");
                    }
                    infcomprob.referencias[i] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                    infcomprob.referencias[i].descripcioncodigo_de_referencia = this.InfoReferencias.ListaReferencias[i].descripcioncodigo_de_referencia;
                    infcomprob.referencias[i].dato_de_referencia = this.InfoReferencias.ListaReferencias[i].dato_de_referencia;
                    infcomprob.referencias[i].codigo_de_referencia = this.InfoReferencias.ListaReferencias[i].codigo_de_referencia;
                }
            }
        }
        private void GenerarInfoVendedor(FeaEntidades.Turismo.cabecera compcab)
        {
            FeaEntidades.Turismo.informacion_vendedor infovend = new FeaEntidades.Turismo.informacion_vendedor();
            if (!GLN_VendedorTextBox.Text.Equals(string.Empty))
            {
                infovend.GLN = Convert.ToInt64(GLN_VendedorTextBox.Text);
                infovend.GLNSpecified = true;
            }
            infovend.codigo_interno = Codigo_Interno_VendedorTextBox.Text;
            infovend.razon_social = Razon_Social_VendedorTextBox.Text;
            infovend.cuit = Convert.ToInt64(Cuit_VendedorTextBox.Text);
            int auxCondIVAVend = Convert.ToInt32(Condicion_IVA_VendedorDropDownList.SelectedValue);
            if (!auxCondIVAVend.Equals(0))
            {
                infovend.condicion_IVASpecified = true;
                infovend.condicion_IVA = auxCondIVAVend;
            }

            try
            {
                infovend.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue);
                infovend.nro_ingresos_brutos = NroIBVendedorTextBox.Text;
            }
            catch
            {

            }
            finally
            {
                if (infovend.condicion_ingresos_brutos != 0)
                {
                    infovend.condicion_ingresos_brutosSpecified = true;
                }
                else
                {
                    infovend.nro_ingresos_brutos = null;
                }
            }
            infovend.inicio_de_actividades = InicioDeActividadesVendedorDatePickerWebUserControl.Text;
            infovend.contacto = Contacto_VendedorTextBox.Text;
            infovend.domicilio_calle = Domicilio_Calle_VendedorTextBox.Text;
            infovend.domicilio_numero = Domicilio_Numero_VendedorTextBox.Text;
            infovend.domicilio_piso = Domicilio_Piso_VendedorTextBox.Text;
            infovend.domicilio_depto = Domicilio_Depto_VendedorTextBox.Text;
            infovend.domicilio_sector = Domicilio_Sector_VendedorTextBox.Text;
            infovend.domicilio_torre = Domicilio_Torre_VendedorTextBox.Text;
            infovend.domicilio_manzana = Domicilio_Manzana_VendedorTextBox.Text;
            infovend.localidad = Localidad_VendedorTextBox.Text;
            string auxCodProvVend = Convert.ToString(Provincia_VendedorDropDownList.SelectedValue);
            if (!auxCodProvVend.Equals("0"))
            {
                infovend.provincia = auxCodProvVend;
            }
            infovend.cp = Cp_VendedorTextBox.Text;
            infovend.email = Email_VendedorTextBox.Text;
            infovend.telefono = Telefono_VendedorTextBox.Text;
            compcab.informacion_vendedor = infovend;
        }
        private void GenerarInfoComprador(FeaEntidades.Turismo.cabecera compcab, FeaEntidades.Turismo.informacion_comprador infcompra)
        {
            if (!GLN_CompradorTextBox.Text.Equals(string.Empty))
            {
                infcompra.GLN = Convert.ToInt64(GLN_CompradorTextBox.Text);
                infcompra.GLNSpecified = true;
            }
            infcompra.codigo_interno = Codigo_Interno_CompradorTextBox.Text;
            try
            {
                infcompra.codigo_doc_identificatorio = Convert.ToInt32(Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
            }
            catch (FormatException)
            {
                throw new Exception("Tipo de documento del comprador no informado");
            }

            if (Nro_Doc_Identificatorio_CompradorTextBox.Visible)
            {
                try
                {
                    infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorTextBox.Text);
                }
                catch (FormatException)
                {
                    throw new Exception("Nro documento del comprador no informado");
                }
            }
            else
            {
                try
                {
                    infcompra.nro_doc_identificatorio = Convert.ToInt64(Nro_Doc_Identificatorio_CompradorDropDownList.SelectedValue);
                }
                catch (FormatException)
                {
                    throw new Exception("Nro documento del comprador para exportación no informado");
                }
            }
            infcompra.denominacion = Denominacion_CompradorTextBox.Text;
            int auxCondIVACompra = Convert.ToInt32(Condicion_IVA_CompradorDropDownList.SelectedValue);
            if (!auxCondIVACompra.Equals(0))
            {
                infcompra.condicion_IVASpecified = true;
                infcompra.condicion_IVA = auxCondIVACompra;
            }
            //infcompra.condicion_ingresos_brutosSpecified = true;
            //infcompra.condicion_ingresos_brutos = Convert.ToInt32(Condicion_Ingresos_Brutos_CompradorDropDownList.SelectedValue);
            //infcompra.nro_ingresos_brutos
            infcompra.inicio_de_actividades = InicioDeActividadesCompradorDatePickerWebUserControl.Text;
            infcompra.contacto = Contacto_CompradorTextBox.Text;

            
            infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
            infcompra.domicilio_numero = Domicilio_Numero_CompradorTextBox.Text;
            
            infcompra.domicilio_piso = Domicilio_Piso_CompradorTextBox.Text;
            infcompra.domicilio_depto = Domicilio_Depto_CompradorTextBox.Text;
            infcompra.domicilio_sector = Domicilio_Sector_CompradorTextBox.Text;
            infcompra.domicilio_torre = Domicilio_Torre_CompradorTextBox.Text;
            infcompra.domicilio_manzana = Domicilio_Manzana_CompradorTextBox.Text;
            infcompra.localidad = Localidad_CompradorTextBox.Text;
            string auxCodProvCompra = Convert.ToString(Provincia_CompradorDropDownList.SelectedValue);
            infcompra.provincia = auxCodProvCompra;
            
            infcompra.cp = Cp_CompradorTextBox.Text;
            infcompra.email = Email_CompradorTextBox.Text;
            infcompra.telefono = Telefono_CompradorTextBox.Text;

            compcab.informacion_comprador = infcompra;
        }
        private void GenerarImportesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r)
        {
            double tipodecambio = Convert.ToDouble(Tipo_de_cambioTextBox.Text);

            FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();

            GenerarImporteTotalNetoGravadoExtranjera(r, tipodecambio, rimo);
            GenerarImporteTotalConceptoNoGravadoExtranjera(r, tipodecambio, rimo);
            GenerarImporteOperacionesExentasExtranjera(r, tipodecambio, rimo);
            GenerarImpuestoLiqExtranjera(r, tipodecambio, rimo);
            GenerarImpuestoLiqRNIExtranjera(r, tipodecambio, rimo);

            GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
            GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
            GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
            GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
            
            r.importe_total_factura = 0;
            rimo.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
            r.importes_moneda_origen = rimo;
        }
        private void GenerarImpuestoLiqRNIExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
        }
        private void GenerarImpuestoLiqExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
        }
        private void GenerarImporteOperacionesExentasExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalConceptoNoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalNetoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
            rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalImpuestosInternosMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_impuestos_internos = 0;
            rimo.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
            if (rimo.importe_total_impuestos_internos != 0)
            {
                r.importe_total_impuestos_internosSpecified = true;
                rimo.importe_total_impuestos_internosSpecified = true;
            }
        }
        private void GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_impuestos_municipales = 0;
            rimo.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
            if (rimo.importe_total_impuestos_municipales != 0)
            {
                r.importe_total_impuestos_municipalesSpecified = true;
                rimo.importe_total_impuestos_municipalesSpecified = true;
            }
        }
        private void GenerarImporteTotalIngresosBrutosMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_ingresos_brutos = 0;
            rimo.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
            if (rimo.importe_total_ingresos_brutos != 0)
            {
                r.importe_total_ingresos_brutosSpecified = true;
                rimo.importe_total_ingresos_brutosSpecified = true;
            }
        }
        private void GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            r.importe_total_impuestos_nacionales = 0;
            rimo.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
            if (rimo.importe_total_impuestos_nacionales != 0)
            {
                r.importe_total_impuestos_nacionalesSpecified = true;
                rimo.importe_total_impuestos_nacionalesSpecified = true;
            }
        }
        private void GenerarImportesMonedaLocal(FeaEntidades.InterFacturas.resumen r)
        {
            GenerarImporteTotalNetoGravado(r);
            GenerarImporteTotalConceptoNoGravado(r);
            GenerarImporteOperacionesExentas(r);
            GenerarImpuestoLiq(r);
            GenerarImpuestoLiqRNI(r);

            double importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
            GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);

            double importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
            GenerarImporteTotalIngresosBrutos(r);

            double importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
            GenerarImporteTotalImpuestosMunicipales(r);

            double importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
            GenerarImporteTotalImpuestosInternos(r);

            r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
        }
        private void GenerarImpuestoLiqRNI(FeaEntidades.InterFacturas.resumen r)
        {
            r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
        }
        private void GenerarImpuestoLiq(FeaEntidades.InterFacturas.resumen r)
        {
            r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
        }
        private void GenerarImporteOperacionesExentas(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalConceptoNoGravado(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalNetoGravado(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
        }
        private void GenerarImporteTotalImpuestosInternos(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
            if (r.importe_total_impuestos_internos != 0)
            {
                r.importe_total_impuestos_internosSpecified = true;
            }
        }
        private void GenerarImporteTotalImpuestosMunicipales(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
            if (r.importe_total_impuestos_municipales != 0)
            {
                r.importe_total_impuestos_municipalesSpecified = true;
            }
        }
        private void GenerarImporteTotalIngresosBrutos(FeaEntidades.InterFacturas.resumen r)
        {
            r.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
            if (r.importe_total_ingresos_brutos != 0)
            {
                r.importe_total_ingresos_brutosSpecified = true;
            }
        }
        private static void GenerarImporteTotalImpuestosNacionales(FeaEntidades.InterFacturas.resumen r, double importe_total_impuestos_nacionales)
        {
            r.importe_total_impuestos_nacionales = importe_total_impuestos_nacionales;
            r.importe_total_impuestos_nacionalesSpecified = true;
        }

        private void ActualizarTipoDeCambio()
        {
            if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Tipo_de_cambioLabel.Visible = true;
                Tipo_de_cambioTextBox.Visible = true;
            }
            else
            {
                Tipo_de_cambioLabel.Visible = false;
                Tipo_de_cambioTextBox.Visible = false;
                Tipo_de_cambioTextBox.Text = null;
            }
        }
        protected void tipoCambioUpdatePanel_Load(object sender, EventArgs e)
        {
            ActualizarTipoDeCambio();
        }
        public DetalleCTConsulta Articulos
        {
            get
            {
                return this.DetalleLinea;
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {

        }
        protected void PuntoVtaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void Tipo_De_ComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}