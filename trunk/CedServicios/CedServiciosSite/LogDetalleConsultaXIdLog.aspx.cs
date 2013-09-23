using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Text;

namespace CedServicios.Site
{
    public partial class LogDetalleConsultaXIdLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    Entidades.Log Log = (Entidades.Log)Session["Log"];
                    TituloPaginaLabel.Text = "Consulta Detalle del Log. (IdLog. " + Log.Id + ")";
                    List<Entidades.LogDetalle> Lista = RN.LogDetalle.ListaPorIdLog(Log.Id, sesion);
                    LogDetalleGridView.DataSource = Lista;
                    if (Lista.Count == 0)
                    {
                        MensajeLabel.Text = "No hay información en el detalle del Log. ";
                    }
                    ViewState["lista"] = Lista;
                    DataBind();
                }
            }
        }
        protected void LogDetalleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            }
        }
        protected void LogDetalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.LogDetalle LogDetalle = new Entidades.LogDetalle();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.LogDetalle> lista = (List<Entidades.LogDetalle>)ViewState["lista"];
                LogDetalle = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["LogDetalle"] = LogDetalle;
                    string textoXML = LogDetalle.Detalle;
                    textoXML = textoXML.Replace("&lt;", "<");
                    textoXML = textoXML.Replace("&gt;", ">");

                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    string filename = sesion.Usuario.Id + ".xml";
                    string dlDir = @"Temp/";
                    string path = Server.MapPath(dlDir + filename);
                    //Crear archivo XML en el temporal
                    using (FileStream fs = File.Create(path))
                    {
                        Encoding enc = Encoding.GetEncoding("utf-16");
                        Byte[] info = enc.GetBytes(textoXML);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    //Leer y mandar al explorador
                    FileInfo toDownload = new FileInfo(path);
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
                        MensajeLabel.Text = "No se puede obtener la información. ";
                    }
                    break;
            }
        }
    }
}