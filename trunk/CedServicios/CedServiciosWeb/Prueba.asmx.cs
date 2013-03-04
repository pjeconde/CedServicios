using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;

namespace CedServiciosWeb
{
    /// <summary>
    /// Descripción breve de Prueba
    /// </summary>
    [WebService(Namespace = "http://www.cedeira.com.ar/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Prueba : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string Texto)
        {
            return "Hello World " + Texto;
        }
    }
}
