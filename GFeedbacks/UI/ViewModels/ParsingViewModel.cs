using Caliburn.Micro;
using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI.ViewModels
{
    class ParsingViewModel : BaseProfileScreen
    {
        public ParsingViewModel(IProfile profile) : base(profile)
        {
            DisplayName = "Parsing";
        }
    }
}
