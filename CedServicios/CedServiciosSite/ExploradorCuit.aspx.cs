using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorCuit : System.Web.UI.Page
    {
        List<Entidades.Cuit> cuit = new List<Entidades.Cuit>();

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

        protected void CuitPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                CuitPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Cuit> lista;
                int CantidadFilas = 0;
                lista = RN.Cuit.ListaPaging(out CantidadFilas, CuitPagingGridView.PageIndex, CuitPagingGridView.PageSize, CuitPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                CuitPagingGridView.VirtualItemCount = CantidadFilas;
                ViewState["lista"] = lista;
                CuitPagingGridView.DataSource = lista;
                CuitPagingGridView.DataBind();
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
        protected void CuitPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
                int CantidadFilas = 0;
                lista = RN.Cuit.ListaPaging(out CantidadFilas, CuitPagingGridView.PageIndex, CuitPagingGridView.PageSize, CuitPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                CuitPagingGridView.DataSource = (List<Entidades.Cuit>)ViewState["lista"];
                CuitPagingGridView.DataBind();
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
        protected void CuitPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[11].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = CuitPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            CuitPagingGridView.SelectedIndex = -1;
        }

        protected void CuitPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Cuit cuit = new Entidades.Cuit();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Cuit> lista = (List<Entidades.Cuit>)ViewState["lista"];
                cuit = lista[item];
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
                    NroLabel.Text = cuit.Nro;
                    RazonSocialLabel.Text = cuit.RazonSocial;
                    DomicilioCalleLabel.Text = cuit.Domicilio.Calle;
                    DomicilioNroLabel.Text = cuit.Domicilio.Nro;
                    DomicilioPisoLabel.Text = cuit.Domicilio.Piso;
                    DomicilioDeptoLabel.Text = cuit.Domicilio.Depto;
                    DomicilioLocalidadLabel.Text = cuit.Domicilio.Localidad;
                    DomicilioDescrProvinciaLabel.Text = cuit.Domicilio.Provincia.Descr;
                    DatosImpositivosDescrCondIVALabel.Text = cuit.DatosImpositivos.DescrCondIVA;
                    DatosImpositivosDescrCondIngBrutosLabel.Text = cuit.DatosImpositivos.DescrCondIngBrutos;
                    EstadoLabel.Text = cuit.Estado;
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
                List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Cuit.ListaPaging(out CantidadFilas, CuitPagingGridView.PageIndex, CuitPagingGridView.PageSize, CuitPagingGridView.OrderBy, NroTextBox.Text, RazonSocialTextBox.Text, LocalidadTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                CuitPagingGridView.VirtualItemCount = CantidadFilas;
                if (lista.Count == 0)
                {
                    CuitPagingGridView.DataSource = null;
                    CuitPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Cuits que satisfagan la busqueda";
                }
                else
                {
                    CuitPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    CuitPagingGridView.DataBind();
                }
            }
        }
    }
}