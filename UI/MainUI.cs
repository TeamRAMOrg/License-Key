using LicenseKey.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseKey
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (GenerateUI generateUI = new GenerateUI())
            {
                generateUI.ShowDialog();
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            using (RegistrationUI registrationUI = new RegistrationUI())
            {
                registrationUI.ShowDialog();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (AboutUI aboutUI = new AboutUI())
            {
                aboutUI.ShowDialog();
            }
        }
    }
}
