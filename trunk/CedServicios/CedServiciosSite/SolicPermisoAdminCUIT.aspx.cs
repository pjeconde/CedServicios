using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class SolicPermisoAdminCUIT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CUITTextBox.Focus();
            }
        }
        protected void SolicitarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cuit cuit = new Entidades.Cuit();
                cuit.Nro = CUITTextBox.Text;
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    if (sesion.UsuarioDemo == true)
                    {
                        Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                    }
                    RN.Cuit.Leer(cuit, sesion);
                    string referenciaAAprobadores = String.Empty;
                    RN.Permiso.SolicitarPermisoParaUsuario(cuit, out referenciaAAprobadores, sesion);
                    CUITTextBox.Enabled = false;
                    SolicitarButton.Enabled = false;
                    SalirButton.Text = "Salir";
                    Funciones.PersonalizarControlesMaster(Master, true, sesion);
                    MensajeLabel.Text = "El permiso fue enviado para su aprobación.<br />Autorizador(es): " + referenciaAAprobadores;
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}