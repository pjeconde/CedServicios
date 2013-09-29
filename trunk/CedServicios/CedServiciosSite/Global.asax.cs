using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CedServicios.Site
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["AplicationStart"] = DateTime.Now;
            Application["ContadorVisitas"] = 0;
            Application["Visitantes"] = 0;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Entidades.Sesion s = new Entidades.Sesion();
            s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
            s.AdministradoresSiteEmail = System.Configuration.ConfigurationManager.AppSettings["Mantenedores"];
            s.OpcionesHabilitadas = RN.Sesion.OpcionesHabilitadas(s);
            Session["Sesion"] = s;
            Session["User"] = "User " + DateTime.Now;
            Application.Lock();
            Application["ContadorVisitas"] = (int)Application["ContadorVisitas"] + 1;
            Application["Visitantes"] = (int)Application["Visitantes"] + 1;
            Application.UnLock();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(SettingsRules.Instance.readIsOnlineSettings("IsOffline")))
            {
                string Virtual = Request.Path.Substring(0, Request.Path.LastIndexOf("/") + 1);
                if (Virtual.ToLower().IndexOf("/admin/") == -1)
                {
                    //We don't makes action, is admin section
                    Server.Transfer("~/TemporarilyOfflineMessage.aspx");
                }
            }
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Visitantes"] = (int)Application["Visitantes"] - 1;
            Application.UnLock();
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}