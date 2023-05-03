using CallTracker_Lib.database;
using CallTracker_Lib.database.wrappers;
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

        private AppOwner _appOwner = new AppOwner();
        private AppOwner _newAppOwner = new AppOwner();

        public CompanySetupUsrCtl()
        {
            InitializeComponent();
        }

        public void LoadSettings()
        {
            //TODO: Implement loading settings for App Owners...?
        }

        public void ResetSettings()
        {
            _newAppOwner = new AppOwner();
            UpdateFields();
        }

        public void SaveSettings()
        {
            _newAppOwner.Insert();
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            _newAppOwner.Name = txtCompanyName.Text;
            if (!_newAppOwner.Name.Equals(_appOwner.Name))
                _newAppOwner.ID = 0;
            SettingsUnchanged = false;
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            _newAppOwner.PhoneNumber = txtPhoneNumber.Text;
            if (!_newAppOwner.PhoneNumber.Equals(_appOwner.PhoneNumber))
                _newAppOwner.ID = 0;
            SettingsUnchanged = false;
        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            if (dlgOpenLogo.ShowDialog() == DialogResult.OK)
            {
                _newAppOwner.Base64Logo = Convert.ToBase64String(File.ReadAllBytes(dlgOpenLogo.FileName));
                picLogo.BackgroundImage = Image.FromFile(dlgOpenLogo.FileName);
                SettingsUnchanged = false;
            }
        }

        private void CompanySetupUsrCtl_Load(object sender, EventArgs e)
        {
            cmbCompanies.DataSource = SQLiteConnector.GetAppOwners();
        }

        private void cmbCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCompanies.SelectedItem is AppOwner)
            {
                _appOwner = (AppOwner)cmbCompanies.SelectedItem;
                _newAppOwner = _appOwner;
                SettingsUnchanged = false;
                UpdateFields();
            }
        }

        private void UpdateFields()
        {
            txtCompanyName.Text = _newAppOwner.Name;
            txtPhoneNumber.Text = _newAppOwner.PhoneNumber;
            try
            {
                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(_newAppOwner.Base64Logo));
                picLogo.BackgroundImage = Image.FromStream(ms);
            } catch (Exception) { picLogo.BackgroundImage = null; }
        }
    }
}
