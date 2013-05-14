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
            Application["Visitantes"] = 0;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Entidades.Sesion s = new Entidades.Sesion();
            s.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"];
            s.OpcionesHabilitadas = RN.Sesion.OpcionesHabilitadas(s);
            Session["Sesion"] = s;
            Application.Lock();
            Application["Visitantes"] = (int)Application["Visitantes"] + 1;
            Application.UnLock();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

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