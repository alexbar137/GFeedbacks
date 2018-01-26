using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFeedbacks.UI
{
    public partial class SettingsForm : Form
    {
        private SettingsController _controller;
        public SettingsForm(SettingsController controller)
        {
            _controller = controller;
            InitializeComponent();
            cmbProfiles.DataSource = controller.Settings.Names;
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowseReport_Click(object sender, EventArgs e)
        {
            dlgBrowse.ShowDialog();
        }

        private void btnBrowseLog_Click(object sender, EventArgs e)
        {
            dlgBrowseLog.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
