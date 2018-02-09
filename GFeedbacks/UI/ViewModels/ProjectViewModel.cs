﻿using Caliburn.Micro;
using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.UI.ViewModels
{
    class ProjectViewModel : BaseProfileScreen
    {
        
        public ProjectViewModel(IProfile profile) : base (profile)
        {
            DisplayName = "Project";
        }
    }
}
