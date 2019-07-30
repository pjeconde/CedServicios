using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorPermiso : System.Web.UI.Page
    {
        List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();

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
                    IdTipoPermisoDropDownList.DataSource = RN.TipoPermiso.Lista(true, sesion);
                    EstadoDropDownList.DataSource = RN.Estado.Lista(true, sesion);
                    DataBind();
                    IdTipoPermisoDropDownList.SelectedValue = String.Empty;
                    EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }
        protected void PermisoPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                PermisoPagingGridView.PageIndex = e.NewPageIndex;
                ViewState["GridPageIndex"] = e.NewPageIndex;
                List<Entidades.Permiso> lista;
                int CantidadFilas = 0;
                lista = RN.Permiso.ListaPaging(out CantidadFilas, PermisoPagingGridView.PageIndex, PermisoPagingGridView.OrderBy, IdUsuarioTextBox.Text, CUITTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, EstadoDropDownList.SelectedValue, VerPermisosDeRadioButtonList.SelectedItem.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                PermisoPagingGridView.VirtualItemCount = CantidadFilas;
                PermisoPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                PermisoPagingGridView.DataSource = lista;
                PermisoPagingGridView.DataBind();
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
        protected void PermisoPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
                int CantidadFilas = 0;
                lista = RN.Permiso.ListaPaging(out CantidadFilas, PermisoPagingGridView.PageIndex, PermisoPagingGridView.OrderBy, IdUsuarioTextBox.Text, CUITTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, EstadoDropDownList.SelectedValue, VerPermisosDeRadioButtonList.SelectedItem.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                PermisoPagingGridView.DataSource = (List<Entidades.Permiso>)ViewState["lista"];
                PermisoPagingGridView.DataBind();
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
        private void DesSeleccionarFilas()
        {
            PermisoPagingGridView.SelectedIndex = -1;
        }
        protected void PermisoPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Permiso permiso = new Entidades.Permiso();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Permiso> lista = (List<Entidades.Permiso>)ViewState["lista"];
                permiso = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "CambiarEstado":
                    if (permiso.WF.Estado == "Vigente" || permiso.WF.Estado == "DeBaja")
                    {
                        TituloConfirmacionLabel.Text = "Confirmar " + (permiso.WF.Estado == "Vigente" ? "Baja" : "Anulación Baja");
                        AccionLabel.Text = permiso.Accion.Tipo + " nº " + permiso.Accion.Nro;
                        CuitLabel.Text = permiso.Cuit;
                        IdTipoPermisoLabel.Text = permiso.TipoPermiso.Id;
                        EstadoLabel.Text = permiso.WF.Estado;
                        FechaFinVigenciaLabel.Text = permiso.FechaFinVigencia.ToString("dd/MM/yyyy");
                        UNLabel.Text = permiso.IdUN.ToString();
                        UsuarioLabel.Text = permiso.Usuario.Id;
                        UsuarioSolicitanteLabel.Text = permiso.UsuarioSolicitante.Id;
                        ViewState["Permiso"] = permiso;
                        ModalPopupExtender1.Show();
                    }
                    else
                    {
                        MensajeLabel.Text = "El cambio de estado sólo puede usarse para Bajas o Anulaciones de bajas.";
                    }
                    break;
            }
            bindGrillaPermiso();
        }
        protected void PermisoPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void CambiarEstadoButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Entidades.Permiso permiso = (Entidades.Permiso)ViewState["Permiso"];
                string idEstadoHst = (permiso.WF.Estado == "Vigente" ? "DeBaja" : "Vigente");
                string idEvento = (idEstadoHst == "Vigente" ? "AnulBaja" : "Baja");
                if (RN.Permiso.CambiarEstado(permiso, idEvento, idEstadoHst, sesion))
                    MensajeLabel.Text = "El cambio de estado se registró satisfactoriamente.";
                else
                    MensajeLabel.Text = "Esta acción no es posible porque la solicitud ya ha cambiado de estado.";
                BuscarButton_Click(BuscarButton, new EventArgs());
                Funciones.PersonalizarControlesMaster(Master, true, sesion);
            }
        }
        protected void PermisoPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PermisoPagingGridView.EditIndex = e.NewEditIndex;
            PermisoPagingGridView.DataSource = ViewState["lista"];
            PermisoPagingGridView.DataBind();
        }
        protected void PermisoPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PermisoPagingGridView.EditIndex = -1;
            PermisoPagingGridView.DataSource = ViewState["lista"];
            PermisoPagingGridView.DataBind();
        }
        protected void PermisoPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                PermisoPagingGridView.EditIndex = -1;
                PermisoPagingGridView.DataSource = ViewState["lista"];
                PermisoPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void PermisoPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void PermisoPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
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
                List<Entidades.Permiso> lista = new List<Entidades.Permiso>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Permiso.ListaPaging(out CantidadFilas, PermisoPagingGridView.PageIndex, PermisoPagingGridView.OrderBy, IdUsuarioTextBox.Text, CUITTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, EstadoDropDownList.SelectedValue, VerPermisosDeRadioButtonList.SelectedItem.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                PermisoPagingGridView.VirtualItemCount = CantidadFilas;
                PermisoPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    PermisoPagingGridView.DataSource = null;
                    PermisoPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Permisos que satisfagan la busqueda";
                }
                else
                {
                    PermisoPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    PermisoPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        private void bindGrillaPermiso()
        {
            PermisoPagingGridView.PageIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            PermisoPagingGridView.DataSource = ViewState["lista"];
            PermisoPagingGridView.DataBind();
        }
    }
}