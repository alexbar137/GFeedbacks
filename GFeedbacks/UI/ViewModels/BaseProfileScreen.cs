using Caliburn.Micro;
using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI.ViewModels
{
    abstract public class BaseProfileScreen : Screen
    {
        public IProfile Profile { get; set; }
        public BaseProfileScreen(IProfile profile)
        {
            Profile = profile;
        }
    }
}
