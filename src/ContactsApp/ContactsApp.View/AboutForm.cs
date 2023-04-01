using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.View
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GitLinkLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tellaryt2");
        }

        private void IconsLinkLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com");
        }

        private void LicenseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LicenseTextBox_TextChanged(object sender, EventArgs e)
        {
         
        }
    }
}
