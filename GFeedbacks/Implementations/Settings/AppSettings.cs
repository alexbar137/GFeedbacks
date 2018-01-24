using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using GFeedbacks.Interfaces;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using GFeedbacks.Implementations.Settings;
using System.Configuration;

namespace GFeedbacks.Implementations
{
    public class JSONAppSettings: IAppSettings
    {
        internal List<ISetting> _settingsList { get; set; }

        public JSONAppSettings()
        {
            _settingsList = new List<ISetting>();
            GetSettings();
        }

        internal void GetSettings()
        {
            ISetting defaultProfile = SettingUtilities.GetSettingsFromJson(Properties.Resources.DefaultProfile);
            _settingsList.Add(defaultProfile);
            foreach (SettingsProperty setting in Properties.Profiles.Default.Properties)
            {
                if(setting.DefaultValue != null)
                {
                    ISetting profile = SettingUtilities.GetSettingsFromJson(setting.DefaultValue.ToString());
                    _settingsList.Add(profile);
                }

            }

        }

        /*
        internal string GetFullPath(string relativePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string directoryPath = Path.GetDirectoryName(new Uri(assembly.CodeBase).LocalPath);
            return Path.GetFullPath(Path.Combine(directoryPath, relativePath));
        }
        */



        public IEnumerator<ISetting> GetEnumerator()
        {
            foreach (JSONSettings s in _settingsList) yield return s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (JSONSettings s in _settingsList) yield return s;
        }


    }


}