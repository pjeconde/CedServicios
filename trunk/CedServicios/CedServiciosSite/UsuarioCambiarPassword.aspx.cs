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
                try
                {
                    if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == String.Empty)
                    {
                        WebForms.Excepciones.Redireccionar("Opcion", TituloLabel.Text, "~/SoloDispPUsuariosRegistrados.aspx");
                    }
                }
                catch (System.Threading.ThreadAbortException)
                {
                    Trace.Warn("Thread abortado");
                }
                catch (Exception ex)
                {
                    WebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                }
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Usuario.CambiarPassword(sesion.Usuario, PasswordTextBox.Text, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (Entidades.Sesion)Session["Sesion"]);
                RN.Sesion.Cerrar(sesion);
                PasswordTextBox.Enabled = false;
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contraseña fue modificada satisfactoriamente.  Si desea seguir trabajando, deberá volver a identificarse en la página de inicio.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Usuario.PasswordNoMatch)
            {
                MsgErrorLabel.Text = "Contraseña actual incorrecta";
            }
            catch (EX.Usuario.PasswordYConfirmacionNoCoincidente)
            {
                MsgErrorLabel.Text = "La Contraseña nueva no coincide con su Confirmación";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
            }
        }

    }
}