using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorArticulo : System.Web.UI.Page
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
                    EstadoDropDownList.DataSource = RN.Estado.Lista(true, sesion);
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
                ArticuloPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Articulo> lista;
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, CuitTextBox.Text, IdArticuloTextBox.Text, DescrArticuloTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ArticuloPagingGridView.VirtualItemCount = CantidadFilas;
                ArticuloPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
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
                List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, CuitTextBox.Text, IdArticuloTextBox.Text, DescrArticuloTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
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
                if (e.Row.Cells[9].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = UNPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            ArticuloPagingGridView.SelectedIndex = -1;
        }

        protected void ArticuloPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Articulo Articulo = new Entidades.Articulo();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Articulo> lista = (List<Entidades.Articulo>)ViewState["lista"];
                Articulo = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Articulo"] = Articulo;
                    //Response.Redirect("~/ArticuloConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    CuitLabel.Text = Articulo.Cuit;
                    IdArticuloLabel.Text = Articulo.Id.ToString();
                    DescrArticuloLabel.Text = Articulo.Descr;
                    IdUnidadLabel.Text = Articulo.Unidad.Id;
                    DescrUnidadLabel.Text = Articulo.Unidad.Descr;
                    IndicacionExentoGravadoLabel.Text = Articulo.IndicacionExentoGravado;
                    AlicuotaIVALabel.Text = Articulo.AlicuotaIVA.ToString();
                    EstadoLabel.Text = Articulo.Estado;
                    ModalPopupExtender1.Show();
                    break;
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
                int CantidadFilas = 0;
                lista = RN.Articulo.ListaPaging(out CantidadFilas, ArticuloPagingGridView.PageIndex, ArticuloPagingGridView.OrderBy, CuitTextBox.Text, IdArticuloTextBox.Text, DescrArticuloTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ArticuloPagingGridView.VirtualItemCount = CantidadFilas;
                ArticuloPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    ArticuloPagingGridView.DataSource = null;
                    ArticuloPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Articulos que satisfagan la busqueda";
                }
                else
                {
                    ArticuloPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    ArticuloPagingGridView.DataBind();
                }
            }
        }
    }
}