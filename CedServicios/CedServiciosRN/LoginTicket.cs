using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.VisualBasic;

namespace CedServicios.RN
{
	/// <summary> 
	/// Clase para crear objetos Login Tickets 
	/// </summary> 
    /// 

    public class TipoServicios
    {
        public const string FacturaE = "wsfe";
        public const string FacturaEX = "wsfex";
        public const string FacturaCT = "wsct";
        public const string ConsultaPadronN3 = "padron-puc-ws-consulta-nivel3";
    }

	public class LoginTicket
	{
        public string Cuit;
		// Entero de 32 bits sin signo que identifica el requerimiento 
		public UInt32 UniqueId;
		// Momento en que fue generado el requerimiento 
		public DateTime GenerationTime;
		// Momento en el que expira la solicitud 
		public DateTime ExpirationTime;
		// Identificacion del WSN para el cual se solicita el TA 
		public string Service;
		// Firma de seguridad recibida en la respuesta 
		public string Sign;
		// Token de seguridad recibido en la respuesta 
		public string Token;

		public XmlDocument XmlLoginTicketRequest = null;
		public XmlDocument XmlLoginTicketResponse = null;
		public string RutaDelCertificadoFirmante;
		public string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";

		private bool _verboseMode = true;
        private string fechaUtc;

		// OJO! NO ES THREAD-SAFE 
		private static UInt32 _globalUniqueID = 0;

        const string DEFAULT_SERVICIO = "wsfe";
        ar.gov.afip.wsw.FEAuthRequest objAutorizacion;
        ar.gov.afip.wsfev1.FEAuthRequest objAutorizacionfev1;
        ar.gov.afip.wsfexv1.ClsFEXAuthRequest objAutorizacionfexv1;
        ar.gov.afip.WSCT.AuthRequestType objAutorizacionWSCT;
        
        System.Net.WebProxy wp;

