using FoxLearn.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseKey.UI
{
    public partial class RegistrationUI : Form
    {
        public RegistrationUI()
        {
            InitializeComponent();
        }

        const int ProductCode = 1;

        private void btnOk_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(txtProductID.Text);
            string productKey = txtProductKey.Text;
            //Check valid
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                //Decrypt license key
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Team RAM";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    //Save license key to file
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("You have been successfully registered.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Your product key is invalid.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegistrationUI_Load(object sender, EventArgs e)
        {
            txtProductID.Text = ComputerInfo.GetComputerId();
        }
    }
}
