using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
//using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace CedServicios.Entidades
{
    public static class EntidadExtensions
    {
        //public static string SerializerJson(this Object valor)
        //{
        //    string json = string.Empty;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(valor.GetType());
        //        ser.WriteObject(ms, valor);
        //        json = Encoding.Default.GetString(ms.ToArray());
        //    }
        //    return json;
        //}

        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Des serializa una entidad a un XML dentro de un string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>string con el XML de la entidad des serializada</returns>
        public static string DesSerializerClassToXmlString<T>(this T value) where T : class
        {
            string respuest = string.Empty;
            try
            {
                if (value.IsNotNull())
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(value.GetType());
                    using (StringWriter textWriter = new StringWriter())
                    {
                        xmlSerializer.Serialize(textWriter, value);
                        respuest = textWriter.ToString();
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw new Exception(e.InnerException.Message, e);
            }
            catch (Exception e)
            {
                throw e;
            }

            return respuest;
        }
    }
}