        public void ObtenerTicket(string RutaCertificado, long Cuit, string Servicio)
        {
            LoginTicket objTicketRespuesta;
            string strTicketRespuesta;
            try
            {
                //Crear WebProxy
                System.Net.WebProxy wp = null;
                //if (!System.Configuration.ConfigurationManager.AppSettings["Proxy"].ToUpper().Equals("NO"))
                //{
                //    wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                //    string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                //    string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                //    string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

                //    System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                //    wp.Credentials = networkCredential;

                //    //System.Net.CredentialCache credentialCache = new System.Net.CredentialCache();
                //    //string wsaaurl = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsaa_LoginCMSService"];
                //    //credentialCache.Add(new Uri(wsaaurl), "NTLM", networkCredential);
                //    //string wsfeurl = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsw_Service"];
                //    //credentialCache.Add(new Uri(wsfeurl), "NTLM", networkCredential);
                //    //wp.Credentials = credentialCache;
                //}
                //URL Login
                string urlWsaa = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsaa_LoginCMSService"];
                //Obtener Ticket
                string servicio = DEFAULT_SERVICIO;
                if (Servicio != "")
                {
                    servicio = Servicio;
                }
                strTicketRespuesta = ObtenerLoginTicketResponse(servicio, urlWsaa, RutaCertificado, false, Wp);
                objAutorizacion = new ar.gov.afip.wsw.FEAuthRequest();
                objAutorizacion.Token = Token;
                objAutorizacion.Sign = Sign;
                objAutorizacion.cuit = Cuit;
                objAutorizacionfev1 = new ar.gov.afip.wsfev1.FEAuthRequest();
                objAutorizacionfev1.Token = Token;
                objAutorizacionfev1.Sign = Sign;
                objAutorizacionfev1.Cuit = Cuit;
                objAutorizacionfexv1 = new ar.gov.afip.wsfexv1.ClsFEXAuthRequest();
                objAutorizacionfexv1.Token = Token;
                objAutorizacionfexv1.Sign = Sign;
                objAutorizacionfexv1.Cuit = Cuit;
                objAutorizacionWSCT = new ar.gov.afip.WSCT.AuthRequestType();
                objAutorizacionWSCT.token = Token;
                objAutorizacionWSCT.sign = Sign;
                objAutorizacionWSCT.cuitRepresentada = Cuit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ar.gov.afip.wsw.FEAuthRequest ObjAutorizacion
        {
            get { return objAutorizacion; }
            set { objAutorizacion = value; }
        }

        public ar.gov.afip.wsfev1.FEAuthRequest ObjAutorizacionfev1
        {
            get { return objAutorizacionfev1; }
            set { objAutorizacionfev1 = value; }
        }

        public ar.gov.afip.wsfexv1.ClsFEXAuthRequest ObjAutorizacionfexv1
        {
            get { return objAutorizacionfexv1; }
            set { objAutorizacionfexv1 = value; }
        }

        public ar.gov.afip.WSCT.AuthRequestType ObjAutorizacionWSCT
        {
            get { return objAutorizacionWSCT; }
            set { objAutorizacionWSCT = value; }
        }

        public System.Net.WebProxy Wp
        {
            get { return wp; }
            set { wp = value; }
        }

		/// <summary> 
		/// Construye un Login Ticket obtenido del WSAA 
		/// </summary> 
		/// <param name="argServicio">Servicio al que se desea acceder</param> 
		/// <param name="argUrlWsaa">URL del WSAA</param> 
		/// <param name="argRutaCertX509Firmante">Ruta del certificado X509 (con clave privada) usado para firmar</param> 
		/// <param name="argVerbose">Nivel detallado de descripcion? true/false</param> 
		/// <remarks></remarks> 
		private string ObtenerLoginTicketResponse(string argServicio, string argUrlWsaa, string argRutaCertX509Firmante, bool argVerbose, WebProxy Wp)
		{

			this.RutaDelCertificadoFirmante = argRutaCertX509Firmante;
			this._verboseMode = argVerbose;
			CertificadosX509Lib.VerboseMode = argVerbose;

			string cmsFirmadoBase64;
			string loginTicketResponse;

			XmlNode xmlNodoUniqueId;
			XmlNode xmlNodoGenerationTime;
			XmlNode xmlNodoExpirationTime;
			XmlNode xmlNodoService;

			// PASO 1: Genero el Login Ticket Request 
			try
			{
				XmlLoginTicketRequest = new XmlDocument();
				XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

				xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
				xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
				xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
				xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");

				// Las horas son UTC formato yyyy-MM-ddTHH:mm:ssZ
                fechaUtc = DateTime.UtcNow.ToString();
				xmlNodoGenerationTime.InnerText = DateTime.UtcNow.AddMinutes(-100).ToString("s") + "Z";
				xmlNodoExpirationTime.InnerText = DateTime.UtcNow.AddMinutes(+100).ToString("s") + "Z";
				xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
				xmlNodoService.InnerText = argServicio;
				this.Service = argServicio;

				_globalUniqueID += 1;

				if (this._verboseMode)
				{
					Console.WriteLine(XmlLoginTicketRequest.OuterXml);
				}
			}

			catch (Exception excepcionAlGenerarLoginTicketRequest)
			{
				throw new Exception("***Error generando el LoginTicketRequest: ObtenerLoginTicketResponse: " + excepcionAlGenerarLoginTicketRequest.Message);
			}

			// PASO 2: Firmo el Login Ticket Request 
			try
			{
				if (this._verboseMode)
				{
					Console.WriteLine("***Leyendo certificado: {0}", RutaDelCertificadoFirmante);
				}
                
				X509Certificate2 certFirmante = CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(RutaDelCertificadoFirmante);

				if (this._verboseMode)
				{
					Console.WriteLine("***Firmando: ");
					Console.WriteLine(XmlLoginTicketRequest.OuterXml);
				}

				// Convierto el login ticket request a bytes, para firmar 
				Encoding EncodedMsg = Encoding.UTF8;
				byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);

				// Firmo el msg y paso a Base64 
				byte[] encodedSignedCms = CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
				cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);
			}

			catch (Exception excepcionAlFirmar)
			{
				throw new Exception("***Error firmando el LoginTicketRequest: ObtenerLoginTicketResponse: " + excepcionAlFirmar.Message);
			}

			// PASO 3: Invoco al WSAA para obtener el Login Ticket Response 
			ar.gov.afip.wsaa.LoginCMSService servicioWsaa = new ar.gov.afip.wsaa.LoginCMSService(); 
			try
			{
				if (this._verboseMode)
				{
					Console.WriteLine("***Llamando al WSAA en URL: {0}", argUrlWsaa);
					Console.WriteLine("***Argumento en el request:");
					Console.WriteLine(cmsFirmadoBase64);
				}

				if (Wp != null)
				{
					servicioWsaa.Proxy = Wp;
				}

				servicioWsaa.Url = argUrlWsaa;

				loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);

				if (this._verboseMode)
				{
					Console.WriteLine("***LoginTicketResponse: ");
					Console.WriteLine(loginTicketResponse);
				}
			}

