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
        internal List<IProfile> _profilesList { get; set; }

        public JSONAppSettings()
        {
            _profilesList = new List<IProfile>();
            GetProfiles();
        }

        internal void GetProfiles()
        {
            IProfile defaultProfile = JsonProfileHelper.GetProfileFromJson(Properties.Resources.DefaultProfile);
            _profilesList.Add(defaultProfile);
            foreach (SettingsProperty setting in Properties.Profiles.Default.Properties)
            {
                if(setting.DefaultValue != null)
                {
                    IProfile profile = JsonProfileHelper.GetProfileFromJson(setting.DefaultValue.ToString());
                    _profilesList.Add(profile);
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



        public IEnumerator<IProfile> GetEnumerator()
        {
            foreach (JSONProfile s in _profilesList) yield return s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (JSONProfile s in _profilesList) yield return s;
        }


    }


}