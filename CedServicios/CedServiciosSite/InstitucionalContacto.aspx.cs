using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InstitucionalContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
            }
        }
        protected void EmpresaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalEmpresa.aspx");
        }
        protected void SolucionesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalSoluciones.aspx");
        }
        protected void RefeComButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InstitucionalRefeCom.aspx");
        }
        protected void NuevaClaveCaptchaButton_Click(object sender, EventArgs e)
        {
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
            Entidades.ContactoSite contacto = new Entidades.ContactoSite();
            if (FactElectronicaRadioButton.Checked)
            {
                contacto.Motivo = "FactElectronica";
            }
            else
            {
                contacto.Motivo = "Otro";
            }
            contacto.Nombre = NombreTextBox.Text;
            contacto.Telefono = TelefonoTextBox.Text;
            contacto.Email = EmailTextBox.Text;
            contacto.Mensaje = MensajeTextBox.Text;
            try
            {
                RN.ContactoSite.Validar(contacto, Session["captcha"].ToString(), CaptchaTextBox.Text);
                RN.ContactoSite.Registrar(contacto);
                EnviarButton.Visible = false;
                BorrarDatosButton.Visible = false;
                NuevaClaveCaptchaButton.Visible = false;
                CaptchaImage.Visible = false;
                ClaveLabel.Visible = false;
                CaptchaTextBox.Visible = false;
                CaseSensitiveLabel.Visible = false;
                FactElectronicaRadioButton.Enabled = false;
                OtrosRadioButton.Enabled = false;
                NombreTextBox.Enabled = false;
                TelefonoTextBox.Enabled = false;
                EmailTextBox.Enabled = false;
                MensajeTextBox.Enabled = false;
                MsgErrorLabel.Text = "Formulario enviado satisfactoriamente";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text =  EX.Funciones.Detalle(ex);
            }
        }
        protected void BorrarDatosButton_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = String.Empty;
            TelefonoTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
            MensajeTextBox.Text = String.Empty;
            MsgErrorLabel.Text = String.Empty;
            Funciones.GenerarImagenCaptcha(Session, CaptchaImage, CaptchaTextBox);
        }
    }
}