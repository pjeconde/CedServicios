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
                ar.gov.afip.awshomo.ContribuyenteNivel3SelectServiceImplService c = new ar.gov.afip.awshomo.ContribuyenteNivel3SelectServiceImplService();
                string cuit = Sesion.Cuit.Nro;
                cuit = "30710015062";
                string token = "-----BEGIN SSOTOKENBASE64-----\n" + Sesion.Ticket.Token + " -----END SSOTOKENBASE64-----";
                string sign = "-----BEGIN SSOSIGNBASE64-----\n" + Sesion.Ticket.Sign + " -----END SSOSIGNBASE64-----";
                resp = c.get(cuit, token, sign);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return resp;
        }
    }
}