			catch (Exception excepcionAlInvocarWsaa)
			{
                throw new Exception("***Error invocando al servicio WSAA: ObtenerLoginTicketResponse: " + excepcionAlInvocarWsaa.Message + "\\n FechaUTC = " + fechaUtc);
			}

			// PASO 4: Analizo el Login Ticket Response recibido del WSAA 
			try
			{
				XmlLoginTicketResponse = new XmlDocument();
				XmlLoginTicketResponse.LoadXml(loginTicketResponse);

				this.UniqueId = UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
				this.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
				this.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
				this.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
				this.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
			}
			catch (Exception excepcionAlAnalizarLoginTicketResponse)
			{
				throw new Exception("***Error analizando respuesta del WSAA: ObtenerLoginTicketResponse: " + excepcionAlAnalizarLoginTicketResponse.Message);
			}
			return loginTicketResponse;

		}


	}

	/// <summary> 
	/// Libreria de utilidades para manejo de certificados 
	/// </summary> 
	/// <remarks></remarks> 
	class CertificadosX509Lib
	{

		public static bool VerboseMode = false;

		/// <summary> 
		/// Firma mensaje 
		/// </summary> 
		/// <param name="argBytesMsg">Bytes del mensaje</param> 
		/// <param name="argCertFirmante">Certificado usado para firmar</param> 
		/// <returns>Bytes del mensaje firmado</returns> 
		/// <remarks></remarks> 
		public static byte[] FirmaBytesMensaje(byte[] argBytesMsg, X509Certificate2 argCertFirmante)
		{
			try
			{
				// Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms) 
				ContentInfo infoContenido = new ContentInfo(argBytesMsg);
				SignedCms cmsFirmado = new SignedCms(infoContenido);

				// Creo objeto CmsSigner que tiene las caracteristicas del firmante 
				CmsSigner cmsFirmante = new CmsSigner(argCertFirmante);
				cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

				if (VerboseMode)
				{
					Console.WriteLine("***Firmando bytes del mensaje...");
				}
				// Firmo el mensaje PKCS #7 
				cmsFirmado.ComputeSignature(cmsFirmante);

				if (VerboseMode)
				{
					Console.WriteLine("***OK mensaje firmado");
				}

				// Encodeo el mensaje PKCS #7. 
				return cmsFirmado.Encode();
			}
			catch (Exception excepcionAlFirmar)
			{
				throw new Exception("***Error al firmar: FirmaBytesMensaje: " + excepcionAlFirmar.Message);
			}
		}

		/// <summary> 
		/// Lee certificado de disco 
		/// </summary> 
		/// <param name="argArchivo">Ruta del certificado a leer.</param> 
		/// <returns>Un objeto certificado X509</returns> 
		/// <remarks></remarks> 
		public static X509Certificate2 ObtieneCertificadoDesdeArchivo(string argArchivo)
		{
            byte[] ba;
            try
            {
                ba = FileToByteArray(argArchivo);
            }
            catch (Exception excepcionAlImportarCertificado)
            {
                throw new Exception("***Error al obtener certificado: (FileToByteArray) ObtieneCertificadoDesdeArchivo(" + argArchivo + "): " + excepcionAlImportarCertificado.Message + " " + excepcionAlImportarCertificado.StackTrace);
            }
			X509Certificate2 objCert = new X509Certificate2();
			try
			{
                objCert.Import(ba, string.Empty, X509KeyStorageFlags.MachineKeySet);
				return objCert; 
			}
			catch (Exception excepcionAlImportarCertificado)
			{
                throw new Exception("***Error al obtener certificado: (Import MachineKeySet) ObtieneCertificadoDesdeArchivo(" + argArchivo + "): " + excepcionAlImportarCertificado.Message + " " + excepcionAlImportarCertificado.StackTrace);
			}
		}

        public static byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

	}
}