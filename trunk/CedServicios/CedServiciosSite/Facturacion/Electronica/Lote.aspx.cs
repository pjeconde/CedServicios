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
	public partial class Lote : System.Web.UI.Page
	{
		#region Variables
		string gvUniqueID = String.Empty;
		System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> referencias;
		#endregion
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Cache.Remove("ComprobanteAClonar");
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
                FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                referencias.Add(referencia);
                referenciasGridView.DataSource = referencias;
                ViewState["referencias"] = referencias;

                Condicion_IVA_VendedorDropDownList.DataValueField = "Codigo";
                Condicion_IVA_VendedorDropDownList.DataTextField = "Descr";
                Condicion_IVA_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();

                Condicion_Ingresos_Brutos_VendedorDropDownList.DataValueField = "Codigo";
                Condicion_Ingresos_Brutos_VendedorDropDownList.DataTextField = "Descr";
                Condicion_Ingresos_Brutos_VendedorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();

                Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();

                Condicion_IVA_CompradorDropDownList.DataValueField = "Codigo";
                Condicion_IVA_CompradorDropDownList.DataTextField = "Descr";
                Condicion_IVA_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();

                //Condicion_Ingresos_Brutos_CompradorDropDownList.DataValueField = "Codigo";
                //Condicion_Ingresos_Brutos_CompradorDropDownList.DataTextField = "Descr";
                //Condicion_Ingresos_Brutos_CompradorDropDownList.DataSource = FeaEntidades.CondicionesIB.CondicionIB.Lista();

                Tipo_De_ComprobanteDropDownList.DataValueField = "Codigo";
                Tipo_De_ComprobanteDropDownList.DataTextField = "Descr";
                Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();

                CodigoOperacionDropDownList.DataValueField = "Codigo";
                CodigoOperacionDropDownList.DataTextField = "Descr";
                CodigoOperacionDropDownList.DataSource = FeaEntidades.CodigosOperacion.CodigoOperacion.Lista();

                Provincia_CompradorDropDownList.DataValueField = "Codigo";
                Provincia_CompradorDropDownList.DataTextField = "Descr";
                Provincia_CompradorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();

                Provincia_VendedorDropDownList.DataValueField = "Codigo";
                Provincia_VendedorDropDownList.DataTextField = "Descr";
                Provincia_VendedorDropDownList.DataSource = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();

                IVAcomputableDropDownList.DataValueField = "Codigo";
                IVAcomputableDropDownList.DataTextField = "Descr";
                IVAcomputableDropDownList.DataSource = FeaEntidades.Dicotomicos.Dicotomico.Lista();

                MonedaComprobanteDropDownList.DataValueField = "Codigo";
                MonedaComprobanteDropDownList.DataTextField = "Descr";
                MonedaComprobanteDropDownList.DataSource = FeaEntidades.CodigosMoneda.CodigoMoneda.ListaNoExportacion();

                TipoExpDropDownList.DataValueField = "Codigo";
                TipoExpDropDownList.DataTextField = "Descr";
                TipoExpDropDownList.DataSource = FeaEntidades.TiposExportacion.TipoExportacion.ListaSinInformar();

                IdiomaDropDownList.DataValueField = "Codigo";
                IdiomaDropDownList.DataTextField = "Descr";
                IdiomaDropDownList.DataSource = FeaEntidades.Idiomas.Idioma.ListaSinInformar();

                PaisDestinoExpDropDownList.DataValueField = "Codigo";
                PaisDestinoExpDropDownList.DataTextField = "Descr";
                PaisDestinoExpDropDownList.DataSource = FeaEntidades.DestinosPais.DestinoPais.ListaSinInformar();

                IncotermsDropDownList.DataValueField = "Codigo";
                IncotermsDropDownList.DataTextField = "Descr";
                IncotermsDropDownList.DataSource = FeaEntidades.Incoterms.Incoterm.ListaSinInformar();

                CodigoConceptoDropDownList.DataValueField = "Codigo";
                CodigoConceptoDropDownList.DataTextField = "Descr";
                CodigoConceptoDropDownList.DataSource = FeaEntidades.CodigosConcepto.CodigosConcepto.Lista();

                DataBind();

                BindearDropDownLists();
                MonedaComprobanteDropDownList.Enabled = true;

                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    if (sesion.Usuario.Id != null)
                    {
                        //Email_VendedorRequiredFieldValidator.Enabled = false;
                        GenerarButton.ToolTip = "se enviará, al vendedor, a " + ((Entidades.Sesion)Session["Sesion"]).Usuario.Email;
                        CompradorDropDownList.Enabled = true;
                    }
                    if (sesion.Cuit.Nro != null && sesion.Cuit.Nro != "")
                    {
                        Entidades.Cuit v = ((Entidades.Sesion)Session["Sesion"]).Cuit;
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
                        Cuit_VendedorTextBox.Text = v.Nro.ToString();
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
                        CompradorDropDownList.DataValueField = "RazonSocial";
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
                    System.Collections.Generic.List<Entidades.PuntoVta> listaPuntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVtaVigentes;
                    PuntoVtaDropDownList.Visible = true;
                    PuntoVtaDropDownList.DataValueField = "Nro";
                    PuntoVtaDropDownList.DataTextField = "Nro";
                    PuntoVtaDropDownList.DataSource = listaPuntoVta;
                    PuntoVtaDropDownList.DataBind();
                    PuntoVtaDropDownList_SelectedIndexChanged(PuntoVtaDropDownList, new EventArgs());

                    try
                    {
                        FeaEntidades.InterFacturas.lote_comprobantes lote = (FeaEntidades.InterFacturas.lote_comprobantes)Cache["ComprobanteAClonar"];
                        CompletarUI(lote, new EventArgs());
                        VerificarMetodoNumeracionLote();
                        Numero_ComprobanteTextBox.Text = string.Empty;
                        FechaEmisionDatePickerWebUserControl.Text = string.Empty;
                        FechaServDesdeDatePickerWebUserControl.Text = string.Empty;
                        FechaServHastaDatePickerWebUserControl.Text = string.Empty;
                        FechaVencimientoDatePickerWebUserControl.Text = string.Empty;
                        Id_LoteTextbox.Text = string.Empty;
                        CAETextBox.Text = string.Empty;
                        FechaCAEObtencionDatePickerWebUserControl.Text = string.Empty;
                        FechaCAEVencimientoDatePickerWebUserControl.Text = string.Empty;
                    }
                    catch
                    {
                    }
                    //sesion.Cuit.DestinosComprobante();
                }
            }
        }

        private void VerificarMetodoNumeracionLote()
        {
            TipoNumeracionLote.Text = "";
            if (!PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
            {
                int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.PuntoVta pVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    });
                    if (!pVta.IdMetodoGeneracionNumeracionLote.Equals(string.Empty))
                    {
                        TipoNumeracionLote.Text = pVta.IdMetodoGeneracionNumeracionLote;
                        switch (pVta.IdMetodoGeneracionNumeracionLote)
                        {
                            case "Autonumerador":
                            case "TimeStamp1":
                            case "TimeStamp2":
                                Id_LoteTextbox.Enabled = false;
                                ButtonGenerarNroLote.Visible = true;
                                break;
                            case "Ninguno":
                                Id_LoteTextbox.Enabled = true;
                                ButtonGenerarNroLote.Visible = false;
                                break;
                        }
                    }
                }
            }
        }

		private void BindearDropDownLists()
		{
			AjustarCodigosDeReferenciaEnFooter();
			ImpuestosGlobales.BindearDropDownLists();
			PermisosExpo.BindearDropDownLists();
			DetalleLinea.BindearDropDownLists();
		}

        private void AjustarCodigosDeReferenciaEnFooter()
        {
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataValueField = "Codigo";
            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataTextField = "Descr";
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Entidades.Sesion)Session["Sesion"]).Usuario != null)
                {
                    //if (!Punto_VentaTextBox.Text.Equals(string.Empty))
                    if (!PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        int auxPV;
                        try
                        {
                            auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                            {
                                return pv.Nro == auxPV;
                            }).IdTipoPuntoVta;
                            switch (idtipo)
                            {
                                case "Comun":
                                case "RG2904":
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                                    break;
                                case "BonoFiscal":
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                                    break;
                                case "Exportacion":
                                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
                                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = false;
                                    break;
                                default:
                                    throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                            }
                        }
                        catch
                        {
                            ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                            ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                        }
                    }
                    else
                    {
                        ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                        ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                        ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                    }
                }
                else
                {
                    ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                    ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoFilteredTextBoxExtender")).Enabled = true;
                }
                ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).DataBind();
            }
        }

        protected void GenerarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ActualizarEstadoButton.Visible = false;
                DescargarPDFButton.Visible = false;
                ActualizarEstadoButton.DataBind();
                DescargarPDFButton.DataBind();
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    try
                    {
                        ValidarCamposObligatorios();

                        //Generar Lote
                        FeaEntidades.InterFacturas.lote_comprobantes lote = GenerarLote(false);

                        //Grabar en base de datos
                        RN.Comprobante comprobante = new RN.Comprobante();
                        lote.cabecera_lote.DestinoComprobante = "ITF";
                        lote.comprobante[0].cabecera.informacion_comprobante.Observacion = "";

                        //Registrar comprobante si no es el usuario de DEMO.
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        if (sesion.UsuarioDemo != true)
                        {
                            Entidades.Comprobante cAux = new Entidades.Comprobante();
                            cAux.Cuit = lote.cabecera_lote.cuit_vendedor.ToString();
                            cAux.TipoComprobante.Id = lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                            cAux.NroPuntoVta = lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                            cAux.Nro = lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                            comprobante.Leer(cAux, sesion);
                            if (cAux.Estado == null || cAux.Estado != "Vigente")
                            {
                                comprobante.Registrar(lote, null, Session["IdNaturalezaComprobante"].ToString(), "ITF", ((Entidades.Sesion)Session["Sesion"]));
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('No se registro el comprobante en la base de datos ya que el comprobante está vigente.\\n');</script>", false);
                                return;
                            }
                        }
                        
                        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(lote.cabecera_lote.cuit_vendedor);
                        sb.Append("-");
                        sb.Append(lote.cabecera_lote.punto_de_venta.ToString("0000"));
                        sb.Append("-");
                        sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString("00"));
                        sb.Append("-");
                        sb.Append(lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante.ToString("00000000"));
                        sb.Append(".xml");

                        System.IO.MemoryStream m = new System.IO.MemoryStream();
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(m);
                        sw.Flush();
                        System.Xml.XmlWriter writerdememoria = new System.Xml.XmlTextWriter(m, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                        x.Serialize(writerdememoria, lote);
                        m.Seek(0, System.IO.SeekOrigin.Begin);

                        string smtpXAmb = System.Configuration.ConfigurationManager.AppSettings["Ambiente"].ToString();
                        System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();

                        try
                        {
                            RegistrarActividad(lote, sb, smtpClient, smtpXAmb, m);
                        }
                        catch
                        {
                        }

                        if (((Button)sender).ID == "DescargarButton")
                        {
                            //Descarga directa del XML
                            System.IO.FileStream fs = new System.IO.FileStream(Server.MapPath(@"~/Temp/" + sb.ToString()), System.IO.FileMode.Create);
                            m.WriteTo(fs);
                            fs.Close();
                            Server.Transfer("~/DescargaTemporarios.aspx?archivo=" + sb.ToString(), false);
                        }
                        else
                        {
                            //Envio por mail del XML
                            System.Net.Mail.MailMessage mail;
                            if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id != null)
                            {
                                mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
                                    ((Entidades.Sesion)Session["Sesion"]).Usuario.Email,
                                    "Ced-eFact-Envío automático archivo XML:" + sb.ToString()
                                    , string.Empty);
                            }
                            else
                            {
                                mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar",
                                    Email_VendedorTextBox.Text,
                                    "Ced-eFact-Envío automático archivo XML:" + sb.ToString()
                                    , string.Empty);
                            }
                            System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                            contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                            contentType.Name = sb.ToString();
                            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(m, contentType);
                            mail.Attachments.Add(attachment);
                            mail.BodyEncoding = System.Text.Encoding.UTF8;
                            mail.Body = Mails.Body.AgregarBody();
                            smtpClient.Host = "localhost";
                            if (smtpXAmb.Equals("DESA"))
                            {
                                string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
                                if (MailServidorSmtp != "")
                                {
                                    string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
                                    string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
                                    smtpClient.Host = MailServidorSmtp;
                                    if (MailCredencialesUsr != "")
                                    {
                                        smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
                                    }
                                    smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
                                }
                            }
                            smtpClient.Send(mail);
                        }
                        m.Close();

                        if (!smtpXAmb.Equals("DESA"))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente');window.open('https://srv1.interfacturas.com.ar/cfeWeb/faces/login/identificacion.jsp/', '_blank');</script>", false);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Archivo enviado satisfactoriamente.');</script>", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al generar el archivo.\\n " + ex.Message + "');</script>", false);
                    }
                }
            }
        }

		protected void referenciasGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			referenciasGridView.EditIndex = -1;
			referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();
		}
		
		protected void referenciasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Addreferencias"))
			{
				try
				{
					FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					string auxCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue.ToString();
					string auxDescrCodRef = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
					if (!auxCodRef.Equals(string.Empty))
					{
						r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
						r.descripcioncodigo_de_referencia = auxDescrCodRef;
					}
					else
					{
						throw new Exception("Referencia no agregada porque el código de referencia no puede estar vacío");
					}
					string auxDatoRef = ((TextBox)referenciasGridView.FooterRow.FindControl("txtdato_de_referencia")).Text;
					if (auxDatoRef.Contains("?"))
					{
						throw new Exception("Referencia no agregada porque el número de referencia no respeta el formato para exportación");
					}
					else
					{
						r.dato_de_referencia = auxDatoRef;
					}
					((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Add(r);
					//Me fijo si elimino la fila automática
					System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
					if (refs[0].codigo_de_referencia == 0)
					{
						((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]).Remove(refs[0]);
					}

					//Saco de edición la fila que estén modificando
					if (!referenciasGridView.EditIndex.Equals(-1))
					{
						referenciasGridView.EditIndex = -1;
					}

					referenciasGridView.DataSource = ViewState["referencias"];
					referenciasGridView.DataBind();
					BindearDropDownLists();
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
				}
			}
		}
		
		protected void referenciasGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + e.Exception.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
				e.ExceptionHandled = true;
			}
		}
		
		protected void referenciasGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				refs.Remove(r);
				if (refs.Count.Equals(0))
				{
					FeaEntidades.InterFacturas.informacion_comprobanteReferencias nuevo = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
					refs.Add(nuevo);
				}
				referenciasGridView.EditIndex = -1;
				referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch
			{
			}
		}
		
		protected void referenciasGridView_RowEditing(object sender, GridViewEditEventArgs e)
		{
			referenciasGridView.EditIndex = e.NewEditIndex;

			referenciasGridView.DataSource = ViewState["referencias"];
			referenciasGridView.DataBind();
			BindearDropDownLists();

			AjustarCodigoReferenciaEnEdicion(sender, e);

			try
			{
				ListItem li = ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).Items.FindByValue(((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"])[e.NewEditIndex].codigo_de_referencia.ToString());
				li.Selected = true;
			}
			catch
			{
			}
		}

        private void AjustarCodigoReferenciaEnEdicion(object sender, GridViewEditEventArgs e)
        {
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataValueField = "Codigo";
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataTextField = "Descr";
            if (!PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
            {
                int auxPV;
                try
                {
                    auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
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
                        switch (idtipo)
                        {
                            case "Comun":
                            case "RG2904":
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                                break;
                            case "BonoFiscal":
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                                break;
                            case "Exportacion":
                                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.Exportaciones.Exportacion.Lista();
                                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = true;
                                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = false;
                                break;
                            default:
                                throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                        }
                    }
                }
                catch
                {
                    ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                    ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                    ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
                }
            }
            else
            {
                ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataSource = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista();
                ((AjaxControlToolkit.MaskedEditExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoMaskedEditExtender")).Enabled = false;
                ((AjaxControlToolkit.FilteredTextBoxExtender)((GridView)sender).Rows[e.NewEditIndex].FindControl("txtdato_de_referenciaEditExpoFilteredTextBoxExtender")).Enabled = true;
            }
            ((DropDownList)((GridView)sender).Rows[e.NewEditIndex].FindControl("ddlcodigo_de_referenciaEdit")).DataBind();
        }
		
		protected void referenciasGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			if (e.Exception != null)
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
				e.ExceptionHandled = true;
			}
		}
		
		protected void referenciasGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> refs = ((System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"]);
				FeaEntidades.InterFacturas.informacion_comprobanteReferencias r = refs[e.RowIndex];
				string auxCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedValue.ToString();
				string auxDescrCodRef = ((DropDownList)referenciasGridView.Rows[e.RowIndex].FindControl("ddlcodigo_de_referenciaEdit")).SelectedItem.Text;
				if (!auxCodRef.Equals(string.Empty))
				{
					r.codigo_de_referencia = Convert.ToInt32(auxCodRef);
					r.descripcioncodigo_de_referencia = auxDescrCodRef;
				}
				else
				{
					throw new Exception("Referencia no actualizada porque el código de referencia no puede estar vacío");
				}
				string auxDatoRef = ((TextBox)referenciasGridView.Rows[e.RowIndex].FindControl("txtdato_de_referencia")).Text;
				if (auxDatoRef.Contains("?"))
				{
					throw new Exception("Referencia no actualizada porque el número de referencia no respeta el formato para exportación");
				}
				else
				{
					r.dato_de_referencia = auxDatoRef;
				}

				referenciasGridView.EditIndex = -1;
				referenciasGridView.DataSource = ViewState["referencias"];
				referenciasGridView.DataBind();
				BindearDropDownLists();
			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
			}
		}

		protected void FileUploadButton_Click(object sender, EventArgs e)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ActualizarEstadoButton.Visible = false;
                DescargarPDFButton.Visible = false;
                ActualizarEstadoButton.DataBind();
                DescargarPDFButton.DataBind();
                if (((Button)sender).ID == "FileUploadButton" && ((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                    if (XMLFileUpload.HasFile)
                    {
                        try
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(XMLFileUpload.FileBytes);
                            ms.Seek(0, System.IO.SeekOrigin.Begin);

                            try
                            {
                                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lc.GetType());
                                lc = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                                CompletarUI(lc, e);
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo');</script>", false);
                            }
                            catch (InvalidOperationException)
                            {
                                try
                                {
                                    LeerFormatoDetalleIBK(e, lc, ms);
                                }
                                catch (InvalidOperationException)
                                {
                                    LeerFormatoLoteIBK(e, lc, ms);
                                }
                            }
                        }
                        catch
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('El archivo no cumple con el esquema de Interfacturas');</script>", false);
                        }
                    }
                    else
                    {
                        //MensajePopupLabel.Text = "Debe seleccionar un archivo";
                        //PruebaPopupButton_Click(PruebaPopupButton, new EventArgs());
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Debe seleccionar un archivo');</script>", false);
                    }
                    VerificarMetodoNumeracionLote();
                }
            }
		}

        protected void PruebaPopupButton_Click(object sender, EventArgs e)
        {
            //ModalPopupExtender1.Show();
        }

		private void LeerFormatoDetalleIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
		{
			//Formato detalle_factura IBK
			ms.Seek(0, System.IO.SeekOrigin.Begin);
			FeaEntidades.InterFacturas.comprobante c = new FeaEntidades.InterFacturas.comprobante();
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(c.GetType());
			c = (FeaEntidades.InterFacturas.comprobante)x.Deserialize(ms);
			FeaEntidades.InterFacturas.comprobante[] cArray = new FeaEntidades.InterFacturas.comprobante[1];
			cArray[0] = c;
			lc.comprobante = cArray;
			CompletarUI(lc, e);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo de formato detalle_factura.xml');</script>", false);
		}

		private void LeerFormatoLoteIBK(EventArgs e, FeaEntidades.InterFacturas.lote_comprobantes lc, System.IO.MemoryStream ms)
		{
			try
			{
				//Formato Lote IBK
				ms.Seek(0, System.IO.SeekOrigin.Begin);
				FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response clr = new FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response();
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(clr.GetType());
				clr = (FeaEntidades.InterFacturas.XML.consulta_lote_comprobantes_response)x.Deserialize(ms);
				lc = clr.consulta_lote_response.lote_comprobantes;
				CompletarUI(lc, e);
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Datos del comprobante correctamente cargados desde el archivo de formato Lote IBK');</script>");
			}
			catch
			{
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('El archivo no cumple con el esquema de Interfacturas');</script>", false);
			}
		}

		private void CompletarUI(FeaEntidades.InterFacturas.lote_comprobantes lc, EventArgs e)
		{
			//Cabecera
			CompletarCabecera(lc);

			//Comprobante
			CompletarComprobante(lc);

			//Exportacion
			CompletarExportacion(lc);

			//Referencias
			CompletarReferencias(lc);

			PermisosExpo.CompletarPermisos(lc);

			//Comprador
			CompletarComprador(lc);

			//Vendedor
			CompletarVendedor(lc);

			//Detalle
			DetalleLinea.CompletarDetalles(lc);

			//Descuentos globales
			DescuentosGlobales.Completar(lc);

			//impuestos globales
			ImpuestosGlobales.Completar(lc);

			ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;

			//Resumen
			CompletarResumen(lc);

			Observaciones_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.observaciones);
			if (!lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
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
			CompletarCAE(lc);

			BindearDropDownLists();
		}

		private void CompletarCAE(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
            CAETextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.cae;
            FechaCAEObtencionDatePickerWebUserControl.Text = lc.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae;
            FechaCAEVencimientoDatePickerWebUserControl.Text = lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae;
            //ResultadoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.resultado;
            //MotivoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.motivo;
		}

        private void CompletarComprobante(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
            FechaEmisionDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
            FechaVencimientoDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
            FechaServDesdeDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
            FechaServHastaDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
            Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
            IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
            CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));
            CodigoConceptoDropDownList.SelectedIndex = CodigoConceptoDropDownList.Items.IndexOf(CodigoConceptoDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_concepto)));
        }

		private void CompletarCabecera(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			try
			{
				Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
				Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
				PuntoVtaDropDownList.SelectedValue = Convert.ToString(lc.cabecera_lote.punto_de_venta);
				int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
				ViewState["PuntoVenta"] = auxPV;
				DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
                Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
				AjustarCamposXPtaVentaChanged(PuntoVtaDropDownList.SelectedValue);
				AjustarCamposXVersion(lc);
				Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
			}
			catch (NullReferenceException)//detalle_factura.xml
			{
				PuntoVtaDropDownList.SelectedValue = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
				int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
				ViewState["PuntoVenta"] = auxPV;
				DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
				AjustarCamposXPtaVentaChanged(PuntoVtaDropDownList.SelectedValue);
				AjustarCamposXVersion(lc);
				Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
			}
		}

        private void CompletarExportacion(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion != null)
            {
                PaisDestinoExpDropDownList.SelectedIndex = PaisDestinoExpDropDownList.Items.IndexOf(PaisDestinoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante)));
                IncotermsDropDownList.SelectedIndex = IncotermsDropDownList.Items.IndexOf(IncotermsDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.incoterms)));
                TipoExpDropDownList.SelectedIndex = TipoExpDropDownList.Items.IndexOf(TipoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion)));
            }
            else
            {
                PaisDestinoExpDropDownList.SelectedIndex = -1;
                IncotermsDropDownList.SelectedIndex = -1;
                TipoExpDropDownList.SelectedIndex = -1;
            }
            PaisDestinoExpDropDownList_SelectedIndexChanged(PaisDestinoExpDropDownList, new EventArgs());
            if (lc.comprobante[0].extensiones != null)
            {
                if (lc.comprobante[0].extensiones.extensiones_camara_facturas != null)
                {
                    IdiomaDropDownList.SelectedIndex = IdiomaDropDownList.Items.IndexOf(IdiomaDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].extensiones.extensiones_camara_facturas.id_idioma)));
                }
                else
                {
                    IdiomaDropDownList.SelectedIndex = -1;
                }
                if (lc.comprobante[0].extensiones.extensiones_datos_comerciales != null && lc.comprobante[0].extensiones.extensiones_datos_comerciales != "")
                {
                    //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                    if (lc.comprobante[0].extensiones.extensiones_datos_comerciales.Substring(0, 1) == "%")
                    {
                        DatosComerciales.Texto = RN.Funciones.HexToString(lc.comprobante[0].extensiones.extensiones_datos_comerciales).Replace("<br>", System.Environment.NewLine);
                    }
                    else
                    {
                        DatosComerciales.Texto = lc.comprobante[0].extensiones.extensiones_datos_comerciales.Replace("<br>", System.Environment.NewLine);
                    }
                }
                else
                {
                    DatosComerciales.Texto = string.Empty;
                }
            }
            else
            {
                IdiomaDropDownList.SelectedIndex = -1;
                DatosComerciales.Texto = string.Empty;
            }
        }

		private void CompletarReferencias(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
			if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
			{
				foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
				{
					//descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
					//Se busca la descripción a través del código.
					try
					{
						if (r != null)
						{
							string descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
							((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedValue = r.codigo_de_referencia.ToString();
							descrcodigo = ((DropDownList)referenciasGridView.FooterRow.FindControl("ddlcodigo_de_referencia")).SelectedItem.Text;
							r.descripcioncodigo_de_referencia = descrcodigo;
							referencias.Add(r);
						}
					}
					catch
					//Referencia no valida
					{
					}
				}
			}
			if (referencias.Count.Equals(0))
			{
				referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
			}
			referenciasGridView.DataSource = referencias;
			referenciasGridView.DataBind();
			ViewState["referencias"] = referencias;
		}

        private void CompletarVendedor(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_vendedor.razon_social != null)
            {
                Razon_Social_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.razon_social);
            }
            Localidad_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.localidad);
            if (lc.comprobante[0].cabecera.informacion_vendedor.GLN != 0)
            {
                GLN_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.GLN);
            }
            Email_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.email);
            Cuit_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cuit);
            Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.provincia)));
            Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVA)));
            Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutos)));
            Cp_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cp);
            Contacto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.contacto);
            Telefono_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.telefono);
            Codigo_Interno_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.codigo_interno);
            NroIBVendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.nro_ingresos_brutos);
            InicioDeActividadesVendedorDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.inicio_de_actividades);
            Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle);
            Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_numero);
            Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_piso);
            Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_depto);
            Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_sector);
            Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_torre);
            Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_manzana);
        }

        private void CompletarComprador(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            if (lc.comprobante[0].cabecera.informacion_comprador.GLN != 0)
            {
                GLN_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.GLN);
            }
            Codigo_Interno_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_interno);
            if (!lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.Equals(70) || PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio);
            }
            else
            {
                Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio)));
            }
            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Codigo_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Codigo_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio)));
            Denominacion_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.denominacion);
            Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle);
            Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
            Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
            Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
            Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
            Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
            Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
            Localidad_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.localidad);
            Cp_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.cp);
            Contacto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.contacto);
            Email_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.email);
            Telefono_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.telefono);
            InicioDeActividadesCompradorDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.inicio_de_actividades);
            Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.provincia)));
            Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.condicion_IVA)));
            if (lc.comprobante[0].extensiones != null)
            {
                if (lc.comprobante[0].extensiones.extensiones_destinatarios != null)
                {
                    EmailAvisoVisualizacionTextBox.Text = lc.comprobante[0].extensiones.extensiones_destinatarios.email;
                }
            }
        }

		private void CompletarResumen(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
			MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].resumen.codigo_moneda)));
			Tipo_de_cambioTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.tipo_de_cambio);
			if (lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_factura);
				if (lc.comprobante[0].resumen.importe_total_impuestos_nacionalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_nacionales);
				}
				else
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_impuestos_municipalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_municipales);
				}
				else
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_impuestos_internosSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_internos);
				}
				else
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importe_total_ingresos_brutosSpecified.Equals(true))
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_ingresos_brutos);
				}
				else
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
				}
			}
			else
			{
				Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado);
				Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
				Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas);
				Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq);
				Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni);
				Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura);
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
				}
				else
				{
					Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales);
				}
				else
				{
					Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified.Equals(true))
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos);
				}
				else
				{
					Importe_Total_Impuestos_Internos_ResumenTextBox.Text = string.Empty;
				}
				if (lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified.Equals(true))
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos);
				}
				else
				{
					Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = string.Empty;
				}
			}
		}

        private void CompletarUI(org.dyndns.cedweb.consulta.ConsultarResult lc, EventArgs e)
        {
            //Cabecera
            Tipo_De_ComprobanteDropDownList.SelectedIndex = Tipo_De_ComprobanteDropDownList.Items.IndexOf(Tipo_De_ComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante)));
            Id_LoteTextbox.Text = Convert.ToString(lc.cabecera_lote.id_lote);
            Presta_ServCheckBox.Checked = Convert.ToBoolean(lc.cabecera_lote.presta_serv);
            PuntoVtaDropDownList.SelectedValue = Convert.ToString(lc.cabecera_lote.punto_de_venta);
            int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
            ViewState["PuntoVenta"] = auxPV;
            DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
            AjustarCamposXPtaVentaChanged(PuntoVtaDropDownList.SelectedValue);
            AjustarCamposXVersion(lc);
            //Comprobante
            Numero_ComprobanteTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante);
            FechaEmisionDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
            FechaVencimientoDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
            FechaServDesdeDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde);
            FechaServHastaDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta);
            Condicion_De_PagoTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago);
            IVAcomputableDropDownList.SelectedIndex = IVAcomputableDropDownList.Items.IndexOf(IVAcomputableDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.iva_computable)));
            CodigoOperacionDropDownList.SelectedIndex = CodigoOperacionDropDownList.Items.IndexOf(CodigoOperacionDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.codigo_operacion)));

            //Exportacion
            if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion != null)
            {
                PaisDestinoExpDropDownList.SelectedIndex = PaisDestinoExpDropDownList.Items.IndexOf(PaisDestinoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante)));
                IncotermsDropDownList.SelectedIndex = IncotermsDropDownList.Items.IndexOf(IncotermsDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.incoterms)));
                TipoExpDropDownList.SelectedIndex = TipoExpDropDownList.Items.IndexOf(TipoExpDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion)));
            }
            else
            {
                PaisDestinoExpDropDownList.SelectedIndex = -1;
                IncotermsDropDownList.SelectedIndex = -1;
                TipoExpDropDownList.SelectedIndex = -1;
            }
            if (lc.comprobante[0].extensiones != null)
            {
                if (lc.comprobante[0].extensiones.extensiones_camara_facturas != null)
                {
                    IdiomaDropDownList.SelectedIndex = IdiomaDropDownList.Items.IndexOf(IdiomaDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].extensiones.extensiones_camara_facturas.id_idioma)));
                }
                else
                {
                    IdiomaDropDownList.SelectedIndex = -1;
                }
                if (lc.comprobante[0].extensiones.extensiones_datos_comerciales != null && lc.comprobante[0].extensiones.extensiones_datos_comerciales != "")
                {
                    //Compatibilidad con archivos xml viejos. Verificar si la descripcion está en Hexa.
                    if (lc.comprobante[0].extensiones.extensiones_datos_comerciales.Substring(0, 1) == "%")
                    {
                        DatosComerciales.Texto = RN.Funciones.HexToString(lc.comprobante[0].extensiones.extensiones_datos_comerciales).Replace("<br>", System.Environment.NewLine);
                    }
                    else
                    {
                        DatosComerciales.Texto = lc.comprobante[0].extensiones.extensiones_datos_comerciales.Replace("<br>", System.Environment.NewLine);
                    }
                }
            }
            else
            {
                IdiomaDropDownList.SelectedIndex = -1;
            }

            //Referencias
            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
            {
                referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
                foreach (org.dyndns.cedweb.consulta.ConsultarResultComprobanteCabeceraInformacion_comprobanteReferencias r in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
                {
                    //descripcioncodigo_de_referencia ( XmlIgnoreAttribute )
                    //Se busca la descripción a través del código.
                    if (r != null)
                    {
                        FeaEntidades.InterFacturas.informacion_comprobanteReferencias icr = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                        icr.codigo_de_referencia = r.codigo_de_referencia;
                        icr.dato_de_referencia = Convert.ToString(r.dato_de_referencia);
                        icr.descripcioncodigo_de_referencia = FeaEntidades.CodigosReferencia.CodigoReferencia.Lista()
                            .Find(
                            delegate(FeaEntidades.CodigosReferencia.CodigoReferencia c)
                            {
                                return c.Codigo == Convert.ToString(icr.codigo_de_referencia);
                            }
                            ).Descr;
                        referencias.Add(icr);
                    }
                }
                if (referencias.Count.Equals(0))
                {
                    referencias.Add(new FeaEntidades.InterFacturas.informacion_comprobanteReferencias());
                }
                referenciasGridView.DataSource = referencias;
                referenciasGridView.DataBind();
                ViewState["referencias"] = referencias;
            }
            //Comprador
            if (lc.comprobante[0].cabecera.informacion_comprador.GLN != 0)
            {
                GLN_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.GLN);
            }
            Codigo_Interno_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.codigo_interno);
            Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio);
            Denominacion_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.denominacion);
            Domicilio_Calle_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle);
            Domicilio_Numero_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero);
            Domicilio_Piso_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_piso);
            Domicilio_Depto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_depto);
            Domicilio_Sector_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_sector);
            Domicilio_Torre_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_torre);
            Domicilio_Manzana_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.domicilio_manzana);
            Localidad_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.localidad);
            Cp_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.cp);
            Contacto_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.contacto);
            Email_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.email);
            Telefono_CompradorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.telefono);
            InicioDeActividadesCompradorDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.inicio_de_actividades);
            Provincia_CompradorDropDownList.SelectedIndex = Provincia_CompradorDropDownList.Items.IndexOf(Provincia_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.provincia)));
            Condicion_IVA_CompradorDropDownList.SelectedIndex = Condicion_IVA_CompradorDropDownList.Items.IndexOf(Condicion_IVA_CompradorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_comprador.condicion_IVA)));
            //Vendedor
            if (lc.comprobante[0].cabecera.informacion_vendedor.razon_social != null)
            {
                Razon_Social_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.razon_social);
            }
            Localidad_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.localidad);
            if (lc.comprobante[0].cabecera.informacion_vendedor.GLN != 0)
            {
                GLN_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.GLN);
            }
            Email_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.email);
            Cuit_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cuit);
            Provincia_VendedorDropDownList.SelectedIndex = Provincia_VendedorDropDownList.Items.IndexOf(Provincia_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.provincia)));
            Condicion_IVA_VendedorDropDownList.SelectedIndex = Condicion_IVA_VendedorDropDownList.Items.IndexOf(Condicion_IVA_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_IVA)));
            Condicion_Ingresos_Brutos_VendedorDropDownList.SelectedIndex = Condicion_Ingresos_Brutos_VendedorDropDownList.Items.IndexOf(Condicion_Ingresos_Brutos_VendedorDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.condicion_ingresos_brutos)));
            Cp_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.cp);
            Contacto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.contacto);
            Telefono_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.telefono);
            Codigo_Interno_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.codigo_interno);
            NroIBVendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.nro_ingresos_brutos);
            InicioDeActividadesVendedorDatePickerWebUserControl.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.inicio_de_actividades);
            Domicilio_Calle_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_calle);
            Domicilio_Numero_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_numero);
            Domicilio_Piso_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_piso);
            Domicilio_Depto_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_depto);
            Domicilio_Sector_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_sector);
            Domicilio_Torre_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_torre);
            Domicilio_Manzana_VendedorTextBox.Text = Convert.ToString(lc.comprobante[0].cabecera.informacion_vendedor.domicilio_manzana);

            //Detalle
            DetalleLinea.CompletarDetallesWS(lc);

            //Descuentos globales
            DescuentosGlobales.CompletarDetallesWS(lc);

            //impuestos globales
            ImpuestosGlobales.CompletarWS(lc);

            ComentariosTextBox.Text = lc.comprobante[0].detalle.comentarios;
            //Resumen
            MonedaComprobanteDropDownList.SelectedIndex = MonedaComprobanteDropDownList.Items.IndexOf(MonedaComprobanteDropDownList.Items.FindByValue(Convert.ToString(lc.comprobante[0].resumen.codigo_moneda)));
            Tipo_de_cambioTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.tipo_de_cambio);
            if (lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_factura);
                Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_nacionales);
                Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_municipales);
                Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_impuestos_internos);
                Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importe_total_ingresos_brutos);
            }
            else
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado);
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado);
                Importe_Operaciones_Exentas_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas);
                Impuesto_Liq_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq);
                Impuesto_Liq_Rni_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni);
                Importe_Total_Factura_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura);
                Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_nacionales);
                Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_municipales);
                Importe_Total_Impuestos_Internos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_impuestos_internos);
                Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_ingresos_brutos);
            }
            Observaciones_ResumenTextBox.Text = Convert.ToString(lc.comprobante[0].resumen.observaciones);
            if (!lc.comprobante[0].resumen.codigo_moneda.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
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
            CAETextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.cae;
            FechaCAEObtencionDatePickerWebUserControl.Text = lc.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae;
            FechaCAEVencimientoDatePickerWebUserControl.Text = lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae;
            //ResultadoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.resultado;
            //MotivoTextBox.Text = lc.comprobante[0].cabecera.informacion_comprobante.motivo;
            //MotivoLoteTextBox.Text = lc.cabecera_lote.motivo;
            BindearDropDownLists();
        }
		
		protected void MonedaComprobanteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		
		protected void CompradorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			AjustarComprador();
		}

        private void AjustarComprador()
        {
            Entidades.Persona comprador = new Entidades.Persona();
            //comprador.IdCliente = ((Entidades.Sesion)Session["Sesion"]).Usuario.Id;
            //comprador.RazonSocial = Convert.ToString(CompradorDropDownList.SelectedItem.Text);
            comprador.RazonSocial = Convert.ToString(CompradorDropDownList.SelectedValue);
            int auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    RN.Persona.Leer(comprador, (Entidades.Sesion)Session["Sesion"]);
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
                    if (!idtipo.Equals("Exportacion") || (comprador.DocumentoIdTipoDoc != null && comprador.DocumentoIdTipoDoc != "70") || PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
                    {
                        Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                        Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                        Nro_Doc_Identificatorio_CompradorTextBox.Text = Convert.ToString(comprador.Documento.Nro);
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
                    }
                    else
                    {
                        Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                        Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                        Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Convert.ToString(comprador.Documento.Nro)));
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
                    }
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                    Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue = Convert.ToString(comprador.Documento.Tipo.Id);

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
                        string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                        {
                            return pv.Nro == auxPV;
                        }).IdTipoPuntoVta;
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                        if (!idtipo.Equals("Exportacion"))
                        {
                            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                            Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
                        }
                        else
                        {
                            Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                            //Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                            //Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                            Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                            Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                            Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
                            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
                        }
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                        Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
                    }
                }
                catch
                {
                    Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                    Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                    Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
                }
                ResetearComprador();
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
			Codigo_Interno_CompradorTextBox.Text = string.Empty;
			InicioDeActividadesCompradorDatePickerWebUserControl.Text = string.Empty;
			EmailAvisoVisualizacionTextBox.Text = string.Empty;
			PasswordAvisoVisualizacionTextBox.Text = string.Empty;
		}
		
		protected void CalcularTotalesButton_Click(object sender, EventArgs e)
		{
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                if (((Button)sender).ID == "DescargarButton" && ((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.');</SCRIPT>", false);
                }
                else
                {
                    try
                    {
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

                        DetalleLinea.CalcularTotalesLineas(ref totalGravado, ref totalNoGravado, ref totalIVA, ref total_Operaciones_Exentas);
                        //Proceso IMPUESTOS GLOBALES
                        double total_Impuestos_Nacionales;
                        double total_Impuestos_Internos;
                        double total_Ingresos_Brutos;
                        double total_Impuestos_Municipales;

                        CalcularImpuestos(out total_Impuestos_Nacionales, out total_Impuestos_Internos, out total_Ingresos_Brutos, out total_Impuestos_Municipales);

                        //Asigno totales
                        if (!PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
                        {
                            int auxPV;
                            try
                            {
                                auxPV = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
                                string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                                {
                                    return pv.Nro == auxPV;
                                }).IdTipoPuntoVta;
                                double total;
                                switch (idtipo)
                                {
                                    case "Comun":
                                    case "RG2904":
                                        CalcularTotalesExceptoExportacion(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas);
                                        if (CodigoConceptoDropDownList.Visible)
                                        {
                                            ImpuestosGlobales.EliminarImpuestosIVA();
                                            ImpuestosGlobales.AgregarImpuestosIVA(DetalleLinea.Lineas);
                                            //Descontar descuentos a impuestos
                                            DescuentosGlobales.RestarDescuentosAImpuestosGlobales(ImpuestosGlobales.Lista);
                                            ImpuestosGlobales.Actualizar(ImpuestosGlobales.Lista);
                                        }
                                        break;
                                    case "BonoFiscal":
                                        CalcularTotalesExceptoExportacion(ref totalGravado, ref totalNoGravado, totalIVA, total_Impuestos_Nacionales, total_Impuestos_Internos, total_Ingresos_Brutos, total_Impuestos_Municipales, total_Operaciones_Exentas);
                                        break;
                                    case "Exportacion":
                                        total = totalGravado + totalNoGravado + totalIVA;
                                        Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
                                        break;
                                    default:
                                        throw new Exception("Tipo de punto de venta no contemplado en la lógica de la aplicación (" + idtipo + ")");
                                }
                            }
                            catch
                            {
                                throw new Exception("Para sugerir totales debe definir previamente el tipo del punto de venta(BF-Exp-Común) en la configuración de datos del vendedor");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al calcular los totales.\\n " + ex.Message + "');</SCRIPT>", false);
                    }
                    finally
                    {
                        //Restauro totales no informados
                        if (Importe_Total_Impuestos_Municipales_ResumenTextBox.Text == "0")
                            Importe_Total_Impuestos_Municipales_ResumenTextBox.Text = String.Empty;
                        if (Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text == "0")
                            Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text = String.Empty;
                        if (Importe_Total_Ingresos_Brutos_ResumenTextBox.Text == "0")
                            Importe_Total_Ingresos_Brutos_ResumenTextBox.Text = String.Empty;
                        if (Importe_Total_Impuestos_Internos_ResumenTextBox.Text == "0")
                            Importe_Total_Impuestos_Internos_ResumenTextBox.Text = String.Empty;
                    }
                }
            }
		}

		private void CalcularTotalesExceptoExportacion(ref double totalGravado, ref double totalNoGravado, double totalIVA, double total_Impuestos_Nacionales, double total_Impuestos_Internos, double total_Ingresos_Brutos, double total_Impuestos_Municipales, double total_Operaciones_Exentas)
		{
			double total;
			DescuentosGlobales.AplicarDtosATotales(ref totalGravado, ref totalNoGravado, ref total_Operaciones_Exentas, ref totalIVA);
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
			Importe_Total_Factura_ResumenTextBox.Text = total.ToString();
            if (Condicion_IVA_VendedorDropDownList.SelectedValue == "6")
            {
                Importe_Total_Neto_Gravado_ResumenTextBox.Text = totalNoGravado.ToString(); 
                Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text = "0";
            }
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
							if (!CodigoConceptoDropDownList.Visible)
							{
								total_Impuestos_Nacionales += listadeimpuestos[i].importe_impuesto;
							}
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

			referencias = new System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>();
			FeaEntidades.InterFacturas.informacion_comprobanteReferencias referencia = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
			referencias.Add(referencia);
			referenciasGridView.DataSource = referencias;
			ViewState["referencias"] = referencias;
			referenciasGridView.DataBind();

			BindearDropDownLists();
			PermisosExpo.ResetearGrillas();
			DetalleLinea.ResetearGrillas();

			ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Se han eliminado artículos, referencias y permisos de exportación por haber cambiado el tipo de punto de venta');</SCRIPT>", false);
		}

        private void AjustarCamposXPtaVentaChanged(string PuntoDeVenta)
        {
            if (!PuntoDeVenta.Equals(string.Empty))
            {
                int auxPV;
                AjustarCodigosDeReferenciaEnFooter();
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
                            case "Comun":
                                AjustarCamposXPtaVentaComun(out listacompradores);
                                break;
                            case "RG2904":
                                AjustarCamposXPtaVentaRG2904(out listacompradores, Tipo_De_ComprobanteDropDownList.SelectedValue);
                                break;
                            case "BonoFiscal":
                                AjustarCamposXPtaVentaBonoFiscal(out listacompradores);
                                break;
                            case "Exportacion":
                                AjustarCamposXPtaVentaExport(out listacompradores);
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
                            CompradorDropDownList.Visible = true;
                            CompradorDropDownList.DataValueField = "RazonSocial";
                            CompradorDropDownList.DataTextField = "RazonSocial";
                            Entidades.Persona persona = new Entidades.Persona();
                            System.Collections.Generic.List<Entidades.Persona> personalist = new System.Collections.Generic.List<Entidades.Persona>();
                            persona.RazonSocial = "";
                            personalist.Add(persona);
                            personalist.AddRange(listacompradores);
                            CompradorDropDownList.DataSource = personalist;
                            CompradorDropDownList.DataBind();
                            CompradorDropDownList.SelectedIndex = 0;
                            AjustarComprador();
                        }
                        else
                        {
                            CompradorDropDownList.Visible = false;
                            CompradorDropDownList.DataSource = null;
                        }
                    }
                }
                catch
                {
                    AjustarCamposXPtaVentaIndefinido();
                }
            }
            else
            {
                AjustarCamposXPtaVentaIndefinido();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Debe definir el punto de venta');</SCRIPT>", false);
            }
        }

        private void AjustarCamposXPtaVentaExport(out System.Collections.Generic.List<Entidades.Persona> listacompradores)
        {
            Presta_ServCheckBox.Checked = false;
            Presta_ServCheckBox.Enabled = false;
            Presta_ServCheckBox.Visible = true;
            Presta_ServLabel.Visible = true;
            //Version0RadioButton.Visible = false;
            Version1RadioButton.Visible = false;
            CodigoConceptoLabel.Visible = false;
            CodigoConceptoDropDownList.Visible = false;
            FechaServDesdeDatePickerWebUserControl.Text = string.Empty;
            FechaServDesdeDatePickerWebUserControl.Visible = false;
            FechaInicioServLabel.Visible = false;
            FechaHstServLabel.Visible = false;
            FechaServHastaDatePickerWebUserControl.Text = string.Empty;
            FechaServHastaDatePickerWebUserControl.Visible = false;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaParaExportaciones();

            Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
            Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
            Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
            Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
            Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
            Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = Nro_Doc_Identificatorio_CompradorDropDownList.Items.IndexOf(Nro_Doc_Identificatorio_CompradorDropDownList.Items.FindByValue(Nro_Doc_Identificatorio_CompradorTextBox.Text));
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
            docCompradorRequiredFieldValidator.Enabled = false;
            listaDocCompradorRequiredFieldValidator.Enabled = true;
            docCompradorRequiredFieldValidator.DataBind();
            listaDocCompradorRequiredFieldValidator.DataBind();

            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = true;
            if (Funciones.SessionTimeOut(Session))
            {
                listacompradores = new List<Entidades.Persona>();
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                listacompradores = RN.Persona.ListaExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                TipoExpDropDownList.Enabled = true;
                PaisDestinoExpDropDownList.Enabled = true;
                IdiomaDropDownList.Enabled = true;
                IncotermsDropDownList.Enabled = true;
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        private void AjustarCamposXPtaVentaBonoFiscal(out System.Collections.Generic.List<Entidades.Persona> listacompradores)
        {
            Presta_ServCheckBox.Checked = false;
            Presta_ServCheckBox.Enabled = false;
            Presta_ServCheckBox.Visible = true;
            Presta_ServLabel.Visible = true;
            //Version0RadioButton.Visible = false;
            Version1RadioButton.Visible = false;
            CodigoConceptoLabel.Visible = false;
            CodigoConceptoDropDownList.Visible = false;
            FechaServDesdeDatePickerWebUserControl.Text = string.Empty;
            FechaServDesdeDatePickerWebUserControl.Visible = false;
            FechaInicioServLabel.Visible = false;
            FechaHstServLabel.Visible = false;
            FechaServHastaDatePickerWebUserControl.Text = string.Empty;
            FechaServHastaDatePickerWebUserControl.Visible = false;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaParaBienesDeCapital();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
            docCompradorRequiredFieldValidator.Enabled = true;
            listaDocCompradorRequiredFieldValidator.Enabled = false;
            docCompradorRequiredFieldValidator.DataBind();
            listaDocCompradorRequiredFieldValidator.DataBind();
            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
            if (Funciones.SessionTimeOut(Session))
            {
                listacompradores = new List<Entidades.Persona>();
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                listacompradores = RN.Persona.ListaSinExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                TipoExpDropDownList.SelectedIndex = -1;
                TipoExpDropDownList.Enabled = false;
                PaisDestinoExpDropDownList.SelectedIndex = -1;
                PaisDestinoExpDropDownList.Enabled = false;
                IdiomaDropDownList.SelectedIndex = -1;
                IdiomaDropDownList.Enabled = false;
                IncotermsDropDownList.SelectedIndex = -1;
                IncotermsDropDownList.Enabled = false;
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        private void AjustarCamposXPtaVentaComun(out System.Collections.Generic.List<Entidades.Persona> listacompradores)
        {
            //Presta_ServCheckBox.Enabled = true;
            HacerVisiblesV0V1();
            AjustarCamposXPtaVtaComunYRG2904(out listacompradores);
        }

        private void AjustarCamposXPtaVentaRG2904(out System.Collections.Generic.List<Entidades.Persona> listacompradores, string tipoComprobante)
        {
            Presta_ServCheckBox.Enabled = true;
            AjustarCamposXPtaVtaComunYRG2904(out listacompradores);
            AjustarCodigoOperacionEn2904(tipoComprobante);
        }

        private void AjustarCodigoOperacionEn2904(string valor)
        {
            if (valor.Equals("2") || valor.Equals("3"))
            {
                CodigoOperacionDropDownList.Visible = false;
                CodigoOperacionLabel.Visible = false;
            }
            else
            {
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        private void AjustarCamposXPtaVtaComunYRG2904(out System.Collections.Generic.List<Entidades.Persona> listacompradores)
        {
            AjustarPrestaServxVersiones();

            FechaServDesdeDatePickerWebUserControl.Visible = true;
            FechaInicioServLabel.Visible = true;
            FechaHstServLabel.Visible = true;
            FechaServHastaDatePickerWebUserControl.Visible = true;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista();
            if (Condicion_IVA_VendedorDropDownList.SelectedValue == "6")
            {
                Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaMonotributo();
                PermisosExpo.Visible = false;
            }
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
            docCompradorRequiredFieldValidator.Enabled = true;
            listaDocCompradorRequiredFieldValidator.Enabled = false;
            docCompradorRequiredFieldValidator.DataBind();
            listaDocCompradorRequiredFieldValidator.DataBind();
            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
            if (Funciones.SessionTimeOut(Session))
            {
                listacompradores = new List<Entidades.Persona>();
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                listacompradores = RN.Persona.ListaSinExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                TipoExpDropDownList.SelectedIndex = -1;
                TipoExpDropDownList.Enabled = false;
                PaisDestinoExpDropDownList.SelectedIndex = -1;
                PaisDestinoExpDropDownList.Enabled = false;
                IdiomaDropDownList.SelectedIndex = -1;
                IdiomaDropDownList.Enabled = false;
                IncotermsDropDownList.SelectedIndex = -1;
                IncotermsDropDownList.Enabled = false;
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        private void HacerVisiblesV0V1()
        {
            //Version0RadioButton.Visible = true;
            //Version0RadioButton.Checked = true;
            //Version1RadioButton.Visible = true;
            //Version1RadioButton.Checked = false;
            //Version1RadioButton.Visible = true;
            Version1RadioButton.Checked = true;
        }

        private void AjustarCamposXPtaVentaIndefinido()
        {
            TipoPtoVentaLabel.Text = "No definido";
            Presta_ServCheckBox.Enabled = true;
            Presta_ServCheckBox.Visible = true;
            Presta_ServLabel.Visible = true;
            //Version0RadioButton.Visible = false;
            Version1RadioButton.Visible = false;
            CodigoConceptoLabel.Visible = false;
            CodigoConceptoDropDownList.Visible = false;
            FechaServDesdeDatePickerWebUserControl.Visible = true;
            FechaInicioServLabel.Visible = true;
            FechaHstServLabel.Visible = true;
            FechaServHastaDatePickerWebUserControl.Visible = true;
            Tipo_De_ComprobanteDropDownList.DataSource = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompleta();
            Tipo_De_ComprobanteDropDownList.DataBind();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
            Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
            Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
            docCompradorRequiredFieldValidator.Enabled = true;
            listaDocCompradorRequiredFieldValidator.Enabled = false;
            docCompradorRequiredFieldValidator.DataBind();
            listaDocCompradorRequiredFieldValidator.DataBind();
            ((AjaxControlToolkit.MaskedEditExtender)referenciasGridView.FooterRow.FindControl("txtdato_de_referenciaFooterExpoMaskedEditExtender")).Enabled = false;
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                System.Collections.Generic.List<Entidades.Persona> listacompradores = RN.Persona.ListaPorCuit(true, Entidades.Enum.TipoPersona.Cliente, ((Entidades.Sesion)Session["Sesion"]));
                if (listacompradores.Count > 0)
                {
                    CompradorDropDownList.Visible = true;
                    CompradorDropDownList.DataValueField = "RazonSocial";
                    CompradorDropDownList.DataTextField = "RazonSocial";
                    Entidades.Persona persona = new Entidades.Persona();
                    System.Collections.Generic.List<Entidades.Persona> personalist = new System.Collections.Generic.List<Entidades.Persona>();
                    persona.RazonSocial = "";
                    personalist.Add(persona);
                    personalist.AddRange(listacompradores);
                    CompradorDropDownList.DataSource = personalist;
                    CompradorDropDownList.DataBind();
                    CompradorDropDownList.SelectedIndex = 0;
                    AjustarComprador();
                }
                else
                {
                    CompradorDropDownList.Visible = false;
                    CompradorDropDownList.DataSource = null;
                }
                TipoExpDropDownList.Enabled = true;
                PaisDestinoExpDropDownList.Enabled = true;
                IdiomaDropDownList.Enabled = true;
                IncotermsDropDownList.Enabled = true;
                CodigoOperacionDropDownList.Visible = true;
                CodigoOperacionLabel.Visible = true;
            }
        }

        protected void ValidarCamposObligatorios()
        {
            if (Cuit_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el CUIT del vendedor');</script>", false);
                return;
            }
            if (Id_LoteTextbox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el nro de lote');</script>", false);
                return;
            }
            if (Numero_ComprobanteTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el número de comprobante');</script>", false);
                return;
            }
            if (!Numero_ComprobanteTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumeric(Numero_ComprobanteTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un dato numérico en el número de comprobante');</script>", false);
                return;
            }
            if (PuntoVtaDropDownList.SelectedValue.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el punto de venta');</script>", false);
                return;
            }
            if (FechaEmisionDatePickerWebUserControl.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar la Fecha de Emisión del comprobante');</script>", false);
                return;
            }
            if (Razon_Social_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar la Razon Social del vendedor');</script>", false);
                return;
            }
            if (Localidad_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar la Localidad del vendedor');</script>", false);
                return;
            }
            if (Email_VendedorTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar la Localidad del vendedor');</script>", false);
                return;
            }
            if (!Id_LoteTextbox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumeric(Id_LoteTextbox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un dato numérico en el número de lote');</script>", false);
                return;
            }
            if (!Email_VendedorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidEmail(Email_VendedorTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un email válido para el vendedor');</script>", false);
                return;
            }
            if (!NroIBVendedorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNroIB(NroIBVendedorTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un Nro. de IB válido para el vendedor');</script>", false);
                return;
            }
            if (!Email_CompradorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidEmail(Email_CompradorTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un email válido para el comprador');</script>", false);
                return;
            }

            if (!GLN_CompradorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericFijo(GLN_CompradorTextBox.Text, "13"))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Ingresar un dato numérico de 13 digitos en el GLN del comprador');</script>", false);
                return;
            }

            //if (Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedValue.Equals(string.Empty))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Tipo de Documento del Comprador');</script>", false);
            //    return;
            //}
            //if (Nro_Doc_Identificatorio_CompradorTextBox.Text.Equals(string.Empty))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Nro. Doc. Comprador');</script>", false);
            //    return;
            //}
            //if (!Nro_Doc_Identificatorio_CompradorTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Nro_Doc_Identificatorio_CompradorTextBox.Text))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Nro. Doc. Comprador');</script>", false);
            //    return;
            //}

            //TIPO DE CAMBIO
            if (!MonedaComprobanteDropDownList.SelectedValue.Equals(FeaEntidades.CodigosMoneda.CodigoMoneda.Local))
            {
                if (Tipo_de_cambioTextBox.Text.Equals(string.Empty))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Tipo de Cambio');</script>", false);
                    return;
                }
                if (!Tipo_de_cambioTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Tipo_de_cambioTextBox.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Tipo de Cambio en el Resumen');</script>", false);
                    return;
                }
            }

            //RESUMEN            
            if (Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Importe Total Neto Gravado del Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Neto_Gravado_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Neto Gravado en el Resumen');</script>", false);
                return;
            }
            if (Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Importe Total Concepto No Gravado del Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Concepto No Gravado en el Resumen');</script>", false);
                return;
            }
            if (Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Importe Operaciones Exentas del Resumen');</script>", false);
                return;
            }
            if (!Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Operaciones_Exentas_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Operaciones Exentas en el Resumen');</script>", false);
                return;
            }
            if (Impuesto_Liq_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el IVA del Resumen');</script>", false);
                return;
            }
            if (!Impuesto_Liq_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Impuesto_Liq_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del IVA en el Resumen');</script>", false);
                return;
            }
            if (Impuesto_Liq_Rni_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el IVA RNI del Resumen');</script>", false);
                return;
            }
            if (!Impuesto_Liq_Rni_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Impuesto_Liq_Rni_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del IVA RNI en el Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Impuestos_Municipales_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Impuestos Municipales en el Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Impuestos Nacionales en el Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Ingresos_Brutos_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Ingresos Brutos en el Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Impuestos_Internos_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Impuestos_Internos_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Impuestos Internos en el Resumen');</script>", false);
                return;
            }
            if (Importe_Total_Factura_ResumenTextBox.Text.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Falta ingresar el Importe Total Factura del Resumen');</script>", false);
                return;
            }
            if (!Importe_Total_Factura_ResumenTextBox.Text.Equals(string.Empty) && !RN.Funciones.IsValidNumericDecimals(Importe_Total_Factura_ResumenTextBox.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Formato erróneo del Importe Total Factura en el Resumen');</script>", false);
                return;
            }
        }
        protected void ValidarIBKButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ActualizarEstadoButton.Visible = false;
                DescargarPDFButton.Visible = false;
                ActualizarEstadoButton.DataBind();
                DescargarPDFButton.DataBind();
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    try
                    {
                        string NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                        if (NroCertif.Equals(string.Empty))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Aún no disponemos de su certificado digital.');</script>", false);
                            return;
                        }
                        try
                        {
                            ValidarCamposObligatorios();

                            string certificado = "";
                            string respuesta = "";

                            certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            org.dyndns.cedweb.valido.ValidoIBK edyndns = new org.dyndns.cedweb.valido.ValidoIBK();
                            string ValidarIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["ValidarIBKUtilizarServidorExterno"];
                            if (ValidarIBKUtilizarServidorExterno == "SI")
                            {
                                edyndns.Url = System.Configuration.ConfigurationManager.AppSettings["ValidarIBKurl"];
                            }
                            FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote(false);

                            string xmlTexto = "";
                            RN.Comprobante.SerializarLc(out xmlTexto, lcFea);
                            
                            //lcIBK = Conversor.Entidad2IBK(lcFea);
                            respuesta = edyndns.ValidarIBK(xmlTexto, certificado);

                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + respuesta + "')</script>", false);

                            if (respuesta == "Comprobante enviado satisfactoriamente a Interfacturas.")
                            {
                                //Grabar en base de datos
                                RN.Comprobante comprobante = new RN.Comprobante();
                                lcFea.cabecera_lote.DestinoComprobante = "ITF";
                                lcFea.comprobante[0].cabecera.informacion_comprobante.Observacion = "";
                                comprobante.Registrar(lcFea, null, Session["IdNaturalezaComprobante"].ToString(), "ITF", ((Entidades.Sesion)Session["Sesion"]));
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
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + "\\n" + errorMessage.Replace("\r", "").Replace("\n", "").Replace("'", " ") + "');</script>", false);
                            }
                            catch (Exception)
                            {
                                throw soapEx;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message.Replace("'", " ");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a Interfacturas.\\n " + a + "');</script>", false);
                    }
                }
            }
        }

        protected void EnviarIBKButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ActualizarEstadoButton.Visible = false;
                DescargarPDFButton.Visible = false;
                ActualizarEstadoButton.DataBind();
                DescargarPDFButton.DataBind();
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    try
                    {
                        string NroCertif = "";
                        NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
                        if (NroCertif.Equals(string.Empty))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Aún no disponemos de su certificado digital.');</script>", false);
                            return;
                        }
                        try
                        {
                            ValidarCamposObligatorios();

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
                            FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote(false);
                            lcIBK = Conversor.Entidad2IBK(lcFea);
                            
                            respuesta = edyndns.EnviarIBK(lcIBK, certificado);

                            //VIEJO MODO DE USO
                            //certificado = NroCertif;
                            //FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote();
                            //RN.Comprobante cc = new RN.Comprobante();
                            //respuesta = cc.EnviarIBK(lcFea, certificado);

                            respuesta = respuesta.Replace("'", "-");

                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + respuesta + "')</script>", false);

                            if (respuesta == "Comprobante enviado satisfactoriamente a Interfacturas.")
                            {
                                //Grabar en base de datos
                                RN.Comprobante c= new RN.Comprobante();
                                lcFea.cabecera_lote.DestinoComprobante = "ITF";
                                lcFea.comprobante[0].cabecera.informacion_comprobante.Observacion = "";
                                c.Registrar(lcFea, null, Session["IdNaturalezaComprobante"].ToString(), "ITF", ((Entidades.Sesion)Session["Sesion"]));


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
                                clcrdyndns = clcdyndnsConsultaIBK.Consultar(Convert.ToInt64(lcFea.comprobante[0].cabecera.informacion_vendedor.cuit), lcFea.cabecera_lote.id_lote, lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta, certificado);
                                FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                                lc = Funciones.Ws2Fea(clcrdyndns);
                                Cache["ComprobanteAConsultar"] = lc;
                                string XML = "";
                                RN.Comprobante.SerializarLc(out XML, lc);
                                Entidades.Comprobante comprobante = new Entidades.Comprobante();
                                comprobante.Cuit = lcFea.comprobante[0].cabecera.informacion_vendedor.cuit.ToString();
                                comprobante.TipoComprobante.Id = lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                                comprobante.NroPuntoVta = lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                                comprobante.Nro = lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                                c.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                Session["comprobantePDF"] = comprobante;
                                comprobante.Response = XML;
                                if (lc.cabecera_lote.resultado == "A")
                                {
                                    comprobante.WF.Estado = "Vigente";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                    c.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                    ActualizarEstadoButton.Visible = false;
                                    DescargarPDFButton.Visible = true;
                                }
                                else if (lc.cabecera_lote.resultado == "R")
                                {
                                    comprobante.WF.Estado = "Rechazado";
                                    RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                                    ActualizarEstadoButton.Visible = false;
                                }
                                else
                                {
                                    ActualizarEstadoButton.Visible = true;
                                }
                                ActualizarEstadoButton.DataBind();
                                DescargarPDFButton.DataBind();
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
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + "\\n" + errorMessage.Replace("\r", "").Replace("\n", "") + "');</script>", false);
                            }
                            catch (Exception)
                            {
                                throw soapEx;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message.Replace("'", " ");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a Interfacturas.\\n " + a + "');</script>", false);
                    }
                }
            }
        }

        protected void ActualizarEstadoButton_Click(object sender, EventArgs e)
        {
            string NroCertif = "";
            NroCertif = ((Entidades.Sesion)Session["Sesion"]).Cuit.NroSerieCertifITF;
            if (NroCertif.Equals(string.Empty))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Aún no disponemos de su certificado digital.');</script>", false);
                return;
            }
            try
            {
                RN.Comprobante c = new RN.Comprobante();
                Entidades.Comprobante comprobante = (Entidades.Comprobante)Session["comprobantePDF"];
                if (comprobante != null)
                {
                    string certificado = "";
                    certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(NroCertif, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();

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
                    clcrdyndns = clcdyndnsConsultaIBK.Consultar(Convert.ToInt64(comprobante.Cuit), comprobante.NroLote, comprobante.NroPuntoVta, certificado);
                    FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
                    lc = Funciones.Ws2Fea(clcrdyndns);
                    Cache["ComprobanteAConsultar"] = lc;
                    string XML = "";
                    RN.Comprobante.SerializarLc(out XML, lc);
                    //c.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                    comprobante.Response = XML;
                    if (lc.cabecera_lote.resultado == "A")
                    {
                        comprobante.WF.Estado = "Vigente";
                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                        c.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                        Session["comprobantePDF"] = comprobante;
                        ActualizarEstadoButton.Visible = false;
                        DescargarPDFButton.Visible = true;
                    }
                    else if (lc.cabecera_lote.resultado == "R")
                    {
                        comprobante.WF.Estado = "Rechazado";
                        RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
                        ActualizarEstadoButton.Visible = false;
                    }
                    else
                    {
                        ActualizarEstadoButton.Visible = true;
                    }
                    ActualizarEstadoButton.DataBind();
                    DescargarPDFButton.DataBind();
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message.Replace("'", " ");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a Interfacturas.\\n " + a + "');</script>", false);
            }
        }

        protected void EnviarAFIPButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                ActualizarEstadoButton.Visible = false;
                DescargarPDFButton.Visible = false;
                ActualizarEstadoButton.DataBind();
                DescargarPDFButton.DataBind();
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    try
                    {
                        try
                        {
                            ValidarCamposObligatorios();

                            string respuesta = "";
                            FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote(false);

                            string caeNro = "";
                            string caeFecVto = "";
                            respuesta = RN.ComprobanteAFIP.EnviarAFIP(out caeNro, out caeFecVto, lcFea, (Entidades.Sesion)Session["Sesion"]);

                            RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), respuesta);
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + respuesta + "')</script>", false);

                            if (respuesta.Length >= 12 && respuesta.Substring(0, 12) == "Resultado: A")
                            {
                                //Grabar en base de datos
                                RN.Comprobante c = new RN.Comprobante();
                                lcFea.cabecera_lote.DestinoComprobante = "AFIP";
                                lcFea.comprobante[0].cabecera.informacion_comprobante.Observacion = "";
                                c.Registrar(lcFea, null, Session["IdNaturalezaComprobante"].ToString(), "AFIP", ((Entidades.Sesion)Session["Sesion"]));

                                //Actualizar estado on-line.
                                if (caeNro != "")
                                {
                                    lcFea.cabecera_lote.resultado = "A";
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.resultado = "A";
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.cae = caeNro;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae = caeFecVto;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae = DateTime.Now.ToString("yyyyMMdd");
                                    lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                                    //Actualizar front-end
                                    CAETextBox.Text = lcFea.comprobante[0].cabecera.informacion_comprobante.cae;
                                    FechaCAEVencimientoDatePickerWebUserControl.Text = lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                                    FechaCAEObtencionDatePickerWebUserControl.Text = lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_obtencion_cae;
                                }
                                string XML = "";
                                RN.Comprobante.SerializarLc(out XML, lcFea);
                                Entidades.Comprobante comprobante = new Entidades.Comprobante();
                                comprobante.Cuit = lcFea.comprobante[0].cabecera.informacion_vendedor.cuit.ToString();
                                comprobante.TipoComprobante.Id = lcFea.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                                comprobante.NroPuntoVta = lcFea.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                                comprobante.Nro = lcFea.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                                c.Leer(comprobante, ((Entidades.Sesion)Session["Sesion"]));
                                comprobante.Response = XML;
                                comprobante.WF.Estado = "Vigente";
                                RN.Comprobante.Actualizar(comprobante, (Entidades.Sesion)Session["Sesion"]);
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
                                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + soapEx.Actor + "\\n" + errorMessage.Replace("\r", "").Replace("\\n", "") + "');</script>", false);
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
                        string a = ex.Message.Replace("'", " ");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al enviar el comprobante a AFIP.\\n " + a + "');</script>", false);
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
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Su sesión ha caducado por inactividad. Por favor vuelva a loguearse.')</script>", false);
                }
                else
                {
                    try
                    {
                        FeaEntidades.InterFacturas.lote_comprobantes lote;
                        string certificado;
                        Entidades.Comprobante comprobante = (Entidades.Comprobante)Session["comprobantePDF"];
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        string DetalleIBKUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKUtilizarServidorExterno"];
                        org.dyndns.cedweb.detalle.DetalleIBK clcdyndns = new org.dyndns.cedweb.detalle.DetalleIBK();
                        org.dyndns.cedweb.detalle.cecd cecd = new org.dyndns.cedweb.detalle.cecd();
                        System.Xml.Serialization.XmlSerializer x;
                        byte[] bytes;
                        System.IO.MemoryStream ms;
                        string resp;
                        string script;

                        if (comprobante.IdDestinoComprobante == "ITF")
                        {
                            #region PDF (InterFacturas)
                            //OBTENCIÓN DE PDF DE INTERFACTURAS
                            if (comprobante.Estado != "Vigente")
                            {
                                MensajeLabel.Text = "El comprobante no está vigente.";
                                return;
                            }
                            MensajeLabel.Text = String.Empty;

                            //On-Line
                            cecd.cuit_canal = Convert.ToInt64("30690783521");
                            cecd.cuit_vendedor = Convert.ToInt64(comprobante.Cuit);
                            cecd.punto_de_venta = Convert.ToInt32(comprobante.NroPuntoVta);
                            cecd.tipo_de_comprobante = Convert.ToInt32(comprobante.TipoComprobante.Id);
                            cecd.numero_comprobante = comprobante.Nro;
                            cecd.id_Lote = 0;
                            cecd.id_LoteSpecified = false;
                            cecd.estado = "PR";

                            if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }
                            Funciones.GrabarLogTexto("~/Detallar.txt", "Consulta de Lote CUIT: " + sesion.Cuit.Nro + "  Punto de Venta: " + cecd.punto_de_venta.ToString() + "  Tipo de Comprobante: " + cecd.tipo_de_comprobante.ToString() + "  Nro de Comprobante: " + cecd.numero_comprobante.ToString());
                            Funciones.GrabarLogTexto("~/Detallar.txt", "NroSerieCertifITF: " + sesion.Cuit.NroSerieCertifITF);
                            if (sesion.Cuit.NroSerieCertifITF.Equals(string.Empty))
                            {
                                MensajeLabel.Text = "Aún no disponemos de su certificado digital";
                                return;
                            }

                            certificado = CaptchaDotNet2.Security.Cryptography.Encryptor.Encrypt(sesion.Cuit.NroSerieCertifITF, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                            Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKUtilizarServidorExterno: " + DetalleIBKUtilizarServidorExterno);
                            if (DetalleIBKUtilizarServidorExterno == "SI")
                            {
                                clcdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"];
                                Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro DetalleIBKurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                            }
                            resp = clcdyndns.DetallarIBK(cecd, certificado);
                            resp = resp.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
                            resp = resp.Replace(" xmlns:xsi=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", " xmlns=\"http://lote.schemas.cfe.ib.com.ar/\"");
                            //Fin On-Line

                            try
                            {
                                string comprobanteXML = resp;

                                Funciones.GrabarLogTexto("~/Detallar.txt", "Inicia ExecuteCommand");
                                org.dyndns.cedweb.generoPDF.GeneroPDF pdfdyndns = new org.dyndns.cedweb.generoPDF.GeneroPDF();

                                string GenerarPDFUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFUtilizarServidorExterno"];
                                Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFUtilizarServidorExterno: " + GenerarPDFUtilizarServidorExterno);
                                if (GenerarPDFUtilizarServidorExterno == "SI")
                                {
                                    pdfdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFurl"];
                                    Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                                }
                                string RespPDF = pdfdyndns.GenerarPDF(comprobante.Cuit, comprobante.NroPuntoVta, comprobante.TipoComprobante.Id, comprobante.Nro, comprobante.IdDestinoComprobante, comprobanteXML);
                                Funciones.GrabarLogTexto("~/Detallar.txt", "Finaliza ExecuteCommand");

                                //Crear nombre de archivo default sin extensión
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

                                script = "window.open('/DescargaTemporarios.aspx?archivo=" + sb.ToString() + "&path=" + @"~/TempRender/" + "', '');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar el PDF.\\n" + ex.Message;
                                script += ex.StackTrace;
                                if (ex.InnerException != null)
                                {
                                    script = ex.InnerException.Message;
                                }
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                                MensajeLabel.Text = script;
                            }
                            #endregion
                        }
                        else
                        {
                            #region PDF (AFIP)
                            //GENERACIÓN DE PDF A PARTIR DE DATOS LOCALES
                            lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                            x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                            if (comprobante.Estado != "Vigente")
                            {
                                MensajeLabel.Text = "El comprobante no está vigente.";
                                return;
                            }
                            try
                            {
                                comprobante.Response = comprobante.Response.Replace("iso-8859-1", "utf-16");
                                bytes = new byte[comprobante.Response.Length * sizeof(char)];
                                System.Buffer.BlockCopy(comprobante.Response.ToCharArray(), 0, bytes, 0, bytes.Length);
                                ms = new System.IO.MemoryStream(bytes);
                                ms.Seek(0, System.IO.SeekOrigin.Begin);
                                lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);

                                string comprobanteXML = "";

                                #region TRATAMIENTO DE LOGOTIPO
                                string uRLfile = String.Empty;
                                if (System.Configuration.ConfigurationManager.AppSettings["Ambiente"] == "DESA")
                                {
                                    uRLfile = "http://cedeiraweb.no-ip.org:8080/ImagenesSubidas/" + lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString() + ".gif";
                                }
                                else
                                {
                                    uRLfile = "http://www.cedeira.com.ar/ImagenesSubidas/" + lote.comprobante[0].cabecera.informacion_vendedor.cuit.ToString() + ".gif";
                                }
                                if (Existe(uRLfile))
                                {
                                    if (lote.comprobante[0].extensiones == null)
                                    {
                                        lote.comprobante[0].extensiones = new FeaEntidades.InterFacturas.extensiones();
                                        lote.comprobante[0].extensionesSpecified = true;
                                    }
                                    if (lote.comprobante[0].extensiones.extensiones_camara_facturas == null)
                                    {
                                        lote.comprobante[0].extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                                        lote.comprobante[0].extensiones.extensiones_camara_facturasSpecified = true;
                                    }
                                    lote.comprobante[0].extensiones.extensiones_camara_facturas.id_logo = uRLfile;
                                }
                                #endregion

                                RN.Comprobante.SerializarC(out comprobanteXML, lote.comprobante[0]);

                                try
                                {
                                    Funciones.GrabarLogTexto("~/Detallar.txt", "Inicia ExecuteCommand");
                                    org.dyndns.cedweb.generoPDF.GeneroPDF pdfdyndns = new org.dyndns.cedweb.generoPDF.GeneroPDF();

                                    string GenerarPDFUtilizarServidorExterno = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFUtilizarServidorExterno"];
                                    Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFUtilizarServidorExterno: " + GenerarPDFUtilizarServidorExterno);
                                    if (GenerarPDFUtilizarServidorExterno == "SI")
                                    {
                                        pdfdyndns.Url = System.Configuration.ConfigurationManager.AppSettings["GenerarPDFurl"];
                                        Funciones.GrabarLogTexto("~/Detallar.txt", "Parametro GenerarPDFurl: " + System.Configuration.ConfigurationManager.AppSettings["DetalleIBKurl"]);
                                    }
                                    string RespPDF = pdfdyndns.GenerarPDF(comprobante.Cuit, comprobante.NroPuntoVta, comprobante.TipoComprobante.Id, comprobante.Nro, comprobante.IdDestinoComprobante, comprobanteXML);
                                    Funciones.GrabarLogTexto("~/Detallar.txt", "Finaliza ExecuteCommand");

                                    //Crear nombre de archivo default sin extensión
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
                                    String dlDir = @"~/TempRenderAFIP/";
                                    new System.Net.WebClient().DownloadFile(url, Server.MapPath(dlDir + filename));

                                    script = "window.open('/DescargaTemporarios.aspx?archivo=" + sb.ToString() + "&path=" + @"~/TempRenderAFIP/" + "', '');";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                                }
                                catch (Exception ex)
                                {
                                    script = "Problemas para generar el PDF.\\n" + ex.Message;
                                    script += ex.StackTrace;
                                    if (ex.InnerException != null)
                                    {
                                        script = ex.InnerException.Message;
                                    }
                                    RN.Sesion.GrabarLogTexto(Server.MapPath("~/Detallar.txt"), script);
                                    MensajeLabel.Text = script;
                                }
                            }
                            catch (Exception ex)
                            {
                                script = "Problemas para generar el PDF.\\n" + ex.Message;
                                RN.Sesion.GrabarLogTexto(Server.MapPath("~/Consultar.txt"), script);
                                MensajeLabel.Text = script;
                            }
                            #endregion
                        }
                      }
                    catch (Exception ex)
                    {
                        string a = ex.Message.Replace("'", " ");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al descargar el archivo PDF.\\n " + a + "');</script>", false);
                    }
                }
            }
        }

        protected void GuardarComprobanteButton_Click(object sender, EventArgs e)
        {
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
            catch (WebException ex)
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
                    Id_LoteTextbox.Text = puntoVta.UltNroLote.ToString();
                }
            }
        }

        private FeaEntidades.InterFacturas.lote_comprobantes GenerarLote(bool EsParaImprimirPDF)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
            FeaEntidades.InterFacturas.comprobante comp = new FeaEntidades.InterFacturas.comprobante();
            FeaEntidades.InterFacturas.cabecera_lote cab = new FeaEntidades.InterFacturas.cabecera_lote();
            cab.cantidad_reg = 1;
            cab.cuit_canal = Convert.ToInt64(Entidades.Const.CuitInterfacturas);
            cab.cuit_vendedor = Convert.ToInt64(Cuit_VendedorTextBox.Text);
            cab.id_lote = Convert.ToInt64(Id_LoteTextbox.Text);

            GenerarPrestaServicio(cab);

            cab.punto_de_venta = Convert.ToInt32(PuntoVtaDropDownList.SelectedValue);
            lote.cabecera_lote = cab;

            FeaEntidades.InterFacturas.cabecera compcab = new FeaEntidades.InterFacturas.cabecera();

            FeaEntidades.InterFacturas.informacion_comprador infcompra = new FeaEntidades.InterFacturas.informacion_comprador();

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
            FeaEntidades.InterFacturas.informacion_comprobante infcomprob = GenerarInfoComprobante();
            GenerarReferencias(infcomprob);
            GenerarInfoExportacion(comp, infcomprob);
            GenerarInfoExtensionesComerciales(comp);
            GenerarInfoExtensionesCamaraFacturas(comp);
            GenerarInfoExtensionesDestinatarios(comp);
            compcab.informacion_comprobante = infcomprob;
            GenerarInfoVendedor(compcab);
            comp.cabecera = compcab;

            int auxPV = Convert.ToInt32(((DropDownList)PuntoVtaDropDownList).SelectedValue);
            string idtipo = String.Empty;
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;
                }
            }
            catch (NullReferenceException)
            {
                idtipo = "Comun";
            }
            FeaEntidades.InterFacturas.detalle det = DetalleLinea.GenerarDetalles(MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text, idtipo, Tipo_De_ComprobanteDropDownList.SelectedValue, EsParaImprimirPDF);

            det.comentarios = ComentariosTextBox.Text;
            comp.detalle = det;

            FeaEntidades.InterFacturas.resumen r = new FeaEntidades.InterFacturas.resumen();
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
            auxPV = Convert.ToInt32(((DropDownList)PuntoVtaDropDownList).SelectedValue);
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;
                    if (idtipo.Equals("Exportacion"))
                    {
                        if (listadeimpuestos[0].importe_impuesto != 0 || listadeimpuestos.Count > 1)
                        {
                            ImpuestosGlobales.Focus();
                            throw new Exception("Los impuestos globales no se deben informar para exportación");
                        }
                    }
                    else
                    {
                        ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                ImpuestosGlobales.GenerarImpuestos(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
            }
            DescuentosGlobales.GenerarResumen(comp, MonedaComprobanteDropDownList.SelectedValue, Tipo_de_cambioTextBox.Text);
            lote.comprobante[0] = comp;
            return lote;
        }

        private void GenerarPrestaServicio(FeaEntidades.InterFacturas.cabecera_lote cab)
        {
            cab.presta_servSpecified = true;
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
                    if (idtipo.Equals("Exportacion") || idtipo.Equals("RG2904"))
                    {
                        cab.presta_servSpecified = false;
                    }
                    else if (idtipo.Equals("Comun"))
                    {
                        GenerarV0oV1(cab);
                    }
                    else
                    {
                        cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
            }
        }


		private void GenerarV0oV1(FeaEntidades.InterFacturas.cabecera_lote cab)
		{
            //if (Version0RadioButton.Checked)
            //{
            //    cab.presta_serv = Convert.ToInt32(Presta_ServCheckBox.Checked);
            //}
            //else
            //{
            //    cab.presta_servSpecified = false;
            //}
            cab.presta_servSpecified = false;
		}

		private void GenerarInfoExtensionesDestinatarios(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!EmailAvisoVisualizacionTextBox.Text.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				comp.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
				comp.extensiones.extensiones_destinatarios.email=EmailAvisoVisualizacionTextBox.Text;
			}
		}

		private void GenerarInfoExtensionesComerciales(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!DatosComerciales.Texto.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				string textoSinSaltoDeLinea = DatosComerciales.Texto.Replace(System.Environment.NewLine, "<br>");
				comp.extensiones.extensiones_datos_comerciales = RN.Funciones.ConvertToHex(textoSinSaltoDeLinea);
			}
		}

		private void GenerarInfoExtensionesCamaraFacturas(FeaEntidades.InterFacturas.comprobante comp)
		{
			if (!PasswordAvisoVisualizacionTextBox.Text.Equals(string.Empty))
			{
				comp.extensionesSpecified = true;
				if (comp.extensiones == null)
				{
					comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				if (comp.extensiones.extensiones_camara_facturas == null)
				{
					comp.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
				}
				comp.extensiones.extensiones_camara_facturas.clave_de_vinculacion = RN.Funciones.CreateMD5Hash(PasswordAvisoVisualizacionTextBox.Text);
				comp.extensiones.extensiones_camara_facturasSpecified = true;
			}
		}

        private FeaEntidades.InterFacturas.informacion_comprobante GenerarInfoComprobante()
        {
            FeaEntidades.InterFacturas.informacion_comprobante infcomprob = new FeaEntidades.InterFacturas.informacion_comprobante();
            infcomprob.tipo_de_comprobante = Convert.ToInt32(Tipo_De_ComprobanteDropDownList.SelectedValue);
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

            GenerarIVAComputable(infcomprob);

            if (!Condicion_De_PagoTextBox.Text.Equals(string.Empty))
            {
                infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
                infcomprob.condicion_de_pagoSpecified = true;
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            throw new Exception("La condición de pago es obligatoria para exportación");
                        }
                        else
                        {
                            infcomprob.condicion_de_pago = string.Empty;
                            infcomprob.condicion_de_pagoSpecified = false;
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    infcomprob.condicion_de_pago = Condicion_De_PagoTextBox.Text;
                    infcomprob.condicion_de_pagoSpecified = false;
                }
            }

            GenerarCodigoOperacion(infcomprob);
            GenerarCodigoConcepto(infcomprob);

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

        private void GenerarInfoFechaVto(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            if (!FechaVencimientoDatePickerWebUserControl.Text.Equals(string.Empty))
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

        private void GenerarIVAComputable(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            //No se tiene que informar para exportación
            if (!IVAcomputableDropDownList.SelectedValue.Equals(string.Empty))
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            IVAcomputableDropDownList.Focus();
                            throw new Exception("El IVA computable no se debe informar para exportación");
                        }
                        else
                        {
                            infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    infcomprob.iva_computable = IVAcomputableDropDownList.SelectedValue;
                }
            }
        }

        private void GenerarCodigoOperacion(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            //No se tiene que informar para exportación
            //El nodo no se debe informar para RG2904 (solo NC A y ND A)
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
                    if (!CodigoOperacionDropDownList.SelectedValue.Equals(string.Empty))
                    {
                        if (idtipo.Equals("Exportacion"))
                        {
                            CodigoOperacionDropDownList.Focus();
                            throw new Exception("El código de operación no se debe informar para exportación");
                        }
                        else if (idtipo.Equals("RG2904") && (Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("2") || Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("3")))
                        {
                            infcomprob.codigo_operacion = string.Empty;
                            infcomprob.codigo_operacionSpecified = false;
                        }
                        else
                        {
                            infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                            infcomprob.codigo_operacionSpecified = true;
                        }
                    }
                    else
                    {
                        if (!idtipo.Equals("Exportacion"))
                        {
                            if (idtipo.Equals("RG2904") && (Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("2") || Tipo_De_ComprobanteDropDownList.SelectedValue.Equals("3")))
                            {
                                infcomprob.codigo_operacion = string.Empty;
                                infcomprob.codigo_operacionSpecified = false;
                            }
                            else
                            {
                                infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                                infcomprob.codigo_operacionSpecified = true;
                            }

                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                infcomprob.codigo_operacion = CodigoOperacionDropDownList.SelectedValue;
                infcomprob.codigo_operacionSpecified = true;
            }
        }

		private void GenerarCodigoConcepto(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			//Se tiene que informar para versión 1 de punto común
			if (CodigoConceptoDropDownList.Visible)
			{
				infcomprob.codigo_concepto = Convert.ToInt32(CodigoConceptoDropDownList.SelectedValue);
				infcomprob.codigo_conceptoSpecified = true;
			}
			else
			{
				infcomprob.codigo_conceptoSpecified = false;
			}
		}

        private void GenerarReferencias(FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> listareferencias = (System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias>)ViewState["referencias"];
            for (int i = 0; i < listareferencias.Count; i++)
            {
                if (listareferencias[i].descripcioncodigo_de_referencia != null)
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
                            string tipoComp = Tipo_De_ComprobanteDropDownList.SelectedValue;
                            if (idtipo.Equals("Exportacion") && tipoComp.Equals("19"))
                            {
                                throw new Exception("Las referencias no se deben informar para facturas de exportación(19). Sólo para notas de débito y/o crédito (20 y 21).");
                            }
                            else
                            {
                                GenerarReferencia(infcomprob, listareferencias, i);
                            }
                        }
                    }
                    catch (System.NullReferenceException)
                    {
                        GenerarReferencia(infcomprob, listareferencias, i);
                    }
                }
            }
        }

		private static void GenerarReferencia(FeaEntidades.InterFacturas.informacion_comprobante infcomprob, System.Collections.Generic.List<FeaEntidades.InterFacturas.informacion_comprobanteReferencias> listareferencias, int i)
		{
			infcomprob.referencias[i] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
			infcomprob.referencias[i].codigo_de_referencia = Convert.ToInt32(listareferencias[i].codigo_de_referencia);
			infcomprob.referencias[i].descripcioncodigo_de_referencia = listareferencias[i].descripcioncodigo_de_referencia;
			infcomprob.referencias[i].dato_de_referencia = listareferencias[i].dato_de_referencia;
		}

        private void GenerarInfoExportacion(FeaEntidades.InterFacturas.comprobante comp, FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
        {
            FeaEntidades.InterFacturas.informacion_exportacion ie = new FeaEntidades.InterFacturas.informacion_exportacion();
            bool exportacion = false;
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
                    string tipoComp = Tipo_De_ComprobanteDropDownList.SelectedValue;
                    string tipoExp = TipoExpDropDownList.SelectedValue;
                    if (idtipo.Equals("Exportacion"))
                    {
                        if (tipoComp.Equals("19"))
                        {
                            if (PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
                            {
                                throw new Exception("El país destino de exportación es obligatorio");
                            }
                            if (IncotermsDropDownList.SelectedValue.Equals(string.Empty))
                            {
                                throw new Exception("Incoterms es obligatorio");
                            }
                            if (tipoExp.Equals("0"))
                            {
                                throw new Exception("El tipo de exportación es obligatorio");
                            }
                            if (IdiomaDropDownList.SelectedValue.Equals("0"))
                            {
                                throw new Exception("El idioma es obligatorio");
                            }
                        }
                        else //NC y ND
                        {
                            if (PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
                            {
                                throw new Exception("El país destino de exportación es obligatorio");
                            }
                            if (tipoExp.Equals("0"))
                            {
                                throw new Exception("El tipo de exportación es obligatorio");
                            }
                            if (IdiomaDropDownList.SelectedValue.Equals("0"))
                            {
                                throw new Exception("El idioma es obligatorio");
                            }
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
            }

            if (!PaisDestinoExpDropDownList.SelectedValue.Equals("0"))
            {
                ie.destino_comprobante = Convert.ToInt32(PaisDestinoExpDropDownList.SelectedValue);
                exportacion = true;
            }
            if (!IncotermsDropDownList.SelectedValue.Equals(string.Empty))
            {
                ie.incoterms = IncotermsDropDownList.SelectedValue;
                exportacion = true;
            }
            if (!TipoExpDropDownList.SelectedValue.Equals("0"))
            {
                ie.tipo_exportacion = Convert.ToInt32(TipoExpDropDownList.SelectedValue);
                exportacion = true;
            }
            if (!IdiomaDropDownList.SelectedValue.Equals("0"))
            {
                comp.extensionesSpecified = true;
                comp.extensiones = new FeaEntidades.InterFacturas.extensiones();
                comp.extensiones.extensiones_camara_facturasSpecified = true;
                comp.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                comp.extensiones.extensiones_camara_facturas.id_idioma = IdiomaDropDownList.SelectedValue;
                exportacion = true;
            }

            GenerarInfoPermisosExportacion(ie, infcomprob);

            if (exportacion)
            {
                infcomprob.informacion_exportacion = ie;
            }
        }

		private void GenerarInfoPermisosExportacion(FeaEntidades.InterFacturas.informacion_exportacion ie, FeaEntidades.InterFacturas.informacion_comprobante infcomprob)
		{
			if (infcomprob.tipo_de_comprobante.Equals(19) && ie.tipo_exportacion.Equals(1))
			{
				if (this.PermisosExpo.HayPermisos)
				{
					ie.permiso_existente = "S";
					ie.permisos = new FeaEntidades.InterFacturas.permisos[5];
					for (int i = 0; i < this.PermisosExpo.PermisosExportacion.Count; i++)
					{
						ie.permisos[i] = new FeaEntidades.InterFacturas.permisos();
						ie.permisos[i].descripcion_destino_mercaderia = this.PermisosExpo.PermisosExportacion[i].descripcion_destino_mercaderia;
						ie.permisos[i].destino_mercaderia = this.PermisosExpo.PermisosExportacion[i].destino_mercaderia;
						ie.permisos[i].id_permiso = this.PermisosExpo.PermisosExportacion[i].id_permiso;
					}
				}
				else
				{
					ie.permiso_existente = "N";
				}
			}
			else
			{
				if (this.PermisosExpo.HayPermisos)
				{
					throw new Exception("No se deben informar permisos de exportación para este tipo de comprobante");
				}
			}
		}

		private void GenerarInfoVendedor(FeaEntidades.InterFacturas.cabecera compcab)
		{
			FeaEntidades.InterFacturas.informacion_vendedor infovend = new FeaEntidades.InterFacturas.informacion_vendedor();
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

        private void GenerarInfoComprador(FeaEntidades.InterFacturas.cabecera compcab, FeaEntidades.InterFacturas.informacion_comprador infcompra)
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

            //obligatorio para exportación
            if (Domicilio_Calle_CompradorTextBox.Text.Equals(string.Empty))
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            Domicilio_Calle_CompradorTextBox.Focus();
                            throw new Exception("La calle del domicilio del comprador es obligatoria para exportación");
                        }
                        else
                        {
                            infcompra.domicilio_calle = string.Empty;
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    infcompra.domicilio_calle = string.Empty;
                }
            }
            else
            {
                infcompra.domicilio_calle = Domicilio_Calle_CompradorTextBox.Text;
            }

            //obligatorio para exportación
            if (Domicilio_Numero_CompradorTextBox.Text.Equals(string.Empty))
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            Domicilio_Numero_CompradorTextBox.Focus();
                            throw new Exception("El número de la calle del domicilio del comprador es obligatorio para exportación");
                        }
                        else
                        {
                            infcompra.domicilio_numero = string.Empty;
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    infcompra.domicilio_numero = string.Empty;
                }
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
            //No se tiene que informar para exportación
            if (!auxCodProvCompra.Equals("0"))
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            if (!PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
                            {
                                Provincia_CompradorDropDownList.Focus();
                                throw new Exception("La provincia del domicilio del comprador no se debe informar para exportación");
                            }
                            else
                            {
                                infcompra.provincia = auxCodProvCompra;
                            }
                        }
                        else
                        {
                            infcompra.provincia = auxCodProvCompra;
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    infcompra.provincia = auxCodProvCompra;
                }
            }
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

			//para exportación no se debe informar
			try
			{
				double importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_nacionalesSpecified = false;
                            rimo.importe_total_impuestos_nacionalesSpecified = false;
                            throw new Exception("El importe total de impuestos nacionales en moneda extranjera no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    GenerarImporteTotalImpuestosNacionalesMonedaExtranjera(r, tipodecambio, rimo);
                }
			}
			catch (FormatException)
			{
			}

			//para exportación no se debe informar
			try
			{
				double importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_ingresos_brutosSpecified = false;
                            rimo.importe_total_ingresos_brutosSpecified = false;
                            throw new Exception("El importe total de ingresos brutos en moneda extranjera no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
                        }
                    }
				}
				catch (System.NullReferenceException)
				{
					GenerarImporteTotalIngresosBrutosMonedaExtranjera(r, tipodecambio, rimo);
				}
			}
			catch (FormatException)
			{
			}

			//para exportación no se debe informar
			try
			{
				double importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_municipalesSpecified = false;
                            rimo.importe_total_impuestos_municipalesSpecified = false;
                            throw new Exception("El importe total de impuestos municipales en moneda extranjera no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    GenerarImporteTotalImpuestosMunicipalesMonedaExtranjera(r, tipodecambio, rimo);
                }
            }
            catch (FormatException)
            {
            }

			//para exportación no se debe informar
            try
            {
                double importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_internosSpecified = false;
                            rimo.importe_total_impuestos_internosSpecified = false;
                            throw new Exception("El importe total de impuestos internos en moneda extranjera no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    GenerarImporteTotalImpuestosInternosMonedaExtranjera(r, tipodecambio, rimo);
                }
            }
            catch (FormatException)
            {
            }
            r.importe_total_factura = 0;
            rimo.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
            r.importes_moneda_origen = rimo;
        }

        private void GenerarImpuestoLiqRNIExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
        {
            //para exportación se debe informar en 0
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
                    if (idtipo.Equals("Exportacion") && !Impuesto_Liq_Rni_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El Impuesto liquidado a RNI o percepción a no categorizados debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.impuesto_liq_rni = 0;
                        rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                r.impuesto_liq_rni = Math.Round(Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text) * tipodecambio, 2);
                rimo.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
            }
        }

		private void GenerarImpuestoLiqExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportación se debe informar en 0
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
                    if (idtipo.Equals("Exportacion") && !Impuesto_Liq_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El IVA Responsable inscripto debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.impuesto_liq = 0;
                        rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.impuesto_liq = Math.Round(Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteOperacionesExentasExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportación se debe informar en 0
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
                    if (idtipo.Equals("Exportacion") && !Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe de operaciones exentas debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_operaciones_exentas = 0;
                        rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_operaciones_exentas = Math.Round(Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalConceptoNoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportación se debe informar en 0
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
                    if (idtipo.Equals("Exportacion") && !Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe total de conceptos que no integren el precio neto gravado debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_total_concepto_no_gravado = 0;
                        rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_total_concepto_no_gravado = Math.Round(Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalNetoGravadoExtranjera(FeaEntidades.InterFacturas.resumen r, double tipodecambio, FeaEntidades.InterFacturas.resumenImportes_moneda_origen rimo)
		{
			//para exportación se debe informar en 0
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
                    if (idtipo.Equals("Exportacion") && !Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe total neto gravado debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_total_neto_gravado = 0;
                        rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_total_neto_gravado = Math.Round(Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text) * tipodecambio, 2);
				rimo.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
			}
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

			//para exportación no se debe informar
			try
			{
				double importe_total_impuestos_nacionales = Convert.ToDouble(Importe_Total_Impuestos_Nacionales_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_nacionalesSpecified = false;
                            throw new Exception("El importe total de impuestos nacionales no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);
                        }
                    }
				}
				catch (System.NullReferenceException)
				{
					GenerarImporteTotalImpuestosNacionales(r, importe_total_impuestos_nacionales);
				}
 			}
			catch (FormatException)
			{
			}

			//para exportación no se debe informar
			try
			{
				double importe_total_ingresos_brutos = Convert.ToDouble(Importe_Total_Ingresos_Brutos_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_ingresos_brutosSpecified = false;
                            throw new Exception("El importe total de ingresos brutos no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalIngresosBrutos(r);
                        }
                    }
				}
				catch (System.NullReferenceException)
				{
					GenerarImporteTotalIngresosBrutos(r);
				}
			}
			catch (FormatException)
			{
			}

			//para exportación no se debe informar
			try
			{
				double importe_total_impuestos_municipales = Convert.ToDouble(Importe_Total_Impuestos_Municipales_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_municipalesSpecified = false;
                            throw new Exception("El importe total de impuestos municipales no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosMunicipales(r);
                        }
                    }
				}
				catch (System.NullReferenceException)
				{
					GenerarImporteTotalImpuestosMunicipales(r);
				}
			}
			catch (FormatException)
			{
			}

			//para exportación no se debe informar
			try
			{
				double importe_total_impuestos_internos = Convert.ToDouble(Importe_Total_Impuestos_Internos_ResumenTextBox.Text);
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
                        if (idtipo.Equals("Exportacion"))
                        {
                            r.importe_total_impuestos_internosSpecified = false;
                            throw new Exception("El importe total de impuestos internos no se debe informar para exportación");
                        }
                        else
                        {
                            GenerarImporteTotalImpuestosInternos(r);
                        }
                    }
				}
				catch (System.NullReferenceException)
				{
					GenerarImporteTotalImpuestosInternos(r);
				}
			}
			catch (FormatException)
			{
			}
			r.importe_total_factura = Convert.ToDouble(Importe_Total_Factura_ResumenTextBox.Text);
		}

		private void GenerarImpuestoLiqRNI(FeaEntidades.InterFacturas.resumen r)
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
                    if (idtipo.Equals("Exportacion") && !Impuesto_Liq_Rni_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El Impuesto liquidado a RNI o percepción a no categorizados debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.impuesto_liq_rni = Convert.ToDouble(Impuesto_Liq_Rni_ResumenTextBox.Text);
			}
		}

		private void GenerarImpuestoLiq(FeaEntidades.InterFacturas.resumen r)
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
                    if (idtipo.Equals("Exportacion") && !Impuesto_Liq_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El IVA Responsable inscripto debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.impuesto_liq = Convert.ToDouble(Impuesto_Liq_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteOperacionesExentas(FeaEntidades.InterFacturas.resumen r)
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
                    if (idtipo.Equals("Exportacion") && !Importe_Operaciones_Exentas_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe de operaciones exentas debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_operaciones_exentas = Convert.ToDouble(Importe_Operaciones_Exentas_ResumenTextBox.Text);
			}
		}

		private void GenerarImporteTotalConceptoNoGravado(FeaEntidades.InterFacturas.resumen r)
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
                    if (idtipo.Equals("Exportacion") && !Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe total de conceptos que no integren el precio neto gravado debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_total_concepto_no_gravado = Convert.ToDouble(Importe_Total_Concepto_No_Gravado_ResumenTextBox.Text);
			}

		}

		private void GenerarImporteTotalNetoGravado(FeaEntidades.InterFacturas.resumen r)
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
                    if (idtipo.Equals("Exportacion") && !Importe_Total_Neto_Gravado_ResumenTextBox.Text.Equals("0"))
                    {
                        throw new Exception("El importe total neto gravado debe informarse en 0 para exportación.");
                    }
                    else
                    {
                        r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
                    }
                }
			}
			catch (System.NullReferenceException)
			{
				r.importe_total_neto_gravado = Convert.ToDouble(Importe_Total_Neto_Gravado_ResumenTextBox.Text);
			}
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

		protected void PDFButton_Click(object sender, EventArgs e)
		{
			try
			{
				FeaEntidades.InterFacturas.lote_comprobantes lcFea = GenerarLote(true);
                if (lcFea.comprobante[0].cabecera.informacion_comprobante.cae == null || lcFea.comprobante[0].cabecera.informacion_comprobante.cae.Equals(string.Empty))
				{
					lcFea.comprobante[0].cabecera.informacion_comprobante.cae = " ";
				}
				lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
				lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
				foreach (FeaEntidades.InterFacturas.linea l in lcFea.comprobante[0].detalle.linea)
				{
					if (l != null)
					{
						l.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
					}
					else
					{
						break;
					}
				}
				if (lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == null)
				{
					lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = string.Empty;
				}
				if (lcFea.cabecera_lote.presta_servSpecified == false)
				{
					lcFea.cabecera_lote.presta_serv = 0;
					lcFea.cabecera_lote.presta_servSpecified = true;
				}
				if (lcFea.comprobante[0].extensiones != null && lcFea.comprobante[0].extensiones.extensiones_datos_comerciales != null && !lcFea.comprobante[0].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
				{
					string dc = RN.Funciones.HexToString(lcFea.comprobante[0].extensiones.extensiones_datos_comerciales);
					lcFea.comprobante[0].extensiones.extensiones_datos_comerciales = dc.Replace("<br>", System.Environment.NewLine);
				}
				else
				{
					lcFea.comprobante[0].extensiones = new FeaEntidades.InterFacturas.extensiones();
				}
				if (lcFea.comprobante[0].resumen.impuestos != null)
				{
					foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lcFea.comprobante[0].resumen.impuestos)
					{
						if (imp != null)
						{
							imp.codigo_jurisdiccionSpecified = true;
							imp.porcentaje_impuestoSpecified = true;
							imp.importe_impuesto_moneda_origenSpecified = true;
						}
					}
				}
				Session["lote"] = lcFea;
				Response.Redirect("Reportes\\FacturaWebForm.aspx", true);
			}
			catch (Exception ex)
			{
				ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Problemas al generar el pdf.\\n " + ex.Message + "');</script>");
			}
            
		}
		
		private void RegistrarActividad(FeaEntidades.InterFacturas.lote_comprobantes lote, System.Text.StringBuilder sb, System.Net.Mail.SmtpClient smtpClient, string smtpXAmb, System.IO.MemoryStream m)
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

        //protected void Version0RadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    AjustarPrestaServxVersiones();
        //}

		protected void Version1RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			AjustarPrestaServxVersiones();
		}

		private void AjustarPrestaServxVersiones()
		{
            //if (Version0RadioButton.Checked && Version0RadioButton.Visible)
            //{
            //    Presta_ServCheckBox.Visible = true;
            //    Presta_ServLabel.Visible = true;
            //    CodigoConceptoLabel.Visible = false;
            //    CodigoConceptoDropDownList.Visible = false;
            //}
            //if (Version1RadioButton.Checked && Version1RadioButton.Visible)
            //{
				Presta_ServCheckBox.Visible = false;
				Presta_ServLabel.Visible = false;
				CodigoConceptoLabel.Visible = true;
				CodigoConceptoDropDownList.Visible = true;
            //}
		}

		private void AjustarCamposXVersion(org.dyndns.cedweb.consulta.ConsultarResult lc)
		{
		}

		private void AjustarCamposXVersion(FeaEntidades.InterFacturas.lote_comprobantes lc)
		{
            //if (lc.cabecera_lote.presta_servSpecified)
            //{
            //    Version0RadioButton.Checked = true;
            //    Version1RadioButton.Checked=false;
            //}
            //else
            //{
				Version1RadioButton.Checked = true;
                //Version0RadioButton.Checked=false;
            //}
			AjustarPrestaServxVersiones();
		}

        protected void PaisDestinoExpDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int auxPV = Convert.ToInt32(((DropDownList)PuntoVtaDropDownList).SelectedValue);
            string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
            {
                return pv.Nro == auxPV;
            }).IdTipoPuntoVta;
            if (!idtipo.Equals("Exportacion"))
            {
                return;
            }
            System.Collections.Generic.List<Entidades.Persona> listacompradores = new List<Entidades.Persona>();
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
            if (PaisDestinoExpDropDownList.SelectedItem.Text.ToUpper().Contains("ARGENTINA"))
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    listacompradores = RN.Persona.ListaSinExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                    Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                    Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                    Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaNoExportacion();
                }
            }
            else if (PaisDestinoExpDropDownList.SelectedItem.Text.Equals(string.Empty))
            {
                try
                {
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        listacompradores = RN.Persona.ListaExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                        Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                        Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                        Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                        Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
                    }
                }
                catch
                {
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        listacompradores = RN.Persona.ListaPorCuit(true, Entidades.Enum.TipoPersona.Cliente, ((Entidades.Sesion)Session["Sesion"]));
                        Nro_Doc_Identificatorio_CompradorTextBox.Visible = true;
                        Nro_Doc_Identificatorio_CompradorDropDownList.Visible = false;
                        Nro_Doc_Identificatorio_CompradorTextBox.Text = string.Empty;
                        Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                    }
                }
            }
            else
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    listacompradores = RN.Persona.ListaExportacion(((Entidades.Sesion)Session["Sesion"]).Usuario, ((Entidades.Sesion)Session["Sesion"]), true);
                    Nro_Doc_Identificatorio_CompradorTextBox.Visible = false;
                    Nro_Doc_Identificatorio_CompradorDropDownList.Visible = true;
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataValueField = "Codigo";
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataTextField = "Descr";
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.ListaSinInformar();
                    Nro_Doc_Identificatorio_CompradorDropDownList.DataBind();
                    Nro_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
                    Codigo_Doc_Identificatorio_CompradorDropDownList.DataSource = FeaEntidades.Documentos.Documento.ListaExportacion();
                }
            }
            CompradorDropDownList.DataValueField = "RazonSocial";
            CompradorDropDownList.DataTextField = "RazonSocial";
            Entidades.Persona persona = new Entidades.Persona();
            System.Collections.Generic.List<Entidades.Persona> personalist = new System.Collections.Generic.List<Entidades.Persona>();
            persona.RazonSocial = "";
            personalist.Add(persona);
            personalist.AddRange(listacompradores);
            CompradorDropDownList.DataSource = personalist;
            CompradorDropDownList.DataBind();
            CompradorDropDownList.SelectedIndex = 0;
            if (CompradorDropDownList.Items.Count > 1)
            {
                CompradorDropDownList.Visible = true;
            }
            else
            {
                CompradorDropDownList.Visible = false;
            }
            Codigo_Doc_Identificatorio_CompradorDropDownList.DataBind();
            Codigo_Doc_Identificatorio_CompradorDropDownList.SelectedIndex = -1;
            ResetearComprador();
        }
       
		public Detalle Articulos
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
            try
            {
                AjustarCamposXPtaVentaChanged(((DropDownList)sender).SelectedValue);
                int auxPV = Convert.ToInt32(((DropDownList)sender).SelectedValue);
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
                DetalleLinea.PuntoDeVenta = Convert.ToString(auxPV);
            }
            catch
            {
                ResetearGrillas();
            }
            //Al cambiar el punto de venta se inicializa el Nro.Lote
            Id_LoteTextbox.Text = "";
            //Verificar método de numeración del lote.
            VerificarMetodoNumeracionLote();
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
                    string idtipo = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv)
                    {
                        return pv.Nro == auxPV;
                    }).IdTipoPuntoVta;
                    if (idtipo.Equals("RG2904"))
                    {
                        AjustarCodigoOperacionEn2904(((DropDownList)sender).SelectedValue);
                    }
                }
            }
            catch
            {
            }
        }

        protected void ButtonGenerarNroLote_Click(object sender, EventArgs e)
        {
            //Genera el número de lote;
            GenerarNroLote();
        }

        protected void ModalPopupExtender1_Load(object sender, EventArgs e)
        {

        }

        protected void ModalPopupExtender3_Load(object sender, EventArgs e)
        {

        }

        protected void AceptarEnvioITFButton_Click(object sender, EventArgs e)
        {
            EnviarIBKButton_Click(EnviarIBKButton, new EventArgs());
        }

        protected void CancelarEnvioITFButton_Click(object sender, EventArgs e)
        {

        }

        protected void AceptarValidarITFButton_Click(object sender, EventArgs e)
        {
            ValidarIBKButton_Click(EnviarIBKButton, new EventArgs());
        }

        protected void CancelarValidarITFButton_Click(object sender, EventArgs e)
        {

        }
        protected void ButtonPrueba_Click(object sender, EventArgs e)
        {

        }

        protected void AceptarEnviarAFIPButton_Click(object sender, EventArgs e)
        {
            EnviarAFIPButton_Click(EnviarIBKButton, new EventArgs());
        }

        protected void CancelarEnviarAFIPButton_Click(object sender, EventArgs e)
        {

        }
	}
}