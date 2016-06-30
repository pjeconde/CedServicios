using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CedServicios.Site
{
    public partial class PersonaModificar : System.Web.UI.Page
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

                    TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                    DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.Lista();
                    Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                    DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                    DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                    ListaPrecioDefaultPersona.ListasPrecioVenta = RN.ListaPrecio.ListaPorCuityTipoLista(true, true, false, "Venta", sesion);
                    ListaPrecioDefaultPersona.ListasPrecioCompra = RN.ListaPrecio.ListaPorCuityTipoLista(true, true, false, "Compra", sesion);
                    DataBind();

                    Entidades.Persona persona = (Entidades.Persona)Session["Persona"];
                    RN.Persona.LeerDestinatariosFrecuentes(persona, false, sesion);
                    if (persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Count == 0) persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Add(new Entidades.DestinatarioFrecuente(string.Empty, string.Empty, string.Empty));

                    CUITTextBox.Text = persona.Cuit;
                    if (persona.EsCliente && persona.EsProveedor)
                    {
                        AmbosRadioButton.Checked = true;
                        TipoPersona_CheckedChanged(AmbosRadioButton, EventArgs.Empty);
                    }
                    if (persona.EsCliente)
                    {
                        ClienteRadioButton.Checked = true;
                        TipoPersona_CheckedChanged(ClienteRadioButton, EventArgs.Empty);
                    }
                    else
                    {
                        ProveedorRadioButton.Checked = true;
                        TipoPersona_CheckedChanged(ProveedorRadioButton, EventArgs.Empty);
                    }
                    TipoDocDropDownList.SelectedValue = persona.Documento.Tipo.Id;
                    TipoDocDropDownList_SelectedIndexChanged(TipoDocDropDownList, new EventArgs());
                    if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                    {
                        DestinosCuitDropDownList.SelectedValue = persona.Documento.Nro.ToString();
                    }
                    else
                    {
                        NroDocTextBox.Text = persona.Documento.Nro.ToString();
                    }
                    RazonSocialTextBox.Text = persona.RazonSocial;
                    Domicilio.Calle = persona.Domicilio.Calle;
                    Domicilio.Nro = persona.Domicilio.Nro;
                    Domicilio.Piso = persona.Domicilio.Piso;
                    Domicilio.Depto = persona.Domicilio.Depto;
                    Domicilio.Manzana = persona.Domicilio.Manzana;
                    Domicilio.Sector = persona.Domicilio.Sector;
                    Domicilio.Torre = persona.Domicilio.Torre;
                    Domicilio.Localidad = persona.Domicilio.Localidad;
                    Domicilio.IdProvincia = persona.Domicilio.Provincia.Id;
                    persona.Domicilio.CodPost = Domicilio.CodPost;
                    Contacto.Nombre = persona.Contacto.Nombre;
                    Contacto.Email = persona.Contacto.Email;
                    Contacto.Telefono = persona.Contacto.Telefono;
                    DatosImpositivos.IdCondIVA = persona.DatosImpositivos.IdCondIVA;
                    DatosImpositivos.IdCondIngBrutos = persona.DatosImpositivos.IdCondIngBrutos;
                    DatosImpositivos.NroIngBrutos = persona.DatosImpositivos.NroIngBrutos;
                    DatosImpositivos.FechaInicioActividades = persona.DatosImpositivos.FechaInicioActividades;
                    DatosIdentificatorios.GLN = persona.DatosIdentificatorios.GLN;
                    DatosIdentificatorios.CodigoInterno = persona.DatosIdentificatorios.CodigoInterno;
                    IdPersonaTextBox.Text = persona.IdPersona;
                    DatosEmailAvisoComprobantePersona.Datos = persona.DatosEmailAvisoComprobantePersona;
                    ListaPrecioDefaultPersona.IdListaPrecioVenta = persona.IdListaPrecioVenta;
                    ListaPrecioDefaultPersona.IdListaPrecioCompra = persona.IdListaPrecioCompra;
                    EmailAvisoVisualizacionTextBox.Text = persona.EmailAvisoVisualizacion;
                    PasswordAvisoVisualizacionTextBox.Text = persona.PasswordAvisoVisualizacion;
                    CUITTextBox.Enabled = false;
                    TipoDocDropDownList.Enabled = false;
                    NroDocTextBox.Enabled = false;
                    IdPersonaTextBox.Enabled = false;
                    DestinosCuitDropDownList.Enabled = false;
                    RazonSocialTextBox.Focus();
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
                Entidades.Persona personaDesde = (Entidades.Persona)Session["Persona"];
                Entidades.Persona personaHasta = RN.Persona.ObternerCopia(personaDesde);
                try
                {
                    personaHasta.Cuit = CUITTextBox.Text;
                    if (AmbosRadioButton.Checked)
                    {
                        personaHasta.EsCliente = true;
                        personaHasta.EsProveedor = true;
                    }
                    else if (ClienteRadioButton.Checked)
                    {
                        personaHasta.EsCliente = true;
                    }
                    else
                    {
                        personaHasta.EsProveedor = true;
                    }
                    personaHasta.Documento.Tipo.Id = TipoDocDropDownList.SelectedValue;
                    personaHasta.Documento.Tipo.Descr = TipoDocDropDownList.SelectedItem.Text;
                    if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                    {
                        personaHasta.Documento.Nro = Convert.ToInt64(DestinosCuitDropDownList.SelectedItem.Value);
                    }
                    else
                    {
                        personaHasta.Documento.Nro = Convert.ToInt64(NroDocTextBox.Text);
                    }
                    personaHasta.RazonSocial = RazonSocialTextBox.Text;
                    personaHasta.Domicilio.Calle = Domicilio.Calle;
                    personaHasta.Domicilio.Nro = Domicilio.Nro;
                    personaHasta.Domicilio.Piso = Domicilio.Piso;
                    personaHasta.Domicilio.Depto = Domicilio.Depto;
                    personaHasta.Domicilio.Manzana = Domicilio.Manzana;
                    personaHasta.Domicilio.Sector = Domicilio.Sector;
                    personaHasta.Domicilio.Torre = Domicilio.Torre;
                    personaHasta.Domicilio.Localidad = Domicilio.Localidad;
                    personaHasta.Domicilio.Provincia.Id = Domicilio.IdProvincia;
                    personaHasta.Domicilio.Provincia.Descr = Domicilio.DescrProvincia;
                    personaHasta.Domicilio.CodPost = Domicilio.CodPost;
                    personaHasta.Contacto.Nombre = Contacto.Nombre;
                    personaHasta.Contacto.Email = Contacto.Email;
                    personaHasta.Contacto.Telefono = Contacto.Telefono;
                    personaHasta.DatosImpositivos.IdCondIVA = DatosImpositivos.IdCondIVA;
                    personaHasta.DatosImpositivos.DescrCondIVA = DatosImpositivos.DescrCondIVA;
                    personaHasta.DatosImpositivos.IdCondIngBrutos = DatosImpositivos.IdCondIngBrutos;
                    personaHasta.DatosImpositivos.DescrCondIngBrutos = DatosImpositivos.DescrCondIngBrutos;
                    personaHasta.DatosImpositivos.NroIngBrutos = DatosImpositivos.NroIngBrutos;
                    personaHasta.DatosImpositivos.FechaInicioActividades = DatosImpositivos.FechaInicioActividades;
                    personaHasta.DatosIdentificatorios.GLN = DatosIdentificatorios.GLN;
                    personaHasta.DatosIdentificatorios.CodigoInterno = DatosIdentificatorios.CodigoInterno;
                    personaHasta.IdPersona = IdPersonaTextBox.Text;
                    personaHasta.EmailAvisoVisualizacion = EmailAvisoVisualizacionTextBox.Text;
                    personaHasta.PasswordAvisoVisualizacion = PasswordAvisoVisualizacionTextBox.Text;
                    personaHasta.DatosEmailAvisoComprobantePersona = DatosEmailAvisoComprobantePersona.Datos;
                    personaHasta.IdListaPrecioVenta = ListaPrecioDefaultPersona.IdListaPrecioVenta;
                    personaHasta.IdListaPrecioCompra = ListaPrecioDefaultPersona.IdListaPrecioCompra;
                    RN.Persona.Validar(personaHasta);
                    RN.Persona.Modificar(personaDesde, personaHasta, sesion);

                    CUITTextBox.Enabled = false;
                    TipoDocDropDownList.Enabled = false;
                    NroDocTextBox.Enabled = false;
                    DestinosCuitDropDownList.Enabled = false;
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

                    MensajeLabel.Text = "La Persona fué modificada satisfactoriamente";
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                    return;
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
                        string xmlString = RN.ServiciosAFIP.DatosFiscales(NroDocTextBox.Text, sesionConsultaAFIP);
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Entidades.AFIP.Contribuyente));
                        StringReader rdr = new StringReader(xmlString);
                        Entidades.AFIP.Contribuyente contribuyente = (Entidades.AFIP.Contribuyente)serializer.Deserialize(rdr);
                        RazonSocialTextBox.Text = contribuyente.Persona.DescripcionCorta;
                        if (contribuyente.Domicilios.Length > 0)
                        {
                            Domicilio.Calle = contribuyente.Domicilios[0].Calle;
                            Domicilio.Nro = contribuyente.Domicilios[0].Numero;
                            Domicilio.Piso = contribuyente.Domicilios[0].Piso;
                            Domicilio.Depto = contribuyente.Domicilios[0].OficinaDeptoLocal;
                            Domicilio.Sector = string.Empty;
                            Domicilio.Torre = string.Empty;
                            Domicilio.Manzana = string.Empty;
                            Domicilio.Localidad = contribuyente.Domicilios[0].Localidad;
                            Domicilio.IdProvincia = RN.ServiciosAFIP.IdProvincia(contribuyente.Domicilios[0].IdProvincia);
                            Domicilio.CodPost = contribuyente.Domicilios[0].CodigoPostal;
                        }
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