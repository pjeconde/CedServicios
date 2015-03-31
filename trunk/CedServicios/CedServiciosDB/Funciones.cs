using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CedServicios.DB
{
    public class Funciones
    {
        public static string ObjetoSerializado(Object Objeto)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Objeto.GetType());
            System.IO.StringWriter textWriter = new System.IO.StringWriter();
            x.Serialize(textWriter, Objeto);
            return textWriter.ToString();
        }
        public static string ObjetoSerializadoParaSQL(Object Objeto)
        {
            return ObjetoSerializado(Objeto).Replace(Environment.NewLine, "' + CHAR(13) + CHAR(10) + '");
        }
        public static DateTime ConvertirFechaStringAAAAMMDDaDatetime(string FechaStringAAAAMMDD)
        {
            return new DateTime(Convert.ToInt32(FechaStringAAAAMMDD.Substring(0, 4)), Convert.ToInt32(FechaStringAAAAMMDD.Substring(4, 2)), Convert.ToInt32(FechaStringAAAAMMDD.Substring(6, 2)));
        }
        public static void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(HttpContext.Current.Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
