using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Browser
{
    public static class SettingsIO
    {
        internal static void Import(string SettingsFilePath)
        {
            if (!File.Exists(SettingsFilePath))
            {
                throw new FileNotFoundException();
            }

            var appSettings = Properties.Settings.Default;
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

                string appSettingsXmlName = Properties.Settings.Default.Context["GroupName"].ToString();
                // returns "MyApplication.Properties.Settings";

                // Open settings file as XML
                var import = XDocument.Load(SettingsFilePath);
                // Get the whole XML inside the settings node
                var settings = import.XPathSelectElements("//" + appSettingsXmlName);

                config.GetSectionGroup("userSettings")
                    .Sections[appSettingsXmlName]
                    .SectionInformation
                    .SetRawXml(settings.Single().ToString());
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("userSettings");

                appSettings.Reload();
            }
            catch (Exception) // Should make this more specific
            {
                // Could not import settings.
                appSettings.Reload(); // from last set saved, not defaults
            }
        }

        internal static void Export(string SettingsFilePath)
        {
            Properties.Settings.Default.Save();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            config.SaveAs(SettingsFilePath);
        }

    }
}