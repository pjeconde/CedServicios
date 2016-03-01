using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class ServiciosAFIP
    {
        public static string DatosFiscales(string Cuit, Entidades.Sesion Sesion)
        {
            string resp = "";
            try
            {
                string RutaCertificado = "";
                if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Sesion.Cuit.Nro + ".p12");
                }
                else
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Convert.ToInt64("30710015062") + ".p12");
                }
                LoginTicket ticket = new LoginTicket();
                ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(Sesion.Cuit.Nro.ToString()), "padron-puc-ws-consulta-nivel3");
                ar.gov.afip.awshomo.ContribuyenteNivel3SelectServiceImplService c = new ar.gov.afip.awshomo.ContribuyenteNivel3SelectServiceImplService();
                string cuit = "<contribuyentePK><id>" + Cuit + "</id></contribuyentePK>";
                string token = "-----BEGIN SSOTOKENBASE64-----\n" + ticket.Token + " -----END SSOTOKENBASE64-----";
                string sign = "-----BEGIN SSOSIGNBASE64-----\n" + ticket.Sign + " -----END SSOSIGNBASE64-----";
                resp = c.get(cuit, token, sign);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }
    }
}
