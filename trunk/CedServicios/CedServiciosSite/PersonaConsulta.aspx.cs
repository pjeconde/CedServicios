using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class PersonaConsulta : System.Web.UI.Page
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
                    List<Entidades.Persona> lista = new List<Entidades.Persona>();
                    lista = RN.Persona.ListaPorCuit(false, sesion);
                    ClientesGridView.DataSource = lista;
                    ViewState["Personas"] = lista;
                    ClientesGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        MensajeLabel.Text = "No hay personas asociadas a este CUIT";
                    }
                }
            }
        }
        protected void ClientesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton verLinkButton = (LinkButton)e.Row.FindControl("VerLinkButton");
                verLinkButton.CommandArgument = e.Row.RowIndex.ToString();
                if (e.Row.Cells[5].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void ClientesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver" && e.CommandArgument != null)
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Persona> lista = (List<Entidades.Persona>)ViewState["Personas"];
                Entidades.Persona persona = lista[rowIndex];

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

                AjaxControlToolkit.ModalPopupExtender modalPopupExtender1 = (AjaxControlToolkit.ModalPopupExtender)ClientesGridView.Rows[rowIndex].FindControl("ModalPopupExtender1");
                modalPopupExtender1.Show();
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