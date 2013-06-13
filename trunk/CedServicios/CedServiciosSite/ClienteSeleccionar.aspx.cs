using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ClienteSeleccionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string a = HttpContext.Current.Request.Url.Query.ToString().Replace("?", String.Empty);
                    switch (a)
                    {
                        case "Modificar":
                            TituloPaginaLabel.Text = "Modificación de Cliente";
                            ViewState["IrA"] = "~/ClienteModificar.aspx";
                            break;
                        case "Baja":
                            TituloPaginaLabel.Text = "Baja/Anul.baja de Cliente";
                            ViewState["IrA"] = "~/ClienteBaja.aspx";
                            break;
                    }
                    TipoDocDropDownList.DataSource = FeaEntidades.Documentos.Documento.Lista();
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
                        RazonSocialRadioButton.Checked = true;
                        TipoBusquedaRadioButton_CheckedChanged(RazonSocialRadioButton, new EventArgs());
                        RazonSocialTextBox.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
                MensajeLabel.Text = String.Empty;
                if (TipoDocRadioButton.Checked)
                {
                    if (NroDocTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = TipoDocRadioButton.Text + " no informado";
                        return;
                    }
                    else
                    {
                        Entidades.Documento documento = new Entidades.Documento();
                        documento.Tipo.Id = TipoDocDropDownList.SelectedValue.ToString();
                        documento.Nro = Convert.ToInt64(NroDocTextBox.Text);
                        lista = RN.Cliente.ListaPorCuityTipoyNroDoc(sesion.Cuit.Nro, documento, sesion);
                    }
                }
                else if (RazonSocialRadioButton.Checked)
                {
                    if (RazonSocialTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = RazonSocialRadioButton.Text + " no informado";
                        return;
                    }
                    else
                    {
                        lista = RN.Cliente.ListaPorCuityRazonSocial(sesion.Cuit.Nro, RazonSocialTextBox.Text, sesion);
                    }
                }
                else
                {
                    if (IdClienteTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = IdClienteRadioButton.Text + " no informado";
                        return;
                    }
                    else
                    {
                        lista = RN.Cliente.ListaPorCuityIdCliente(sesion.Cuit.Nro, IdClienteTextBox.Text, sesion);
                    }
                }
                if (lista.Count == 0)
                {
                    ClientesGridView.DataSource = null;
                    ClientesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado clientes que satisfagan la busqueda";
                }
                else if (lista.Count == 1)
                {
                    Session["Cliente"] = lista[0];
                    Response.Redirect(ViewState["IrA"].ToString());
                }
                else
                {
                    ClientesGridView.DataSource = lista;
                    ViewState["Clientes"] = lista;
                    ClientesGridView.DataBind();
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ClientesGridView.DataSource = null;
            ClientesGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (TipoDocRadioButton.Checked)
            {
                RazonSocialTextBox.Text = String.Empty;
                IdClienteTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = true;
                NroDocTextBox.Visible = true;
                RazonSocialTextBox.Visible = false;
                IdClienteTextBox.Visible = false;
            }
            else if (RazonSocialRadioButton.Checked)
            {
                NroDocTextBox.Text = String.Empty;
                IdClienteTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = false;
                NroDocTextBox.Visible = false;
                RazonSocialTextBox.Visible = true;
                IdClienteTextBox.Visible = false;
            }
            else
            {
                RazonSocialTextBox.Text = String.Empty;
                NroDocTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = false;
                NroDocTextBox.Visible = false;
                RazonSocialTextBox.Visible = false;
                IdClienteTextBox.Visible = true;
            }
        }
        protected void ClientesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Cliente> lista = (List<Entidades.Cliente>)ViewState["Clientes"];
            Entidades.Cliente cliente = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["Cliente"] = cliente;
                    Response.Redirect(ViewState["IrA"].ToString());
                    break;
            }
        }
        protected void ClientesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
    }
}