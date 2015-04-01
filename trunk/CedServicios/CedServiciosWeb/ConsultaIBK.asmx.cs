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
    public class ConsultaIBK : System.Web.Services.WebService
    {
        [WebMethod]
        public FeaEntidades.InterFacturas.lote_comprobantes Consultar(long cuit_vendedor, long id_lote, int punto_de_venta, string pathCertificado)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            try
            {
                string nroSerie = CaptchaDotNet2.Security.Cryptography.Encryptor.Decrypt(pathCertificado, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp")).ToString();
                using (FileStream fs = File.Open(Server.MapPath("~/Consultar.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("pathCertificado cifrado:" + pathCertificado);
                        sw.WriteLine("pathCertificado descifrado:" + nroSerie);
                        sw.WriteLine("cuit_vendedor:" + cuit_vendedor);
                        sw.WriteLine("id_lote:" + id_lote);
                    }
                }
                CedServicios.RN.IBK.consulta_lote_comprobantes consulta = new CedServicios.RN.IBK.consulta_lote_comprobantes();
                consulta.cuit_canal = 30690783521;
                consulta.cuit_vendedor = cuit_vendedor;
                consulta.id_lote = id_lote;
                consulta.cod_interno_canal = string.Empty;
                consulta.punto_de_ventaSpecified = true;
                consulta.punto_de_venta = punto_de_venta;

                lc = CedServicios.RN.Comprobante.ConsultarIBK(consulta, nroSerie);

            }
            catch (Exception ex)
            {
                throw ExcepcionesSOAP.RaiseException("Consultar", "http://www.cedeira.com.ar/webservices", ex.Message,
                    "0", ex.Source, FaultCode.Server);

            }
            return lc;
        }
    }
}
