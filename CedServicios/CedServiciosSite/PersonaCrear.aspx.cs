using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CedServicios.Site
{
    public partial class PersonaCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.Lista();
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                Entidades.DatosEmailAvisoComprobantePersona datos = new Entidades.DatosEmailAvisoComprobantePersona();
                datos.DestinatariosFrecuentes.Add(new Entidades.DestinatarioFrecuente(string.Empty, string.Empty, string.Empty));
                DatosEmailAvisoComprobantePersona.Datos = datos;
                ListaPrecioDefaultPersona.ListasPrecioVenta = RN.ListaPrecio.ListaPorCuityTipoLista(true, true, false, "Venta", sesion);
                ListaPrecioDefaultPersona.ListasPrecioCompra = RN.ListaPrecio.ListaPorCuityTipoLista(true, true, false, "Compra", sesion);
                DataBind();
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    TipoDocDropDownList.SelectedValue = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                    DestinosCuitDropDownList.SelectedValue = new FeaEntidades.DestinosCuit.BrasilPersonaJuridica().Codigo.ToString();
                    DatosImpositivos.FechaInicioActividades = DateTime.Today;
                    NroDocTextBox.Focus();
                }
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
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
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                Entidades.Persona persona = new Entidades.Persona();
                try
                {
                    persona.Cuit = CUITTextBox.Text;
                    if (AmbosRadioButton.Checked)
                    {
                        persona.EsCliente = true;
                        persona.EsProveedor = true;
                    }
                    else if (ClienteRadioButton.Checked)
                    {
                        persona.EsCliente = true;
                    }
                    else
                    {
                        persona.EsProveedor = true;
                    }
                    persona.Documento.Tipo.Id = TipoDocDropDownList.SelectedValue;
                    persona.Documento.Tipo.Descr = TipoDocDropDownList.SelectedItem.Text;
                    if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                    {
                        persona.Documento.Nro = Convert.ToString(DestinosCuitDropDownList.SelectedItem.Value);
                    }
                    else
                    {
                        persona.Documento.Nro = NroDocTextBox.Text;
                    }
                    persona.RazonSocial = RazonSocialTextBox.Text;
                    persona.Domicilio.Calle = Domicilio.Calle;
                    persona.Domicilio.Nro = Domicilio.Nro;
                    persona.Domicilio.Piso = Domicilio.Piso;
                    persona.Domicilio.Depto = Domicilio.Depto;
                    persona.Domicilio.Manzana = Domicilio.Manzana;
                    persona.Domicilio.Sector = Domicilio.Sector;
                    persona.Domicilio.Torre = Domicilio.Torre;
                    persona.Domicilio.Localidad = Domicilio.Localidad;
                    persona.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                    persona.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                    persona.Domicilio.CodPost = Domicilio.CodPost;
                    persona.Contacto.Nombre = Contacto.Nombre;
                    persona.Contacto.Email = Contacto.Email;
                    persona.Contacto.Telefono = Contacto.Telefono;
                    persona.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                    persona.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                    persona.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                    persona.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                    persona.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                    persona.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                    persona.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                    persona.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                    persona.IdPersona = IdPersonaTextBox.Text;
                    persona.EmailAvisoVisualizacion = EmailAvisoVisualizacionTextBox.Text;
                    persona.PasswordAvisoVisualizacion = PasswordAvisoVisualizacionTextBox.Text;
                    persona.DatosEmailAvisoComprobantePersona = DatosEmailAvisoComprobantePersona.Datos;
                    persona.IdListaPrecioVenta = ListaPrecioDefaultPersona.IdListaPrecioVenta;
                    persona.IdListaPrecioCompra = ListaPrecioDefaultPersona.IdListaPrecioCompra;
                    RN.Persona.Validar(persona);
                    RN.Persona.Crear(persona, sesion);

                    CUITTextBox.Enabled = false;
                    TipoDocDropDownList.Enabled = false;
                    NroDocTextBox.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    IdPersonaTextBox.Enabled = false;
                    DatosEmailAvisoComprobantePersona.Enabled = false;
                    ListaPrecioDefaultPersona.Enabled = false;
                    EmailAvisoVisualizacionTextBox.Enabled = false;
                    PasswordAvisoVisualizacionTextBox.Enabled = false;
                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "La Persona fué creada satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    if (MensajeLabel.Text.IndexOf("PK_Cliente") != -1)
                    {
                        MensajeLabel.Text = "Ya existe una Persona con este 'Nro.'";
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.Text.ToString().Replace("'", "") + "');", true);
                }
            }
        }
        protected void TipoDocDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
            {
                NroDocTextBox.Visible = false;
                DestinosCuitDropDownList.Visible = true;
            }
            else
            {
                NroDocTextBox.Visible = true;
                DestinosCuitDropDownList.Visible = false;
            }
            TraerDatosDeAFIPLinkButton.Visible = TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUIT().Codigo.ToString()) || TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUIL().Codigo.ToString());
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void TipoPersona_CheckedChanged(object sender, EventArgs e)
        {
            Contacto.Required = ClienteRadioButton.Checked || AmbosRadioButton.Checked;
        }
        protected void TraerDatosDeAFIPLinkButton_Click(object sender, EventArgs e)
        {
            if (TipoDocDropDownList.SelectedValue == "80" || TipoDocDropDownList.SelectedValue == "86") //CUIT o CUIL
            {
                try
                {
                    Entidades.Sesion sesion = ((Entidades.Sesion)Session["Sesion"]);
                    Entidades.Sesion sesionConsultaAFIP = new Entidades.Sesion();
                    sesionConsultaAFIP.Cuit.UsaCertificadoAFIPPropio = true;
                    sesionConsultaAFIP.Cuit.Nro = RN.Configuracion.CuitConsultaAFIP(sesion);
                    sesionConsultaAFIP.CnnStr = sesion.CnnStr;
                    if (sesionConsultaAFIP.Cuit.Nro != string.Empty)
                    {
                        Entidades.PadronA13.persona persona = RN.ServiciosAFIP.DatosFiscales(NroDocTextBox.Text, sesionConsultaAFIP);
                        RazonSocialTextBox.Text = persona.razonSocial;
                        if (persona.domicilio.Length > 0)
                        {
                            for (int i = 0; i < persona.domicilio.Length; i++)
                            {
                                if (persona.domicilio[i].tipoDomicilio.IndexOf("LEGAL") != -1)
                                {
                                    Domicilio.Calle = persona.domicilio[i].calle;
                                    Domicilio.Nro = persona.domicilio[i].numero.ToString();
                                    Domicilio.Piso = persona.domicilio[i].piso;
                                    Domicilio.Depto = persona.domicilio[i].oficinaDptoLocal;
                                    Domicilio.Sector = persona.domicilio[i].sector;
                                    Domicilio.Torre = persona.domicilio[i].torre;
                                    Domicilio.Manzana = persona.domicilio[i].manzana;
                                    Domicilio.Localidad = persona.domicilio[i].localidad;
                                    Domicilio.IdProvincia = RN.ServiciosAFIP.IdProvincia(persona.domicilio[i].idProvincia.ToString());
                                    Domicilio.CodPost = persona.domicilio[i].codigoPostal;
                                }
                            }
                        }
                        //string xmlString = RN.ServiciosAFIP.DatosFiscales(NroDocTextBox.Text, sesionConsultaAFIP);
                        //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Entidades.AFIP.Contribuyente));
                        //StringReader rdr = new StringReader(xmlString);
                        //Entidades.AFIP.Contribuyente contribuyente = (Entidades.AFIP.Contribuyente)serializer.Deserialize(rdr);
                        //RazonSocialTextBox.Text = contribuyente.Persona.DescripcionCorta;
                        //if (contribuyente.Domicilios.Length > 0)
                        //{
                        //    Domicilio.Calle = contribuyente.Domicilios[0].Calle;
                        //    Domicilio.Nro = contribuyente.Domicilios[0].Numero;
                        //    Domicilio.Piso = contribuyente.Domicilios[0].Piso;
                        //    Domicilio.Depto = contribuyente.Domicilios[0].OficinaDeptoLocal;
                        //    Domicilio.Sector = string.Empty;
                        //    Domicilio.Torre = string.Empty;
                        //    Domicilio.Manzana = string.Empty;
                        //    Domicilio.Localidad = contribuyente.Domicilios[0].Localidad;
                        //    Domicilio.IdProvincia = RN.ServiciosAFIP.IdProvincia(contribuyente.Domicilios[0].IdProvincia);
                        //    Domicilio.CodPost = contribuyente.Domicilios[0].CodigoPostal;
                        //}
                    }
                    else
                    {
                        MensajeLabel.Text = "Servicio de consulta no disponible en estos momentos";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.Text.ToString().Replace("'", "") + "');", true);
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.Text.ToString().Replace("'", "") + "');", true);
                }
            }
            else
            {
                MensajeLabel.Text = "Para obtener los datos de la AFIP hay que ingresar CUIT/CUIL";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('" + MensajeLabel.Text.ToString().Replace("'", "") + "');", true);
            }
        }
    }
}