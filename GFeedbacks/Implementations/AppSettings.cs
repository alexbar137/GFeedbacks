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

namespace GFeedbacks.Implementations
{
    public class AppSettings: IAppSettings
    {
        internal List<Setting> _settingsList { get; set; }

        public AppSettings()
        {
            _settingsList = new List<Setting>();
        }

        public void GetSettings()
        {
            string SettingsPath = Properties.Settings.Default.SettingsPath;
            var parser = new FileIniDataParser();

            foreach (string line in File.ReadLines(SettingsPath))
            {

                try
                {
                    IniData data = parser.ReadFile(line);
                    Setting set = MapSettings(data);
                    _settingsList.Add(set);

                }
                catch (Exception e)
                {
                    ErrorLogger.LogError(e);
                }

            }
        }

        internal Setting MapSettings(IniData data)
        {
            Setting set = new Setting();
            set.Name = data["Folders"]["Name"];
            set.TargetMailFolder = data["Folders"]["TargetMailFolder"];
            set.ReportFolder = data["Folders"]["ReportFolder"];
            set.LogFolder = data["Folders"]["LogFolder"];
            set.PM = int.Parse(data["ProjectInfo"]["PM"]);
            set.Account = int.Parse(data["ProjectInfo"]["Account"]);
            set.Client = int.Parse(data["ProjectInfo"]["Client"]);
            set.Team = int.Parse(data["ProjectInfo"]["Team"]);

            set.Email = data["ParseInfo"]["Email"];
            set.Subj = data["ParseInfo"]["Subj"];
            set.SourceLang = data["ParseInfo"]["SourceLang"];
            set.SourceLangSource = data["ParseInfo"]["SourceLangSource"];
            set.TargetLang = data["ParseInfo"]["TargetLang"];
            set.TargetLangSource = data["ParseInfo"]["TargetLangSource"];
            set.Result = data["ParseInfo"]["Result"];
            set.ResultSource = data["ParseInfo"]["ResultSource"];
            set.WordCount = data["ParseInfo"]["WordCount"];
            set.WordCountSource = data["ParseInfo"]["WordCountSource"];
            set.ProjectCode = data["ParseInfo"]["ProjectCode"];
            set.ProjectCodeSource = data["ParseInfo"]["ProjectCodeSource"];

            set.Languages = new Dictionary<string, int>();
            foreach (var lang in data["Languages"])
            {
                set.Languages.Add(lang.KeyName, int.Parse(lang.Value));
            }

            return set;
        }

        public IEnumerator<Setting> GetEnumerator()
        {
            foreach (Setting s in _settingsList) yield return s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Setting s in _settingsList) yield return s;
        }
    }


    public class Setting
    {
        public string Name { get; set; }
        public string TargetMailFolder { get; set; }
        public string ReportFolder { get; set; }
        public string LogFolder { get; set; }
        public int PM { get; set; }
        public int Account { get; set; }
        public int Client { get; set; }
        public int Team { get; set; }

        public string Email { get; set; }
        public string Subj { get; set; }
        public string SourceLang { get; set; }
        public string SourceLangSource { get; set; }
        public string TargetLang { get; set; }
        public string TargetLangSource { get; set; }
        public string Result { get; set; }
        public string ResultSource { get; set; }
        public string WordCount { get; set; }
        public string WordCountSource { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectCodeSource { get; set; }

        public Dictionary<string, int> Languages { get; set; }
    }
}