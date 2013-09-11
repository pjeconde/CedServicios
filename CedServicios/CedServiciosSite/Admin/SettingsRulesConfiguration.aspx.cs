using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Admin
{
    public partial class SettingsRulesConfiguration : System.Web.UI.Page
    {
        SettingsRules mySettings = new SettingsRules();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsOffline.Checked = Convert.ToBoolean(mySettings.readIsOnlineSettings("IsOffline"));
                OfflineMessage.Text = mySettings.readIsOnlineSettings("IsOfflineMessage");
                OfflineMessage.Text = OfflineMessage.Text.Replace("<br />", "\r\n");
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string htmlMessage = OfflineMessage.Text.Replace(Environment.NewLine, "<br />");
            // Update the Application variables
            Application.Lock();
            if (IsOffline.Checked)
            {
                mySettings.saveIsOnlineSettings("IsOffline", "True");
                mySettings.saveIsOnlineSettings("IsOfflineMessage", htmlMessage);
            }
            else
            {
                mySettings.saveIsOnlineSettings("IsOffline", "false");
                mySettings.saveIsOnlineSettings("IsOfflineMessage", htmlMessage);
            }
            Application.UnLock();
        }
    }
}