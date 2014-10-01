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
    public class GeneroPDF : System.Web.Services.WebService
    {

        [WebMethod]
        public string GenerarPDF(string CuitVendedor, int NroPuntoVta, int TipoComprobante, long NroComprobante, string IdDestinoComprobante, string ArchivoXML)
        {
            string resultado = string.Empty;
            try
            {
                CedServicios.RN.Comprobante c = new CedServicios.RN.Comprobante();
                using (FileStream fs = File.Open(Server.MapPath("~/Detallar.txt"), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(System.DateTime.Now);
                        sw.WriteLine("CuitVendedor:" + CuitVendedor);
                        sw.WriteLine("NroPuntoVta:" + NroPuntoVta.ToString());
                        sw.WriteLine("TipoComprobante:" + TipoComprobante.ToString());
                        sw.WriteLine("NroComprobante:" + NroComprobante.ToString());
                    }
                }
                resultado = c.GenerarPDF(CuitVendedor, NroPuntoVta, TipoComprobante, NroComprobante, IdDestinoComprobante, ArchivoXML);
            }
            catch (Exception ex)
            {
                throw ExcepcionesSOAP.RaiseException("GenerarPDF", "http://www.cedeira.com.ar/webservices", ex.Message,
                    "0", ex.Source, FaultCode.Server);

            }
            return resultado;
        }
    }
}
