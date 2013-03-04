using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.WebForms
{
    public static class Excepciones
    {
        public static void Redireccionar(Exception ex, string url)
        {
            UrlParameterPasser urlWrapper = new UrlParameterPasser(url);
            urlWrapper["ex"] = Detalle(ex);
            urlWrapper.PassParameters();
        }
        public static void Redireccionar(string idParm, string valor, string url)
        {
            UrlParameterPasser urlWrapper = new UrlParameterPasser(url);
            urlWrapper[idParm] = valor.Replace("<b>", String.Empty).Replace("<b/>", String.Empty);
            urlWrapper.PassParameters();
        }
        public static string Detalle(Exception ex)
        {
            System.Text.StringBuilder a = new System.Text.StringBuilder();
            a.Append(ex.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
            if (ex.InnerException != null)
            {
                a.Append(" (");
                a.Append(ex.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
                a.Append(")");
            }
            return a.ToString();
        }
    }
}
