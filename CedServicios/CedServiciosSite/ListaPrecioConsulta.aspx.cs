using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ListaPrecioConsulta : System.Web.UI.Page
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
                    List<Entidades.ListaPrecio> lista = new List<Entidades.ListaPrecio>();
                    lista = RN.ListaPrecio.ListaPorCuit(false, false, false, sesion);
                    ListasPrecioGridView.DataSource = lista;
                    ViewState["ListasPrecio"] = lista;
                    ListasPrecioGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        MensajeLabel.Text = "No hay listas de precios asociados a este CUIT";
                    }
                }
            }
        }
        protected void ListasPrecioGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton verLinkButton = (LinkButton)e.Row.FindControl("VerLinkButton");
                verLinkButton.CommandArgument = e.Row.RowIndex.ToString();
                if (e.Row.Cells[3].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void ListasPrecioGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver" && e.CommandArgument != null)
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Entidades.ListaPrecio> lista = (List<Entidades.ListaPrecio>)ViewState["ListasPrecio"];
                Entidades.ListaPrecio listaPrecio = lista[rowIndex];

                CUITTextBox.Text = listaPrecio.Cuit;
                IdTextBox.Text = listaPrecio.Id;
                DescrTextBox.Text = listaPrecio.Descr;
                OrdenTextBox.Text = listaPrecio.Orden.ToString();

                CUITTextBox.Enabled = false;
                IdTextBox.Enabled = false;
                DescrTextBox.Enabled = false;
                OrdenTextBox.Enabled = false;

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ShowModalListaPrecio();", true);

                //AjaxControlToolkit.ModalPopupExtender modalPopupExtender1 = (AjaxControlToolkit.ModalPopupExtender)ListasPrecioGridView.Rows[rowIndex].FindControl("ModalPopupExtender1");
                //modalPopupExtender1.Show();
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}