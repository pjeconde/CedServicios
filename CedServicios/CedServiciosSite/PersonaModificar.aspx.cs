using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    DataBind();

                    Entidades.Persona persona = (Entidades.Persona)Session["Persona"];

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
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void TipoPersona_CheckedChanged(object sender, EventArgs e)
        {
            Contacto.Required = ClienteRadioButton.Checked || AmbosRadioButton.Checked;
        }
    }
}