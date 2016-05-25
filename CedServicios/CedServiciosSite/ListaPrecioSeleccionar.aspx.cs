using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ListaPrecioSeleccionar : System.Web.UI.Page
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
                            TituloPaginaLabel.Text = "Modificación de Lista de Precios";
                            ViewState["IrA"] = "~/ListaPrecioModificar.aspx";
                            break;
                        case "Baja":
                            TituloPaginaLabel.Text = "Baja/Anul.baja de Lista de Precios";
                            ViewState["IrA"] = "~/ListaPrecioBaja.aspx";
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
                List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
                MensajeLabel.Text = String.Empty;
                if (IdRadioButton.Checked)
                {
                    if (IdTextBox.Text.Equals(String.Empty))
                    {
                        MensajeLabel.Text = IdRadioButton.Text + " no informada";
                        return;
                    }
                    else
                    {
                        lista = RN.ListaPrecio.ListaPorCuityId(sesion.Cuit.Nro, IdTextBox.Text, sesion);
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
                        lista = RN.ListaPrecio.ListaPorCuityDescr(sesion.Cuit.Nro, DescrTextBox.Text, sesion);
                    }
                }
                if (lista.Count == 0)
                {
                    ListasPrecioGridView.DataSource = null;
                    ListasPrecioGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado listas de precios que satisfagan la busqueda";
                }
                else if (lista.Count == 1)
                {
                    Session["ListaPrecio"] = lista[0];
                    Response.Redirect(ViewState["IrA"].ToString());
                }
                else
                {
                    ListasPrecioGridView.DataSource = lista;
                    ViewState["ListaPrecio"] = lista;
                    ListasPrecioGridView.DataBind();
                }
            }
        }
        protected void TipoBusquedaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ListasPrecioGridView.DataSource = null;
            ListasPrecioGridView.DataBind();
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
        protected void ListasPrecioGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.ListaPrecio> lista = (List<Entidades.ListaPrecio>)ViewState["ListaPrecio"];
            Entidades.ListaPrecio listaPrecio = lista[item];
            switch (e.CommandName)
            {
                case "Seleccionar":
                    Session["ListaPrecio"] = listaPrecio;
                    Response.Redirect(ViewState["IrA"].ToString());
                    break;
            }
        }
        protected void ListasPrecioGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}