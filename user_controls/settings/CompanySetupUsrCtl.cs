using CallTracker_Lib.database;
using CallTracker_Lib.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallTracker_GUI.user_controls
{
    public partial class CompanySetupUsrCtl : UserControl, ISettingPage
    {
        public string UniqueName { get => "comp_settings"; }

        public bool SettingsUnchanged { get; set; }

        private string _compName = string.Empty;
        private string _compPhone = string.Empty;
        private Image? _compImage = null;

        public CompanySetupUsrCtl()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            if (DBConnection.IsConnected())
            {
                SQLiteConnector.
            }
        }

        public void ResetSettings()
        {
            
        }

        public void SaveSettings()
        {
            
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
