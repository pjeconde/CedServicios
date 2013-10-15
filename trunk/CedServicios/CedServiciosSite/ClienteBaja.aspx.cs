using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ClienteBaja : System.Web.UI.Page
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

                    Entidades.Cliente cliente = (Entidades.Cliente)Session["Cliente"];

                    CUITTextBox.Text = cliente.Cuit;
                    TipoDocDropDownList.SelectedValue = cliente.Documento.Tipo.Id;
                    TipoDocDropDownList_SelectedIndexChanged(TipoDocDropDownList, new EventArgs());
                    if (TipoDocDropDownList.SelectedValue.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
                    {
                        DestinosCuitDropDownList.SelectedValue = cliente.Documento.Nro.ToString();
                    }
                    else
                    {
                        NroDocTextBox.Text = cliente.Documento.Nro.ToString();
                    }
                    RazonSocialTextBox.Text = cliente.RazonSocial;
                    Domicilio.Calle = cliente.Domicilio.Calle;
                    Domicilio.Nro = cliente.Domicilio.Nro;
                    Domicilio.Piso = cliente.Domicilio.Piso;
                    Domicilio.Depto = cliente.Domicilio.Depto;
                    Domicilio.Manzana = cliente.Domicilio.Manzana;
                    Domicilio.Sector = cliente.Domicilio.Sector;
                    Domicilio.Torre = cliente.Domicilio.Torre;
                    Domicilio.Localidad = cliente.Domicilio.Localidad;
                    Domicilio.IdProvincia = cliente.Domicilio.Provincia.Id;
                    cliente.Domicilio.CodPost = Domicilio.CodPost;
                    Contacto.Nombre = cliente.Contacto.Nombre;
                    Contacto.Email = cliente.Contacto.Email;
                    Contacto.Telefono = cliente.Contacto.Telefono;
                    DatosImpositivos.IdCondIVA = cliente.DatosImpositivos.IdCondIVA;
                    DatosImpositivos.IdCondIngBrutos = cliente.DatosImpositivos.IdCondIngBrutos;
                    DatosImpositivos.NroIngBrutos = cliente.DatosImpositivos.NroIngBrutos;
                    DatosImpositivos.FechaInicioActividades = cliente.DatosImpositivos.FechaInicioActividades;
                    DatosIdentificatorios.GLN = cliente.DatosIdentificatorios.GLN;
                    DatosIdentificatorios.CodigoInterno = cliente.DatosIdentificatorios.CodigoInterno;
                    IdClienteTextBox.Text = cliente.IdCliente;
                    EmailAvisoVisualizacionTextBox.Text = cliente.EmailAvisoVisualizacion;
                    PasswordAvisoVisualizacionTextBox.Text = cliente.PasswordAvisoVisualizacion;

                    CUITTextBox.Enabled = false;
                    TipoDocDropDownList.Enabled = false;
                    NroDocTextBox.Enabled = false;
                    DestinosCuitDropDownList.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    IdClienteTextBox.Enabled = false;
                    EmailAvisoVisualizacionTextBox.Enabled = false;
                    PasswordAvisoVisualizacionTextBox.Enabled = false;

                    if (cliente.WF.Estado == "Vigente")
                    {
                        TituloPaginaLabel.Text = "Baja de Cliente";
                        AceptarButton.Text = "Dar de Baja";
                    }
                    else
                    {
                        TituloPaginaLabel.Text = "Anulación de Baja de Cliente";
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
                Entidades.Cliente cliente = (Entidades.Cliente)Session["Cliente"];
                try
                {

                    if (AceptarButton.Text == "Dar de Baja")
                    {
                        RN.Cliente.CambiarEstado(cliente, "DeBaja", sesion);
                    }
                    else
                    {
                        RN.Cliente.CambiarEstado(cliente, "Vigente", sesion);
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
    }
}