using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GFeedbacks.UI
{
    /// <summary>
    /// Interaction logic for WPFSettingsForm.xaml
    /// </summary>
    public partial class WPFSettingsForm : Window
    {
        SettingsController _controller;
        public WPFSettingsForm(SettingsController controller)
        {
            InitializeComponent();
            _controller = controller;
        }
    }
}
