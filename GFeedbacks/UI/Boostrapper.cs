using Caliburn.Micro;
using GFeedbacks.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GFeedbacks.UI
{
    public class Boostrapper : BootstrapperBase
    {
        public Boostrapper() : base(false)
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
