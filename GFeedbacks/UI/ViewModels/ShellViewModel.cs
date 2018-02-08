using Caliburn.Micro;
using GFeedbacks.Interfaces;
using GFeedbacks.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private BindableCollection<IProfile> _profiles;
        private IProfile _selectedProfile;
        private ProjectViewModel _projectViewModel;
        private FoldersViewModel _foldersViewModel;
        private ParsingViewModel _parsingViewModel;

        public BindableCollection<IProfile> Profiles
        {
            get { return _profiles; }
            set { _profiles = value; }
        }
        public IProfile SelectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                _selectedProfile = value;
                NotifyOfPropertyChange(() => SelectedProfile);
            }
        }

        public ShellViewModel()
        {
            _profiles = new BindableCollection<IProfile>();
            _profiles.AddRange(Globals.ThisAddIn.Settings);
            SelectedProfile = _profiles.FirstOrDefault();
        }

        protected override void OnInitialize()
        {
            _projectViewModel = new ProjectViewModel();
            _foldersViewModel = new FoldersViewModel();
            _parsingViewModel = new ParsingViewModel();
            Items.Add(_projectViewModel);
            Items.Add(_foldersViewModel);
            Items.Add(_parsingViewModel);
        }

        

            

    }
}
