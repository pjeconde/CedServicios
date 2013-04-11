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
        bool pendientes = false;
        List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = HttpContext.Current.Request.Url.Query.ToString();
                if (a.ToLower() == "?pendientes")
                {
                    pendientes = true;
                }
                ViewState["ExploradorAutorizacionPendientes"] = pendientes;
            }
            else
            {
                pendientes = Convert.ToBoolean(ViewState["ExploradorAutorizacionPendientes"]);
            }
            if (pendientes)
            {
                TituloPaginaLabel.Text = "Explorador de Autorizaciones pendientes";
            }
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            List<Entidades.Permiso> permiso = new List<Entidades.Permiso>();
            if (pendientes)
            {
                permiso = RN.Permiso.LeerListaPermisosPteAutoriz(sesion.Usuario, sesion);
            }
            else
            {
            }
            AutorizacionesGridView.DataSource = permiso;
            AutorizacionesGridView.DataBind();
            if (permiso.Count == 0)
            {
                MensajeLabel.Text = "No hay autorizaciones";
                if (pendientes) MensajeLabel.Text += " pendientes";
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
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            Entidades.Permiso permiso = (Entidades.Permiso)ViewState["Permiso"];
            string evento = ViewState["PermisoAccion"].ToString();
            switch (evento)
            {
                case "Autorización":
                    RN.Permiso.Autorizar(permiso, sesion);
                    break;
                case "Rechazo":
                    RN.Permiso.Rechazar(permiso, sesion);
                    break;
            }
            ActualizarGrilla();
            Funciones.PersonalizarControlesMaster(Master, true, sesion);
        }
    }
}