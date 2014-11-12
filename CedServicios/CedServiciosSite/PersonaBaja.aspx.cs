using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PersonaBaja : System.Web.UI.Page
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
                    }
                    if (persona.EsCliente)
                    {
                        ClienteRadioButton.Checked = true;
                    }
                    else
                    {
                        ProveedorRadioButton.Checked = true;
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
                    DestinosCuitDropDownList.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    IdPersonaTextBox.Enabled = false;
                    EmailAvisoVisualizacionTextBox.Enabled = false;
                    PasswordAvisoVisualizacionTextBox.Enabled = false;

                    if (persona.WF.Estado == "Vigente")
                    {
                        TituloPaginaLabel.Text = "Baja de Persona";
                        AceptarButton.Text = "Dar de Baja";
                    }
                    else
                    {
                        TituloPaginaLabel.Text = "Anulación de Baja de Persona";
                        AceptarButton.Text = "Anular Baja";
                    }
                    AceptarButton.Focus();
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
                Entidades.Persona persona = (Entidades.Persona)Session["Persona"];
                try
                {

                    if (AceptarButton.Text == "Dar de Baja")
                    {
                        RN.Persona.CambiarEstado(persona, "DeBaja", sesion);
                    }
                    else
                    {
                        RN.Persona.CambiarEstado(persona, "Vigente", sesion);
                    }

                    AceptarButton.Enabled = false;
                    SalirButton.Text = "Salir";

                    MensajeLabel.Text = "El cambio de estado fué registrado satisfactoriamente";
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
    }
}