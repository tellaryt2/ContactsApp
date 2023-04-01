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
            this.MinimumSize = new Size(580, 480);
            this.MaximumSize = new Size(580, 480);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tellaryt2");
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com");
        }
    }
}
