using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
