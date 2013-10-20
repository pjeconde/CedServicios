using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorConfiguracion : System.Web.UI.Page
    {
        List<Entidades.Configuracion> Configuracion = new List<Entidades.Configuracion>();

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
                    DataBind();
                    IdTipoPermisoDropDownList.SelectedValue = String.Empty;
                }
            }
        }

        protected void ConfiguracionPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                ConfiguracionPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Configuracion> lista;
                int CantidadFilas = 0;
                lista = RN.Configuracion.ListaPaging(out CantidadFilas, ConfiguracionPagingGridView.PageIndex, ConfiguracionPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, IdUsuarioTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, IdItemConfigTextBox.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ConfiguracionPagingGridView.VirtualItemCount = CantidadFilas;
                ConfiguracionPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                ConfiguracionPagingGridView.DataSource = lista;
                ConfiguracionPagingGridView.DataBind();
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
        protected void ConfiguracionPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Configuracion> lista = new List<Entidades.Configuracion>();
                int CantidadFilas = 0;
                lista = RN.Configuracion.ListaPaging(out CantidadFilas, ConfiguracionPagingGridView.PageIndex, ConfiguracionPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, IdUsuarioTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, IdItemConfigTextBox.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ConfiguracionPagingGridView.DataSource = (List<Entidades.Configuracion>)ViewState["lista"];
                ConfiguracionPagingGridView.DataBind();
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
        protected void ConfiguracionPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                //if (e.Row.Cells[9].Text != "Vigente")
                //{
                //    e.Row.ForeColor = Color.Red;
                //}
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = ConfiguracionPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            ConfiguracionPagingGridView.SelectedIndex = -1;
        }

        protected void ConfiguracionPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Configuracion Configuracion = new Entidades.Configuracion();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Configuracion> lista = (List<Entidades.Configuracion>)ViewState["lista"];
                Configuracion = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Configuracion"] = Configuracion;
                    //Response.Redirect("~/ConfiguracionConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    CuitLabel.Text = Configuracion.Cuit;
                    IdUNLabel.Text = Configuracion.IdUN.ToString();
                    IdUsuarioLabel.Text = Configuracion.IdUsuario;
                    TipoPermisoIdLabel.Text = Configuracion.TipoPermisoId;
                    TipoPermisoDescrLabel.Text = Configuracion.TipoPermisoDescr;
                    IdItemConfigLabel.Text = Configuracion.IdItemConfig;
                    ValorLabel.Text = Configuracion.Valor;
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
                List<Entidades.Configuracion> lista = new List<Entidades.Configuracion>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Configuracion.ListaPaging(out CantidadFilas, ConfiguracionPagingGridView.PageIndex, ConfiguracionPagingGridView.OrderBy, CuitTextBox.Text, IdUNTextBox.Text, IdUsuarioTextBox.Text, IdTipoPermisoDropDownList.SelectedValue, IdItemConfigTextBox.Text, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ConfiguracionPagingGridView.VirtualItemCount = CantidadFilas;
                ConfiguracionPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    ConfiguracionPagingGridView.DataSource = null;
                    ConfiguracionPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Configuraciones que satisfagan la busqueda";
                }
                else
                {
                    ConfiguracionPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    ConfiguracionPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}