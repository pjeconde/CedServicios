using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ArticuloConsultaConFiltros : System.Web.UI.Page
    {
        List<Entidades.Articulo> Articulo = new List<Entidades.Articulo>();

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
                    UnidadDropDownList.DataSource = FeaEntidades.CodigosUnidad.CodigoUnidad.Lista();
                    IndicacionExentoGravadoDropDownList.DataSource = FeaEntidades.Indicacion.Indicacion.Lista();
                    AlicuotaIVADropDownList.DataSource = FeaEntidades.IVA.IVA.Lista();
                    EstadoDropDownList.DataSource = RN.Estado.ListaArticulos(true);
                    DataBind();
                    EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }

        protected void ArticuloPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                Entidades.Sesion sesion = ((Entidades.Sesion)Session["Sesion"]);
                ArticuloPagingGridView.PageIndex = e.NewPageIndex;
                ViewState["GridPageIndex"] = e.NewPageIndex; 
                List<Entidades.Articulo> lista;
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, sesion.Cuit.Nro, IdArticuloTextBox.Text, DescrTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ArticuloPagingGridView.VirtualItemCount = CantidadFilas;
                ArticuloPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                ArticuloPagingGridView.DataSource = lista;
                ArticuloPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                //CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ArticuloPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                Entidades.Sesion sesion = ((Entidades.Sesion)Session["Sesion"]);
                List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, sesion.Cuit.Nro, IdArticuloTextBox.Text, DescrTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ArticuloPagingGridView.DataSource = (List<Entidades.Articulo>)ViewState["lista"];
                ArticuloPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ArticuloPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[6].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        private void DesSeleccionarFilas()
        {
            ArticuloPagingGridView.SelectedIndex = -1;
        }

        protected void ArticuloPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Articulo articulo = new Entidades.Articulo();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Articulo> lista = (List<Entidades.Articulo>)ViewState["lista"];
                articulo = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    //CancelarButton.Text = "Salir";

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

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#DetalleModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DetalleScript", sb.ToString(), false);
                    break;
            }
            bindGrillaArticulo();
        }
        protected void ArticuloPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ArticuloPagingGridView.EditIndex = e.NewEditIndex;
            ArticuloPagingGridView.DataSource = ViewState["lista"];
            ArticuloPagingGridView.DataBind();
        }
        protected void ArticuloPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ArticuloPagingGridView.EditIndex = -1;
            ArticuloPagingGridView.DataSource = ViewState["lista"];
            ArticuloPagingGridView.DataBind();
        }
        protected void ArticuloPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ArticuloPagingGridView.EditIndex = -1;
                ArticuloPagingGridView.DataSource = ViewState["lista"];
                ArticuloPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void ArticuloPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ArticuloPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
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
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, sesion.Cuit.Nro, IdArticuloTextBox.Text, DescrTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ArticuloPagingGridView.VirtualItemCount = CantidadFilas;
                ArticuloPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    ArticuloPagingGridView.DataSource = null;
                    ArticuloPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Artículos que satisfagan la busqueda";
                }
                else
                {
                    ArticuloPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    ArticuloPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }

        private void bindGrillaArticulo()
        {
            ArticuloPagingGridView.PageIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            ArticuloPagingGridView.DataSource = ViewState["lista"];
            ArticuloPagingGridView.DataBind();
        }

    }
}