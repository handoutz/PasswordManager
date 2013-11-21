using PasswordManager.Forms;
using PasswordManager.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void passwordUtilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowManager.LaunchSingle<PasswordUtilsForm>(true);
        }
    }
}
