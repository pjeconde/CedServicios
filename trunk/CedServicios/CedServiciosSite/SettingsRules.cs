using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Configuration;

namespace CedServicios.Site
{
    public class SettingsRules
    {
        public SettingsRules()
        {
        }
        public string readIsOnlineSettings(string sectionToRead)
        {
            Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            KeyValueConfigurationElement isOnlineSettings = (KeyValueConfigurationElement)cfg.AppSettings.Settings[sectionToRead];
            return isOnlineSettings.Value;
        }
        public bool saveIsOnlineSettings(string sectionToWrite, string value)
        {

            bool succesFullySaved;
            try
            {
                Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
                KeyValueConfigurationElement repositorySettings = (KeyValueConfigurationElement)cfg.AppSettings.Settings[sectionToWrite];
                if (repositorySettings != null)
                {
                    repositorySettings.Value = value;
                    cfg.Save(ConfigurationSaveMode.Modified);
                }
                succesFullySaved = true;
            }
            catch (Exception)
            {
                succesFullySaved = false;
            }
            return succesFullySaved;
        }
        #region instance
        private static SettingsRules m_instance;
        // Properties
        public static SettingsRules Instance
        {
            get
            {
                if (m_instance == null)
                {

                    m_instance = new SettingsRules();
                }
                return m_instance;
            }
        }
        #endregion instance
    }
}