using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CedServicios.RN
{
    public class EnvioSMS
    {
        public static string UserSmtp, PsSmtp;
        public static void Enviar(string Asunto, string Mensaje, List<Entidades.Usuario> Destinatarios, Entidades.Sesion Sesion)
        {
            if (Destinatarios.Count > 0)
            {
                SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
                for (int i = 0; i < Destinatarios.Count; i++)
                {
                    mail.To.Add(new MailAddress(Destinatarios[i].EmailSMS));
                }
                mail.Subject = Asunto;
                mail.Body = Mensaje;
                EnvioCorreo.ObtenerCredencialesSmtp(Sesion);
                smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
                smtpClient.Send(mail);
            }
        }
    }
}