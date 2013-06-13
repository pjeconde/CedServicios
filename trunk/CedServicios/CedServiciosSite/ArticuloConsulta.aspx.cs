using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ArticuloConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnidadDropDownList.DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
                IndicacionExentoGravadoDropDownList.DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
                AlicuotaIVADropDownList.DataSource = FeaEntidades.IVA.IVA.Lista();
                DataBind();
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
                    lista = RN.Articulo.ListaPorCuit(false, sesion);
                    ArticulosGridView.DataSource = lista;
                    ViewState["Articulos"] = lista;
                    ArticulosGridView.DataBind();
                    if (lista.Count == 0)
                    {
                        MensajeLabel.Text = "No hay artículos asociados a este CUIT";
                    }
                }
            }
        }
        protected void ArticulosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton verLinkButton = (LinkButton)e.Row.FindControl("VerLinkButton");
                verLinkButton.CommandArgument = e.Row.RowIndex.ToString();
                if (e.Row.Cells[6].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void ArticulosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver" && e.CommandArgument != null)
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Articulo> lista = (List<Entidades.Articulo>)ViewState["Articulos"];
                Entidades.Articulo articulo = lista[rowIndex];

                CUITTextBox.Text = articulo.Cuit;
                IdTextBox.Text = articulo.Id;
                DescrTextBox.Text = articulo.Descr;
                GTINTextBox.Text = articulo.GTIN;
                UnidadDropDownList.SelectedValue = articulo.Unidad.Id;
                IndicacionExentoGravadoDropDownList.SelectedValue = articulo.IndicacionExentoGravado;
                AlicuotaIVADropDownList.SelectedValue = articulo.AlicuotaIVA.ToString();

                CUITTextBox.Enabled = false;
                IdTextBox.Enabled = false;
                DescrTextBox.Enabled = false;
                GTINTextBox.Enabled = false;
                UnidadDropDownList.Enabled = false;
                IndicacionExentoGravadoDropDownList.Enabled = false;
                AlicuotaIVADropDownList.Enabled = false;

                AjaxControlToolkit.ModalPopupExtender modalPopupExtender1 = (AjaxControlToolkit.ModalPopupExtender)ArticulosGridView.Rows[rowIndex].FindControl("ModalPopupExtender1");
                modalPopupExtender1.Show();
            }
        }
    }
}