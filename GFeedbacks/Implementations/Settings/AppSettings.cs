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


            string path = GetFullPath(Properties.Settings.Default.SettingsPath);

            foreach (string line in File.ReadLines(path))
            {
                string filePath = GetFullPath(line);
                JSONSettings setting;
                try
                {
                    
                    using (StreamReader file = File.OpenText(filePath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        setting = (JSONSettings)serializer.Deserialize(file, typeof(JSONSettings));
                        _settingsList.Add(setting);
                    }

                }
                catch (Exception e)
                {
                    ErrorLogger.LogError(e);
                }

            }
        }

        internal string GetFullPath(string relativePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string directoryPath = Path.GetDirectoryName(new Uri(assembly.CodeBase).LocalPath);
            return Path.GetFullPath(Path.Combine(directoryPath, relativePath));
        }



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