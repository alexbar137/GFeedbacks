using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI
{
    public class SettingsController
    {
        public string CurrentProfileName { get; set; }
        public IAppSettings Settings
        {
            get
            {
                return Globals.ThisAddIn.Settings;
            }
        }

        public ISetting CurrentProfile
        {
            get
            {
                return Settings.FirstOrDefault(s => s.Name == CurrentProfileName);
            }
        }

        public SettingsController()
        {
            ShowForm();
        }

        public void ShowForm()
        {
            SettingsForm form = new SettingsForm(this);
            form.Show();
        }

    }
}
