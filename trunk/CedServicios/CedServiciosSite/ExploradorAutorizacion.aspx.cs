using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ExploradorAutorizacion : System.Web.UI.Page
    {
        List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();
                permisos = RN.Permiso.LeerListaPermisosPteAutoriz(sesion.Usuario, sesion);
                AutorizacionesGridView.DataSource = permisos;
                AutorizacionesGridView.DataBind();
                if (permisos.Count == 0)
                {
                    MensajeLabel.Text = "No hay autorizaciones pendientes";
                }
            }
        }
        protected void AutorizacionesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Autorizar":
                    Confirmar("Autorización", e);
                    break;
                case "Rechazar":
                    Confirmar("Rechazo", e);
                    break;
                default:
                    break;
            }
        }
        private void Confirmar(string Evento, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            Entidades.Permiso permiso = ((List<Entidades.Permiso>)((System.Web.UI.WebControls.GridView)e.CommandSource).DataSource)[item];
            TituloConfirmacionLabel.Text = "Confirmar " + Evento.ToLower();
            AccionLabel.Text = permiso.Accion.Tipo + " nº " + permiso.Accion.Nro;
            if (!permiso.Cuit.Equals(String.Empty))
            {
                CuitLabel.Text = permiso.Cuit;
            }
            else
            {
                CuitLabel.Text = "(no aplica)";
            }
            DescrTipoPermisoLabel.Text = permiso.TipoPermiso.Descr;
            EstadoLabel.Text = permiso.WF.Estado;
            FechaFinVigenciaLabel.Text = permiso.FechaFinVigencia.ToString("dd/MM/yyyy");
            if (permiso.UN.Id != 0)
            {
                UNLabel.Text = permiso.UN.Descr;
            }
            else
            {
                UNLabel.Text = "(no aplica)";
            }
            if (permiso.Usuario.Id != String.Empty)
            {
                UsuarioLabel.Text = permiso.Usuario.Nombre + " (" + permiso.Usuario.Email + ")";
            }
            else
            {
                UsuarioLabel.Text = "(no aplica)";
            }
            UsuarioSolicitanteLabel.Text = permiso.UsuarioSolicitante.Nombre + " (" + permiso.UsuarioSolicitante.Email + ")";
            ViewState["Permiso"] = permiso;
            ViewState["PermisoAccion"] = Evento;
            ModalPopupExtender1.Show();
        }
        protected void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                Entidades.Permiso permiso = (Entidades.Permiso)ViewState["Permiso"];
                string evento = ViewState["PermisoAccion"].ToString();
                switch (evento)
                {
                    case "Autorización":
                        if (RN.Permiso.Autorizar(permiso, sesion))
                            MensajeLabel.Text = "La autorización fué registrada satisfactoriamente.";
                        else
                            MensajeLabel.Text = "Esta solicitud ya no está 'pendiente de autorización'";
                        break;
                    case "Rechazo":
                        if (RN.Permiso.Rechazar(permiso, sesion))
                            MensajeLabel.Text = "El rechazo fué registrado satisfactoriamente.";
                        else
                            MensajeLabel.Text = "Esta solicitud ya no está 'pendiente de autorización'";
                        break;
                }
                ActualizarGrilla();
                Funciones.PersonalizarControlesMaster(Master, true, sesion);
            }
        }
    }
}