using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                            break;
                    }
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    CUITTextBox.Text = sesion.Cuit.Nro;
                    CUITTextBox.Enabled = false;
                    DescrRadioButton.Checked = true;
                    TipoBusquedaRadioButton_CheckedChanged(DescrRadioButton, new EventArgs());
                    DescrTextBox.Focus();
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
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
                    lista = RN.Articulo.ListaPorCuityId(sesion.Cuit.Nro, IdRadioButton.Text, sesion);
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
                    lista = RN.Articulo.ListaPorCuityDescr(sesion.Cuit.Nro, DescrTextBox.Text, sesion);
                }
            }
            if (lista.Count == 0)
            {
                ArticulosGridView.DataSource = null;
                ArticulosGridView.DataBind();
                MensajeLabel.Text = "No se han encontrado artículos que satisfagan la busqueda";
            }
            else if (lista.Count == 1)
            {
                Session["Articulo"] = lista[0];
                Response.Redirect("~/ArticuloModificar.aspx");
            }
            else
            {
                ArticulosGridView.DataSource = lista;
                ViewState["Articulo"] = lista;
                ArticulosGridView.DataBind();
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
                    Response.Redirect("~/ArticuloModificar.aspx");
                    break;
            }
        }
    }
}