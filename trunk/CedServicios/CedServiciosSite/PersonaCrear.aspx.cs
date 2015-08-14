﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class PersonaCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
                DestinosCuitDropDownList.DataSource = FeaEntidades.DestinosCuit.DestinoCuit.Lista();
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                DataBind();
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
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
                        persona.Documento.Nro = Convert.ToInt64(DestinosCuitDropDownList.SelectedItem.Value);
                    }
                    else
                    {
                        persona.Documento.Nro = Convert.ToInt64(NroDocTextBox.Text);
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