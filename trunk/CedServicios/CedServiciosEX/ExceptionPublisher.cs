using System;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mail;
using System.IO;
using System.Reflection;


namespace CedServicios.EX
{
	public sealed class ExceptionPublisher : IExceptionPublisher
	{
		private string m_LogName = System.IO.Path.GetTempPath()  + "CedeiraErrorLog.txt";
		private string m_OpMail = ""; //

		public ExceptionPublisher()
		{
		}
		// Provide implementation of the IPublishException interface
		// This contains the single Publish method.
		void IExceptionPublisher.Publish(Exception exception, NameValueCollection AdditionalInfo, NameValueCollection ConfigSettings)
		{
			// Load Config values if they are provided.
			if (ConfigSettings != null)
			{
				if (ConfigSettings["fileName"] != null &&  
					ConfigSettings["fileName"].Length > 0)
				{  
					m_LogName = ConfigSettings["fileName"];
				}
				if (ConfigSettings["operatorMail"] !=null && 
					ConfigSettings["operatorMail"].Length > 0)
				{
					m_OpMail = ConfigSettings["operatorMail"];
				}
			}
			// Create StringBuilder to maintain publishing information.
			StringBuilder strInfo = new StringBuilder();

			// Record the contents of the AdditionalInfo collection.
			if (AdditionalInfo != null)
			{
				// Record General information.
				strInfo.AppendFormat("{0}Información General {0}", Environment.NewLine);
				strInfo.AppendFormat("{0}Info adicional:", Environment.NewLine);
				foreach (string i in AdditionalInfo)
				{
					if(i!="ExceptionManager.AppDomainName")
					{
						strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, AdditionalInfo.Get(i));
					}
					else
					{
						//Agrego version
						try
						{
							string name=AdditionalInfo.Get(3);
							name=name.Replace(".exe","");
							name=name.Replace(".dll","");
							Assembly a = Assembly.Load(name);
							AssemblyName an = a.GetName();
							String v = an.Version.ToString();
							strInfo.AppendFormat("{0}{1}: {2}, Versión=" + v , Environment.NewLine,i, AdditionalInfo.Get(i));
						}
						catch (Exception ex)
						{
							System.Diagnostics.Debug.WriteLine(ex.Message);
							strInfo.AppendFormat("{0}{1}: {2}, Versión=sin informar", Environment.NewLine,i, AdditionalInfo.Get(i));
						}
					}
				}
			}
			// Append the exception text
			strInfo.AppendFormat("{0}{0}Información de la excepción:{0}{0}{1}", Environment.NewLine, exception.Message);
			if(exception.InnerException!=null)
			{
				strInfo.AppendFormat("{0}{1}", Environment.NewLine, exception.InnerException.Message);
			}
			strInfo.AppendFormat("{0}{0}StackTrace:", Environment.NewLine);
			strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.StackTrace.ToString());
			if(exception.InnerException!=null)
			{			
				strInfo.AppendFormat("{0}{0}{1}", Environment.NewLine, exception.InnerException.StackTrace.ToString());
			}
			//Agrego el nombre del archivo y localización
			strInfo.AppendFormat("{0}{0}Archivo: " + m_LogName + "{0}", Environment.NewLine);
			// Write the entry to the log file.   
			using ( FileStream fs = File.Open(m_LogName,
						FileMode.Append,FileAccess.Write))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					sw.Write(strInfo.ToString());
				}
			}
			// send notification email if operatorMail attribute was provided
			if (m_OpMail.Length > 0)
			{
                string body = strInfo.ToString();
                string subject = "Notificación de excepción";
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage mail;
                mail = new System.Net.Mail.MailMessage("facturaelectronica@cedeira.com.ar", m_OpMail, subject, body);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                string MailServidorSmtp = System.Configuration.ConfigurationManager.AppSettings["MailServidorSmtp"];
                string MailCredencialesUsr = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesUsr"];
                string MailCredencialesPsw = System.Configuration.ConfigurationManager.AppSettings["MailCredencialesPsw"];
                smtpClient.Host = MailServidorSmtp;
                if (MailCredencialesUsr != "")
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(MailCredencialesUsr, MailCredencialesPsw);
                }
                smtpClient.Send(mail);
			}
		}
	}
}