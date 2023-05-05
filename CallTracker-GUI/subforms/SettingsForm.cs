using CallTracker_GUI.user_controls;
using CallTracker_Lib.database;
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
using CallTracker_GUI.user_controls.settings;

namespace CallTracker_GUI.subforms
{
    public partial class SettingsForm : Form
    {
        private readonly NLog.Logger _logger = LogManager<SettingsForm>.GetLogger();

        private List<ISettingPage> _settingPages = new List<ISettingPage>
        {
            new DbSetupUsrCtl()
        };

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Controls.Add(_settingPages.Find(n => n.UniqueName.Equals("db_setup")) as UserControl);
        }

        private void SaveSettingsBtn_Click(object sender, EventArgs e)
        {
            foreach (ISettingPage settingPage in _settingPages)
            {
                if (settingPage.SettingsChanged)
                {
                    settingPage.SaveSettings();
                    settingPage.SettingsChanged = false;
                }
            }
            MessageBox.Show(this, "Settings Saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _logger.Info("Settings have been updated.");
        }

        private void ResetToDefaultBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, 
                "Are you sure you want to reset ALL settings? " +
                "Changes do not save unless you click the \"Save\" button.", "Confirm", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                foreach (ISettingPage settingPage in _settingPages)
                    settingPage.ResetSettings();
        }

        private void CancelChangesBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckForChanges())
                e.Cancel = true;
        }
        
        /// <summary>
        /// Checks for pending changes on the settings.
        /// </summary>
        /// <returns>True: if changes are pending and user confirms -or- changes are not pending and closing is safe; False: if changes are pending and user responds to not close settings.</returns>
        private bool CheckForChanges()
        {
            bool changesPending = false;
            foreach (ISettingPage settingPage in _settingPages)
                changesPending = settingPage.SettingsChanged;
                    
            if (changesPending)
            {
                DialogResult response = MessageBox.Show(this, "There are changes pending to the settings. Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
    }
}
