using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorCV : System.Web.UI.Page
    {
        List<Entidades.Cuit> cuit = new List<Entidades.Cuit>();

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
                    DataBind();
                }
            }
        }

        protected void CVPagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                CVPagingGridView.PageIndex = e.NewPageIndex;
                List<Entidades.Archivo> lista = new List<Entidades.Archivo>();
                String path = Server.MapPath("~/CVs/");
                List<Entidades.Archivo> archivos = (List<Entidades.Archivo>)ViewState["ListaCompleta"];
                int hasta = (CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina) + ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                if (archivos.Count < (CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina) + ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina)
                {
                    hasta = archivos.Count;
                }
                if (archivos.Count != 0)
                {
                    for (int i = CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina; i < hasta; i++)
                    {
                        Entidades.Archivo archivo = new Entidades.Archivo();
                        archivo = archivos[i];
                        lista.Add(archivo);
                    }
                }

                CVPagingGridView.VirtualItemCount = archivos.Count;
                CVPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["Lista"] = lista;
                CVPagingGridView.DataSource = lista;
                CVPagingGridView.DataBind(); ;
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

        protected void CVPagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                CVPagingGridView.PageIndex = 0;
                List<Entidades.Archivo> lista = new List<Entidades.Archivo>();
                String path = Server.MapPath("~/CVs/");
                List<Entidades.Archivo> archivos = (List<Entidades.Archivo>)ViewState["ListaCompleta"];
                if (CVPagingGridView.OrderBy.ToUpper() == "NOMBRE DESC")
                {
                    archivos = archivos.OrderByDescending(o => o.Nombre).ToList();
                }
                else
                { 
                    archivos = archivos.OrderBy(o => o.Nombre).ToList();
                }
                int hasta = (CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina) + ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                if (archivos.Count < (CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina) + ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina)
                {
                    hasta = archivos.Count;
                }
                if (archivos.Count != 0)
                {
                    for (int i = CVPagingGridView.PageIndex * ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina; i < hasta; i++)
                    {
                        Entidades.Archivo archivo = new Entidades.Archivo();
                        archivo = archivos[i];
                        lista.Add(archivo);
                    }
                }

                CVPagingGridView.VirtualItemCount = archivos.Count;
                CVPagingGridView.PageSize = ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina;
                ViewState["Lista"] = lista;
                CVPagingGridView.DataSource = lista;
                CVPagingGridView.DataBind();
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

        protected void CVPagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                //if (e.Row.Cells[11].Text != "Vigente")
                //{
                //    e.Row.ForeColor = Color.Red;
                //}
                //DropDownList ddlB = (DropDownList)e.Row.FindControl("ddlB");
                //if (ddlB != null)
                //{
                //    ddlB.DataSource = Entidades.B.Lista();
                //    ddlB.DataBind();
                //    ddlB.SelectedValue = CVPagingGridView.DataKeys[e.Row.RowIndex].Values[0].ToString();
                //}
            }
        }
        private void DesSeleccionarFilas()
        {
            CVPagingGridView.SelectedIndex = -1;
        }

        protected void CVPagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Archivo arch = new Entidades.Archivo();
            string[] archNombre = new string[0];
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Archivo> lista = (List<Entidades.Archivo>)ViewState["Lista"];
                arch = lista[item];
                archNombre = arch.Nombre.Split(Convert.ToChar("\\"));
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    CancelarButton.Text = "Salir";
                    NombreLabel.Text = arch.Nombre;
                    FechaLabel.Text = "";
                    PesoLabel.Text = "";
                    System.IO.FileInfo fi = new System.IO.FileInfo(Server.MapPath("~/CVs/" + archNombre[archNombre.Length - 1]));
                    if (fi != null)
                    {
                        FechaLabel.Text = fi.CreationTime.ToString("dd/MM/yyyy");
                        PesoLabel.Text = fi.Length.ToString() + " Bytes";
                    }
                    ModalPopupExtender1.Show();
                    break;
                case "Abrir":
                    string script = "window.open('/DescargaTemporarios.aspx?archivo=" + archNombre[archNombre.Length - 1] + "&path=" + @"~/CVs/" + "', '');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
                    break;
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
                MensajeLabel.Text = String.Empty;
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Archivo> listaCompleta = new List<Entidades.Archivo>();
                List<Entidades.Archivo> lista = new List<Entidades.Archivo>();
                int CantidadFilas = sesion.Usuario.CantidadFilasXPagina;
                String path = Server.MapPath("~/CVs/");
                string[] archivos = System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.TopDirectoryOnly);
                int hasta = CantidadFilas;
                for (int i = 0; i < archivos.Length; i++)
                {
                    Entidades.Archivo archivo = new Entidades.Archivo();
                    if(RazonSocialTextBox.Text.Trim() != "")
                    {
                        if (archivos[i].ToUpper().IndexOf(RazonSocialTextBox.Text.ToUpper().Trim()) > -1)
                        {
                            archivo.Nombre = archivos[i];
                            listaCompleta.Add(archivo);
                        }
                    }
                    else
                    { 
                        archivo.Nombre = archivos[i];
                        listaCompleta.Add(archivo);
                    }
                }
                if (listaCompleta.Count < ((Entidades.Sesion)Session["Sesion"]).Usuario.CantidadFilasXPagina)
                {
                    hasta = listaCompleta.Count;
                }
                if (listaCompleta.Count != 0)
                {
                    for (int i = 0; i < listaCompleta.Count; i++)
                    {
                        if (i < hasta)
                        { 
                            lista.Add(listaCompleta[i]);
                        }
                    }
                }
                CVPagingGridView.VirtualItemCount = listaCompleta.Count;
                CVPagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    CVPagingGridView.DataSource = null;
                    CVPagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado CVs que satisfagan la busqueda";
                }
                else
                {
                    CVPagingGridView.DataSource = lista;
                    ViewState["Lista"] = lista;
                    ViewState["ListaCompleta"] = listaCompleta;
                    CVPagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}