﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class TemporarilyOfflineMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OfflineMessage.Text = SettingsRules.Instance.readIsOnlineSettings("IsOfflineMessage");
        }
    }
}