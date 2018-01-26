using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using GFeedbacks.UI;

namespace GFeedbacks
{
    public partial class GFeedbackRibbon
    {
        private void GFeedbackRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            SettingsController controller = new SettingsController();
        }
    }
}
