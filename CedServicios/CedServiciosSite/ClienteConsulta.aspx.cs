using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ClienteConsulta : System.Web.UI.Page
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

                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
                lista = RN.Cliente.ListaPorCuit(sesion);
                ClientesGridView.DataSource = lista;
                ViewState["Clientes"] = lista;
                ClientesGridView.DataBind();
                if (lista.Count == 0)
                {
                    MensajeLabel.Text = "No hay clientes asociados a este CUIT";
                }
            }
        }
        protected void ClientesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton verLinkButton = (LinkButton)e.Row.FindControl("VerLinkButton");
                verLinkButton.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void ClientesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver" && e.CommandArgument != null)
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Cliente> lista = (List<Entidades.Cliente>)ViewState["Clientes"];
                Entidades.Cliente cliente = lista[rowIndex];

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
    }
}