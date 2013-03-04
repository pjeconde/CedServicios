using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace CedServiciosWeb
{
    [WebService(Namespace = "http://www.cedeira.com.ar/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class EnvioIBK : System.Web.Services.WebService
    {
        [WebMethod]
        public string EnviarIBK(FeaEntidades.InterFacturas.lote_comprobantes lc, string pathCertificado)
        {
            string resultado = string.Empty;
            try
			{
                string nroSerie = CaptchaDotNet2.Security.Cryptography.Encryptor.Decrypt(pathCertificado, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                CedServicios.RN.Comprobante c = new CedServicios.RN.Comprobante();
                using (FileStream fs = File.Open(Server.MapPath("~/Enviar.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("pathCertificado cifrado:" + pathCertificado);
                        sw.WriteLine("pathCertificado descifrado:" + nroSerie);
                        sw.WriteLine("cuit_vendedor:" + lc.cabecera_lote.cuit_vendedor);
                        sw.WriteLine("id_lote:" + lc.cabecera_lote.id_lote);
                    }
                }
                resultado = c.EnviarIBK(lc, nroSerie);
			}
			catch (Exception ex)
			{
				throw ExcepcionesSOAP.RaiseException("Enviar", "http://www.cedeira.com.ar/webservices", ex.Message,
					"0", ex.Source, FaultCode.Server);

			}
            return resultado;
        }
    }
}
