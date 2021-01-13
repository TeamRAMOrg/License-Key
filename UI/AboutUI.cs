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
    public partial class AboutUI : Form
    {
        public AboutUI()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        const int ProductCode = 1;

        private void AboutUI_Load(object sender, EventArgs e)
        {
            lblProductID.Text = ComputerInfo.GetComputerId();
            KeyManager km = new KeyManager(lblProductID.Text);
            LicenseInfo lic = new LicenseInfo();
            //Get license information from license file
            int value = km.LoadSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), ref lic);
            string productKey = lic.ProductKey;
            //Check valid
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                //Decrypt license key
                if (km.DisassembleKey(productKey, ref kv))
                {
                    lblProductName.Text = "Team RAM";
                    lblProductKey.Text = productKey;
                    lblLicenseType.Text = kv.Type.ToString();
                    if (kv.Type == LicenseType.TRIAL)
                        lblExpDays.Text = string.Format("{0} days", (kv.Expiration - DateTime.Now.Date).Days);
                    else
                        lblLicenseType.Text = "Full";
                }
            }
        }
    }
}
