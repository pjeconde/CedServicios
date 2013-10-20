using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Web.SessionState;
using System.Data;
using System.Configuration;
using System.Collections;

namespace CedServicios.Site
{
    public partial class ExploradorAdministracion : System.Web.UI.Page
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
                    RefrescarButton_Click(RefrescarButton, new EventArgs());
                    //EstadoDropDownList.DataSource = RN.Estado.Lista(true, sesion);
                    DataBind();
                    //EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }

        protected void RefrescarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                AplicationStartLabel.Text = Application["AplicationStart"].ToString();
                ContadorVisitasLabel.Text = Application["ContadorVisitas"].ToString();
                VisitantesLabel.Text = Application["Visitantes"].ToString();

                SesionesActivasLabel.Text = "";
	            object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
	            object[] obj2 = (object[])obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);
	            for (int i = 0; i < obj2.Length; i++)
	            {
	                Hashtable c2 = (Hashtable)obj2[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj2[i]);
	                foreach (DictionaryEntry entry in c2)
	                {
	                    object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
	                    if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
	                    {
	                        SessionStateItemCollection sess = (SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
	                        if (sess != null)
	                        {
	                            if (sess["User"] != null)
	                            {
                                    SesionesActivasLabel.Text += sess["User"] + " is Active.<br>";
	                            }
	                        }
	                    }
	                }
                }
                //MensajeLabel.Text = "No se han encontrado UNs que satisfagan la busqueda";
                //ViewState["lista"] = lista;
                //UNPagingGridView.DataBind();
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}