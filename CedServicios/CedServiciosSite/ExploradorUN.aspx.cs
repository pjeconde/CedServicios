using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorUN : System.Web.UI.Page
    {
        List<Entidades.UN> UN = new List<Entidades.UN>();

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

        protected void UNPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                UNPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.UN> lista;
                int CantidadFilas = 0;
                lista = RN.UN.ListaPaging(out CantidadFilas, UNPagingGridView.PageIndex, UNPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, DescrUNTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                UNPagingGridView.VirtualItemCount = CantidadFilas;
                UNPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                UNPagingGridView.DataSource = lista;
                UNPagingGridView.DataBind();
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
        protected void UNPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.UN> lista = new List<Entidades.UN>();
                int CantidadFilas = 0;
                lista = RN.UN.ListaPaging(out CantidadFilas, UNPagingGridView.PageIndex, UNPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, DescrUNTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UNPagingGridView.DataSource = (List<Entidades.UN>)ViewState["lista"];
                UNPagingGridView.DataBind();
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
        protected void UNPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[4].Text != "Vigente")
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
            UNPagingGridView.SelectedIndex = -1;
        }

        protected void UNPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.UN UN = new Entidades.UN();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.UN> lista = (List<Entidades.UN>)ViewState["lista"];
                UN = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["UN"] = UN;
                    //Response.Redirect("~/UNConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    IdUNLabel.Text = UN.Id.ToString();
                    DescrUNLabel.Text = UN.Descr;
                    CuitLabel.Text = UN.Cuit;
                    EstadoLabel.Text = UN.Estado;
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
                List<Entidades.UN> lista = new List<Entidades.UN>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.UN.ListaPaging(out CantidadFilas, UNPagingGridView.PageIndex, UNPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, DescrUNTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                UNPagingGridView.VirtualItemCount = CantidadFilas;
                UNPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    UNPagingGridView.DataSource = null;
                    UNPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado UNs que satisfagan la busqueda";
                }
                else
                {
                    UNPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    UNPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}