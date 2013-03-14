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
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            if (pendientes)
            {
                TituloPaginaLabel.Text = "Explorador de Autorizaciones pendientes";
                AutorizacionesGridView.DataSource = RN.Permiso.LeerListaPermisosPteAutoriz(sesion.Usuario, sesion);
                AutorizacionesGridView.DataBind();
            }
        }
        protected void AutorizacionesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                MensajeLabel.Text = "Procesar renglon " + e.CommandArgument.ToString();
            }
        }
    }
}