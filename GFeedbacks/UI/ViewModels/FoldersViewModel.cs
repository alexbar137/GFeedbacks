using Caliburn.Micro;
using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI.ViewModels
{
    public class FoldersViewModel : BaseProfileScreen
    {
        public FoldersViewModel(IProfile profile) : base (profile)
        {
            DisplayName = "Folders";
            
        }
    }
}
