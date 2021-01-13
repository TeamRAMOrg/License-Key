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

namespace LicenseKey
{
    public partial class GenerateUI : Form
    {
        public GenerateUI()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(txtProductID.Text);
            KeyValuesClass kv;
            string productKey = string.Empty;
            if (cmbLicenseType.SelectedIndex == 0)
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.FULL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,//As order of your software
                    Edition = Edition.ENTERPRISE,
                    Version = 1
                };
                if (!km.GenerateKey(kv, ref productKey))//Generate full license key
                    txtProductKey.Text = "ERROR";
            }
            else
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.TRIAL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1,
                    Expiration = DateTime.Now.Date.AddDays(Convert.ToInt32(txtExpDays.Text))
                };
                if (!km.GenerateKey(kv, ref productKey))//Generate trial license key
                    txtProductKey.Text = "ERROR";
            }
            txtProductKey.Text = productKey;
        }

        const int ProductCode = 1;
        private void GenerateUI_Load(object sender, EventArgs e)
        {
            cmbLicenseType.SelectedIndex = 0;
            //Get computer id, it's unique for each computer
            txtProductID.Text = ComputerInfo.GetComputerId();
        }
    }
}
