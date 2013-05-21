using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;

namespace CedServicios.Site
{
    public partial class UsuarioCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBox.Attributes.Add("value", PasswordTextBox.Text);
            ConfirmacionPasswordTextBox.Attributes.Add("value", ConfirmacionPasswordTextBox.Text);
            if (!IsPostBack)
            {
                NombreTextBox.Focus();
                try
                {
                    Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
                    CondicionesTextBox.Text = RN.Usuario.TerminosYCondiciones().Replace("<br />", Environment.NewLine);
                }
                catch (Exception ex)
                {
                    WebForms.Excepciones.Redireccionar(ex, "~/NotificacionDeExcepcion.aspx");
                }
            }
        }
        protected void CrearCuentaButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            ResultadoComprobarDisponibilidadLabel.Text = String.Empty;
            Entidades.Usuario usuario = new Entidades.Usuario();
            usuario.Nombre = NombreTextBox.Text;
            usuario.Telefono = TelefonoTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Id = IdUsuarioTextBox.Text;
            usuario.Password = PasswordTextBox.Text;
            usuario.Pregunta = PreguntaTextBox.Text;
            usuario.Respuesta = RespuestaTextBox.Text;
            try
            {
                RN.Usuario.Validar(usuario, ConfirmacionPasswordTextBox.Text, Session["captcha"].ToString(), CaptchaTextBox.Text, (Entidades.Sesion)Session["Sesion"]);
                RN.Usuario.Registrar(usuario, true, (Entidades.Sesion)Session["Sesion"]);
                ComprobarDisponibilidadButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CrearCuentaButton.Visible = false;
                CancelarButton.Visible = false;
                CrearCuentaLabel.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                IdUsuarioTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                ConfirmacionPasswordTextBox.Enabled = false;
                PreguntaTextBox.Enabled = false;
                RespuestaTextBox.Enabled = false;
                MensajeLabel.Text = "Gracias por crear su cuenta.<br />Siga las instrucciones, que se enviaron por email, para confirmar la creación de su cuenta.<br />La recepción del email puede demorar unos minutos.";
            }
            catch (Exception ex)
            {
                string a = EX.Funciones.Detalle(ex);
                MensajeLabel.Text = a;
            }
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
        protected void ComprobarDisponibilidadButton_Click(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            Entidades.Usuario usuario = new Entidades.Usuario();
            usuario.Id = IdUsuarioTextBox.Text;
            try
            {
                bool disponible = RN.Usuario.IdCuentaDisponible(usuario, (Entidades.Sesion)Session["Sesion"]);
                if (disponible)
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Green;
                    ResultadoComprobarDisponibilidadLabel.Text = "OK";
                }
                else
                {
                    ResultadoComprobarDisponibilidadLabel.ForeColor = System.Drawing.Color.Red;
                    ResultadoComprobarDisponibilidadLabel.Text = "No disponible";
                }
            }
            catch (EX.Validaciones.ValorNoInfo)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MensajeLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "IdUsuario no informado";
            }
            catch (Exception ex)
            {
                ResultadoComprobarDisponibilidadLabel.ForeColor = MensajeLabel.ForeColor;
                ResultadoComprobarDisponibilidadLabel.Text = "ver detalle al pie de página";
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
    }
}