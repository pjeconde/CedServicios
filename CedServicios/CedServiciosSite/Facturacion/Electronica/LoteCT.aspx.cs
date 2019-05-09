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
using System.Net;

namespace CedServicios.Site.Facturacion.Electronica
{
	public partial class LoteCT : System.Web.UI.Page
	{
		#region Variables
		string gvUniqueID = String.Empty;
		System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
		#endregion
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Session.Remove("ComprobanteATratar");
            Session.Remove("EsComprobanteOriginal");
        }
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
                    Session.Remove("FaltaCalcularTotales");
                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["CaT"] == "Venta")
                        {
                            Session["ComprobanteATratar"] = new Entidades.ComprobanteATratar("Venta");
                        }
                    }
                    Entidades.ComprobanteATratar comprobanteATratar = (Entidades.ComprobanteATratar)Session["ComprobanteATratar"];
                    ViewState["ComprobanteATratarOrig"] = (Entidades.ComprobanteATratar)Session["ComprobanteATratar"];
                    TratamientoTextBox.Text = comprobanteATratar.Tratamiento.ToString();
                    string descrTratamiento = String.Empty;
                    switch (TratamientoTextBox.Text)
                    {
                        case "Alta":
                            descrTratamiento = "Alta";
                            break;
                        case "Clonado":
                            descrTratamiento = "Alta";
                            break;
                        case "Modificacion":
                            descrTratamiento = "Modificación";
                            break;
                        default:
                            WebForms.Excepciones.Redireccionar(new EX.Validaciones.ValorNoInfo("Tratamiento del Comprobante"), "~/NotificacionDeExcepcion.aspx");
                            break;
                    }
                    IdNaturalezaComprobanteTextBox.Text = comprobanteATratar.Comprobante.NaturalezaComprobante.Id;
                    if (IdNaturalezaComprobanteTextBox.Text == "Venta")
                    {
                        TituloPaginaLabel.Text = descrTratamiento + " de Comprobante";
                        DatosComprobanteLabel.Text = "COMPROBANTE DE VENTA - TURISMO (electrónica)";
                        if (descrTratamiento == "Alta")
                        {
                            ProximoNroComprobanteLinkButton.Visible = true;
                        }
                    }
                    else
                    {
                        WebForms.Excepciones.Redireccionar(new EX.Validaciones.ValorNoInfo("Naturaleza del Comprobante"), "~/NotificacionDeExcepcion.aspx");
                    }

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
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaTurismo();
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                    Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                    Condicion_IVA_CompradorDropDownList.DataValueField = "Codigo";
                    Condicion_IVA_CompradorDropDownList.DataTextField = "Descr";
                    Condicion_IVA_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.ListaTurismo();
                    Condicion_IVA_CompradorDropDownList.DataBind();
                    Provincia_CompradorDropDownList.DataValueField = "Codigo";
                    Provincia_CompradorDropDownList.DataTextField = "Descr";
                    Provincia_CompradorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                    Provincia_CompradorDropDownList.DataBind();
                    CodigoPaisDropDownList.DataValueField = "Codigo";
                    CodigoPaisDropDownList.DataTextField = "Descr";
                    CodigoPaisDropDownList.DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();
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
                    MonedaComprobanteDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.ListaTurismo();
                    MonedaComprobanteDropDownList.DataBind();

                    //DETALLE DE ARTÍCULOS / SERVICIOS
                    DetalleLinea.IdNaturalezaComprobante = IdNaturalezaComprobanteTextBox.Text;

                    #region Personalización campos vendedor y comprador para VENTAS
                    //VendedorUpdatePanel.Visible = false;
                    pBody.Enabled = false;
                    ComprobantePanel.Visible = false;
                    if (sesion.Usuario.Id != null)
                    {
                        CompradorDropDownList.Enabled = true;
                    }
                    if (sesion.Cuit.Nro != null && sesion.Cuit.Nro != "")
                    {
                        Entidades.Cuit v = ((Entidades.Sesion)Session["Sesion"]).Cuit;
                        Cuit_VendedorTextBox.Text = v.Nro.ToString();
                        Razon_Social_VendedorTextBox.Text = v.RazonSocial;

                        Domicilio_Calle_VendedorTextBox.Text = v.Domicilio.Calle;
                        Domicilio_Numero_VendedorTextBox.Text = v.Domicilio.Nro;
                        Domicilio_Piso_VendedorTextBox.Text = v.Domicilio.Piso;
                        Domicilio_Depto_VendedorTextBox.Text = v.Domicilio.Depto;
                        Domicilio_Sector_VendedorTextBox.Text = v.Domicilio.Sector;
                        Domicilio_Torre_VendedorTextBox.Text = v.Domicilio.Torre;
                        Domicilio_Manzana_VendedorTextBox.Text = v.Domicilio.Manzana;
                        Localidad_VendedorTextBox.Text = v.Domicilio.Localidad;
                        Provincia_VendedorDropDownList.SelectedValue = v.Domicilio.Provincia.Id;
                        Cp_VendedorTextBox.Text = v.Domicilio.CodPost;
                        Contacto_VendedorTextBox.Text = v.Contacto.Nombre;
                        Email_VendedorTextBox.Text = v.Contacto.Email;
                        Telefono_VendedorTextBox.Text = v.Contacto.Telefono.ToString();
                        Condicion_IVA_VendedorDropDownList.SelectedValue = v.DatosImpositivos.IdCondIVA.ToString();
                        NroIBVendedorTextBox.Text = v.DatosImpositivos.NroIngBrutos.ToString();
                        Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue = v.DatosImpositivos.IdCondIngBrutos.ToString();
                        if (!v.DatosIdentificatorios.GLN.ToString().Equals("0"))
                        {
                            GLN_VendedorTextBox.Text = v.DatosIdentificatorios.GLN.ToString();
                        }
                        Codigo_Interno_VendedorTextBox.Text = v.DatosIdentificatorios.CodigoInterno;
                        InicioDeActividadesVendedorDatePickerWebUserControl.Text = v.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd");
                    }
                    System.Collections.Generic.List<Entidades.Persona> listacompradores = ((Entidades.Sesion)Session["Sesion"]).ClientesDelCuit;
                    if (listacompradores.Count > 0)
                    {
                        CompradorDropDownList.Visible = true;
                        CompradorDropDownList.DataValueField = "ClavePrimaria";
                        CompradorDropDownList.DataTextField = "RazonSocial";
                        Entidades.Persona persona = new Entidades.Persona();
                        System.Collections.Generic.List<Entidades.Persona> personalist = new System.Collections.Generic.List<Entidades.Persona>();
                        persona.RazonSocial = "";
                        personalist.Add(persona);
                        personalist.AddRange(listacompradores);
                        CompradorDropDownList.DataSource = personalist;
                        CompradorDropDownList.DataBind();
                    }
                    else
                    {
                        CompradorDropDownList.Visible = false;
                        CompradorDropDownList.DataSource = null;
                    }
                    PuntoVtaDropDownList.Enabled = true;
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPuntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVtaVigentes.FindAll(delegate(Entidades.PuntoVta pv)
                    {
                        return (pv.IdTipoPuntoVta == "Turismo");
                    });
                    if (listaPuntoVta.Count == 0)
                    {
                        WebForms.Excepciones.Redireccionar(new EX.Validaciones.ValorNoInfo("Puntos de Venta de Turismo"), "~/NotificacionDeExcepcion.aspx");
                    }
                    PuntoVtaDropDownList.Visible = true;
                    PuntoVtaDropDownList.DataValueField = "Nro";
                    PuntoVtaDropDownList.DataTextField = "Descr";
                    PuntoVtaDropDownList.DataSource = listaPuntoVta;
                    PuntoVtaDropDownList.DataBind();
                    PuntoVtaDropDownList_SelectedIndexChanged(PuntoVtaDropDownList, new EventArgs());

                    VerificarDatosVendedorDelPuntoVta();
                    #endregion

                    BindearDropDownLists();

                    MonedaComprobanteDropDownList.Enabled = true;

                    Numero_ComprobanteTextBox.Attributes.Add("autocomplete", "off");

                    try
                    {
                        //Tratamiento de clonado y modificación
                        if (comprobanteATratar.Tratamiento != Entidades.Enum.TratamientoComprobante.Alta)
                        {
                            FeaEntidades.Turismo.comprobante lote = new FeaEntidades.Turismo.comprobante();
                            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                            byte[] bytes = new byte[comprobanteATratar.Comprobante.Request.Length * sizeof(char)];
                            System.Buffer.BlockCopy(comprobanteATratar.Comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            lote = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
                            if (lote != null)
                            {
                                LlenarCampos(lote, comprobanteATratar);
                                if (comprobanteATratar.Tratamiento == Entidades.Enum.TratamientoComprobante.Clonado) BorrarCamposNoClonables();
                            }

                            //Informar datos actualizados del cuit.
                            VerificarDatosVendedorDelPuntoVta();
                        }
                    }
                    catch
                    {
                    }

                    AyudaFechaEmisionCalcular();

                    DescargarPDFPanel.Visible = false;
                    DescargarPDFButton.Visible = true;
                }
            }
        }
        private void VerificarDatosVendedorDelPuntoVta()
        {
            //Verificar si el Punto de Venta tiene datos especificados para el vendedor.
            Entidades.Sesion s = (Entidades.Sesion)Session["Sesion"];
            List<Entidades.UN> listaUN = s.Cuit.UNs.FindAll(delegate(Entidades.UN un)
            {
                return un.Id == s.UN.Id;
            });
            if (listaUN.Count != 0)
            {
                List<Entidades.PuntoVta> listaPV = listaUN[0].PuntosVtaVigentes.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return pv.Nro == Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                });
                if (listaPV.Count != 0)
                {
                    if (listaPV[0].UsaSetPropioDeDatosCuit == true)
                    {
                        Entidades.PuntoVta v = listaPV[0];
                        //Cuit y Razon_Social no se ajustan.
                        Domicilio_Calle_VendedorTextBox.Text = v.Domicilio.Calle;
                        Domicilio_Numero_VendedorTextBox.Text = v.Domicilio.Nro;
                        Domicilio_Piso_VendedorTextBox.Text = v.Domicilio.Piso;
                        Domicilio_Depto_VendedorTextBox.Text = v.Domicilio.Depto;
                        Domicilio_Sector_VendedorTextBox.Text = v.Domicilio.Sector;
                        Domicilio_Torre_VendedorTextBox.Text = v.Domicilio.Torre;
                        Domicilio_Manzana_VendedorTextBox.Text = v.Domicilio.Manzana;
                        Localidad_VendedorTextBox.Text = v.Domicilio.Localidad;
                        Provincia_VendedorDropDownList.SelectedValue = v.Domicilio.Provincia.Id;
                        Cp_VendedorTextBox.Text = v.Domicilio.CodPost;
                        Contacto_VendedorTextBox.Text = v.Contacto.Nombre;
                        Email_VendedorTextBox.Text = v.Contacto.Email;
                        Telefono_VendedorTextBox.Text = v.Contacto.Telefono.ToString();
                        Condicion_IVA_VendedorDropDownList.SelectedValue = v.DatosImpositivos.IdCondIVA.ToString();
                        NroIBVendedorTextBox.Text = v.DatosImpositivos.NroIngBrutos.ToString();
                        Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue = v.DatosImpositivos.IdCondIngBrutos.ToString();
                        if (!v.DatosIdentificatorios.GLN.ToString().Equals("0"))
                        {
                            GLN_VendedorTextBox.Text = v.DatosIdentificatorios.GLN.ToString();
                        }
                        Codigo_Interno_VendedorTextBox.Text = v.DatosIdentificatorios.CodigoInterno;
                        InicioDeActividadesVendedorDatePickerWebUserControl.Text = v.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd");

                    }
                }
            }
        }
        private void AyudaFechaEmisionCalcular()
        {
            string texto = "";
            DateTime fecha = DateTime.Now;
            
            string Ayuda1 = "<a href='javascript:void(0)' id='Ayuda1' role='button' class='popover-test' data-html='true' title='Fecha de Emisión' data-placement='auto' style='width: 200px'";
            texto = "Para turismo la fecha de emisión permitida es del " + (fecha.AddDays(-10)).ToString("dd/MM/yyyy") + " al " + (fecha.AddDays(10)).ToString("dd/MM/yyyy");
            //texto += "El formato válido es de 8 dígitos: YYYYMMDD (Año Mes Día).";
            Ayuda1 += " data-content='" + texto + "'> ";
            Ayuda1 += "<span class='glyphicon glyphicon-info-sign gi-1x' style='vertical-align: inherit;'></span></a>";
            AyudaFechaEmision.Text = Ayuda1; 
        }

		private void BindearDropDownLists()
		{
            InfoReferencias.BindearDropDownLists();
			ImpuestosGlobales.BindearDropDownLists();
			DetalleLinea.BindearDropDownLists();
		}

		private void LeerXmlLote(out FeaEntidades.Turismo.comprobante lc, System.IO.MemoryStream ms)
		{
            lc = new FeaEntidades.Turismo.comprobante();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
            lc = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
        }
        private void LeerXmlComprobante(out FeaEntidades.Turismo.comprobante lc, System.IO.MemoryStream ms)
		{
            lc = new FeaEntidades.Turismo.comprobante();
			ms.Seek(0, System.IO.SeekOrigin.Begin);
			FeaEntidades.Turismo.comprobante c = new FeaEntidades.Turismo.comprobante();
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
			c = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
			lc = c;
		}

        private void LlenarCampos(FeaEntidades.Turismo.comprobante comprobante, Entidades.ComprobanteATratar ComprobanteATratar)
        {
            LlenarCampos(comprobante);
        }
        private void LlenarCampos(FeaEntidades.Turismo.comprobante comprobante)
        {
            #region Ajuste de controles
            if (IdNaturalezaComprobanteTextBox.Text.IndexOf("Venta") != -1)
            {
                try
                {
                    PuntoVtaDropDownList.SelectedValue = Convert.ToString(comprobante.cabecera.informacion_comprobante.punto_de_venta);
                }
                catch (NullReferenceException)
                {
                    PuntoVtaDropDownList.SelectedValue = Convert.ToString(comprobante.cabecera.informacion_comprobante.punto_de_venta);
                }
                PuntoVtaDropDownList_SelectedIndexChanged(PuntoVtaDropDownList, new EventArgs());
            }
            else
            {
                PuntoVtaTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.punto_de_venta);
            }
            if (!comprobante.resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
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
            #endregion
            #region CompletarCabecera
            if (IdNaturalezaComprobanteTextBox.Text.IndexOf("Venta") != -1)
            {
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                ViewState["PuntoVenta"] = auxPV;
                DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                ImpuestosGlobales.PuntoDeVenta = Convert.ToString(auxPV);
                InfoReferencias.PuntoDeVenta = Convert.ToString(auxPV);
            }
            else
            {
                DetalleLinea.PuntoDeVenta = "";
                ImpuestosGlobales.PuntoDeVenta = "";
                InfoReferencias.PuntoDeVenta = "";
            }
            Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprobante.tipo_de_comprobante)));
            #endregion
            #region CompletarComprobante
            Numero_ComprobanteTextBox.Text = Convert.ToString(Math.Abs(comprobante.cabecera.informacion_comprobante.numero_comprobante));
            FechaEmisionDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.fecha_emision);
            FechaVencimientoDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.fecha_vencimiento);
            FechaServDesdeDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.fecha_serv_desde);
            FechaServHastaDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.fecha_serv_hasta);
            Condicion_De_PagoTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprobante.condicion_de_pago);
            #endregion
            #region CompletarComprador
            if (comprobante.cabecera.informacion_comprador.GLN != 0)
            {
                GLN_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.GLN);
            }
            Codigo_Interno_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.codigo_interno);
            if (!comprobante.cabecera.informacion_comprador.codigo_doc_identificatorio.Equals(70))
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.nro_doc_identificatorio_afip);
            }
            else
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.nro_doc_identificatorio_afip)));
            }
            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Codigo_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Codigo_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.codigo_doc_identificatorio)));
            Denominacion_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.denominacion);
            Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_calle);
            Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_numero);
            Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_piso);
            Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_depto);
            Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_sector);
            Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_torre);
            Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.domicilio_manzana);
            Localidad_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.localidad);
            Cp_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.cp);
            Contacto_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.contacto);
            Email_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.email);
            Telefono_CompradorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.telefono);
            InicioDeActividadesCompradorDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_comprador.inicio_de_actividades);
            Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.provincia)));
            Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.condicion_IVA)));
            if (comprobante.extensiones != null)
            {
                if (comprobante.extensiones.extensiones_destinatarios != null)
                {
                    EmailAvisoVisualizacionTextBox.Text = comprobante.extensiones.extensiones_destinatarios.email;
                }
            }
            CodigoPaisDropDownList.SelectedIndex = CodigoPaisDropDownList.Items.IndexOf(CodigoPaisDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.codigo_Pais)));
            CodigoRelacionReceptorEmisorDropDownList.SelectedIndex = CodigoRelacionReceptorEmisorDropDownList.Items.IndexOf(CodigoRelacionReceptorEmisorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_comprador.codigo_Relacion_Receptor_Emisor)));
            #endregion
            #region CompletarVendedor(lote);
            if (comprobante.cabecera.informacion_vendedor.razon_social != null)
            {
                Razon_Social_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.razon_social);
            }
            Localidad_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.localidad);
            if (comprobante.cabecera.informacion_vendedor.GLN != 0)
            {
                GLN_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.GLN);
            }
            Email_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.email);
            Cuit_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.cuit);
            Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_vendedor.provincia)));
            Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_vendedor.condicion_IVA)));
            Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(comprobante.cabecera.informacion_vendedor.condicion_ingresos_brutos)));
            Cp_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.cp);
            Contacto_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.contacto);
            Telefono_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.telefono);
            Codigo_Interno_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.codigo_interno);
            NroIBVendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.nro_ingresos_brutos);
            InicioDeActividadesVendedorDatePickerWebUserControl.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.inicio_de_actividades);
            Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_calle);
            Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_numero);
            Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_piso);
            Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_depto);
            Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_sector);
            Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_torre);
            Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.domicilio_manzana);
            DesambiguacionCuitPaisVendedorTextBox.Text = Convert.ToString(comprobante.cabecera.informacion_vendedor.desambiguacionCuitPais);
            #endregion
            DetalleLinea.CompletarDetalles(comprobante);
            InfoReferencias.CompletarReferencias(comprobante);
            ImpuestosGlobales.Completar(comprobante);
			ComentariosTextBox.Text = comprobante.detalle.comentarios;
            #region CompletarResumen
            MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(comprobante.resumen.codigo_moneda)));
            Tipo_de_cambioTextBox.Text = Convert.ToString(comprobante.resumen.tipo_de_cambio);
            if (comprobante.resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_factura);
                if (comprobante.resumen.importe_total_impuestos_nacionalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_impuestos_nacionales);
                }
                else
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importe_total_impuestos_municipalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_impuestos_municipales);
                }
                else
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importe_total_impuestos_internosSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_impuestos_internos);
                }
                else
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importe_total_ingresos_brutosSpecified.Equals(true))
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_total_ingresos_brutos);
                }
                else
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
                }
            }
            else
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_factura);
                if (comprobante.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
                }
                else
                {
                    Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_impuestos_municipales);
                }
                else
                {
                    Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified.Equals(true))
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_impuestos_internos);
                }
                else
                {
                    Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
                }
                if (comprobante.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified.Equals(true))
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importes_moneda_origen.importe_total_ingresos_brutos);
                }
                else
                {
                    Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
                }
            }
            if (comprobante.resumen.importe_ReintegroSpecified.Equals(true))
            {
                Importe_Total_Reintegros_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.importe_Reintegro);
            }
            else
            {
                Importe_Total_Reintegros_ResumenTextBox.Text = string.Empty;
            }
            #endregion
            Observaciones_ResumenTextBox.Text = Convert.ToString(comprobante.resumen.observaciones);
            #region CompletarCAE
            CAETextBox.Text = comprobante.cabecera.informacion_comprobante.cae;
            FechaCAEObtencionDatePickerWebUserControl.Text = comprobante.cabecera.informacion_comprobante.fecha_obtencion_cae;
            FechaCAEVencimientoDatePickerWebUserControl.Text = comprobante.cabecera.informacion_comprobante.fecha_vencimiento_cae;
            //ResultadoTextBox.Text = comprobante.cabecera.informacion_comprobante.resultado;
            //MotivoTextBox.Text = comprobante.cabecera.informacion_comprobante.motivo;
            #endregion
            BindearDropDownLists();
		}
        private void BorrarCamposFileUpload()
        {
            CAETextBox.Text = string.Empty;
            FechaCAEObtencionDatePickerWebUserControl.Text = string.Empty;
            FechaCAEVencimientoDatePickerWebUserControl.Text = string.Empty;
        }
        private void BorrarCamposNoClonables()
        {
            Numero_ComprobanteTextBox.Text = string.Empty;
            FechaEmisionDatePickerWebUserControl.Text = string.Empty;
            FechaServDesdeDatePickerWebUserControl.Text = string.Empty;
            FechaServHastaDatePickerWebUserControl.Text = string.Empty;
            FechaVencimientoDatePickerWebUserControl.Text = string.Empty;
            CAETextBox.Text = string.Empty;
            FechaCAEObtencionDatePickerWebUserControl.Text = string.Empty;
            FechaCAEVencimientoDatePickerWebUserControl.Text = string.Empty;
        }
		protected void CompradorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			AjustarComprador();
		}
        private void AjustarComprador()
        {
            if (CompradorDropDownList.SelectedValue.ToString() != "\t0\t0\t\t0")
            {
                Entidades.Persona comprador = new Entidades.Persona();
                string[] elementosClavePrimaria = CompradorDropDownList.SelectedValue.ToString().Split('\t');
                comprador.Cuit = elementosClavePrimaria[0];
                comprador.Documento.Tipo.Id = elementosClavePrimaria[1];
                comprador.Documento.Nro = elementosClavePrimaria[2];
                comprador.IdPersona = elementosClavePrimaria[3];
                comprador.DesambiguacionCuitPais = Convert.ToInt32(elementosClavePrimaria[4]);
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                try
                {
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        RN.Persona.LeerPorClavePrimaria(comprador, (Entidades.Sesion)Session["Sesion"]);
                        IdPersonaCompradorTextBox.Text = comprador.IdPersona;
                        DesambiguacionCuitPaisCompradorTextBox.Text = comprador.DesambiguacionCuitPais.ToString();
                        Denominacion_CompradorTextBox.Text = comprador.RazonSocial;
                        Domicilio_Calle_CompradorTextBox.Text = comprador.Domicilio.Calle;
                        Domicilio_Numero_CompradorTextBox.Text = comprador.Domicilio.Nro;
                        Domicilio_Piso_CompradorTextBox.Text = comprador.Domicilio.Piso;
                        Domicilio_Depto_CompradorTextBox.Text = comprador.Domicilio.Depto;
                        Domicilio_Sector_CompradorTextBox.Text = comprador.Domicilio.Sector;
                        Domicilio_Torre_CompradorTextBox.Text = comprador.Domicilio.Torre;
                        Domicilio_Manzana_CompradorTextBox.Text = comprador.Domicilio.Manzana;
                        Localidad_CompradorTextBox.Text = comprador.Domicilio.Localidad;
                        if (comprador.Domicilio.Provincia.Id == "")
                        {
                            Provincia_CompradorDropDownList.SelectedValue = "0";
                        }
                        else
                        {
                            Provincia_CompradorDropDownList.SelectedValue = comprador.Domicilio.Provincia.Id;
                        }
                        Cp_CompradorTextBox.Text = comprador.Domicilio.CodPost;
                        Contacto_CompradorTextBox.Text = comprador.Contacto.Nombre;
                        Email_CompradorTextBox.Text = comprador.Contacto.Email;
                        Telefono_CompradorTextBox.Text = Convert.ToString(comprador.Contacto.Telefono);

                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                        Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                        Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                        Nro_Doc_Identificatorio_CompradorTextBox.Text = comprador.Documento.Nro;
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaTurismo();
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                        if (comprador.Documento.Tipo.Id != null)
                        {
                            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = comprador.Documento.Tipo.Id;
                        }
                        else
                        {
                            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                        }

                        Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.DatosImpositivos.IdCondIVA);
                        //NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
                        //CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
                        string auxGLN = Convert.ToString(comprador.DatosIdentificatorios.GLN);
                        if (!auxGLN.Equals("0"))
                        {
                            GLN_CompradorTextBox.Text = auxGLN;
                        }
                        else
                        {
                            GLN_CompradorTextBox.Text = string.Empty;
                        }
                        IdListaPrecioTextBox.Text = comprador.IdListaPrecioVenta;
                        DetalleLinea.IdListaPrecio = comprador.IdListaPrecioVenta;
                        Codigo_Interno_CompradorTextBox.Text = comprador.DatosIdentificatorios.CodigoInterno;
                        if (comprador.DatosImpositivos.FechaInicioActividades.Equals(new DateTime(9999, 12, 31)) || comprador.DatosImpositivos.FechaInicioActividades.Equals(new DateTime(0001, 01, 01)))
                        {
                            InicioDeActividadesCompradorDatePickerWebUserControl.Text = string.Empty;
                        }
                        else
                        {
                            InicioDeActividadesCompradorDatePickerWebUserControl.Text = comprador.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd");
                        }
                        EmailAvisoVisualizacionTextBox.Text = comprador.EmailAvisoVisualizacion;
                        PasswordAvisoVisualizacionTextBox.Text = comprador.PasswordAvisoVisualizacion;
                    }
                }
                catch (EX.Validaciones.ElementoInexistente)
                {
                    try
                    {
                        if (Funciones.SessionTimeOut(Session))
                        {
                            Response.Redirect("~/SessionTimeout.aspx");
                        }
                        else
                        {
                            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                            Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaTurismo();
                            Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                        }
                    }
                    catch
                    {
                    }
                    ResetearComprador();
                }
            }
        }
		private void ResetearComprador()
		{
			Denominacion_CompradorTextBox.Text = string.Empty;
			Domicilio_Calle_CompradorTextBox.Text = string.Empty;
			Domicilio_Numero_CompradorTextBox.Text = string.Empty;
			Domicilio_Piso_CompradorTextBox.Text = string.Empty;
			Domicilio_Depto_CompradorTextBox.Text = string.Empty;
			Domicilio_Sector_CompradorTextBox.Text = string.Empty;
			Domicilio_Torre_CompradorTextBox.Text = string.Empty;
			Domicilio_Manzana_CompradorTextBox.Text = string.Empty;
			Localidad_CompradorTextBox.Text = string.Empty;
			Provincia_CompradorDropDownList.SelectedValue = Convert.ToString(0);
			Cp_CompradorTextBox.Text = string.Empty;
			Contacto_CompradorTextBox.Text = string.Empty;
			Email_CompradorTextBox.Text = string.Empty;
			Telefono_CompradorTextBox.Text = string.Empty;
			Condicion_IVA_CompradorDropDownList.SelectedValue = Convert.ToString(0);
			//NroIngBrutosTextBox.Text = comprador.NroIngBrutos;
			//CondIngBrutosDropDownList.SelectedValue = Convert.ToString(comprador.IdCondIngBrutos);
			GLN_CompradorTextBox.Text = string.Empty;
            IdListaPrecioTextBox.Text = string.Empty;
			Codigo_Interno_CompradorTextBox.Text = string.Empty;
			InicioDeActividadesCompradorDatePickerWebUserControl.Text = string.Empty;
			EmailAvisoVisualizacionTextBox.Text = string.Empty;
			PasswordAvisoVisualizacionTextBox.Text = string.Empty;
		}
		protected void VendedorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			AjustarVendedor();
		}
        private void AjustarVendedor()
        {
            Entidades.Persona vendedor = new Entidades.Persona();
            string[] elementosClavePrimaria = VendedorDropDownList.SelectedValue.ToString().Split('\t');
            vendedor.Cuit = elementosClavePrimaria[0];
            vendedor.Documento.Tipo.Id = elementosClavePrimaria[1];
            vendedor.Documento.Nro = elementosClavePrimaria[2];
            vendedor.IdPersona = elementosClavePrimaria[3];
            vendedor.DesambiguacionCuitPais = Convert.ToInt32(elementosClavePrimaria[4]);
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RN.Persona.LeerPorClavePrimaria(vendedor, (Entidades.Sesion)Session["Sesion"]);
                    IdPersonaVendedorTextBox.Text = vendedor.IdPersona;
                    DesambiguacionCuitPaisVendedorTextBox.Text = vendedor.DesambiguacionCuitPais.ToString();
                    Razon_Social_VendedorTextBox.Text = vendedor.RazonSocial;
                    Domicilio_Calle_VendedorTextBox.Text = vendedor.Domicilio.Calle;
                    Domicilio_Numero_VendedorTextBox.Text = vendedor.Domicilio.Nro;
                    Domicilio_Piso_VendedorTextBox.Text = vendedor.Domicilio.Piso;
                    Domicilio_Depto_VendedorTextBox.Text = vendedor.Domicilio.Depto;
                    Domicilio_Sector_VendedorTextBox.Text = vendedor.Domicilio.Sector;
                    Domicilio_Torre_VendedorTextBox.Text = vendedor.Domicilio.Torre;
                    Domicilio_Manzana_VendedorTextBox.Text = vendedor.Domicilio.Manzana;
                    Localidad_VendedorTextBox.Text = vendedor.Domicilio.Localidad;
                    if (vendedor.Domicilio.Provincia.Id == "")
                    {
                        Provincia_VendedorDropDownList.SelectedValue = "0";
                    }
                    else
                    {
                        Provincia_VendedorDropDownList.SelectedValue = vendedor.Domicilio.Provincia.Id;
                    }
                    Cp_VendedorTextBox.Text = vendedor.Domicilio.CodPost;
                    Contacto_VendedorTextBox.Text = vendedor.Contacto.Nombre;
                    Email_VendedorTextBox.Text = vendedor.Contacto.Email;
                    Telefono_VendedorTextBox.Text = Convert.ToString(vendedor.Contacto.Telefono);
                    Cuit_VendedorTextBox.Text = Convert.ToString(vendedor.Documento.Nro);
                    Condicion_IVA_VendedorDropDownList.SelectedValue = Convert.ToString(vendedor.DatosImpositivos.IdCondIVA);
                    Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedValue = Convert.ToString(vendedor.DatosImpositivos.IdCondIngBrutos);
                    NroIBVendedorTextBox.Text = vendedor.DatosImpositivos.NroIngBrutos;
                    string auxGLN = Convert.ToString(vendedor.DatosIdentificatorios.GLN);
                    if (!auxGLN.Equals("0"))
                    {
                        GLN_VendedorTextBox.Text = auxGLN;
                    }
                    else
                    {
                        GLN_VendedorTextBox.Text = string.Empty;
                    }
                    IdListaPrecioTextBox.Text = vendedor.IdListaPrecioCompra;
                    DetalleLinea.IdListaPrecio = vendedor.IdListaPrecioCompra;
                    Codigo_Interno_VendedorTextBox.Text = vendedor.DatosIdentificatorios.CodigoInterno;
                    if (vendedor.DatosImpositivos.FechaInicioActividades.Equals(new DateTime(9999, 12, 31)) || vendedor.DatosImpositivos.FechaInicioActividades.Equals(new DateTime(0001, 01, 01)))
                    {
                        InicioDeActividadesVendedorDatePickerWebUserControl.Text = string.Empty;
                    }
                    else
                    {
                        InicioDeActividadesVendedorDatePickerWebUserControl.Text = vendedor.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd");
                    }
                    EmailAvisoVisualizacionTextBox.Text = vendedor.EmailAvisoVisualizacion;
                    PasswordAvisoVisualizacionTextBox.Text = vendedor.PasswordAvisoVisualizacion;
                }
            }
            catch (EX.Validaciones.ElementoInexistente)
            {
                ResetearVendedor();
            }
        }
		private void ResetearVendedor()
		{
			Razon_Social_VendedorTextBox.Text = string.Empty;
			Domicilio_Calle_VendedorTextBox.Text = string.Empty;
			Domicilio_Numero_VendedorTextBox.Text = string.Empty;
			Domicilio_Piso_VendedorTextBox.Text = string.Empty;
			Domicilio_Depto_VendedorTextBox.Text = string.Empty;
			Domicilio_Sector_VendedorTextBox.Text = string.Empty;
			Domicilio_Torre_VendedorTextBox.Text = string.Empty;
			Domicilio_Manzana_VendedorTextBox.Text = string.Empty;
			Localidad_VendedorTextBox.Text = string.Empty;
			Provincia_VendedorDropDownList.SelectedValue = Convert.ToString(0);
			Cp_VendedorTextBox.Text = string.Empty;
			Contacto_VendedorTextBox.Text = string.Empty;
			Email_VendedorTextBox.Text = string.Empty;
			Telefono_VendedorTextBox.Text = string.Empty;
            Cuit_VendedorTextBox.Text = string.Empty;
            Condicion_IVA_VendedorDropDownList.SelectedValue = Convert.ToString(0);
			//NroIngBrutosTextBox.Text = Vendedor.NroIngBrutos;
			//CondIngBrutosDropDownList.SelectedValue = Convert.ToString(Vendedor.IdCondIngBrutos);
			GLN_VendedorTextBox.Text = string.Empty;
			Codigo_Interno_VendedorTextBox.Text = string.Empty;
			InicioDeActividadesVendedorDatePickerWebUserControl.Text = string.Empty;
			EmailAvisoVisualizacionTextBox.Text = string.Empty;
			PasswordAvisoVisualizacionTextBox.Text = string.Empty;
		}
		protected void SugerirTotalesButton_Click(object sender, EventArgs e)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Button)sender).ID == "DescargarXMLButton" && ((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Su sesión ha caducado por inactividad. Por favor vuelva a loguearse."), false);
                }
                else
                {
                    try
                    {
                        Session.Remove("FaltaCalcularTotales");
                        //Proceso DETALLE
                        Importe_Total_Neto_Gravado_ResumenTextBox.Text = "0";
                        Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = "0";
                        Importe_Operaciones_Exentas_ResumenTextBox.Text = "0";
                        Impuesto_Liq_ResumenTextBox.Text = "0";
                        Impuesto_Liq_Rni_ResumenTextBox.Text = "0";
                        Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = "0";
                        Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = "0";
                        Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = "0";
                        Importe_Total_Impuestos_Internos_ResumenTextBox.Text = "0";
                        Importe_Total_Factura_ResumenTextBox.Text = "0";
                        double totalGravado = 0;
                        double totalNoGravado = 0;
                        double totalIVA = 0;
                        double total_Operaciones_Exentas = 0;
                        double total_Reintegros = 0;

                        DetalleLinea.CalcularTotalesLineas(ref totalGravado, ref totalNoGravado, ref totalIVA, ref total_Operaciones_Exentas, ref total_Reintegros);
                        //Proceso IMPUESTOS GLOBALES
                        double total_Impuestos_Nacionales;
                        double total_Impuestos_Internos;
                        double total_Ingresos_Brutos;
                        double total_Impuestos_Municipales;

                        CalcularImpuestos(out total_Impuestos_Nacionales, out total_Impuestos_Internos, out total_Ingresos_Brutos, out total_Impuestos_Municipales);

                        CalcularTotales(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas, total_Reintegros);
                        ImpuestosGlobales.EliminarImpuestosIVA();
                        ImpuestosGlobales.AgregarImpuestosIVA(IdNaturalezaComprobanteTextBox.Text, DetalleLinea.Lineas);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas al calcular los totales:  " + ex.Message), false);
                    }
                    finally
                    {
                        RestauroTotalesNoInformados();
                    }
                }
            }
		}
        private void RestauroTotalesNoInformados()
        {
            if (Importe_Total_Impuestos_Municipales_ResumenTextBox.Text == "0")
                Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = String.Empty;
            if (Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text == "0")
                Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = String.Empty;
            if (Importe_Total_Ingresos_Brutos_ResumenTextBox.Text == "0")
                Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = String.Empty;
            if (Importe_Total_Impuestos_Internos_ResumenTextBox.Text == "0")
                Importe_Total_Impuestos_Internos_ResumenTextBox.Text = String.Empty;
        }
        private void CalcularTotales(ref double totalGravado, ref double totalNoGravado, double totalIVA, double total_Impuestos_Nacionales, double total_Impuestos_Internos, double total_Ingresos_Brutos, double total_Impuestos_Municipales, double total_Operaciones_Exentas, double total_Reintegros)
		{
			double total;
			Importe_Total_Neto_Gravado_ResumenTextBox.Text = totalGravado.ToString();
			Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = totalNoGravado.ToString();
			Importe_Operaciones_Exentas_ResumenTextBox.Text = total_Operaciones_Exentas.ToString();
			if (Condicion_IVA_CompradorDropDownList.SelectedValue == (new FeaEntidades.CondicionesIVA.ResponsableNoInscripto()).Codigo.ToString() || Condicion_IVA_CompradorDropDownList.SelectedValue == (new FeaEntidades.CondicionesIVA.SujetoNoCategorizado()).Codigo.ToString())
			{
				Impuesto_Liq_Rni_ResumenTextBox.Text = totalIVA.ToString();
			}
			else
			{
				Impuesto_Liq_ResumenTextBox.Text = totalIVA.ToString();
			}
			Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = total_Impuestos_Municipales.ToString();
			Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = total_Impuestos_Nacionales.ToString();
			Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = total_Ingresos_Brutos.ToString();
			Importe_Total_Impuestos_Internos_ResumenTextBox.Text = total_Impuestos_Internos.ToString();
            total = totalGravado + totalNoGravado + totalIVA + total_Impuestos_Nacionales + total_Impuestos_Internos + total_Ingresos_Brutos + total_Impuestos_Municipales + total_Operaciones_Exentas;
            Importe_Total_Reintegros_ResumenTextBox.Text = total_Reintegros.ToString();
            total = total + total_Reintegros;
            Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
            //if (Condicion_IVA_VendedorDropDownList.SelectedValue == "6")
            //{
            //    Importe_Total_Neto_Gravado_ResumenTextBox.Text = totalNoGravado.ToString(); 
            //    Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = "0";
            //}
		}
		private void CalcularImpuestos(out double total_Impuestos_Nacionales, out double total_Impuestos_Internos, out double total_Ingresos_Brutos, out double total_Impuestos_Municipales)
		{
			total_Impuestos_Nacionales = 0;
			total_Impuestos_Internos = 0;
			total_Ingresos_Brutos = 0;
			total_Impuestos_Municipales = 0;
			System.Collections.Generic.List<FeaEntidades.InterFacturas.resumenImpuestos> listadeimpuestos = ImpuestosGlobales.Lista;
			for (int i = 0; i < listadeimpuestos.Count; i++)
			{
				if (!listadeimpuestos[i].codigo_impuesto.Equals(0))
				{
					switch (listadeimpuestos[i].codigo_impuesto)
					{
						case 1://IVA
                            //total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							break;
						case 3://Otros
							total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							break;
						case 4://Nacionales
							total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							break;
						case 2://Internos
							total_Impuestos_Internos += listadeimpuestos[i].importe_impuesto;
							break;
						case 5://IB
							total_Ingresos_Brutos += listadeimpuestos[i].importe_impuesto;
							break;
						case 6://Municipales
							total_Impuestos_Municipales += listadeimpuestos[i].importe_impuesto;
							break;
						default:
							throw new Exception("Código del impuesto inválido");
					}
				}
			}
		}
		private void ResetearGrillas()
		{
			DetalleLinea.ResetearGrillas();
            InfoReferencias.ResetearGrillas();
			DetalleLinea.ResetearGrillas();
		}
        private void AjustarCamposXPtaVentaChanged(string PuntoDeVenta)
        {
            if (!PuntoDeVenta.Equals(string.Empty))
            {
                int auxPV;
                try
                {
                    auxPV = Convert.ToInt32(PuntoDeVenta);
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
                        Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                        System.Collections.Generic.List<Entidades.Persona> listacompradores = new System.Collections.Generic.List<Entidades.Persona>();
                        switch (idtipo)
                        {
                            case "Turismo":
                                AjustarCamposXPtaVentaTurismo(out listacompradores);
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                        Tipo_De_ComprobanteDropDownList.DataBind();
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                        TipoPtoVentaLabel.Text = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (listacompradores.Count > 0)
                        {
                            //CompradorDropDownList.Visible = true;
                            //CompradorDropDownList.DataValueField = "ClavePrimaria";
                            //CompradorDropDownList.DataTextField = "RazonSocialeIdPersona";
                            //Entidades.Persona persona = new Entidades.Persona();
                            //System.Collections.Generic.List<Entidades.Persona> personalist = new System.Collections.Generic.List<Entidades.Persona>();
                            //persona.RazonSocial = "";
                            //RN.Persona.LeerDestinatariosFrecuentes(persona, true, (Entidades.Sesion)Session["Sesion"]);
                            //personalist.Add(persona);
                            //personalist.AddRange(listacompradores);
                            //CompradorDropDownList.DataSource = personalist;
                            //CompradorDropDownList.DataBind();
                            //CompradorDropDownList.SelectedIndex = 0;
                            AjustarComprador();
                        }
                        else
                        {
                            CompradorDropDownList.Visible = false;
                            CompradorDropDownList.DataSource = null;
                        }
                        if (ProximoNroComprobanteLinkButton.Visible) ProximoNroComprobanteLinkButton_Click(ProximoNroComprobanteLinkButton, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Debe seleccionar el punto de venta"), false);
            }
        }

        private void AjustarCamposXPtaVentaTurismo(out System.Collections.Generic.List<Entidades.Persona> listacompradores)
        {
            FechaInicioServLabel.Visible = true;
            FechaServDesdeDatePickerWebUserControl.Visible = true;
            ImageCalendarFechaServDesde.Visible = true;
            FechaHstServLabel.Visible = true;
            FechaServHastaDatePickerWebUserControl.Visible = true;
            ImageCalendarFechaServHasta.Visible = true;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaTurismoAFIP();
            Tipo_De_ComprobanteDropDownList.DataBind();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
            
            if (Funciones.SessionTimeOut(Session))
            {
                listacompradores = new List<Entidades.Persona>();
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                listacompradores = RN.Persona.ListaTurismo(((Entidades.Sesion)Session["Sesion"]));
            }
        }

        protected bool ValidarCamposObligatorios(string Accion)
        {
            if (Cuit_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el CUIT del vendedor"), false);
                return false;
            }
            if (Numero_ComprobanteTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el número de " + ((IdNaturalezaComprobanteTextBox.Text == "VentaContrato") ? "contrato" : "comprobante")), false);
                return false;
            }
            if (!Numero_ComprobanteTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericOnly(Numero_ComprobanteTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un dato numérico en el número de " + ((IdNaturalezaComprobanteTextBox.Text == "VentaContrato") ? "contrato" : "comprobante")), false);
                return false;
            }
            if (Convert.ToInt64(Numero_ComprobanteTextBox.Text) <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un valor positivo en el número de " + ((IdNaturalezaComprobanteTextBox.Text == "VentaContrato") ? "contrato" : "comprobante")), false);
                return false;
            }
            if (PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el punto de venta"), false);
                return false;
            }
            if (Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue == "70")
            {
                if (Nro_Doc_Identificatorio_CompradorDropDownList.SelectedValue.Equals(string.Empty))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta seleccionar el número de documento"), false);
                    return false;
                }
            }
            else
            {
                if (Nro_Doc_Identificatorio_CompradorTextBox.Text.Equals(string.Empty))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el número de documento"), false);
                    return false;
                }
            }
            if (FechaEmisionDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la Fecha de Emisión del comprobante"), false);
                return false;
            }
            if (!FechaEmisionDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                bool resp = RN.Funciones.IsValidNumericDateyyyyMMdd(FechaEmisionDatePickerWebUserControl.Text);
                if (!resp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar la Fecha de Emisión con el formato yyyyMMdd"), false);
                    return false;
                }
            }
            if (!FechaVencimientoDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                bool resp = RN.Funciones.IsValidNumericDateyyyyMMdd(FechaVencimientoDatePickerWebUserControl.Text);
                if (!resp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar la Fecha de Vencimiento con el formato yyyyMMdd"), false);
                    return false;
                }
            }
            if (!FechaServDesdeDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                bool resp = RN.Funciones.IsValidNumericDateyyyyMMdd(FechaServDesdeDatePickerWebUserControl.Text);
                if (!resp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar la Fecha de Servicio Desde con el formato yyyyMMdd"), false);
                    return false;
                }
            }
            if (!FechaServHastaDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                bool resp = RN.Funciones.IsValidNumericDateyyyyMMdd(FechaServHastaDatePickerWebUserControl.Text);
                if (!resp)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar la Fecha de Servicio Hasta con el formato yyyyMMdd"), false);
                    return false;
                }
            }
            if (Condicion_De_PagoTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la condición de pago"), false);
                return false;
            }
            if (Razon_Social_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la Razon Social del vendedor"), false);
                return false;
            }
            if (Localidad_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la Localidad del vendedor"), false);
                return false;
            }
            if (Email_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la email del vendedor"), false);
                return false;
            }
            if (!Email_VendedorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidEmail(Email_VendedorTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un email válido para el vendedor"), false);
                return false;
            }

            if (!NroIBVendedorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNroIB(NroIBVendedorTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un Nro. de IB válido para el vendedor"), false);
                return false;
            }
            if (Denominacion_CompradorTextBox.Text.Length > 50)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("La descripción de la Razón Social del Comprador es muy larga. Máximo permitido 50 caracteres."), false);
                return false;
            }
            if (Accion != "SubirAAFIP")
            {
                if (Email_CompradorTextBox.Text.Equals(string.Empty))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar la email del comprador"), false);
                    return false;
                }
                if (!Email_CompradorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidEmail(Email_CompradorTextBox.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un email válido para el comprador"), false);
                    return false;
                }
            }
            if (CodigoPaisDropDownList.SelectedValue.Equals(string.Empty) || CodigoPaisDropDownList.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el código del pais para el comprador"), false);
                return false;
            }
            if (Domicilio_Calle_CompradorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el domicilio para el comprador"), false);
                return false;
            }
            if (!GLN_CompradorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericFijo(GLN_CompradorTextBox.Text, "13"))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Ingresar un dato numérico de 13 digitos en el GLN del comprador"), false);
                return false;
            }
            bool faltaCalcularTotales = false;
            try
            {
                faltaCalcularTotales = (bool)Session["FaltaCalcularTotales"];
            }
            catch
            { 
            }
            if (faltaCalcularTotales)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta presionar el botón de Sugerir totales."), false);
                return false;
            }
            //TIPO DE CAMBIO
            if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                if (Tipo_de_cambioTextBox.Text.Equals(string.Empty))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el Tipo de Cambio"), false);
                    return false;
                }
                if (!Tipo_de_cambioTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Tipo_de_cambioTextBox.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Tipo de Cambio en el Resumen"), false);
                    return false;
                }
            }
            //RESUMEN            
            if (Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el Importe Total Neto Gravado del Resumen"), false);
                return false;
            }
            if (!Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Neto_Gravado_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Neto Gravado en el Resumen"), false);
                return false;
            }
            if (Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el Importe Total Concepto No Gravado del Resumen"), false);
                return false;
            }
            if (!Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Concepto No Gravado en el Resumen"), false);
                return false;
            }
            if (Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el Importe Operaciones Exentas del Resumen"), false);
                return false;
            }
            if (!Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Operaciones_Exentas_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Operaciones Exentas en el Resumen"), false);
                return false;
            }
            if (Impuesto_Liq_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el IVA del Resumen"), false);
                return false;
            }
            if (!Impuesto_Liq_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Impuesto_Liq_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del IVA en el Resumen"), false);
                return false;
            }
            if (Impuesto_Liq_Rni_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el IVA RNI del Resumen"), false);
                return false;
            }
            if (!Impuesto_Liq_Rni_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Impuesto_Liq_Rni_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del IVA RNI en el Resumen"), false);
                return false;
            }
            if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Impuestos Municipales en el Resumen"), false);
                return false;
            }
            if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Impuestos Nacionales en el Resumen"), false);
                return false;
            }
            if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Ingresos Brutos en el Resumen"), false);
                return false;
            }
            if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Internos_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Impuestos Internos en el Resumen"), false);
                return false;
            }
            if (Importe_Total_Factura_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Falta ingresar el Importe Total Factura del Resumen"), false);
                return false;
            }
            if (!Importe_Total_Factura_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Factura_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Formato erróneo del Importe Total Factura en el Resumen"), false);
                return false;
            }
            //DATOSEMAIL
            return true;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
        protected void AccionSubirAAFIPButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                DescargarPDFPanel.Visible = false;
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Su sesión ha caducado por inactividad. Por favor vuelva a loguearse."), false);
                }
                else
                {
                    try
                    {
                        try
                        {
                            int auxPV;
                            auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == auxPV;
                            }).IdTipoPuntoVta;
                            if (idtipo != "Turismo")
                            {
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Esta opción solo está habilitada para puntos de venta de Turismo."), false);
                                return;
                            }
                            if (ValidarCamposObligatorios("SubirAAFIP"))
                            {
                                string respuesta = "";
                                FeaEntidades.Turismo.comprobante Comprobante = GenerarLote(false);

                                //Grabar en base de datos
                                //lcFea.cabecera_lote.DestinoComprobante = "AFIP";
                                Comprobante.cabecera.informacion_comprobante.Observacion = "";
                                string tratamiento = TratamientoTextBox.Text;
                                if (tratamiento == "Clonado") { tratamiento = "Alta"; }
                                Entidades.ComprobanteATratar comprobanteATratar = (Entidades.ComprobanteATratar)ViewState["ComprobanteATratarOrig"];
                                ViewState["ComprobanteParaRegistrar"] = Comprobante;
                                RN.Comprobante.Registrar(Comprobante, tratamiento, comprobanteATratar.Comprobante, null, IdNaturalezaComprobanteTextBox.Text, "AFIP", "PteEnvio", "No Aplica", Convert.ToDateTime("31/12/9999"), 0, 0, 0, string.Empty, false, string.Empty, string.Empty, string.Empty, ((Entidades.Sesion)Session["Sesion"]));

                                string caeNro = "";
                                string caeFecVto = "";
                                respuesta = RN.ComprobanteAFIP.EnviarAFIPCT(out caeNro, out caeFecVto, Comprobante, (Entidades.Sesion)Session["Sesion"]);
                                
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), respuesta);
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(respuesta), false);

                                if (respuesta.Length >= 12 && respuesta.Substring(0, 12) == "Resultado: A")
                                {
                                    //Actualizar estado on-line.
                                    if (caeNro != "")
                                    {
                                        Comprobante.cabecera.informacion_comprobante.resultado = "A";
                                        Comprobante.cabecera.informacion_comprobante.cae = caeNro;
                                        Comprobante.cabecera.informacion_comprobante.caeSpecified = true;
                                        Comprobante.cabecera.informacion_comprobante.fecha_vencimiento_cae = caeFecVto;
                                        Comprobante.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                                        Comprobante.cabecera.informacion_comprobante.fecha_obtencion_cae = DateTime.Now.ToString("yyyyMMdd");
                                        Comprobante.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                                    }
                                    string XML = "";
                                    RN.Comprobante.SerializarLc(out XML, Comprobante);
                                    Entidades.Comprobante comprobante = new Entidades.Comprobante();
                                    comprobante.Cuit = Comprobante.cabecera.informacion_vendedor.cuit.ToString();
                                    comprobante.TipoComprobante.Id = Comprobante.cabecera.informacion_comprobante.tipo_de_comprobante;
                                    comprobante.NroPuntoVta = Comprobante.cabecera.informacion_comprobante.punto_de_venta;
                                    comprobante.Nro = Comprobante.cabecera.informacion_comprobante.numero_comprobante;
                                    comprobante.NaturalezaComprobante.Id = "Venta";
                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                    comprobante.Response = XML;
                                    comprobante.WF.Estado = "Vigente";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);

                                    RN.Comprobante.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                    Session["comprobantePDF"] = comprobante;
                                    DescargarPDFPanel.Visible = true;
                                }
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
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(soapEx.Actor.Trim() + ": " + errorMessage), false);
                            }
                            catch (Exception)
                            {
                                throw soapEx;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        string mensaje = ex.Message;
                        if (ex.InnerException != null)
                        {
                            if (ex.InnerException.ToString().IndexOf("PRIMARY KEY 'PK_Table_Comprobante'") != -1)
                            {
                                mensaje = "Ya existe el comprobante. ";
                                try
                                {
                                    FeaEntidades.Turismo.comprobante comprobante = (FeaEntidades.Turismo.comprobante)ViewState["ComprobanteParaRegistrar"];
                                    Entidades.Comprobante comprobanteVerifEstado = new Entidades.Comprobante();
                                    comprobanteVerifEstado.Cuit = comprobante.cabecera.informacion_vendedor.cuit.ToString();
                                    comprobanteVerifEstado.TipoComprobante.Id = comprobante.cabecera.informacion_comprobante.tipo_de_comprobante;
                                    comprobanteVerifEstado.NroPuntoVta = comprobante.cabecera.informacion_comprobante.punto_de_venta;
                                    comprobanteVerifEstado.Nro = comprobante.cabecera.informacion_comprobante.numero_comprobante;
                                    RN.Comprobante.Leer(comprobanteVerifEstado, (Entidades.Sesion)Session["Sesion"]);
                                    mensaje += "Se encuentra en estado: " + comprobanteVerifEstado.Estado;
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                mensaje += ex.InnerException.ToString();
                            }
                        }
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), mensaje);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas al enviar el comprobante a AFIP.  " + mensaje), false);
                    }
                }
            }
        }
        protected void DescargarPDFButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Su sesión ha caducado por inactividad. Por favor vuelva a loguearse."), false);
                }
                else
                {
                    try
                    {
                        FeaEntidades.Turismo.comprobante comprobanteT;
                        Entidades.Comprobante comprobante = (Entidades.Comprobante)Session["comprobantePDF"];
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        string DetalleIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKUtilizarServidorExterno"];
                        org.dyndns.cedweb.detalle.DetalleIBK clcdyndns = new org.dyndns.cedweb.detalle.DetalleIBK();
                        org.dyndns.cedweb.detalle.cecd cecd = new org.dyndns.cedweb.detalle.cecd();
                        System.Xml.Serialization.XmlSerializer x;
                        byte[] bytes;
                        System.IO.MemoryStream ms;
                        string script;

                        #region PDF (AFIP)
                        //GENERACIÓN DE PDF A PARTIR DE DATOS LOCALES
                        comprobanteT = new FeaEntidades.Turismo.comprobante();
                        x = new System.Xml.Serialization.XmlSerializer(comprobanteT.GetType());
                        if (comprobante.Estado != "Vigente")
                        {
                            MensajeLabel.Text = "El comprobante no está vigente.";
                            return;
                        }
                        try
                        {
                            FeaEntidades.Turismo.lote_comprobantes LoteT = new FeaEntidades.Turismo.lote_comprobantes();
                            comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                            bytes = new byte[comprobante.Response.Length * sizeof(char)];
                            System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                            ms = new System.IO.MemoryStream(bytes);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);
                            comprobanteT = (FeaEntidades.Turismo.comprobante)x.Deserialize(ms);
                            LoteT.comprobante[0] = comprobanteT;

                            RN.Comprobante.AjustarLoteTParaImprimirPDF(LoteT);
                               
                            Session["lote"] = LoteT;
                            script = "window.open('/Facturacion/Electronica/Reportes/FacturaWebFormT.aspx', '');";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                        }
                        catch (Exception ex)
                        {
                            script = "Problemas para generar el PDF.\\n" + ex.Message;
                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                            MensajeLabel.Text = script;
                        }
                        #endregion
                      }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas al descargar el archivo PDF.  " + ex.Message), false);
                    }
                }
            }
        }
        protected void AccionGuardarComprobanteButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Su sesión ha caducado por inactividad. Por favor vuelva a loguearse."), false);
                }
                else
                {
                    try
                    {
                        try
                        {
                            if (ValidarCamposObligatorios("GuardarComprobante"))
                            {
                                FeaEntidades.Turismo.comprobante comprobante = GenerarLote(false);
                                //Grabar en base de datos
                                //lote.cabecera_lote.DestinoComprobante = "Ninguno";
                                comprobante.cabecera.informacion_comprobante.Observacion = "";
                                comprobante.cabecera.informacion_comprador.id = IdPersonaCompradorTextBox.Text;
                                comprobante.cabecera.informacion_comprador.desambiguacionCuitPais = Convert.ToInt32(DesambiguacionCuitPaisCompradorTextBox.Text);

                                string tratamiento = TratamientoTextBox.Text;
                                if (tratamiento == "Clonado") { tratamiento = "Alta"; }
                                Entidades.ComprobanteATratar comprobanteATratar = (Entidades.ComprobanteATratar)ViewState["ComprobanteATratarOrig"];
                                RN.Comprobante.Registrar(comprobante, tratamiento, comprobanteATratar.Comprobante, null, IdNaturalezaComprobanteTextBox.Text, string.Empty, "Vigente", "No Aplica", DateTime.ParseExact("31/12/9999", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture), 0, 0, 0, string.Empty, false, string.Empty, string.Empty, string.Empty, ((Entidades.Sesion)Session["Sesion"]));
                                AccionesPanel.Visible = false;
                                MensajeLabel.Text = "Comprobante guardado satisfactoriamente";
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(MensajeLabel.Text), false);
                            }
                        }
                        catch (System.Web.Services.Protocols.SoapException soapEx)
                        {
                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(soapEx.Detail.OuterXml);
                                XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                                nsManager.AddNamespace("errorNS", "http://www.cedeira.com.ar/webservices");
                                XmlNode Node = doc.DocumentElement.SelectSingleNode("errorNS:Error", nsManager);
                                string errorNumber = Node.SelectSingleNode("errorNS:ErrorNumber", nsManager).InnerText;
                                string errorMessage = Node.SelectSingleNode("errorNS:ErrorMessage", nsManager).InnerText;
                                string errorSource = Node.SelectSingleNode("errorNS:ErrorSource", nsManager).InnerText;
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript(soapEx.Actor.Trim() + ": " + errorMessage), false);
                            }
                            catch (Exception)
                            {
                                throw soapEx;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), ex.Message);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas al guardar el " + ((IdNaturalezaComprobanteTextBox.Text == "VentaContrato") ? "contrato" : "comprobante") + ".  " + ex.Message), false);
                    }
                }
            }
        }
        private bool Existe(string URLfile)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(URLfile);
            bool existe = true;
            request.Method = "HEAD";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)     //WebException ex
            {
                existe = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return existe;
        }
        private void GenerarNroLote()
        {
            try
            {
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.PuntoVta puntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    });
                    if (puntoVta.IdMetodoGeneracionNumeracionLote.Equals("Autonumerador") || puntoVta.IdMetodoGeneracionNumeracionLote.Equals("TimeStamp1") || puntoVta.IdMetodoGeneracionNumeracionLote.Equals("TimeStamp2"))
                    {
                        RN.PuntoVta.GenerarNuevoNroLote(puntoVta, (Entidades.Sesion)Session["Sesion"]);
                    }
                }
            }
            catch (Exception ex)
            {
                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), "GenerarNroLote - " + ex.Message);
            }
        }
        private FeaEntidades.Turismo.comprobante GenerarLote(bool EsParaImprimirPDF)
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
            FeaEntidades.Turismo.detalle det = DetalleLinea.GenerarDetalles(MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text, idtipo, Tipo_De_ComprobanteDropDownList.SelectedValue, EsParaImprimirPDF);

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
            {
                //Moneda local
                GenerarImportesMonedaLocal(r);
            }
            else
            {
                //Moneda extranjera
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
				comp.extensiones.extensiones_destinatarios.email=EmailAvisoVisualizacionTextBox.Text;
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
            infcomprob.numero_comprobante = Math.Abs(Convert.ToInt64(Numero_ComprobanteTextBox.Text));
            infcomprob.numero_comprobante = Convert.ToInt64(Numero_ComprobanteTextBox.Text);
            infcomprob.punto_de_venta = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
            
            infcomprob.fecha_emision = FechaEmisionDatePickerWebUserControl.Text;
            if (infcomprob.fecha_emision.Length != 8)
            {
                throw new Exception("La fecha de emisión es obligatoria");
            }
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
                infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
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
            //if (!ResultadoTextBox.Text.Equals(string.Empty))
            //{
            //    infcomprob.resultado = ResultadoTextBox.Text;
            //}
            //if (!MotivoTextBox.Text.Equals(string.Empty))
            //{
            //    infcomprob.motivo = MotivoTextBox.Text;
            //}
            return infcomprob;
        }
        private void GenerarInfoFechaVto(FeaEntidades.Turismo.informacion_comprobante infcomprob)
        {
            if (!FechaVencimientoDatePickerWebUserControl.Text.Equals(string.Empty) || IdNaturalezaComprobanteTextBox.Text == "VentaContrato")
            {
                infcomprob.fecha_vencimiento = FechaVencimientoDatePickerWebUserControl.Text;
            }
            else
            {
                int auxPV = Convert.ToInt32(((DropDownList)PuntoVtaDropDownList).SelectedValue);
                try
                {
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        if (!idtipo.Equals("Exportacion"))
                        {
                            throw new Exception("La fecha de vencimiento es obligatoria");
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    throw new Exception("La fecha de vencimiento es obligatoria");
                }
            }
        }

        private void GenerarReferencias(FeaEntidades.Turismo.informacion_comprobante infcomprob)
        {
            if (this.InfoReferencias.HayReferencias)
            {
                for (int i = 0; i < this.InfoReferencias.ListaReferencias.Count; i++)
                {
                    if (infcomprob.tipo_de_comprobante.Equals(19))
                    {
                        //throw new Exception("Las referencias no se deben informar para facturas de exportación(19). Sólo para notas de débito y/o crédito (20 y 21).");
                    }
                    infcomprob.referencias[i] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                    infcomprob.referencias[i].tipo_comprobante_afip = this.InfoReferencias.ListaReferencias[i].tipo_comprobante_afip;
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

            if (Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue != new FeaEntidades.Documentos.CUITPais().Codigo.ToString())
            {
                try
                {
                    infcompra.nro_doc_identificatorio_afip = Nro_Doc_Identificatorio_CompradorTextBox.Text;
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
                    infcompra.nro_doc_identificatorio_afip = Nro_Doc_Identificatorio_CompradorDropDownList.SelectedValue;
                }
                catch (FormatException)
                {
                    throw new Exception("Nro documento del comprador del exterior no informado");
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

            //obligatorio para exportación
            if (Domicilio_Calle_CompradorTextBox.Text.Equals(string.Empty))
            {
                infcompra.domicilio_calle = string.Empty;
            }
            else
            {
                infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
            }
            //obligatorio para exportación
            if (Domicilio_Numero_CompradorTextBox.Text.Equals(string.Empty))
            {
                infcompra.domicilio_numero = string.Empty;
            }
            else
            {
                infcompra.domicilio_numero = Domicilio_Numero_CompradorTextBox.Text;
            }
            infcompra.domicilio_piso = Domicilio_Piso_CompradorTextBox.Text;
            infcompra.domicilio_depto = Domicilio_Depto_CompradorTextBox.Text;
            infcompra.domicilio_sector = Domicilio_Sector_CompradorTextBox.Text;
            infcompra.domicilio_torre = Domicilio_Torre_CompradorTextBox.Text;
            infcompra.domicilio_manzana = Domicilio_Manzana_CompradorTextBox.Text;
            infcompra.localidad = Localidad_CompradorTextBox.Text;
            string auxCodProvCompra = Convert.ToString(Provincia_CompradorDropDownList.SelectedValue);
            if (!auxCodProvCompra.Equals("0"))
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    infcompra.provincia = auxCodProvCompra;
                }
            }
            infcompra.cp = Cp_CompradorTextBox.Text;
            infcompra.email = Email_CompradorTextBox.Text;
            infcompra.telefono = Telefono_CompradorTextBox.Text;
            infcompra.codigo_Relacion_Receptor_Emisor = Convert.ToInt16(CodigoRelacionReceptorEmisorDropDownList.SelectedValue);
            infcompra.codigo_Pais = Convert.ToInt16(CodigoPaisDropDownList.SelectedValue);
            compcab.informacion_comprador = infcompra;
        }
        private void GenerarImportesMonedaExtranjera(FeaEntidades.Turismo.resumen r)
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

            r.importe_total_factura = Math.Round(Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text) * tipodecambio, 2); ;
            rimo.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
            r.importes_moneda_origen = rimo;
        }
        private void GenerarImpuestoLiqRNIExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
            }
        }
        private void GenerarImpuestoLiqExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
            }
		}
        private void GenerarImporteOperacionesExentasExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
            }
		}
        private void GenerarImporteTotalConceptoNoGravadoExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
            }
		}
        private void GenerarImporteTotalNetoGravadoExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
            }
		}
        private void GenerarImporteTotalImpuestosInternosMonedaExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_internos = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text) * tipodecambio, 2);
                    rimo.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
                }
                else
                {
                    r.importe_total_impuestos_internos = 0;
                    rimo.importe_total_impuestos_internos = 0;
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_impuestos_internosSpecified = true;
                rimo.importe_total_impuestos_internosSpecified = true;
            }
            else
            {
                r.importe_total_impuestos_internosSpecified = false;
                rimo.importe_total_impuestos_internosSpecified = false;
            }
		}
        private void GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_municipales = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text) * tipodecambio, 2);
                    rimo.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
                }
                else
                {
                    r.importe_total_impuestos_municipales = 0;
                    rimo.importe_total_impuestos_municipales = 0;
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_impuestos_municipalesSpecified = true;
                rimo.importe_total_impuestos_municipalesSpecified = true;
            }
            else
            {
                r.importe_total_impuestos_municipalesSpecified = false;
                rimo.importe_total_impuestos_municipalesSpecified = false;
            }
		}
        private void GenerarImporteTotalIngresosBrutosMonedaExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_ingresos_brutos = Math.Round(Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text) * tipodecambio, 2);
                    rimo.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
                }
                else
                {
                    r.importe_total_ingresos_brutos = 0;
                    rimo.importe_total_ingresos_brutos = 0;
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_ingresos_brutosSpecified = true;
                rimo.importe_total_ingresos_brutosSpecified = true;
            }
            else
            {
                r.importe_total_ingresos_brutosSpecified = false;
                rimo.importe_total_ingresos_brutosSpecified = false;
            }
		}
        private void GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(FeaEntidades.Turismo.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_nacionales = Math.Round(Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text) * tipodecambio, 2);
                    rimo.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
                }
                else
                {
                    r.importe_total_impuestos_nacionales = 0;
                    rimo.importe_total_impuestos_nacionales = 0;
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(""))
			{
				r.importe_total_impuestos_nacionalesSpecified = true;
				rimo.importe_total_impuestos_nacionalesSpecified = true;
			}
            else
            {
                r.importe_total_impuestos_nacionalesSpecified = false;
                rimo.importe_total_impuestos_nacionalesSpecified = false;
            }
		}

		private void GenerarImportesMonedaLocal(FeaEntidades.Turismo.resumen r)
		{
			GenerarImporteTotalNetoGravado(r);
			GenerarImporteTotalConceptoNoGravado(r);
			GenerarImporteOperacionesExentas(r);
			GenerarImpuestoLiq(r);
			GenerarImpuestoLiqRNI(r);
			GenerarImporteTotalImpuestosNacionales(r);
            GenerarImporteTotalIngresosBrutos(r);
            GenerarImporteTotalImpuestosMunicipales(r);
            GenerarImporteTotalImpuestosInternos(r);
            GenerarImporteTotalReintegros(r);
			r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
		}
		private void GenerarImpuestoLiqRNI(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
            }
		}
		private void GenerarImpuestoLiq(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
            }
		}
		private void GenerarImporteOperacionesExentas(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
            }

		}
		private void GenerarImporteTotalConceptoNoGravado(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
            }
		}
		private void GenerarImporteTotalNetoGravado(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
            }
		}
		private void GenerarImporteTotalImpuestosInternos(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_impuestos_internosSpecified = true;
            }
            else
            {
                r.importe_total_impuestos_internosSpecified = false;
            }
		}
		private void GenerarImporteTotalImpuestosMunicipales(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_impuestos_municipalesSpecified = true;
            }
            else
            {
                r.importe_total_impuestos_municipalesSpecified = false;
            }
		}
		private void GenerarImporteTotalIngresosBrutos(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_ingresos_brutosSpecified = true;
            }
            else
            {
                r.importe_total_ingresos_brutosSpecified = false;
            }
		}
		private void GenerarImporteTotalImpuestosNacionales(FeaEntidades.Turismo.resumen r)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(""))
                {
                    r.importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(""))
            {
                r.importe_total_impuestos_nacionalesSpecified = true;
            }
            else
            {
                r.importe_total_impuestos_nacionalesSpecified = false;
            }
		}
        private void GenerarImporteTotalReintegros(FeaEntidades.Turismo.resumen r)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (!Importe_Total_Reintegros_ResumenTextBox.Equals(""))
                {
                    r.importe_Reintegro = Convert.ToDecimal(Importe_Total_Reintegros_ResumenTextBox.Text);
                }
            }
            //Marcar si están informados
            if (!Importe_Total_Reintegros_ResumenTextBox.Text.Equals(""))
            {
                r.importe_ReintegroSpecified = true;
            }
            else
            {
                r.importe_ReintegroSpecified = false;
            }
        }
        protected void AccionObtenerPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                FeaEntidades.Turismo.comprobante comprobante = GenerarLote(true);

                FeaEntidades.Turismo.lote_comprobantes loteT = new FeaEntidades.Turismo.lote_comprobantes();
                loteT.comprobante[0] = comprobante;
                RN.Comprobante.AjustarLoteTParaImprimirPDF(loteT);
                Session["lote"] = loteT;
                Session["EsComprobanteOriginal"] = false;
                Response.Redirect("Reportes\\FacturaWebFormT.aspx", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Message", Funciones.TextoScript("Problemas al generar el pdf.  " + ex.Message));
            }
        }
        private void RegistrarActividad(FeaEntidades.Turismo.comprobante lote, System.Text.StringBuilder sb, System.Net.Mail.SmtpClient smtpClient, string smtpXAmb, System.IO.MemoryStream m)
		{
            ////Registro cantidad de comprobantes
            //if (((Entidades.Sesion)Session["Sesion"]).Cuenta.Id != null)
            //{
            //    CedWebRN.Cuenta.RegistrarComprobante(((CedWebEntidades.Sesion)Session["Sesion"]).Cuenta, (CedEntidades.Sesion)Session["Sesion"]);
            //}

            //if (((CedWebEntidades.Sesion)Session["Sesion"]).Flag.ModoDepuracion)
            //{
            //    //ModoDepuracion encendido
            //    System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sb.ToString()), System.IO.FileMode.Create);
            //    m.WriteTo(fs);
            //    fs.Close();
            //}
		}
		private void ActualizarTipoDeCambio()
		{
			DetalleLinea.ActualizarTipoDeCambio(MonedaComprobanteDropDownList.SelectedValue);
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
		public DetalleCT Articulos
		{
			get
			{
				return this.DetalleLinea;
			}
		}
        protected void Codigo_Doc_Identificatorio_CompradorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int auxTipoDoc = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            try
            {
                if (auxTipoDoc.ToString() == "70")
                {
                    Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                    Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                    Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Nro_Doc_Identificatorio_CompradorTextBox.Text));
                }
                else
                {
                    Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                    Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                }
            }
            catch
            {
            }
        }
        protected void PuntoVtaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int auxPV = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            try
            {
                AjustarCamposXPtaVentaChanged(((DropDownList)sender).SelectedValue);
                DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                ImpuestosGlobales.PuntoDeVenta = Convert.ToString(auxPV);
                InfoReferencias.PuntoDeVenta = Convert.ToString(auxPV);
                if (ViewState["PuntoVenta"] != null)
                {
                    int auxViewState = Convert.ToInt32(ViewState["PuntoVenta"]);
                    try
                    {
                        if (Funciones.SessionTimeOut(Session))
                        {
                            Response.Redirect("~/SessionTimeout.aspx");
                        }
                        else
                        {
                            string idtipoAnterior = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == auxViewState;
                            }).IdTipoPuntoVta;
                            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == auxPV;
                            }).IdTipoPuntoVta;
                            if (!idtipo.Equals(idtipoAnterior))
                            {
                                ResetearGrillas();
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        ResetearGrillas();
                    }
                }
                ViewState["PuntoVenta"] = auxPV;
            }
            catch
            {
                ResetearGrillas();
            }
            AyudaFechaEmisionCalcular();
        }

        protected void Tipo_De_ComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    if (ProximoNroComprobanteLinkButton.Visible) ProximoNroComprobanteLinkButton_Click(ProximoNroComprobanteLinkButton, EventArgs.Empty);
                }
            }
            catch
            {
            }
        }
        protected void ModalPopupExtender1_Load(object sender, EventArgs e)
        {

        }
        protected void ModalPopupExtender3_Load(object sender, EventArgs e)
        {

        }
        protected void CancelarEnviarAFIPButton_Click(object sender, EventArgs e)
        {

        }
        protected void ProximoNroComprobanteLinkButton_Click(object sender, EventArgs e)
        {
            //Nuevo número de comprobante
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"]; 
            Entidades.Comprobante ultimoComprobanteEmitido = new Entidades.Comprobante();
            ultimoComprobanteEmitido.TipoComprobante.Id = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue.ToString());
            ultimoComprobanteEmitido.NroPuntoVta = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue.ToString());
            ultimoComprobanteEmitido.NaturalezaComprobante.Id = "Venta";
            RN.Comprobante.LeerUltimoEmitido(ultimoComprobanteEmitido, sesion);
            Numero_ComprobanteTextBox.Text = Convert.ToString(ultimoComprobanteEmitido.Nro + 1);
        }
 
        protected void ProximoNroLoteLinkButton_Click(object sender, EventArgs e)
        {
            GenerarNroLote();
        }
 
        protected void CodigoConceptoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    AyudaFechaEmisionCalcular();
                }
            }
            catch
            {
            }
        }

        protected void Condicion_Ingresos_Brutos_VendedorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}