using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.RN
{
    public class EnvioCorreo
    {
        public static string UserSmtp, PsSmtp;

        public static void ConfirmacionAltaUsuario(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Usuario.Email));
            mail.Subject = "Ahora dispone de una nueva cuenta";
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a <b>" + Usuario.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Gracias por crear su cuenta.<br />");
            a.Append("<br />");
            a.Append("Para confirmar el alta, haga clic en el enlace que aparece a continuación:<br />");
            a.Append("<br />");
            string link = Sesion.URLsite + "UsuarioConfirmacion.aspx?Id=" + RN.Funciones.Encriptar(Usuario.Id);
            char c = (char)34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
            a.Append("<br />");
            a.Append("Si no puede acceder a la página, copie la URL y péguela en una ventana nueva del navegador.<br />");
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado la creación de una cuenta, es probable que otro usuario haya introducido su dirección por error al intentar llevar a cabo este proceso. Si no ha solicitado la creación de una cuenta, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>Cedeira Software Factory</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            ObtenerCredencialesSmtp(Sesion);
            smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
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
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a <b>" + cuentas[0].Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Cumplimos en informarle cuáles son las cuentas vinculadas a este correo electrónico:<br />");
            a.Append("<br />");
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Cuenta '" + cuentas[i].Nombre + "' (Id.Usuario='" + cuentas[i].Id + "')<br />");
            }
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado información sobre su(s) cuenta(s), es probable que otro usuario haya introducido su dirección por error. Si no ha solicitado esta información, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>Cedeira Software Factory</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            ObtenerCredencialesSmtp(Sesion);
            smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
            smtpClient.Send(mail);
        }
        public static void SolicitudAutorizacion(Entidades.Permiso Permiso, Entidades.Usuario UsuarioSolicitante, List<Entidades.Usuario> Autorizadores, Entidades.Sesion Sesion)
        {
            for (int i = 0; i < Autorizadores.Count; i++)
            {
                SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
                mail.To.Add(new MailAddress(Autorizadores[i].Email));
                mail.CC.Add(new MailAddress(UsuarioSolicitante.Email));
                mail.Subject = "Solicitud de autorización";
                mail.IsBodyHtml = true;
                StringBuilder a = new StringBuilder();
                a.Append("Estimado/a " + Autorizadores[i].Nombre + ":<br />");
                a.Append("<br />");
                a.Append("Se le está solicitando la siguiente autorización:<br />");
                a.Append("<br />");
                a.Append("<hr>");
                a.Append("Permiso: <b>" + RN.Permiso.DescrPermiso(Permiso) + "</b><br />");
                a.Append("Usuario solicitante: <b>" + UsuarioSolicitante.Nombre + "</b><br />");
                a.Append("<hr>");
                a.Append("<br />");
                a.Append("Para responder a esta solicitud, haga clic en el enlace que aparece a continuación:<br />");
                a.Append("<br />");
                string delim = "<<<>>>";
                string parametros = UsuarioSolicitante.Id + delim + Permiso.Cuit + delim + Permiso.IdUN + delim + Permiso.TipoPermiso.Id + delim + Autorizadores[i].Id;
                string link = Sesion.URLsite + "Autorizacion.aspx?" + RN.Funciones.Encriptar(parametros);
                char c = (char)34;
                a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
                a.Append("<br />");
                a.Append("<br />");
                a.Append("Saludos.<br />");
                a.Append("<br />");
                a.Append("<b>Cedeira Software Factory</b><br />");
                a.Append("<br />");
                a.Append("<br />");
                a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
                a.Append("<br />");
                mail.Body = a.ToString();
                ObtenerCredencialesSmtp(Sesion);
                smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
                smtpClient.Send(mail);
            }
        }
        public static void RespuestaAutorizacion(Entidades.Permiso Permiso, Entidades.Usuario UsuarioAutorizador, Entidades.Sesion Sesion)
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
            a.Append("<b>Cedeira Software Factory</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            a.Append("<br />");
            mail.Body = a.ToString();
            ObtenerCredencialesSmtp(Sesion);
            smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
            smtpClient.Send(mail);
        }
        public static void ContactoSite(Entidades.ContactoSite ContactoSite, string CuentaMailCedeira)
        {
            StringBuilder a;
            //Mail para Cedeira
            SmtpClient smtpClient2Cedeira = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail2Cedeira = new MailMessage();
            mail2Cedeira.From = new MailAddress("contacto@cedeira.com.ar");
            mail2Cedeira.To.Add(new MailAddress(CuentaMailCedeira));
            mail2Cedeira.Subject = "Formulario electrónico (Contacto de cedeira.com.ar)";
            mail2Cedeira.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Los siguientes, son los datos del nuevo contacto");
            if (ContactoSite.Motivo == "FactElectronica") a.Append(" (por el tema de FACTURA ELECTRONICA)");
            a.Append(":<br />");
            a.Append("<br />");
            a.Append("Nombre: " + ContactoSite.Nombre + "<br />");
            a.Append("Telefono: " + ContactoSite.Telefono + "<br />");
            a.Append("Email: " + ContactoSite.Email + "<br />");
            a.Append("Mensaje:<br />");
            a.Append("------------------------------------------------<br />");
            a.Append(ContactoSite.Mensaje + "<br />");
            a.Append("------------------------------------------------<br />");
            mail2Cedeira.Body = a.ToString();
            smtpClient2Cedeira.Credentials = new NetworkCredential("contacto@cedeira.com.ar", "123QWEasdZXC");
            smtpClient2Cedeira.Send(mail2Cedeira);

            //Mail para el Contacto
            SmtpClient smtpClient2Contacto = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail2Contacto = new MailMessage();
            mail2Contacto.From = new MailAddress(CuentaMailCedeira);
            mail2Contacto.To.Add(new MailAddress(ContactoSite.Email));
            mail2Contacto.Subject = "Acuse de recibo de Formulario electrónico";
            mail2Contacto.IsBodyHtml = true;
            a = new StringBuilder();
            a.Append("Estimado/a <b>" + ContactoSite.Nombre.Trim() + "</b>:<br />");
            a.Append("<br />");
            a.Append("Gracias por comunicarse con nosotros.<br />");
            if (ContactoSite.Motivo == "FactElectronica")
            {
                a.Append("Su consulta, sobre el tema de Factura Electrónica, será respondida a la brevedad.<br />");
            }
            else
            {
                a.Append("Su consulta será respondida a la brevedad.<br />");
            }
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("<b>Cedeira Software Factory</b><br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail2Contacto.Body = a.ToString();
            smtpClient2Contacto.Credentials = new NetworkCredential("contacto@cedeira.com.ar", "123QWEasdZXC");
            smtpClient2Contacto.Send(mail2Contacto);
        }
        public static void ReporteActividad(DateTime FechaDsd, DateTime FechaHst, Entidades.Sesion Sesion)
        {
            DB.ReporteActividad dbReporteActividad = new DB.ReporteActividad(Sesion);
            List<Entidades.ReporteActividad> estadistica = dbReporteActividad.Estadistica(FechaDsd, FechaHst);

            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Sesion.AdministradoresSiteEmail));
            if (Sesion.Ambiente != "PROD")
            {
                mail.Subject = "Reporte de actividad (" + Sesion.Ambiente + ")";
            }
            else
            {
                mail.Subject = "Reporte de actividad";
            }
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Periodo: del " + FechaDsd.ToString("dd/MM/yyyy") + " al " + FechaHst.ToString("dd/MM/yyyy") + ".");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("<table border=1 cellspacing=0 cellpadding=2>");
            a.Append("    <tr style=\"font-weight:bold\" align=\"center\">");
            a.Append("        <td>");
            a.Append("            Entidad");
            a.Append("        </td>");
            a.Append("        <td>");
            a.Append("            Evento");
            a.Append("        </td>");
            a.Append("        <td>");
            a.Append("            Estado");
            a.Append("        </td>");
            a.Append("        <td>");
            a.Append("            Cantidad");
            a.Append("        </td>");
            a.Append("    </tr>");
            for (int i = 0; i < estadistica.Count; i++)
            {
                a.Append("    <tr>");
                a.Append("        <td>");
                a.Append("            ");
                if (i == 0 || estadistica[i].DescrEntidad != estadistica[i - 1].DescrEntidad)
                {
                    a.Append(estadistica[i].DescrEntidad);
                }
                a.Append("        </td>");
                a.Append("        <td>");
                a.Append("            " + estadistica[i].Evento);
                a.Append("        </td>");
                a.Append("        <td>");
                a.Append("            " + estadistica[i].Estado);
                a.Append("        </td>");
                a.Append("        <td align=\"right\">");
                a.Append("            " + estadistica[i].Cantidad.ToString());
                a.Append("        </td>");
                a.Append("    </tr>");
            }
            a.Append("</table>");
            a.Append("<br />");
            a.Append("<b>Cedeira Software Factory</b><br />");
            a.Append("<br />");
            mail.Body = a.ToString();
            ObtenerCredencialesSmtp(Sesion);
            smtpClient.Credentials = new NetworkCredential(UserSmtp, PsSmtp);
            smtpClient.Send(mail);
        }
        public static void AvisoGeneracionComprobante(Entidades.Persona Persona, Entidades.Comprobante Contrato, Entidades.Comprobante Comprobante, FeaEntidades.InterFacturas.lote_comprobantes Lote, string ArchivoPDF, string LogoPath, Entidades.Sesion Sesion)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Persona.DatosEmailAvisoComprobantePersona.De);
            string[] para = Contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Para.Split(',');
            for (int i = 0; i < para.Length; i++)
            {
                if (para[i].Trim() != string.Empty) mail.To.Add(new MailAddress(para[i].Trim()));
            }
            string[] cc = Contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Cc.Split(',');
            for (int i = 0; i < cc.Length; i++)
            {
                if (cc[i].Trim() != string.Empty) mail.CC.Add(new MailAddress(cc[i].Trim()));
            }
            if (Persona.DatosEmailAvisoComprobantePersona.Cco.Trim() != string.Empty)
            {
                string[] cco = Persona.DatosEmailAvisoComprobantePersona.Cco.Split(',');
                for (int i = 0; i < cco.Length; i++)
                {
                    if (cco[i].Trim() != string.Empty) mail.Bcc.Add(new MailAddress(cco[i].Trim()));
                }
                //mail.Bcc.Add(new MailAddress(Persona.DatosEmailAvisoComprobantePersona.Cco)); 
            }
            if (Sesion.Ambiente != "PROD")
            {
                mail.Subject = TratamientoPalabrasReservadas(Contrato.DatosEmailAvisoComprobanteContrato.Asunto, Comprobante, Lote, LogoPath, false) + " (" + Sesion.Ambiente + ")";
            }
            else
            {
                mail.Subject = TratamientoPalabrasReservadas(Contrato.DatosEmailAvisoComprobanteContrato.Asunto, Comprobante, Lote, LogoPath, false);
            }
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append(TratamientoPalabrasReservadas(Contrato.DatosEmailAvisoComprobanteContrato.Cuerpo, Comprobante, Lote, LogoPath, true));

            ////Create two views, one text, one HTML.
            //var htmlView = AlternateView.CreateAlternateViewFromString(a.ToString(), null, "text/html");
            ////Add image to HTML version
            //var imageResource = new LinkedResource(HttpContext.Current.Server.MapPath("~/Imagenes/CedeiraSF_v1.jpg"), System.Net.Mime.MediaTypeNames.Image.Jpeg)
            //    {
            //        ContentId = "LogoImage"
            //    };
            //htmlView.LinkedResources.Add(imageResource);
            //mail.AlternateViews.Add(htmlView);
            
            mail.Body = a.ToString();
            mail.Attachments.Add(new Attachment(ArchivoPDF));
            ObtenerCredencialesSmtp(Sesion);
            smtpClient.Credentials = new NetworkCredential(UserSmtp,PsSmtp);
            smtpClient.Send(mail);
        }
        private static string TratamientoPalabrasReservadas(string Cuerpo, Entidades.Comprobante Comprobante, FeaEntidades.InterFacturas.lote_comprobantes Lote, string LogoPath, bool Negritas)
        {
            string negritasDsd = "<b>";
            string negritasHst = "</b>";
            if (!Negritas)
            {
                negritasDsd = string.Empty;
                negritasHst = string.Empty;
            }
            string a = Cuerpo.Replace("\r\n", "<br />");
            a = a.Replace("@RAZONSOCIAL", negritasDsd + Comprobante.RazonSocial + negritasHst);
            a = a.Replace("@TIPOYNROCOMPROBANTE", Comprobante.TipoComprobante.Descr.Replace("s ", " ") + " Nº " + Comprobante.NroPuntoVta.ToString("0000") + "-" + negritasDsd + Comprobante.Nro.ToString("00000000") + negritasHst);
            a = a.Replace("@MONEDAEIMPORTETOTAL", negritasDsd + Comprobante.Moneda.Replace("PES", "$").Replace("DOL", "u$s") + " " + Comprobante.Importe.ToString("N2", new System.Globalization.CultureInfo("es-AR")) + negritasHst);
            try
            {
                a = a.Replace("@PERIODODELSERVICIO", "del " + negritasDsd + DateTime.ParseExact(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy") + negritasHst + " al " + negritasDsd + DateTime.ParseExact(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy") + negritasHst);
                string mesDelServicio = DateTime.ParseExact(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("MMMM yyyy", new System.Globalization.CultureInfo("es-AR")).Replace(" ", " de ");
                mesDelServicio = mesDelServicio.Substring(0, 1).ToUpper() + mesDelServicio.Substring(1, mesDelServicio.Length - 1);
                a = a.Replace("@MESDELSERVICIO", negritasDsd + mesDelServicio + negritasHst);
            }
            catch {}
            a = a.Replace("@FECHAVTO", negritasDsd + Comprobante.FechaVto.ToString("dd/MM/yyyy") + negritasHst);
            a = a.Replace("@TAB", "&emsp;");
            //a = a + "<br />" + "<image src='cid:LogoImage' alt='logo' />";
            return a;
        }
        public static void Prueba(string Para)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Para));
            mail.Subject = "Prueba de envio de mail";
            mail.IsBodyHtml = true;
            mail.Body = "Prueba de envio de mail";
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "q7]?9X_IpuJb");
            smtpClient.Send(mail);
        }

        public static void ObtenerCredencialesSmtp(Entidades.Sesion Sesion)
        {
            DB.Parametro credenciales = new DB.Parametro(Sesion);

            UserSmtp = credenciales.ObtenerUsuarioSmtp();
            PsSmtp = credenciales.ObtenerContraseñaSmtp();
        }

    }
}