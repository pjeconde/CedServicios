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
    public class DetalleIBK : System.Web.Services.WebService
    {
        [WebMethod]
        public string DetallarIBK(FeaEntidades.InterFacturas.Detalle.consulta_emisor_comprobante_detalle cecd, string pathCertificado)
        {
            string resultado = string.Empty;
            try
            {
                string nroSerie = CaptchaDotNet2.Security.Cryptography.Encryptor.Decrypt(pathCertificado, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                using (FileStream fs = File.Open(Server.MapPath("~/Detallar.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("pathCertificado cifrado:" + pathCertificado);
                        sw.WriteLine("pathCertificado descifrado:" + nroSerie);
                        sw.WriteLine("cuit_vendedor:" + cecd.cuit_vendedor);
                        sw.WriteLine("punto_de_venta:" + cecd.punto_de_venta);
                        sw.WriteLine("tipo_de_comprobante:" + cecd.tipo_de_comprobante + "  numero_comprobante: " + cecd.numero_comprobante);
                    }
                }
                resultado = CedServicios.RN.Comprobante.ComprobanteDetalleIBK(cecd, nroSerie);
            }
            catch (Exception ex)
            {
                throw ExcepcionesSOAP.RaiseException("Detallar", "http://www.cedeira.com.ar/webservices", ex.Message,
                    "0", ex.Source, FaultCode.Server);

            }
            return resultado;
        }
    }
}
