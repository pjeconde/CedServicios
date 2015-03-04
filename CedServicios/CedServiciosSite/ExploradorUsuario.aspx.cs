using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorUsuario : System.Web.UI.Page
    {
        List<Entidades.Usuario> usuario = new List<Entidades.Usuario>();

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

        protected void UsuarioPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                UsuarioPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Usuario> lista;
                int CantidadFilas = 0;
                lista = RN.Usuario.ListaPaging(out CantidadFilas, UsuarioPagingGridView.PageIndex, UsuarioPagingGridView.OrderBy, IdUsuarioTextBox.Text, NombreTextBox.Text, EmailTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                UsuarioPagingGridView.VirtualItemCount = CantidadFilas;
                UsuarioPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                UsuarioPagingGridView.DataSource = lista;
                UsuarioPagingGridView.DataBind();
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
        protected void UsuarioPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
                int CantidadFilas = 0;
                lista = RN.Usuario.ListaPaging(out CantidadFilas, UsuarioPagingGridView.PageIndex, UsuarioPagingGridView.OrderBy, IdUsuarioTextBox.Text, NombreTextBox.Text, EmailTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                UsuarioPagingGridView.DataSource = (List<Entidades.Usuario>)ViewState["lista"];
                UsuarioPagingGridView.DataBind();
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
        protected void UsuarioPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
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
                //    ddlB.SelectedValue = UsuarioPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            UsuarioPagingGridView.SelectedIndex = -1;
        }

        protected void UsuarioPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Usuario usuario = new Entidades.Usuario();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Usuario> lista = (List<Entidades.Usuario>)ViewState["lista"];
                usuario = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Usuario"] = usuario;
                    //Response.Redirect("~/UsuarioConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CambiarEstadoButton.Visible = false;
                    CancelarButton.Text = "Salir";
                    IdUsuarioLabel.Text = usuario.Id;
                    NombreLabel.Text = usuario.Nombre;
                    TelefonoLabel.Text = usuario.Telefono;
                    EmailLabel.Text = usuario.Email;
                    PreguntaLabel.Text = usuario.Pregunta;
                    RespuestaLabel.Text = usuario.Respuesta;
                    PasswordLabel.Text = usuario.Password;
                    EstadoLabel.Text = usuario.Estado;
                    ModalPopupExtender1.Show();
                    break;
                case "CambiarEstado":
                    TituloConfirmacionLabel.Text = "Confirmar " + (usuario.WF.Estado == "Vigente" ? "Baja" : "Anulación Baja");
                    CambiarEstadoButton.Visible = true;
                    ReenviarEmailButton.Visible = false;
                    CancelarButton.Text = "Cancelar";

                    IdUsuarioLabel.Text = usuario.Id;
                    NombreLabel.Text = usuario.Nombre;
                    TelefonoLabel.Text = usuario.Telefono;
                    EmailLabel.Text = usuario.Email;
                    PreguntaLabel.Text = usuario.Pregunta;
                    RespuestaLabel.Text = usuario.Respuesta;
                    EstadoLabel.Text = usuario.Estado;
                    ViewState["Usuario"] = usuario;
                    ModalPopupExtender1.Show();
                    break;
                case "ReenviarEmail":
                    TituloConfirmacionLabel.Text = "Confirmar el reenvio de email";
                    CambiarEstadoButton.Visible = false;
                    ReenviarEmailButton.Visible = true;
                    CancelarButton.Text = "Cancelar";

                    IdUsuarioLabel.Text = usuario.Id;
                    NombreLabel.Text = usuario.Nombre;
                    TelefonoLabel.Text = usuario.Telefono;
                    EmailLabel.Text = usuario.Email;
                    PreguntaLabel.Text = usuario.Pregunta;
                    RespuestaLabel.Text = usuario.Respuesta;
                    EstadoLabel.Text = usuario.Estado;
                    ViewState["Usuario"] = usuario;
                    ModalPopupExtender1.Show();
                    break;
            }
        }
        protected void UsuarioPagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UsuarioPagingGridView.EditIndex = e.NewEditIndex;
            UsuarioPagingGridView.DataSource = ViewState["lista"];
            UsuarioPagingGridView.DataBind();
        }
        protected void UsuarioPagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UsuarioPagingGridView.EditIndex = -1;
            UsuarioPagingGridView.DataSource = ViewState["lista"];
            UsuarioPagingGridView.DataBind();
        }
        protected void UsuarioPagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //List<Entidades.Usuario> usuarios = ((List<Entidades.Usuario>)ViewState["lista"]);
                //Entidades.Usuario usuarioActual = RN.Usuario.ObtenerCopia(usuarios[e.RowIndex]);
                //Entidades.Usuario usuario = usuarios[e.RowIndex];

                //string a = ((TextBox)UsuarioPagingGridView.Rows[e.RowIndex].FindControl("a")).Text;
                //usuario.A = a;
                //string b = ((DropDownList)UsuarioPagingGridView.Rows[e.RowIndex].FindControl("ddlB")).SelectedValue;
                //if (b != string.Empty)
                //{
                //    usuario.B = b;
                //}
                //else
                //{
                //    throw new Exception("Debe informar B. No puede estar vacío.");
                //}

                //RN.Usuario.Modificar(usuarioActual, usuario, (Entidades.Sesion)Session["Sesion"]);
                UsuarioPagingGridView.EditIndex = -1;
                UsuarioPagingGridView.DataSource = ViewState["lista"];
                UsuarioPagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", RN.Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void UsuarioPagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void UsuarioPagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }
        protected void ReenviarEmailButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            try
            {
                Entidades.Usuario usr = (Entidades.Usuario)ViewState["Usuario"];
                if (usr.Estado != "PteConf")
                {
                    MensajeLabel.Text = "Solamente puede reenviar mail a los usuarios que se encuentran pendientes de confirmación.";
                    return;
                }
                RN.Usuario.ReenviarMail(usr, (Entidades.Sesion)Session["Sesion"]);
                UsuarioPagingGridView.DataBind();
                DesSeleccionarFilas();
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = ex.Message;
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
                //Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                //Entidades.Usuario usuario = (Entidades.Usuario)ViewState["Usuario"];
                //string idEstadoHst = (usuario.WF.Estado == "Vigente" ? "DeBaja" : "Vigente");
                //string idEvento = (idEstadoHst == "Vigente" ? "AnulBaja" : "Baja");
                //RN.Usuario.CambiarEstado(usuario, idEvento, idEstadoHst, sesion);
                //BuscarButton_Click(BuscarButton, new EventArgs());
                //Funciones.PersonalizarControlesMaster(Master, true, sesion);
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
                List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Usuario.ListaPaging(out CantidadFilas, UsuarioPagingGridView.PageIndex, UsuarioPagingGridView.OrderBy, IdUsuarioTextBox.Text, NombreTextBox.Text, EmailTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                UsuarioPagingGridView.VirtualItemCount = CantidadFilas;
                UsuarioPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    UsuarioPagingGridView.DataSource = null;
                    UsuarioPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Usuarios que satisfagan la busqueda";
                }
                else
                {
                    UsuarioPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    UsuarioPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}