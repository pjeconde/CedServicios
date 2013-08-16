using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class ExploradorAutorizacionLog : System.Web.UI.Page
    {
        List<Entidades.Permiso> permisos = new List<Entidades.Permiso>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarGrilla();
            }
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
                List<Entidades.PermisoLog> intervencionesAutorizador = RN.PermisoLog.LeerListaIntervencionesDelAutorizador(sesion.Usuario, sesion);
                AutorizacionesGridView.DataSource = intervencionesAutorizador;
                AutorizacionesGridView.DataBind();
                if (intervencionesAutorizador.Count == 0)
                {
                    MensajeLabel.Text = "No hay intervenciones del autorizador";
                }
            }
        }
    }
}