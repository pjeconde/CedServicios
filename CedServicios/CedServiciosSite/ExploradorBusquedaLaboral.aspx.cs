using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorBusquedaLaboral : System.Web.UI.Page
    {
        List<Entidades.BusquedaLaboral> cuit = new List<Entidades.BusquedaLaboral>();

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

        protected void BLPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                BLPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.BusquedaLaboral> lista;
                int CantidadFilas = 0;
                lista = RN.BusquedaLaboral.ListaPaging(out CantidadFilas, BLPagingGridView.PageIndex, BLPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                BLPagingGridView.VirtualItemCount = CantidadFilas;
                BLPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                BLPagingGridView.DataSource = lista;
                BLPagingGridView.DataBind();
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
        protected void BLPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.BusquedaLaboral> lista = new List<Entidades.BusquedaLaboral>();
                int CantidadFilas = 0;
                lista = RN.BusquedaLaboral.ListaPaging(out CantidadFilas, BLPagingGridView.PageIndex, BLPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                BLPagingGridView.DataSource = (List<Entidades.BusquedaLaboral>)ViewState["lista"];
                BLPagingGridView.DataBind();
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
        protected void BLPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[5].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = BLPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            BLPagingGridView.SelectedIndex = -1;
        }

        protected void BLPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.BusquedaLaboral> lista = (List<Entidades.BusquedaLaboral>)ViewState["lista"];
                bl = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Cuit"] = cuit;
                    //Response.Redirect("~/CuitConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    EmailLabel.Text = bl.Email;
                    NombreLabel.Text = bl.NombreArchCV;
                    NombreArchCVLabel.Text = bl.NombreArchCV;
                    IdBusquedaPerfil.Text = bl.BusquedaPerfil.IdBusquedaPerfil;
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
                List<Entidades.BusquedaLaboral> lista = new List<Entidades.BusquedaLaboral>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.BusquedaLaboral.ListaPaging(out CantidadFilas, BLPagingGridView.PageIndex, BLPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                BLPagingGridView.VirtualItemCount = CantidadFilas;
                BLPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    BLPagingGridView.DataSource = null;
                    BLPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Cuits que satisfagan la busqueda";
                }
                else
                {
                    BLPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    BLPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}