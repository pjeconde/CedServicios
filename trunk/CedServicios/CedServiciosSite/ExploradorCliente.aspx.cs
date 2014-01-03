using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorCliente : System.Web.UI.Page
    {
        List<Entidades.Cliente> cliente = new List<Entidades.Cliente>();

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

        protected void ClientePagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                ClientePagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Cliente> lista;
                int CantidadFilas = 0;
                lista = RN.Cliente.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, CUITTextBox.Text, RazSocTextBox.Text, NroDocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ClientePagingGridView.VirtualItemCount = CantidadFilas;
                ClientePagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                ClientePagingGridView.DataSource = lista;
                ClientePagingGridView.DataBind();
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
        protected void ClientePagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
                int CantidadFilas = 0;
                lista = RN.Cliente.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, CUITTextBox.Text, RazSocTextBox.Text, NroDocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ClientePagingGridView.DataSource = (List<Entidades.Cliente>)ViewState["lista"];
                ClientePagingGridView.DataBind();
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
        protected void ClientePagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[14].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = ClientePagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            ClientePagingGridView.SelectedIndex = -1;
        }

        protected void ClientePagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Cliente cliente = new Entidades.Cliente();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Cliente> lista = (List<Entidades.Cliente>)ViewState["lista"];
                cliente = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Cliente"] = uliente;
                    //Response.Redirect("~/UsuarioConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    CUITLabel.Text = cliente.Cuit;
                    TipoDocLabel.Text = cliente.DocumentoIdTipoDoc;
                    NroDocLabel.Text = cliente.DocumentoNro.ToString();
                    RazSocLabel.Text = cliente.RazonSocial;
                    CalleLabel.Text = cliente.Domicilio.Calle;
                    NroLabel.Text = cliente.Domicilio.Nro;
                    PisoLabel.Text = cliente.Domicilio.Piso;
                    DeptoLabel.Text = cliente.Domicilio.Depto;
                    LocalidadLabel.Text = cliente.Domicilio.Localidad;
                    CodPostLabel.Text = cliente.Domicilio.CodPost;
                    EstadoLabel.Text = cliente.Estado;
                    ModalPopupExtender1.Show();
                    break;
            }
        }
        protected void ClientePagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClientePagingGridView.EditIndex = e.NewEditIndex;
            ClientePagingGridView.DataSource = ViewState["lista"];
            ClientePagingGridView.DataBind();
        }
        protected void ClientePagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClientePagingGridView.EditIndex = -1;
            ClientePagingGridView.DataSource = ViewState["lista"];
            ClientePagingGridView.DataBind();
        }
        protected void ClientePagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ClientePagingGridView.EditIndex = -1;
                ClientePagingGridView.DataSource = ViewState["lista"];
                ClientePagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>alert('" + ex.Message.ToString().Replace("'", "") + "');</SCRIPT>", false);
            }
        }
        protected void ClientePagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ClientePagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
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
                List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Cliente.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, CUITTextBox.Text, RazSocTextBox.Text, NroDocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ClientePagingGridView.VirtualItemCount = CantidadFilas;
                ClientePagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    ClientePagingGridView.DataSource = null;
                    ClientePagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Clientes que satisfagan la busqueda";
                }
                else
                {
                    ClientePagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    ClientePagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}