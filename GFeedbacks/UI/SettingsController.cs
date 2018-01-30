using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GFeedbacks.Annotations;

namespace GFeedbacks.UI
{
    public class SettingsController: INotifyPropertyChanged
    {
        private string _currentProfileName;
        public string CurrentProfileName
        {
            get { return _currentProfileName; }
            set
            {
                _currentProfileName = value;
                OnPropertyChanged(nameof(CurrentProfileName));
                OnPropertyChanged(nameof(CurrentProfile));

            }
        }
        public IAppSettings Settings => Globals.ThisAddIn.Settings;

        public ISetting CurrentProfile => Settings.FirstOrDefault(s => s.Name == CurrentProfileName);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
