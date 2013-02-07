using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                sesion.Usuario.Id = UsuarioTextBox.Text;
                sesion.Usuario.Password = PasswordTextBox.Text;
                RN.Usuario.Login(sesion.Usuario, (Entidades.Sesion)Session["Sesion"]);
                Response.Redirect("~/Default.aspx");
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Validaciones.ElementoInexistente ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
                UsuarioTextBox.Focus();
            }
            catch (EX.Usuario.LoginRechazadoXPasswordInvalida ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
                PasswordTextBox.Focus();
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void UsuarioTextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
    }
}