using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class Descarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = Request.QueryString.Get("archivo");
            if (!String.IsNullOrEmpty(filename))
            {
                String dlDir = @"Descargas/";
                String path = Server.MapPath(dlDir + filename);
                System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                if (toDownload.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                    Response.AddHeader("Content-Length", toDownload.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(dlDir + filename);
                    Response.End();
                }
                else
                {
                    WebForms.Excepciones.Redireccionar(new EX.Validaciones.ArchivoInexistente(filename), "~/NotificacionDeExcepcion.aspx");
                }
            }
        }
    }
}