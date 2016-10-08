using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ArticuloSeleccionar : System.Web.UI.Page
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
                            TituloPaginaLabel.Text = "Modificación de Artículo";
                            ViewState["IrA"] = "~/ArticuloModificar.aspx";
                            break;
                        case "Baja":
                            TituloPaginaLabel.Text = "Baja/Anul.baja de Artículo";
                            ViewState["IrA"] = "~/ArticuloBaja.aspx";
                            break;
                    }
                    if (Funciones.SessionTimeOut(Session))
                    {
                        Response.Redirect("~/SessionTimeout.aspx");
                    }
                    else
                    {
                        Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                        CUITTextBox.Text = sesion.Cuit.Nro;
                        CUITTextBox.Enabled = false;
                        DescrRadioButton.Checked = true;
                        TipoBusquedaRadioButton_CheckedChanged(DescrRadioButton, new EventArgs());
                        DescrTextBox.Focus();
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
                List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
                MensajeLabel.Text = String.Empty;
                if (TodosRadioButton.Checked)
                {
                    lista = RN.Articulo.ListaPorCuit(false, true, sesion);
                }
                else
                {
                    if (IdRadioButton.Checked)
                    {
                        if (IdTextBox.Text.Equals(String.Empty))
                        {
                            MensajeLabel.Text = IdRadioButton.Text + " no informada";
                            return;
                        }
                        else
                        {
                            lista = RN.Articulo.ListaPorCuityId(sesion.Cuit.Nro, IdTextBox.Text, false, sesion);
                        }
                    }
                    else
                    {
                        if (DescrTextBox.Text.Equals(String.Empty))
                        {
                            MensajeLabel.Text = DescrRadioButton.Text + " no informada";
                            return;
                        }
                        else
                        {
                            lista = RN.Articulo.ListaPorCuityDescr(sesion.Cuit.Nro, DescrTextBox.Text, false, sesion);
                        }
                    }
                }
                if (lista.Count == 0)
                {
                    ArticulosGridView.Caption = string.Empty;
                    ArticulosGridView.DataSource = null;
                    ArticulosGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado artículos que satisfagan la busqueda";
                }
                else if (lista.Count == 1)
                {
                    Session["Articulo"] = lista[0];
                    Response.Redirect(ViewState["IrA"].ToString());
                }
                else
                {
                    ArticulosGridView.Caption = "Se encontraron " + lista.Count.ToString() + " Artículos";
                    ArticulosGridView.DataSource = lista;
                    ViewState["Articulo"] = lista;
                    ArticulosGridView.DataBind();
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ArticulosGridView.DataSource = null;
            ArticulosGridView.DataBind();
            MensajeLabel.Text = String.Empty;
            if (IdRadioButton.Checked)
            {
                DescrTextBox.Text = String.Empty;

                IdTextBox.Visible = true;
                DescrTextBox.Visible = false;
            }
            else
            {
                IdTextBox.Text = String.Empty;

                IdTextBox.Visible = false;
                DescrTextBox.Visible = true;
            }
        }
        protected void ArticulosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Articulo> lista = (List<Entidades.Articulo>)ViewState["Articulo"];
            Entidades.Articulo articulo = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["Articulo"] = articulo;
                    Response.Redirect(ViewState["IrA"].ToString());
                    break;
            }
        }
        protected void ArticulosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text != "Vigente")
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
            IdRadioButton.Enabled = FiltradosRadioButton.Checked;
            IdTextBox.Enabled = FiltradosRadioButton.Checked;
            DescrRadioButton.Enabled = FiltradosRadioButton.Checked;
            DescrTextBox.Enabled = FiltradosRadioButton.Checked;
            MensajeLabel.Text = string.Empty;
            ArticulosGridView.Caption = string.Empty;
            ArticulosGridView.DataSource = null;
            ArticulosGridView.DataBind();
        }
    }
}