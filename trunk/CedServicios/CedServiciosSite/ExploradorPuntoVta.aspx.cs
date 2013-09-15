using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorPuntoVta : System.Web.UI.Page
    {
        List<Entidades.PuntoVta> PuntoVta = new List<Entidades.PuntoVta>();

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

        protected void PuntoVtaPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                PuntoVtaPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.PuntoVta> lista;
                int CantidadFilas = 0;
                lista = RN.PuntoVta.ListaPaging(out CantidadFilas, PuntoVtaPagingGridView.PageIndex, PuntoVtaPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, NroTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                PuntoVtaPagingGridView.VirtualItemCount = CantidadFilas;
                PuntoVtaPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                PuntoVtaPagingGridView.DataSource = lista;
                PuntoVtaPagingGridView.DataBind();
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
        protected void PuntoVtaPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
                int CantidadFilas = 0;
                lista = RN.PuntoVta.ListaPaging(out CantidadFilas, PuntoVtaPagingGridView.PageIndex, PuntoVtaPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, NroTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PuntoVtaPagingGridView.DataSource = (List<Entidades.PuntoVta>)ViewState["lista"];
                PuntoVtaPagingGridView.DataBind();
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
        protected void PuntoVtaPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[8].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = PuntoVtaPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            PuntoVtaPagingGridView.SelectedIndex = -1;
        }

        protected void PuntoVtaPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.PuntoVta PuntoVta = new Entidades.PuntoVta();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.PuntoVta> lista = (List<Entidades.PuntoVta>)ViewState["lista"];
                PuntoVta = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["PuntoVta"] = PuntoVta;
                    //Response.Redirect("~/PuntoVtaConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    CuitLabel.Text = PuntoVta.Cuit;
                    IdUNLabel.Text = PuntoVta.IdUN.ToString();
                    NroLabel.Text = PuntoVta.Nro.ToString();
                    IdTipoPuntoVtaLabel.Text = PuntoVta.IdTipoPuntoVta;
                    UsaSetPropioDeDatosCuitLabel.Text = PuntoVta.UsaSetPropioDeDatosCuit.ToString();
                    IdMetodoGeneracionNumeracionLoteLabel.Text = PuntoVta.IdMetodoGeneracionNumeracionLote;
                    UltNroLoteLabel.Text = PuntoVta.UltNroLote.ToString();
                    EstadoLabel.Text = PuntoVta.Estado;
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
                List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.PuntoVta.ListaPaging(out CantidadFilas, PuntoVtaPagingGridView.PageIndex, PuntoVtaPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, NroTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                PuntoVtaPagingGridView.VirtualItemCount = CantidadFilas;
                PuntoVtaPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    PuntoVtaPagingGridView.DataSource = null;
                    PuntoVtaPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Puntos de Venta que satisfagan la busqueda";
                }
                else
                {
                    PuntoVtaPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    PuntoVtaPagingGridView.DataBind();
                }
            }
        }
    }
}