using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;

namespace CedServicios.RN
{
    public class Usuario
    {
        public static void Leer(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Usuario db = new  DB.Usuario(Sesion);
            db.Leer(Usuario);
        }
        public static void Login(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            if (Usuario.Id == String.Empty)
            {
                throw new CedServicios.EX.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                if (Usuario.Password == String.Empty)
                {
                    throw new CedServicios.EX.Validaciones.ValorNoInfo("Contraseña");
                }
                else
                {
                    string passwordIngresada = Usuario.Password;
                    Leer(Usuario, Sesion);
                    if (passwordIngresada != Usuario.Password)
                    {
                        throw new CedServicios.EX.Usuario.LoginRechazadoXPasswordInvalida();
                    }
                    //Se impide el login a cuenta pendientes de confirmacion o dadas de baja
                    //(las cuentas "Prem" suspendidas se comportan como cuentas "Free")
                    if (Usuario.WF.Estado != "Vigente")
                    {
                        throw new CedServicios.EX.Usuario.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
        public static string TerminosYCondiciones()
        {
            string a = "Los siguientes términos y condiciones generales regularán expresamente las relaciones surgidas entre este Portal www.cedeira.com.ar de Cedeira Software Factory S.R.L ( en adelante 'NUESTRA EMPRESA' ) y Usted (en adelante el 'USUARIO o USUARIOS') en virtud de las cuales NUESTRA EMPRESA le brinda servicios de gratuito de generación de comprobantes electrónicos en un archivo de formato XML, ya sea que se trate de nuevos USUARIOS o aquellos vinculados a través de cualquier acuerdo previo que pudiera existir entre las partes. Este acuerdo sustituye cualquier otra comunicación previa oral o de otro tipo, que haya habido entre las partes.<br />La utilización del Portal www.cedeira.com.ar atribuye la condición de USUARIO del Portal, sea persona física o jurídica, e implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluidas en estos terminos y condiciones que se detallan a contituación.<br /><br />NUESTRA EMPRESA:<br /><br />1.No asume ninguna responsabilidad por la utilización de los presentes modelos de carga de comprobantes, ya que sólo los ofrece en forma gratuita a modo de simplificar las tareas en la carga de la información del comprobante electrónico que solicita InterFacturas.<br /><br />2.No asume responsabilidad alguna sobre los datos de los comprobantes que usted envíe a Interfacturas. La información generada desde este sitio web, puede ser modificada por usted.<br /><br />3.Se reserva el derecho unilateral de suspender temporalmente o de terminar definitivamente la prestación del servicios a través del Portal.<br /><br />4.Se reserva el derecho de modificar unilateralmente y en cualquier momento el sistema de acceso al servicio.<br /><br />5.No garantiza que el sitio web vaya a funcionar en forma constante, fiable y correctamente, sin retrasos o interrupciones, por lo que no se hace responsable de los daños y prejuicios que puedan derivarse de los posibles fallos en disponibilidad y continuidad técnica del sitio web.<br /><br />6.No presenta ninguna garantía, explicita o implícitamente, acerca de la utilización de este servicio gratuito.<br /><br />7.No será responsable por cualquier daño y/o perjuicio y/o beneficio dejado de obtener por el usuario o cualquier otro tercero causados directa o indirectamente por la conexión y/o utilización y/o acceso al sitio web www.cedeira.com.ar o a páginas enlazadas a él.<br /><br />Ley aplicable y jurisdicción competente<br />El USUARIO acepta que la legislación aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicción de los juzgados y tribunales de la Ciudad Autónoma de Buenos Aires para la resolución de las devergencias que se deriven de la interpretación o aplicación de este clausulado.";
            return a;
        }
        public static void Validar(Entidades.Usuario Usuario, string ConfirmacionPassword, string ClaveCatpcha, string Clave, Entidades.Sesion Sesion)
        {
            if (Usuario.Nombre == String.Empty)
            {
                throw new EX.Validaciones.ValorNoInfo("Nombre y Apellido");
            }
            else
            {
                if (Usuario.Telefono == String.Empty)
                {
                    throw new EX.Validaciones.ValorNoInfo("Teléfono");
                }
                else
                {
                    if (Usuario.Email == String.Empty)
                    {
                        throw new EX.Validaciones.ValorNoInfo("Email");
                    }
                    else
                    {
                        if (!RN.Funciones.EsEmail(Usuario.Email))
                        {
                            throw new EX.Validaciones.ValorInvalido("Email");
                        }
                        else
                        {
                            if (Usuario.Id == String.Empty)
                            {
                                throw new EX.Validaciones.ValorNoInfo("Id.Usuario");
                            }
                            else
                            {
                                if (!IdCuentaDisponible(Usuario, Sesion))
                                {
                                    throw new EX.Usuario.IdUsuarioNoDisponible();
                                }
                                else
                                {
                                    if (Usuario.Password == String.Empty)
                                    {
                                        throw new EX.Validaciones.ValorNoInfo("Contraseña");
                                    }
                                    else
                                    {
                                        if (ConfirmacionPassword == String.Empty)
                                        {
                                            throw new EX.Validaciones.ValorNoInfo("Confirmación de Contraseña");
                                        }
                                        else
                                        {
                                            if (Usuario.Password != ConfirmacionPassword)
                                            {
                                                throw new EX.Usuario.PasswordYConfirmacionNoCoincidente();
                                            }
                                            else
                                            {
                                                if (Usuario.Pregunta == String.Empty)
                                                {
                                                    throw new EX.Validaciones.ValorNoInfo("Pregunta");
                                                }
                                                else
                                                {
                                                    if (Usuario.Respuesta == String.Empty)
                                                    {
                                                        throw new EX.Validaciones.ValorNoInfo("Respuesta");
                                                    }
                                                    else
                                                    {
                                                        if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                                        {
                                                            throw new EX.Validaciones.ValorInvalido("Clave");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Registrar(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            Usuario.WF.Estado = "PteConfig";
            DB.Usuario usuario = new DB.Usuario(Sesion);
            usuario.Crear(Usuario);
            EnviarMailConfirmacion("Ahora dispone de una nueva cuenta", Usuario);
        }
        public static void Confirmar(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            Usuario.Id = Encryptor.Decrypt(Usuario.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Leer(Usuario, (Entidades.Sesion)Sesion);
            DB.Usuario usuario = new DB.Usuario((Entidades.Sesion)Sesion);
            usuario.Confirmar(Usuario);
            Leer(Usuario, (Entidades.Sesion)Sesion);
            EnviarSMS("Alta cuenta " + CantidadDeFilas((Entidades.Sesion)Sesion).ToString(), Usuario.Nombre, usuario.DestinatariosAvisoAltaUsuario());
        }
        public static bool IdCuentaDisponible(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            if (Usuario.Id == String.Empty)
            {
                throw new EX.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                try
                {
                    DB.Usuario usuario = new DB.Usuario(Sesion);
                    return usuario.IdUsuarioDisponible(Usuario);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private static void EnviarMailConfirmacion(string Asunto, Entidades.Usuario Usuario)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Usuario.Email));
            mail.Subject = Asunto;
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
        public static void EnviarSMS(string Asunto, string Mensaje, List<Entidades.Usuario> Destinatarios)
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
                smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
                smtpClient.Send(mail);
            }
        }
        public static int CantidadDeFilas(Entidades.Sesion Sesion)
        {
            DB.Usuario usuario = new DB.Usuario(Sesion);
            return usuario.CantidadDeFilas();
        }
        public static void CambiarPassword(Entidades.Usuario Usuario, string PasswordActual, string PasswordNueva, string ConfirmacionPasswordNueva, Entidades.Sesion Sesion)
        {
            if (PasswordActual == String.Empty)
            {
                throw new EX.Validaciones.ValorNoInfo("Contraseña actual");
            }
            else
            {
                if (PasswordNueva == String.Empty)
                {
                    throw new EX.Validaciones.ValorNoInfo("Contraseña nueva");
                }
                else
                {
                    if (ConfirmacionPasswordNueva == String.Empty)
                    {
                        throw new EX.Validaciones.ValorNoInfo("Confirmación de Contraseña nueva");
                    }
                    else
                    {
                        if (Usuario.Password != PasswordActual)
                        {
                            throw new EX.Usuario.PasswordNoMatch();
                        }
                        else
                        {
                            if (PasswordNueva != ConfirmacionPasswordNueva)
                            {
                                throw new EX.Usuario.PasswordYConfirmacionNoCoincidente();
                            }
                            else
                            {
                                if (Usuario.Password == PasswordNueva)
                                {
                                    throw new EX.Usuario.PasswordNuevaIgualAActual();
                                }
                                else
                                {
                                    DB.Usuario usuario = new DB.Usuario(Sesion);
                                    usuario.CambiarPassword(Usuario, PasswordNueva);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ReportarIdUsuarios(string Email, Entidades.Sesion Sesion)
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
    }
}