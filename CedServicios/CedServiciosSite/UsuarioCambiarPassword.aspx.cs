using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UsuarioCambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                PasswordTextBox.Focus();
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeLabel.Text = String.Empty;
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
                    RN.Usuario.CambiarPassword(sesion.Usuario, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (Entidades.Sesion)Session["Sesion"]);
                    RN.Sesion.Cerrar(sesion);
                    PasswordTextBox.Enabled = false;
                    PasswordNuevaTextBox.Enabled = false;
                    ConfirmacionPasswordNuevaTextBox.Enabled = false;
                    AceptarButton.Visible = false;
                    CancelarButton.Visible = false;
                    RN.Sesion.Cerrar(sesion);
                    Funciones.PersonalizarControlesMaster(Master, false, sesion);
                    MensajeLabel.Text = "La Contraseña fue cambiada satisfactoriamente.<br />Para seguir trabajando, haga click en 'Ingresar'.";
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Usuario.PasswordNoMatch)
            {
                MensajeLabel.Text = "Contraseña actual incorrecta";
            }
            catch (EX.Usuario.PasswordYConfirmacionNoCoincidente)
            {
                MensajeLabel.Text = "La Contraseña nueva no coincide con su Confirmación";
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