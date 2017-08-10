using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class PersonaSeleccionar : System.Web.UI.Page
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
                            TituloPaginaLabel.Text = "Modificación de Persona";
                            ViewState["IrA"] = "~/PersonaModificar.aspx";
                            break;
                        case "Baja":
                            TituloPaginaLabel.Text = "Baja/Anul.baja de Persona";
                            ViewState["IrA"] = "~/PersonaBaja.aspx";
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
                List<Entidades.Persona> lista = new List<Entidades.Persona>();
                MensajeLabel.Text = String.Empty;

                Entidades.Enum.TipoPersona tipoPersona = new Entidades.Enum.TipoPersona();
                if (ClienteRadioButton.Checked) tipoPersona = Entidades.Enum.TipoPersona.Cliente; 
                else if (ProveedorRadioButton.Checked) tipoPersona = Entidades.Enum.TipoPersona.Proveedor; 
                else tipoPersona = Entidades.Enum.TipoPersona.Ambos;

                if (TodosRadioButton.Checked)
                {
                    lista = RN.Persona.ListaPorCuit(false, false, tipoPersona, sesion);
                }
                else
                {
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
                            documento.Nro = NroDocTextBox.Text;
                            lista = RN.Persona.ListaPorCuityTipoyNroDoc(sesion.Cuit.Nro, documento, tipoPersona, sesion);
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
                            lista = RN.Persona.ListaPorCuityRazonSocial(sesion.Cuit.Nro, RazonSocialTextBox.Text, tipoPersona, sesion);
                        }
                    }
                    else
                    {
                        if (IdPersonaTextBox.Text.Equals(String.Empty))
                        {
                            MensajeLabel.Text = IdClienteRadioButton.Text + " no informado";
                            return;
                        }
                        else
                        {
                            lista = RN.Persona.ListaPorCuityIdPersona(sesion.Cuit.Nro, IdPersonaTextBox.Text, tipoPersona, sesion);
                        }
                    }
                }
                if (lista.Count == 0)
                {
                    ClientesGridView.Caption = string.Empty;
                    ClientesGridView.DataSource = null;
                    ClientesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Personas que satisfagan la busqueda";
                }
                else if (lista.Count == 1)
                {
                    Session["Persona"] = lista[0];
                    Response.Redirect(ViewState["IrA"].ToString());
                }
                else
                {
                    ClientesGridView.Caption = "Se encontraron " + lista.Count.ToString() + " Personas";
                    ClientesGridView.DataSource = lista;
                    ViewState["Personas"] = lista;
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
                IdPersonaTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = true;
                NroDocTextBox.Visible = true;
                RazonSocialTextBox.Visible = false;
                IdPersonaTextBox.Visible = false;
            }
            else if (RazonSocialRadioButton.Checked)
            {
                NroDocTextBox.Text = String.Empty;
                IdPersonaTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = false;
                NroDocTextBox.Visible = false;
                RazonSocialTextBox.Visible = true;
                IdPersonaTextBox.Visible = false;
            }
            else
            {
                RazonSocialTextBox.Text = String.Empty;
                NroDocTextBox.Text = String.Empty;

                TipoDocDropDownList.Visible = false;
                NroDocTextBox.Visible = false;
                RazonSocialTextBox.Visible = false;
                IdPersonaTextBox.Visible = true;
            }
        }
        protected void ClientesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Persona> lista = (List<Entidades.Persona>)ViewState["Personas"];
            Entidades.Persona persona = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["Persona"] = persona;
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
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void FiltroButton_CheckedChanged(object sender, EventArgs e)
        {
            TipoDocRadioButton.Enabled = FiltradosRadioButton.Checked;
            RazonSocialRadioButton.Enabled = FiltradosRadioButton.Checked;
            IdClienteRadioButton.Enabled = FiltradosRadioButton.Checked;
            TipoDocDropDownList.Enabled = FiltradosRadioButton.Checked;
            NroDocTextBox.Enabled = FiltradosRadioButton.Checked;
            RazonSocialTextBox.Enabled = FiltradosRadioButton.Checked;
            IdPersonaTextBox.Enabled = FiltradosRadioButton.Checked;
            MensajeLabel.Text = string.Empty;
            ClientesGridView.Caption = string.Empty;
            ClientesGridView.DataSource = null;
            ClientesGridView.DataBind();
        }
    }
}