using CallTracker_GUI.user_controls;
using CallTracker_Lib.interfaces;
using CallTracker_Lib.logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallTracker_GUI.subforms
{
    public partial class SettingsForm : Form
    {
        private readonly NLog.Logger Logger = LogManager<SettingsForm>.GetLogger();

        private List<ISettingPage> settingPages = new List<ISettingPage>
        {
            new DBSetupUsrCtl(), new CompanySetupUsrCtl(), new ApplicationSetupUsrCtl()
        };

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TabPageDBSettings.Controls.Add(settingPages.Find(n => n.UniqueName.Equals("db_setup")) as UserControl);
            TabPageCompanySettings.Controls.Add(settingPages.Find(n => n.UniqueName.Equals("comp_settings")) as UserControl);
            TabPageApplicationSettings.Controls.Add(settingPages.Find(n => n.UniqueName.Equals("app_settings")) as UserControl);
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            foreach (ISettingPage settingPage in settingPages)
            {
                if (!settingPage.SettingsUnchanged)
                    settingPage.SaveSettings();
            }
            Logger.Info("Settings have been updated.");
        }

        private void ResetToDefaultBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, 
                "Are you sure you want to reset ALL settings? " +
                "Changes do not save unless you click the \"Save\" button.", "Confirm", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                foreach (ISettingPage settingPage in settingPages)
                    settingPage.ResetSettings();
        }

        private void CancelChangesBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
