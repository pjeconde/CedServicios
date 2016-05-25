using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class ServiciosAFIP
    {
        private static void CrearTicket(Entidades.Sesion Sesion, out LoginTicket ticket)
        {
            string RutaCertificado = "";
            ticket = new LoginTicket();
            string cuitServicioAFIP = RN.Configuracion.CuitConsultaAFIP(Sesion);
                
            DB.Ticket ticketDB = new DB.Ticket(Sesion);
            bool SolicitarTicket = false;

            if (Sesion.Ticket == null)
            {
                Sesion.Ticket = ticketDB.Leer(cuitServicioAFIP, TipoServicios.ConsultaPadronN3);
            }
            else
            {
                if (Sesion.Ticket.Cuit != cuitServicioAFIP || Sesion.Ticket.Service != TipoServicios.ConsultaPadronN3)
                {
                    Sesion.Ticket = ticketDB.Leer(cuitServicioAFIP, TipoServicios.ConsultaPadronN3);
                }
            }
            if (Sesion.Ticket.Cuit == null)
            {
                SolicitarTicket = true;
            }
            else if (Convert.ToInt64(Sesion.Ticket.ExpirationTime.ToString("yyyyMMddHHmmss")) <= Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")))
            {
                SolicitarTicket = true;
            }
            else
            {
                ticket.Service = TipoServicios.ConsultaPadronN3;
                ticket.Cuit = Sesion.Ticket.Cuit;
                ticket.Sign = Sesion.Ticket.Sign;
                ticket.Token = Sesion.Ticket.Token;
                ticket.UniqueId = Convert.ToUInt32(Sesion.Ticket.UniqueId);
                ticket.GenerationTime = Sesion.Ticket.GenerationTime;
                ticket.ExpirationTime = Sesion.Ticket.ExpirationTime;
            }

            if (SolicitarTicket)
            {
                ticket = new LoginTicket();
                RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + cuitServicioAFIP + ".p12");

                ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(Sesion.Cuit.Nro), TipoServicios.ConsultaPadronN3);

                //Guardar Ticket de AFIP
                Sesion.Ticket = new Entidades.Ticket();
                Sesion.Ticket.Cuit = ticket.ObjAutorizacionfev1.Cuit.ToString().Trim();
                Sesion.Ticket.Service = ticket.Service;
                Sesion.Ticket.UniqueId = ticket.UniqueId.ToString().Trim();
                Sesion.Ticket.GenerationTime = ticket.GenerationTime;
                Sesion.Ticket.ExpirationTime = ticket.ExpirationTime;
                Sesion.Ticket.Sign = ticket.Sign;
                Sesion.Ticket.Token = ticket.Token;
                ticketDB.Modificar(Sesion.Ticket);

                SolicitarTicket = false;
            }
        }
        public static string DatosFiscales(string Cuit, Entidades.Sesion Sesion)
        {
            string resp = "";
            try
            {
                //string RutaCertificado = "";
                //if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                //{
                //    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Sesion.Cuit.Nro + ".p12");
                //}
                //else
                //{
                //    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Convert.ToInt64("30710015062") + ".p12");
                //}
                //LoginTicket ticket = new LoginTicket();
                //ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(Sesion.Cuit.Nro.ToString()), "padron-puc-ws-consulta-nivel3");

                LoginTicket ticket = new LoginTicket();
                CrearTicket(Sesion, out ticket);
                ar.gov.afip.padron_puc_ws.ContribuyenteNivel3SelectServiceImplService c = new ar.gov.afip.padron_puc_ws.ContribuyenteNivel3SelectServiceImplService();
                c.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_padron-puc-ws_Service"];
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
        public static string IdProvincia(string IdProvinciaAFIP)
        {
            switch (IdProvinciaAFIP)
            {
                case "0":   //Ciudad Autónoma de Buenos Aires
                    return "1";
                case "1":   //Buenos Aires
                    return "2";
                case "2":   //CatamarCa
                    return "3";
                case "3":   //Córdoba
                    return "4";
                case "4":   //Corrientes
                    return "5";
                case "5":   //Entre Ríos
                    return "8";
                case "6":   //Jujuy
                    return "10";
                case "7":   //Mendoza
                    return "13";
                case "8":   //La Rioja
                    return "12";
                case "9":   //Salta
                    return "17";
                case "10":  //San Juan
                    return "18";
                case "11":  //San Luis
                    return "19";
                case "12":  //Santa Fe
                    return "21";
                case "13":  //Santiago del Estero
                    return "22";
                case "14":  //Tucumán
                    return "24";
                case "16":  //Chaco
                    return "6";
                case "17":  //Chubut
                    return "7";
                case "18":  //Formosa
                    return "9";
                case "19":  //Misiones
                    return "14";
                case "20":  //Neuquén
                    return "15";
                case "21":  //La Pampa
                    return "11";
                case "22":  //Río Negro
                    return "16";
                case "23":  //Santa Cruz
                    return "20";
                case "24":  //Tierra del Fuego
                    return "23";
                default:
                    return string.Empty;
            }
        }
    }
}
