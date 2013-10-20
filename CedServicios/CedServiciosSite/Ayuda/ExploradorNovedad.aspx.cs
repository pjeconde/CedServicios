using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class ExploradorNovedad : System.Web.UI.Page
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
                    String path = Server.MapPath("~/Ayuda/Novedades/");
                    string[] archivos = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.TopDirectoryOnly);
                    List<Entidades.Archivo> lista = new List<Entidades.Archivo>();
                    if (archivos.Length > 0)
                    {
                        for (int i = 0; i < archivos.Length; i++)
                        {
                            Entidades.Archivo arch = new Entidades.Archivo();
                            arch.Nombre = archivos[i].Replace(Server.MapPath("~/Ayuda/Novedades/"), String.Empty);
                            lista.Add(arch);
                        }
                    }
                    ViewState["Archivos"] = lista;
                    NovedadGridView.DataSource = lista;
                    DataBind();
                }
            }
        }
        protected void NovedadGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int item = Convert.ToInt32(e.CommandArgument);
            List<Entidades.Archivo> lista = (List<Entidades.Archivo>)ViewState["Archivos"];
            Entidades.Archivo arch = lista[item];
            switch (e.CommandName)
            {
                case "Ver":
                        Response.Redirect("~/Ayuda/Novedades/" + arch.Nombre);
                    break;
            }
        }
        protected void NovedadGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //if (e.Row.Cells[1].Text != "Vigente")
                //{
                //    e.Row.ForeColor = Color.Red;
                //}
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
                List<Entidades.Archivo> lista = new List<Entidades.Archivo>();
                //MensajeLabel.Text = String.Empty;
                //lista = RN.Archivo.Lista(TextoTextBox.Text, sesion);
                //if (lista.Count == 0)
                //{
                //    NovedadGridView.DataSource = null;
                //    NovedadGridView.DataBind();
                //    MensajeLabel.Text = "No se han encontrado Permisos que satisfagan la busqueda";
                //}
                //else
                //{
                //    NovedadGridView.DataSource = lista;
                //    ViewState["Archivos"] = lista;
                //    NovedadGridView.DataBind();
                //}
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}