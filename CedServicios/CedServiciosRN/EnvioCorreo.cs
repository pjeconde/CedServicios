using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;

namespace CedServicios.RN
{
    public class EnvioCorreo
    {
        public static void ConfirmacionAltaUsuario(Entidades.Usuario Usuario)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Usuario.Email));
            mail.Subject = "Ahora dispone de una nueva cuenta";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + Usuario.Nombre.Trim() + ":<br />");
            a.Append("<br />");
            a.Append("Gracias por crear su cuenta.<br />");
            a.Append("<br />");
            a.Append("Para confirmar el alta, haga clic en el enlace que aparece a continuación:<br />");
            a.Append("<br />");
            string link = "http://www.cedeira.com.ar/UsuarioConfirmacion.aspx?Id=" + Encryptor.Encrypt(Usuario.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            char c = (char)34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
            a.Append("<br />");
            a.Append("Si no puede acceder a la página, copie la URL y péguela en una ventana nueva del navegador.<br />");
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado la creación de una cuenta, es probable que otro usuario haya introducido su dirección por error al intentar llevar a cabo este proceso. Si no ha solicitado la creación de una cuenta, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("Cedeira Software Factory<br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static void ReporteIdUsuarios(string Email, Entidades.Sesion Sesion)
        {
            DB.Usuario db = new DB.Usuario(Sesion);
            List<Entidades.Usuario> cuentas = db.Lista(Email);

            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Email));
            mail.Subject = "Información de cuenta(s)";
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + cuentas[0].Nombre.Trim() + ":"); a.AppendLine();
            a.AppendLine();
            a.Append("Cumplimos en informarle cuáles son las cuentas vinculadas a este correo electrónico:"); a.AppendLine();
            a.AppendLine();
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Cuenta '" + cuentas[i].Nombre + "' (Id.Usuario='" + cuentas[i].Id + "')"); a.AppendLine();
            }
            a.AppendLine();
            a.Append("Si ha recibido este correo electrónico y no ha solicitado información sobre su(s) cuenta(s), es probable que otro usuario haya introducido su dirección por error. Si no ha solicitado esta información, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad."); a.AppendLine();
            a.Append("Saludos."); a.AppendLine();
            a.AppendLine();
            a.Append("Cedeira Software Factory"); a.AppendLine();
            a.AppendLine();
            a.AppendLine();
            a.AppendLine("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden."); a.AppendLine();
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static void SolicitudAutorizacion(string DescrPermiso, Entidades.Usuario UsuarioSolicitante, List<Entidades.Usuario> Autorizadores)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            string listaAutorizadores = String.Empty;
            for (int i = 0; i < Autorizadores.Count; i++)
            {
                listaAutorizadores += Autorizadores[i].Email;
                if (i != Autorizadores.Count - 1) listaAutorizadores += "; ";
            }
            mail.To.Add(listaAutorizadores);
            mail.CC.Add(new MailAddress(UsuarioSolicitante.Email));
            mail.Subject = "Solicitud de autorización";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a usuario/a:<br />");
            a.Append("<br />");
            a.Append("Se le está solicitando la siguiente autorización:<br />");
            a.Append("<br />");
            a.Append("<hr>");
            a.Append("Permiso: <b>" + DescrPermiso + "</b><br />");
            a.Append("Usuario solicitante: <b>" + UsuarioSolicitante.Nombre + "</b><br />");
            a.Append("<hr>");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("Cedeira Software Factory<br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            a.Append("<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static void RespuestaAutorizacion(Entidades.Permiso Permiso, Entidades.Usuario UsuarioAutorizador)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Permiso.UsuarioSolicitante.Email));
            mail.CC.Add(new MailAddress(UsuarioAutorizador.Email));
            mail.Subject = "Respuesta a la Solicitud de autorización";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a <b>" + Permiso.UsuarioSolicitante.Nombre + "</b>:<br />");
            a.Append("<br />");
            a.Append("El siguiente permiso solicitado ");
            if (Permiso.WF.Estado == "Vigente")
            {
                a.Append("ha sido autorizado.<br />");
            }
            else
            {
                a.Append("ha sido rechazado.<br />");
            }
            a.Append("<br />");
            a.Append("<hr>");
            a.Append("<b>" + RN.Permiso.DescrPermiso(Permiso) + "</b><br />");
            a.Append("<hr>");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("Cedeira Software Factory<br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            a.Append("<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
    }
}
