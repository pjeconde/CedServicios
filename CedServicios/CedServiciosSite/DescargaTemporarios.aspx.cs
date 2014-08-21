using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site
{
    public partial class DescargaTemporarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filename = Request.QueryString.Get("archivo");
            string pathname = Request.QueryString.Get("path");
            if (!String.IsNullOrEmpty(filename))
            {
                String dlDir = pathname;
                if (pathname == null)
                {
                    dlDir = @"~/Temp/";
                }
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
                    toDownload.Delete();
                }
                else
                {
                    WebForms.Excepciones.Redireccionar(new EX.Validaciones.ArchivoInexistente(filename), "~/NotificacionDeExcepcion.aspx");
                }
            }
        }
    }
}
