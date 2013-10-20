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
    public partial class ExploradorLog : System.Web.UI.Page
    {
        List<Entidades.Log> Log = new List<Entidades.Log>();

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
                    EstadoDropDownList.DataSource = RN.Estado.Lista(true, sesion);
                    FechaDesdeTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    FechaHastaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    DataBind();
                    EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }

        protected void LogPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                LogPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Log> lista;
                int CantidadFilas = 0;
                lista = RN.Log.ListaPaging(out CantidadFilas, LogPagingGridView.PageIndex, LogPagingGridView.OrderBy, IdLogTextBox.Text, IdWFTextBox.Text, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, IdUsuarioTextBox.Text, EntidadTextBox.Text, EventoTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                LogPagingGridView.VirtualItemCount = CantidadFilas;
                LogPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                LogPagingGridView.DataSource = lista;
                LogPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                //CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void LogPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                List<Entidades.Log> lista = new List<Entidades.Log>();
                int CantidadFilas = 0;
                lista = RN.Log.ListaPaging(out CantidadFilas, LogPagingGridView.PageIndex, LogPagingGridView.OrderBy, IdLogTextBox.Text, IdWFTextBox.Text, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, IdUsuarioTextBox.Text, EntidadTextBox.Text, EventoTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                LogPagingGridView.DataSource = (List<Entidades.Log>)ViewState["lista"];
                LogPagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void LogPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[9].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = LogPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            LogPagingGridView.SelectedIndex = -1;
        }

        protected void LogPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Log Log = new Entidades.Log();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Log> lista = (List<Entidades.Log>)ViewState["lista"];
                Log = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    //Session["Log"] = Log;
                    //Response.Redirect("~/LogConsultaDetallada.aspx");
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    IdLogLabel.Text = Log.Id.ToString();
                    IdWFLabel.Text = Log.IdWF.ToString();
                    FechaLabel.Text = Log.Fecha.ToString();
                    IdUsuarioLabel.Text = Log.IdUsuario;
                    EntidadLabel.Text = Log.Entidad;
                    EventoLabel.Text = Log.Evento;
                    ComentarioLabel.Text = Log.Comentario;
                    EstadoLabel.Text = Log.Estado;
                    ModalPopupExtender1.Show();
                    break;
                case "LogDetalle":
                    Session["Log"] = Log;
                    Response.Redirect("~/LogDetalleConsultaXIdLog.aspx", false);
                    break;
                case "VerEntidad":
                    switch (Log.Entidad)
                    {
                        case "Cliente":
                            Entidades.Cliente cliente =new Entidades.Cliente();
                            string xml = RN.Cliente.LeerYSerializar(Log.IdWF, (Entidades.Sesion)Session["Sesion"]);
                            DescargarXMLEntidad(xml);
                            break;
                        default:
                            MensajeLabel.Text = "Esta entidad no está definida aún para la consulta. (Por ahora solo 'Cliente')";
                            break;
                    }
                    break;
            }
        }

        private void DescargarXMLEntidad(string Xml)
        {
            string textoXML = Xml;
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
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Log> lista = new List<Entidades.Log>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Log.ListaPaging(out CantidadFilas, LogPagingGridView.PageIndex, LogPagingGridView.OrderBy, IdLogTextBox.Text, IdWFTextBox.Text, FechaDesdeTextBox.Text, FechaHastaTextBox.Text, IdUsuarioTextBox.Text, EntidadTextBox.Text, EventoTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                LogPagingGridView.VirtualItemCount = CantidadFilas;
                LogPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    LogPagingGridView.DataSource = null;
                    LogPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Logs que satisfagan la busqueda";
                }
                else
                {
                    LogPagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    LogPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}